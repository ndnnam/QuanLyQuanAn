CREATE DATABASE QuanLyQuanAn
GO

USE QuanLyQuanAn
GO

CREATE TABLE Ban
(
	MaBan INT IDENTITY PRIMARY KEY,
	TenBan NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	TrangThaiBan NVARCHAR(100) NOT NULL DEFAULT N'Không có người'
)
GO

CREATE TABLE LoaiDoAnUong
(
	MaLoaiDoAnUong INT IDENTITY PRIMARY KEY,
	TenLoaiDoAnUong NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE LoaiTaiKhoan
(
	MaLoaiTaiKhoan INT IDENTITY PRIMARY KEY,
	TenLoaiTaiKhoan NVARCHAR(100) NOT NULL
)

CREATE TABLE TaiKhoan
(
	TenDangNhap NVARCHAR(100) PRIMARY KEY,
	MatKhau NVARCHAR(1000) NOT NULL DEFAULT 0,
	HoTen NVARCHAR(100) NOT NULL,
	SoDienThoai NCHAR(10) NOT NULL,
	MaLoaiTaiKhoan INT NOT NULL

	FOREIGN KEY (MaLoaiTaiKhoan) REFERENCES LoaiTaiKhoan(MaLoaiTaiKhoan)
)
GO

CREATE TABLE DoAnUong
(
	MaDoAnUong INT IDENTITY PRIMARY KEY,
	TenDoAnUong NVARCHAR(100) DEFAULT N'Chưa đặt tên',
	MaLoaiDoAnUong INT NOT NULL,
	GiaNiemYet FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (MaLoaiDoAnUong) REFERENCES LoaiDoAnUong(MaLoaiDoAnUong)
)
GO

CREATE TABLE HoaDon
(
	MaHoaDon INT IDENTITY PRIMARY KEY,
	NgayGioKhachToi DATE NOT NULL DEFAULT GETDATE(),
	NgayGioKhachDi DATE,
	TrangThaiThanhToan INT NOT NULL DEFAULT 0,
	GiamGia INT,
	TongGia FLOAT,
	TenKhachHang NVARCHAR(100) NOT NULL,
	SoDienThoaiKhachHang NCHAR(10) NOT NULL,
	MaNhanVienBan NVARCHAR(100) NOT NULL,
	MaBan INT NOT NULL

	FOREIGN KEY (MaNhanVienBan) REFERENCES TaiKhoan(TenDangNhap),
	FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
)
GO

CREATE TABLE ChiTietHoaDon
(
	MaChiTietHoaDon INT IDENTITY,
	MaHoaDon INT NOT NULL,
	MaDoAnUong INT NOT NULL,
	SoLuong INT NOT NULL DEFAULT 0

	PRIMARY KEY (MaChiTietHoaDon, MaHoaDon, MaDoAnUong),
	FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	FOREIGN KEY (MaDoAnUong) REFERENCES DoAnUong(MaDoAnUong)
)
GO

--Thêm bàn
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 1', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 2', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 3', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 4', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 5', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 6', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 7', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 8', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 9', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 10', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 11', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 12', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 13', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 14', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 15', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 16', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 17', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 18', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 19', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 20', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 21', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 22', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 23', N'Không có người')
INSERT INTO Ban(TenBan, TrangThaiBan) VALUES (N'Bàn 24', N'Không có người')

--Thêm loại đồ ăn
INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (N'Hải sản')
INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (N'Gia cầm')
INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (N'Lương thực')
INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (N'Rau củ')
INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (N'Đồ uống')

--Thêm loại tài khoản
INSERT INTO LoaiTaiKhoan(TenLoaiTaiKhoan) VALUES (N'Quản Lý Quán Ăn')
INSERT INTO LoaiTaiKhoan(TenLoaiTaiKhoan) VALUES (N'Nhân Viên Quán Ăn')

--Thêm tài khoản
INSERT INTO TaiKhoan(TenDangNhap, MatKhau, HoTen, SoDienThoai, MaLoaiTaiKhoan) VALUES (N'lephilong', N'223018912569815552702387813134219207146', N'Lê Phi Long', 0397738679, 2)
INSERT INTO TaiKhoan(TenDangNhap, MatKhau, HoTen, SoDienThoai, MaLoaiTaiKhoan) VALUES (N'ndnnam', N'2437610675226213248841721712515312722678', N'Nguyễn Đăng Nhựt Nam', 0344201700, 1)

-- Thêm Đồ Ăn
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Mực một nắng nướng sa tế', 1, 120000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Nghêu hấp xả', 1, 50000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Dú dê nướng sữa', 2, 50000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Heo rừng nướng muối ớt', 2, 50000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Cơm chiên dương châu', 3, 40000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Rau muống sào tỏi', 4, 30000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'7UP', 5, 20000)
INSERT INTO DoAnUong(TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (N'Cà phê', 5, 20000)
GO
--1
CREATE PROC USP_CAPNHATMATKHAU @tenDangNhap NVARCHAR(100), @matKhau NVARCHAR(1000), @matKhauMoi NVARCHAR(1000)
AS
BEGIN
	DECLARE @kiemTra INT = 0
	SELECT @kiemTra = COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau
	IF (@kiemTra = 1)
		UPDATE TaiKhoan SET MatKhau = @matKhauMoi WHERE TenDangNhap = @tenDangNhap
END
GO
--2
CREATE PROC USP_CAPNHATTAIKHOAN @tenDangNhap NVARCHAR(100), @hoTen NVARCHAR(100), @soDienThoai NCHAR(10), @matKhau NVARCHAR(1000)
AS
BEGIN
	DECLARE @kiemTra INT = 0
	SELECT @kiemTra = COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau
	IF (@kiemTra = 1)
		UPDATE TaiKhoan SET HoTen = @hoTen, SoDienThoai = @soDienThoai WHERE TenDangNhap = @tenDangNhap
END
GO
--3
CREATE PROC USP_CHUYANBAN @maBan1 INT, @maBan2 INT, @tenKhachHang NVARCHAR(100), @soDienThoai NCHAR(10), @maNhanVienBan NVARCHAR(100)
AS
BEGIN
	DECLARE @maHoaDon1 INT, @maHoaDon2 INT
	DECLARE @kiemTraBan1 INT = 1, @kiemTraBan2 INT = 1
	SELECT @maHoaDon1 = MaHoaDon FROM HoaDon WHERE MaBan = @maBan1 AND TrangThaiThanhToan = 0
	SELECT @maHoaDon2 = MaHoaDon FROM HoaDon WHERE MaBan = @maBan2 AND TrangThaiThanhToan = 0
	IF (@maHoaDon1 IS NULL)
	BEGIN
		INSERT INTO HoaDon(NgayGioKhachToi, NgayGioKhachDi, TrangThaiThanhToan, TenKhachHang, SoDienThoaiKhachHang, MaNhanVienBan, MaBan) 
		VALUES (GETDATE(), NULL, 0, @tenKhachHang, @soDienThoai, @maNhanVienBan, @maBan1)
		SELECT @maHoaDon1 = MAX(MaHoaDon) FROM HoaDon WHERE MaBan = @maBan1 AND TrangThaiThanhToan = 0
	END
	SELECT @kiemTraBan1 = COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon1
	IF (@maHoaDon2 IS NULL)
	BEGIN
		INSERT INTO HoaDon(NgayGioKhachToi, NgayGioKhachDi, TrangThaiThanhToan, TenKhachHang, SoDienThoaiKhachHang, MaNhanVienBan, MaBan) 
		VALUES (GETDATE(), NULL, 0, @tenKhachHang, @soDienThoai, @maNhanVienBan, @maBan2)
		SELECT @maHoaDon2 = MAX(MaHoaDon) FROM HoaDon WHERE MaBan = @maBan2 AND TrangThaiThanhToan = 0
	END
	SELECT @kiemTraBan2 = COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon2
	SELECT MaChiTietHoaDon INTO BangChiTietHoaDon FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon2
	UPDATE ChiTietHoaDon SET MaHoaDon = @maHoaDon2 WHERE MaHoaDon = @maHoaDon1
	UPDATE ChiTietHoaDon SET MaHoaDon = @maHoaDon1 WHERE MaChiTietHoaDon IN (SELECT * FROM BangChiTietHoaDon)
	DROP TABLE BangChiTietHoaDon
	IF (@kiemTraBan1 = 0)
		UPDATE Ban SET TrangThaiBan = N'Không có người' WHERE MaBan = @maBan2
	IF (@kiemTraBan2 = 0)
		UPDATE Ban SET TrangThaiBan = N'Không có người' WHERE MaBan = @maBan1
END
GO
--4
ALTER PROC USP_DANGKY @tenDangNhap NVARCHAR(100), @matKhau NVARCHAR(1000), @hoTen NVARCHAR(100), @soDienThoai NCHAR(10)
AS
BEGIN
	INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, SoDienThoai, MaLoaiTaiKhoan) VALUES (@tenDangNhap, @matKhau, @hoTen, @soDienThoai, 2)
