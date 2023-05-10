using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace BarangKamu.UnitTest
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

        [TearDown]
        public void TearDown()
        {
            dataBarang.HapusSemuaBarang();
        }

        [Test]
        public void TambahBarang_BarangBaru_DitambahkanKeDaftar()
        {
            // Arrange
            string namaBarang = "Pensil";
            int jumlahBarang = 10;

            // Act
            dataBarang.TambahBarang();

            // Assert
            Assert.AreEqual(1, dataBarang.DaftarBarang.Count);
            Assert.AreEqual(namaBarang, dataBarang.DaftarBarang[0].NamaBarang);
            Assert.AreEqual(jumlahBarang, dataBarang.DaftarBarang[0].JumlahBarang);
        }

        [Test]
        public void TambahBarang_BarangSudahAda_DaftarTidakBerubah()
        {
            // Arrange
            string namaBarang = "Buku";
            int jumlahBarang = 5;
            Barang barang = new Barang(namaBarang, jumlahBarang);
            dataBarang.DaftarBarang.Add(barang);

            // Act
            dataBarang.TambahBarang();

            // Assert
            Assert.AreEqual(1, dataBarang.DaftarBarang.Count);
            Assert.AreEqual(namaBarang, dataBarang.DaftarBarang[0].NamaBarang);
            Assert.AreEqual(jumlahBarang, dataBarang.DaftarBarang[0].JumlahBarang);
        }

        [Test]
        public void TampilkanBarang_DaftarBarangKosong_TampilkanPesan()
        {
            // Act
            string result = CaptureConsoleOutput(() =>
            {
                dataBarang.TampilkanBarang();
            });

            // Assert
            StringAssert.Contains("Data barang masih kosong", result);
        }

        [Test]
        public void TampilkanBarang_DaftarBarangTidakKosong_TampilkanDaftarBarang()
        {
            // Arrange
            Barang barang1 = new Barang("Buku", 5);
            Barang barang2 = new Barang("Pensil", 10);
            dataBarang.DaftarBarang.Add(barang1);
            dataBarang.DaftarBarang.Add(barang2);

            // Act
            string result = CaptureConsoleOutput(() =>
            {
                dataBarang.TampilkanBarang();
            });

            // Assert
            StringAssert.Contains("Buku | 5", result);
            StringAssert.Contains("Pensil | 10", result);
        }

        [Test]
        public void UbahBarang_BarangTerdapatDiDaftar_BarangDiubah()
        {
            // Arrange
            Barang barang = new Barang("Buku", 5);
            dataBarang.DaftarBarang.Add(barang);

            string namaBarangBaru = "Buku Tulis";
            int jumlahBarangBaru = 3;

            // Act
            dataBarang.UbahBarang();

            // Assert
            Assert.AreEqual(namaBarangBaru, barang.NamaBarang);
            Assert.AreEqual(jumlahBarangBaru, barang.JumlahBarang);
        }

        private string CaptureConsoleOutput(Action action)
        {
            // Redirect console output to a StringWriter
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Execute the action
            action.Invoke();

            // Get the captured output
            string output = stringWriter.ToString();

            // Restore console output
            Console.SetOut(Console.Out);

            return output;
        }
    }
}