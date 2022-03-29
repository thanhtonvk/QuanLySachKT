create database QLSach
go
use QLSach
go
create table Sach(
	MaSach int identity primary key,
	TenSach nvarchar(50) not null,
	LinhVu nvarchar(50) not null,
	CacTacGia nvarchar(200) not null,
	NhaXB nvarchar(50) not null,
	NamXB int,
	LanTaiBan int
)