END
GO
--5
CREATE PROC USP_DANGNHAP
@tenDangNhap NVARCHAR(100), @matKhau NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau
END
GO
--6
CREATE PROC USP_DATLAIMATKHAU @tenDangNhap NVARCHAR(100)
AS
BEGIN
	UPDATE TaiKhoan SET MatKhau = N'223018912569815552702387813134219207146' WHERE TenDangNhap = @tenDangNhap
END
GO
--7
CREATE PROC USP_KIEMTRATENDANGNHAP @tenDangNhap NVARCHAR(100)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap
END
GO
--8
CREATE PROC USP_LAYBAN
AS
BEGIN
	SELECT Ban.MaBan, Ban.TenBan, Ban.TrangThaiBan
	FROM Ban	
END
GO
--9
CREATE PROC USP_LAYDANHSACHDOANUONG @maLoaiDoAnUong INT
AS
BEGIN
	SELECT * FROM DoAnUong WHERE MaLoaiDoAnUong = @maLoaiDoAnUong
END
GO
--10
CREATE PROC USP_LAYDANHSACHHOADONTHEONGAYVATRANG @ngayGioKhachToi DATE, @ngayGioKhachDi DATE, @trang INT
AS
BEGIN
	DECLARE @soDongTrenTrang INT = 18
	DECLARE @chonDong INT = @soDongTrenTrang, @ngoaiTruDong INT = (@trang - 1) * @soDongTrenTrang
	;WITH HienThiHoaDon AS
	(
		SELECT MaHoaDon AS [Mã hóa đơn], TenBan AS [Tên bàn], NgayGioKhachToi AS [Ngày giờ khách tới], NgayGioKhachDi AS [Ngày giờ khách đi], GiamGia AS [Giảm giá], TongGia AS [Tổng giá], TenKhachHang AS [Tên khách hàng], SoDienThoaiKhachHang AS [Số điện thoại], HoTen AS [Tên nhân viên]
		FROM HoaDon, Ban, TaiKhoan
		WHERE HoaDon.MaBan= Ban.MaBan AND HoaDon.MaNhanVienBan = TaiKhoan.TenDangNhap AND NgayGioKhachToi >= @ngayGioKhachToi AND NgayGioKhachDi <= @ngayGioKhachDi AND TrangThaiThanhToan = 1
	)
	SELECT TOP(@chonDong) * FROM HienThiHoaDon WHERE [Mã hóa đơn] NOT IN (SELECT TOP (@ngoaiTruDong) [Mã hóa đơn] FROM HienThiHoaDon)
