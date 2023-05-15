using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using BarangKamu;


namespace UnitTesting
{
    [TestFixture]
    public class DataBarangTests
    {
        private DataBarang dataBarang;

        [SetUp]
        public void SetUp()
        {
            dataBarang = new DataBarang();
            dataBarang.LoadData();
        }

        [Test]
        public void TambahBarang_InputNamaBarangKosong_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => dataBarang.TambahBarang());
        }

        [Test]
        public void TambahBarang_InputJumlahBarangKosong_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => dataBarang.TambahBarang());
        }

        [Test]
        public void TambahBarang_DuplicateNamaBarang_ReturnsErrorMessage()
        {
            // Arrange
            dataBarang.daftarBarang = new List<Barang>
            {
                new Barang("Buku", 10)
            };

            // Act
            using var input = new StringReader("Buku\n5\n");
            Console.SetIn(input);
            dataBarang.TambahBarang();

            // Assert
            Assert.AreEqual("Barang dengan nama tersebut sudah ada dalam daftar.\r\n", Console.Out.ToString());
        }

        [Test]
        public void TambahBarang_InputValidData_ReturnsSuccessMessage()
        {
            // Arrange, Act
            using var input = new StringReader("Buku\n5\n");
            Console.SetIn(input);
            dataBarang.TambahBarang();

            // Assert
            Assert.AreEqual("Note: Barang berhasil ditambahkan.\r\n", Console.Out.ToString(), "TambahBarang should return success message");
        }

        [Test]
        public void TampilkanBarang_DaftarBarangKosong_ReturnsSuccessMessage()
        {
            // Arrange, Act
            dataBarang.daftarBarang.Clear();
            dataBarang.TampilkanBarang();

            // Assert
            Assert.AreEqual("Data barang masih kosong\r\n", Console.Out.ToString());
        }

        [Test]
        public void TampilkanBarang_DaftarBarangNotEmpty_ReturnsDaftarBarang()
        {
            // Arrange
            dataBarang.daftarBarang = new List<Barang>
            {
                new Barang("Buku", 10),
                new Barang("Pensil", 5)
            };

            // Act
            dataBarang.TampilkanBarang();

            // Assert
            var expectedOutput = "Nama Barang | Jumlah Barang\r\nBuku         | 10\r\nPensil       | 5\r\n";
            Assert.AreEqual(expectedOutput, Console.Out.ToString());
        }

        [Test]
        public void UbahBarang_InputNamaBarangLamaNotFound_ReturnsErrorMessage()
        {
            // Arrange
            dataBarang.daftarBarang = new List<Barang>
            {
                new Barang("Buku", 10),
                new Barang("Pensil", 5)
            };

            // Act
            using var input = new StringReader("Penghapus\nBuku Baru\n5\n");
            Console.SetIn(input);
            dataBarang.UbahBarang();

            // Assert
            Assert.AreEqual("Note: Barang tidak ditemukan.\r\n", Console.Out.ToString());
        }

    }
}
