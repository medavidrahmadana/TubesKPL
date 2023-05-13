using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BarangKamu
{
    //automata
    public enum MenuOption
    {
        dashboard,
        TambahBarang,
        TampilkanBarang,
        UbahBarang,
        HapusBarang,
        HapusSemuaBarang,
        Keluar
    }

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
    

    public MenuOption ShowMenu()
        {
            Console.WriteLine("===== Menu =====");
            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Tampilkan Barang");
            Console.WriteLine("3. Ubah Barang");
            Console.WriteLine("4. Hapus Barang");
            Console.WriteLine("5. Hapus Semua Barang");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu (1-6): ");

            string input = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(input), "Pilihan tidak valid. Silakan pilih menu yang sesuai.");
            int selectedOption;
            bool isValidOption = int.TryParse(input, out selectedOption);
            Debug.Assert(isValidOption, "Pilihan tidak valid. Silakan pilih menu yang sesuai.");

            if (isValidOption && Enum.IsDefined(typeof(MenuOption), selectedOption))
            {
                return (MenuOption)selectedOption;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Pilihan cuma sampai 6 :) , Silakan pilih menu yang sesuai.");
                Console.WriteLine();
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                Console.Clear();
                return ShowMenu();
            }
        }

        public void Run()
        {
            LoadData();

            bool isRunning = true;
            while (isRunning)
            {
                MenuOption option = ShowMenu();
                Console.Clear();

                Debug.Assert(Enum.IsDefined(typeof(MenuOption), option), "Pilihan tidak valid. Silakan pilih menu yang sesuai.");
                switch (option)
                {

                    case MenuOption.dashboard:
                        ShowMenu();
                        Console.WriteLine("Tidak ada pilihan 0 itu lo :)");
                        break;
                    case MenuOption.TambahBarang:
                        TambahBarang();
                        break;
                    case MenuOption.TampilkanBarang:
                        TampilkanBarang();
                        break;
                    case MenuOption.UbahBarang:
                        UbahBarang();
                        break;
                    case MenuOption.HapusBarang:
                        HapusBarang();
                        break;
                    case MenuOption.HapusSemuaBarang:
                        HapusSemuaBarang();
                        break;
                    case MenuOption.Keluar:
                        isRunning = false;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}