END
GO
--11
CREATE PROC USP_LAYDANHSACHTAIKHOAN
AS
BEGIN
	SELECT TenDangNhap, HoTen, SoDienThoai, MaLoaiTaiKhoan FROM TaiKhoan
END
GO
--12
CREATE PROC USP_LAYDANHSACHTHUCDON @maBan INT
AS
BEGIN
	SELECT DoAnUong.TenDoAnUong, ChiTietHoaDon.SoLuong, DoAnUong.GiaNiemYet, ((ISNULL(DoAnUong.GiaNiemYet, 0) * ISNULL(ChiTietHoaDon.SoLuong, 0)) - (ISNULL(DoAnUong.GiaNiemYet, 0) * ISNULL(ChiTietHoaDon.SoLuong, 0) * ISNULL(HoaDon.GiamGia, 0))/100) AS ThanhTien, HoTen, TenKhachHang, SoDienThoaiKhachHang
	FROM ChiTietHoaDon, DoAnUong, HoaDon, TaiKhoan
	WHERE ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
	AND ChiTietHoaDon.MaDoAnUong = DoAnUong.MaDoAnUong
	AND HoaDon.MaNhanVienBan = TaiKhoan.TenDangNhap
	AND HoaDon.TrangThaiThanhToan = 0
	AND HoaDon.MaBan = @maBan
