using dataBarangLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace BarangKamu
{
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

    //automata


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

            Debug.Assert(!string.IsNullOrWhiteSpace(namaBarang), "namaBarang harus diisi");

            if (daftarBarang.Any(barang => barang.NamaBarang == namaBarang))
            {
                Console.WriteLine();
                Console.WriteLine("Barang dengan nama tersebut sudah ada dalam daftar.");
            }
            else
            {
                Console.Write("Masukkan jumlah barang: ");
                int jumlahBarang = int.Parse(Console.ReadLine());

                Debug.Assert(jumlahBarang > 0, "jumlahBarang harus lebih besar dari nol");

                Barang barangBaru = new Barang(namaBarang, jumlahBarang);
                daftarBarang.Add(barangBaru);
                Console.WriteLine();
                Console.WriteLine("Note: Barang berhasil ditambahkan.");
                Debug.Assert(daftarBarang.Contains(barangBaru), "daftarBarang harus berisi barangBaru setelah barang ditambahkan");

                SaveData();
            }
        }

        public void TampilkanBarang()
        {

            // Menampilkan daftar barang
            Console.WriteLine("===== Daftar Barang =====");

            // Precondition: daftarBarang tidak boleh null
            Debug.Assert(daftarBarang != null, "daftarBarang tidak boleh null");

            if (daftarBarang.Count == 0)
            {
                Console.WriteLine("Data barang masih kosong");
            }
            else
            {
                Console.WriteLine("Nama Barang | Jumlah Barang");

                // Precondition: setiap barang dalam daftarBarang harus tidak null
                Debug.Assert(daftarBarang.All(barang => barang != null), "setiap barang dalam daftarBarang harus tidak null");

                foreach (Barang barang in daftarBarang)
                {
                    // Invariant: setiap barang dalam daftarBarang harus memiliki nama dan jumlah yang valid
                    Debug.Assert(!string.IsNullOrWhiteSpace(barang.NamaBarang), "setiap barang dalam daftarBarang harus memiliki nama yang valid");
                    Debug.Assert(barang.JumlahBarang >= 00, "setiap barang dalam daftarBarang harus memiliki jumlah barang yang tidak negatif");

                    Console.WriteLine(barang);
                }
            }
        }

        public void UbahBarang()
        {
            // Precondition
            Debug.Assert(daftarBarang.Count > 0, "Data barang masih kosong!");

            // Mengubah barang
            Console.WriteLine("===== Ubah Barang =====");
            Console.Write("Masukkan nama barang yang akan diubah: ");
            string namaBarangLama = Console.ReadLine();
            Barang barang = daftarBarang.Find(b => b.NamaBarang == namaBarangLama);

            // Precondition
            Debug.Assert(barang != null, "Barang tidak ditemukan.");

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

                // Postcondition
                Debug.Assert(!string.IsNullOrWhiteSpace(namaBarangBaru), "Nama barang tidak boleh kosong!");

                barang.NamaBarang = namaBarangBaru;
                barang.JumlahBarang = jumlahBarang;
                Console.WriteLine();
                Console.WriteLine("Note: Barang berhasil diubah.");

                // Postcondition
                Debug.Assert(daftarBarang.Any(b => b.NamaBarang == namaBarangBaru), "Barang gagal diubah.");

                SaveData(); // Menyimpan perubahan ke dalam file
            }

            // Postcondition
            Debug.Assert(daftarBarang.Count > 0, "Data barang masih kosong!");
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
            Debug.Assert(daftarBarang != null, "daftarBarang harus tidak null");

            // Menghapus seluruh data dalam file
            string path = "informasi_barang.txt";
            File.WriteAllText(path, string.Empty);

            // Postcondition: daftarBarang harus kosong setelah data dihapus
            Debug.Assert(daftarBarang.Count == 0, "daftarBarang harus kosong setelah data dihapus");

            daftarBarang.Clear();
            Console.WriteLine("Seluruh data berhasil dihapus.");
        }


        

        public void Run()
        {
            LoadData();
            //Class1 dataBarang = new dataBarangLibrary.Class1();

            bool isRunning = true;
            while (isRunning)
            {
                Class1  menu = new Class1();
                MenuOption option = (MenuOption)menu.ShowMenu();
                Console.Clear();


                Debug.Assert(Enum.IsDefined(typeof(MenuOption), option), "Pilihan tidak valid. Silakan pilih menu yang sesuai.");
                //string namabarang = "buku";
                //int jumlahbarang = 7;
                switch (option)
                {

                    case MenuOption.dashboard:
                        menu.ShowMenu();
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
