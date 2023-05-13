using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BarangKamu
{


    public class Barang
    {
        public string NamaBarang { get; set; }
        public int JumlahBarang { get; set; }

        public Barang(string namaBarang, int jumlahBarang)
        {
            NamaBarang = namaBarang;
            JumlahBarang = jumlahBarang;
        }

        public override string ToString()
        {
            return $"{NamaBarang} | {JumlahBarang}";
        }
    }

    public class DataBarang
    {

        public List<Barang> daftarBarang;

        public DataBarang()
        {
            daftarBarang = new List<Barang>();
        }

        // Teknik Runtime configuration
        public void LoadData()
        {
            string path = "informasi_barang.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                daftarBarang = JsonSerializer.Deserialize<List<Barang>>(json);
            }
        }

        public void SaveData()
        {
            string path = "informasi_barang.json";
            string json = JsonSerializer.Serialize(daftarBarang, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, json);
        }

        public void TambahBarang()
        {
            Console.WriteLine("===== Tambah Barang =====");
            Console.Write("Masukkan nama barang: ");
            string namaBarang = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(namaBarang))
            {
                Console.WriteLine();
                Console.WriteLine("Data barang tidak boleh kosong!");
            }
            else if (daftarBarang.Any(barang => barang.NamaBarang == namaBarang))
            {
                Console.WriteLine();
                Console.WriteLine("Barang dengan nama tersebut sudah ada dalam daftar.");
            }
            else
            {
                Console.Write("Masukkan jumlah barang: ");
                int jumlahBarang = int.Parse(Console.ReadLine());
                Barang barangBaru = new Barang(namaBarang, jumlahBarang);
                daftarBarang.Add(barangBaru);
                Console.WriteLine();
                Console.WriteLine("Note: Barang berhasil ditambahkan.");
                SaveData();
            }
        }

        public void TampilkanBarang()
        {
            // Menampilkan daftar barang
            Console.WriteLine("===== Daftar Barang =====");
            if (daftarBarang.Count == 0)
            {
                Console.WriteLine("Data barang masih kosong");
            }
            else
            {
                Console.WriteLine("Nama Barang | Jumlah Barang");
                foreach (Barang barang in daftarBarang)
                {
                    Console.WriteLine(barang);
                }
            }
        }

        public void UbahBarang()
        {
            // Mengubah barang
            Console.WriteLine("===== Ubah Barang =====");
            Console.Write("Masukkan nama barang yang akan diubah: ");
            string namaBarangLama = Console.ReadLine();
            Barang barang = daftarBarang.Find(b => b.NamaBarang == namaBarangLama);
            if (barang == null)
            {
                Console.WriteLine("Note: Barang tidak ditemukan.");
            }
            else
            {
                Console.Write("Masukkan nama barang baru: ");
                string namaBarangBaru = Console.ReadLine();
                Console.Write("Masukkan jumlah barang baru: ");
                int jumlahBarang = int.Parse(Console.ReadLine());
                barang.NamaBarang = namaBarangBaru;
                barang.JumlahBarang = jumlahBarang;
                Console.WriteLine();
                Console.WriteLine("Note: Barang berhasil diubah.");
                SaveData(); // Menyimpan perubahan ke dalam file
            }
        }

        public void HapusBarang()
        {
            // Menghapus barang
            Console.WriteLine("===== Hapus Barang =====");
            Console.Write("Masukkan nama barang yang akan diubah: ");
            string namaBarang = Console.ReadLine();
            Barang barang = daftarBarang.Find(b => b.NamaBarang == namaBarang);
            if (barang == null)
            {
                Console.WriteLine("Barang tidak ditemukan.");
            }
            else
            {
                daftarBarang.Remove(barang);
                Console.WriteLine();
                Console.WriteLine("Note: Barang berhasil dihapus.");
                SaveData(); // Menyimpan perubahan ke dalam file
            }
        }

        public void HapusSemuaBarang()
        {
            // Menghapus seluruh data dalam file
            string path = "informasi_barang.txt";
            File.WriteAllText(path, string.Empty);
            daftarBarang.Clear();
            Console.WriteLine("Seluruh data berhasil dihapus.");
        }
    }
}