END
GO
--13
CREATE PROC USP_LAYDOANUONG
AS
BEGIN
	SELECT * FROM DoAnUong
END
GO
--14
CREATE PROC USP_LAYLOAIDOANUONG
AS
BEGIN
	SELECT * FROM LoaiDoAnUong
END
GO
--15
CREATE PROC USP_LAYLOAIDOANUONGTHEOMA @maLoaiDoAnUong INT
AS
BEGIN
	SELECT * FROM LoaiDoAnUong WHERE MaLoaiDoAnUong = @maLoaiDoAnUong
END
GO
--16
CREATE PROC USP_LAYLOAITAIKHOAN
AS
BEGIN
	SELECT * FROM LoaiTaiKhoan
END
GO
--17
CREATE PROC USP_LAYLOAITAIKHOANTHEOMA @maLoaiTaiKhoan INT
AS
BEGIN
	SELECT * FROM LoaiTaiKhoan WHERE MaLoaiTaiKhoan = @maLoaiTaiKhoan
END
GO
--18
CREATE PROC USP_LAYMAHOADONCHUATHANHTOANTHEOMABAN @maBan INT
AS
BEGIN
	SELECT * FROM HoaDon WHERE TrangThaiThanhToan = 0 AND MaBan = @maBan
END
GO
--19
CREATE PROC USP_LAYMAHOADONLONNHAT
AS
BEGIN
	SELECT MAX(MaHoaDon) FROM HoaDon
END
GO
--20
CREATE PROC USP_LAYSOLUONGHOADONTHEONGAY @ngayGioKhachToi DATE, @ngayGioKhachDi DATE
AS
BEGIN
	SELECT COUNT(*)
	FROM HoaDon, Ban
	WHERE HoaDon.MaBan= Ban.MaBan AND NgayGioKhachToi >= @ngayGioKhachToi AND NgayGioKhachDi <= @ngayGioKhachDi AND TrangThaiThanhToan = 1
END
GO
--21
CREATE PROC USP_LAYTAIKHOAN
AS
BEGIN
	SELECT * FROM TaiKhoan
END
GO
--22
CREATE PROC USP_LAYTAIKHOANTHEOTENDANGNHAP @tenDangNhap NVARCHAR(100)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap
END
GO
--23
CREATE PROC USP_QUENMATKHAU @tenDangNhap NVARCHAR(100), @matKhauMoi NVARCHAR(1000)
AS
BEGIN
	DECLARE @kiemTra INT = 0
	SELECT @kiemTra = COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap
	IF (@kiemTra = 1)
		UPDATE TaiKhoan SET MatKhau = @matKhauMoi WHERE TenDangNhap = @tenDangNhap
END
GO
--24
CREATE PROC USP_SUADOANUONG @maDoAnUong INT, @tenDoAnUong NVARCHAR(100), @maLoaiDoAnUong INT, @giaNiemYet float
AS
BEGIN
	UPDATE DoAnUong SET TenDoAnUong = @tenDoAnUong, MaLoaiDoAnUong = @maLoaiDoAnUong, GiaNiemYet = @giaNiemYet WHERE MaDoAnUong = @maDoAnUong
