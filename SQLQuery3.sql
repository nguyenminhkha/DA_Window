
use QLNS
Drop table dbo.Hoadon
drop table dbo.chitiethoadon


create table Hoadon(
  MAHOADON int IDENTITY(1,1) ,
  TENKHACHHANG nvarchar(50),
  NGAYLAP date default NULL,
  Checks nvarchar(10) default '0',
  TONGTIEN decimal(10,0) default NULL,
  PRIMARY KEY  (MAHOADON)
)
GO

CREATE TABLE chitiethoadon (
  MaCTHoadon int identity(1,1) primary key,
  MAHOADON INT references Hoadon(MAHOADON),
  MASACH char(13)  references sach(MASACH),
  SOLUONG INT NOT NULL,
  MUCGIAMGIA FLOAT default NULL,
 
)

select MAX(MAHOADON) FROM Hoadon
go

alter proc CThoadon @masach nvarchar(13), @soluong int, @mucgiamgia int
as
begin
	declare @mahd int
	set @mahd = (select MAX(MAHOADON) FROM Hoadon where Hoadon.Checks=0)
	insert dbo.chitiethoadon values(@mahd,@masach,@soluong,@mucgiamgia)
end


	

EXEC CThoadon '8931654654455',2,5

Create proc LoadList
as
begin
	declare @mahd int
	set @mahd = (select MAX(MAHOADON) FROM Hoadon where Hoadon.Checks=0)
	select MaCTHoadon,TenSach,GiaMua,SOLUONG,MUCGIAMGIA,((GiaMua * SOLUONG)-((GiaMua * SOLUONG)*(MUCGIAMGIA/100))) as [Tongtien]
	from chitiethoadon,sach,Hoadon
	where chitiethoadon.MAHOADON = @mahd and sach.MaSach = chitiethoadon.MASACH and Hoadon.Checks =0 and chitiethoadon.MAHOADON = Hoadon.MAHOADON
	
end

EXEC LoadList

delete dbo.chitiethoadon where MaCTHoadon=2	

Create proc UpdateBill @date date, @TT int
as
	begin
	declare @mahd int
	set @mahd = (select MAX(MAHOADON) FROM Hoadon where Hoadon.Checks=0)
	update dbo.Hoadon set NGAYLAP = @date,Checks =1,TONGTIEN =@TT WHERE MAHOADON = @mahd
	end

	EXEC UpdateBill ,400000


alter proc updateBillInfo @soluong int , @masach nvarchar(13)
as
begin
	declare @idbill int
	set @idbill = (select MaCTHoadon from chitiethoadon,Hoadon where MASACH =@masach and Hoadon.Checks=0 AND Hoadon.MAHOADON = chitiethoadon.MAHOADON)
	update dbo.chitiethoadon set SOLUONG=SOLUONG + @soluong
	where MaCTHoadon = @idbill
	END
Create proc DThu @date1 date , @date2 date
as
begin
	select Hoadon.MAHOADON,TENKHACHHANG,NGAYLAP,TONGTIEN
	from dbo.Hoadon
	where NGAYLAP between @date1 and @date2
end

EXEC DThu '2019/05/13' , '2019/05/13'