END
GO
--25
CREATE PROC USP_SUALOAIDOANUONG @maLoaiDoAnUong INT, @tenLoaiDoAnUong NVARCHAR(100)
AS
BEGIN
	UPDATE LoaiDoAnUong SET TenLoaiDoAnUong = @tenLoaiDoAnUong WHERE MaLoaiDoAnUong = @maLoaiDoAnUong
END	
GO
--26
CREATE PROC USP_SUATAIKHOAN @tenDangNhap NVARCHAR(100), @maLoaiTaiKhoan INT
AS
BEGIN
	UPDATE TaiKhoan SET MaLoaiTaiKhoan = @maLoaiTaiKhoan WHERE TenDangNhap = @tenDangNhap
END
GO
--27
CREATE PROC USP_THANHTOAN @maHoaDon INT, @giamGia INT, @tongGia FLOAT
AS
BEGIN
	UPDATE HoaDon SET NgayGioKhachDi = GETDATE(), TrangThaiThanhToan = 1, GiamGia = @giamGia, TongGia = @tongGia WHERE MaHoaDon = @maHoaDon
END
GO
--28
CREATE PROC USP_THEMCHITIETHOADON @maHoaDon INT, @maDoAnUong INT, @soLuong INT
AS
BEGIN
	DECLARE @kiemTraChiTietHoaDon INT, @soLuongDoAn INT = 1
	SELECT @kiemTraChiTietHoaDon = MaChiTietHoaDon, @soLuongDoAn = SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon AND MaDoAnUong = @maDoAnUong
	IF (@kiemTraChiTietHoaDon > 0)
	BEGIN
		DECLARE @soLuongMoi INT = @soLuongDoAn + @soLuong
		IF (@soLuongMoi > 0)
			UPDATE ChiTietHoaDon SET SoLuong = @soLuongDoAn + @soLuong WHERE MaHoaDon = @maHoaDon AND MaDoAnUong = @maDoAnUong
		ELSE
			DELETE ChiTietHoaDon WHERE MaHoaDon = @maHoaDon AND MaDoAnUong = @maDoAnUong
	END
	ELSE
		INSERT INTO ChiTietHoaDon(MaHoaDon, MaDoAnUong, SoLuong) VALUES (@maHoaDon, @maDoAnUong, @soLuong)
END
GO
--29
CREATE PROC USP_THEMDOANUONG @tenDoAnUong NVARCHAR(100), @maLoaiDoAnUong INT, @giaNiemYet float
AS
BEGIN
	INSERT INTO DoAnUong (TenDoAnUong, MaLoaiDoAnUong, GiaNiemYet) VALUES (@tenDoAnUong, @maLoaiDoAnUong, @giaNiemYet)
END
GO
--30
CREATE PROC USP_THEMHOADON @maBan INT, @tenKhachHang NVARCHAR(100), @soDienThoai NCHAR(10), @maNhanVienBan NVARCHAR(100)
AS
BEGIN
	INSERT INTO HoaDon(NgayGioKhachToi, NgayGioKhachDi, TrangThaiThanhToan, GiamGia, TenKhachHang, SoDienThoaiKhachHang, MaNhanVienBan, MaBan)
	VALUES (GETDATE(), NULL, 0, 0, @tenKhachHang, @soDienThoai, @maNhanVienBan, @maBan)
END
GO
--31
CREATE PROC USP_THEMLOAIDOANUONG @tenLoaiDoAnUong NVARCHAR(100)
AS
BEGIN
	INSERT INTO LoaiDoAnUong(TenLoaiDoAnUong) VALUES (@tenLoaiDoAnUong)
END
GO
--32
CREATE PROC USP_THEMTAIKHOAN @tenDangNhap NVARCHAR(100), @matKhau NVARCHAR(1000), @hoTen NVARCHAR(100), @soDienThoai NCHAR(10), @maLoaiTaiKhoan INT
AS
BEGIN
	INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, SoDienThoai, MaLoaiTaiKhoan) VALUES (@tenDangNhap, @matKhau, @hoTen, @soDienThoai, @maLoaiTaiKhoan)
END
GO
--33
CREATE PROC USP_XOACHITIETHOADONTHEOMADOANUONG @maDoAnUong INT
AS
BEGIN
	DELETE ChiTietHoaDon WHERE MaDoAnUong = @maDoAnUong
END
GO
--34
CREATE PROC USP_XOADOANUONG @maDoAnUong INT
AS
BEGIN
	DELETE DoAnUong WHERE MaDoAnUong = @maDoAnUong
END
GO
--35
CREATE PROC USP_XOAHOADONTHEOMANHANVIEN @maNhanVienBan NVARCHAR(100)
AS
BEGIN
	DELETE HoaDon WHERE MaNhanVienBan = @maNhanVienBan
END
GO
--36
CREATE PROC USP_XOATAIKHOAN @tenDangNhap NVARCHAR(100)
AS
BEGIN
	DELETE TaiKhoan WHERE TenDangNhap = @tenDangNhap
END
GO
CREATE TRIGGER UTG_CAPNHATCHITIETHOADON
ON ChiTietHoaDon FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @maHoaDon INT
	SELECT @maHoaDon = MaHoaDon FROM inserted
	DECLARE @maBan INT
	SELECT @maBan = MaBan FROM HoaDon WHERE MaHoaDon = @maHoaDon AND TrangThaiThanhToan = 0
	DECLARE @soLuong INT
	SELECT @soLuong = COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @maHoaDon
	IF (@soLuong > 0)
		UPDATE Ban SET TrangThaiBan = N'Có người' WHERE MaBan = @maBan
	ELSE
		UPDATE Ban SET TrangThaiBan = N'Không có người' WHERE MaBan = @maBan
END
GO
CREATE TRIGGER UTG_CAPNHATHOADON
ON HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @maHoaDon INT
	SELECT @maHoaDon = MaHoaDon FROM inserted
	DECLARE @maBan INT
	SELECT @maBan = MaBan FROM HoaDon WHERE MaHoaDon = @maHoaDon
	DECLARE @soLuong INT = 0
	SELECT @soLuong = COUNT(*) FROM HoaDon WHERE MaBan = @maBan AND TrangThaiThanhToan = 0
	IF (@soLuong = 0)
		UPDATE Ban SET TrangThaiBan = N'Không có người' WHERE MaBan = @maBan
END
GO
CREATE TRIGGER UTG_XOACHITIETHOADON
ON ChiTietHoaDon FOR DELETE
AS
BEGIN
	DECLARE @maChiTietHoaDon INT, @maHoaDon INT, @maBan INT, @soLuong INT = 0
	SELECT @maChiTietHoaDon = MaChiTietHoaDon, @maHoaDon = MaHoaDon FROM deleted
	SELECT @maBan = MaBan FROM HoaDon WHERE MaHoaDon = @maHoaDon
	SELECT @soLuong = COUNT(*) FROM ChiTietHoaDon, HoaDon WHERE HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon AND HoaDon.MaHoaDon = @maHoaDon AND HoaDon.TrangThaiThanhToan = 0
	IF (@soLuong = 0)
		UPDATE Ban SET TrangThaiBan = N'Không có người' WHERE MaBan = @maBan
END
GO
CREATE FUNCTION fuConvertToUnsign1
(
	@strInput NVARCHAR(4000)
)
RETURNS NVARCHAR(4000)
AS
BEGIN
	IF @strInput IS NULL RETURN @strInput 
	IF @strInput = '' RETURN @strInput 
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' 
	+NCHAR(272)+ NCHAR(208) 
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
			BEGIN 
				IF @COUNTER=1 
					SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
				ELSE
					SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
					BREAK 
			END
			SET @COUNTER1 = @COUNTER1 +1 
		END
		SET @COUNTER = @COUNTER +1
	END 
	SET @strInput = replace(@strInput,' ','-') 
	RETURN @strInput
END
GO