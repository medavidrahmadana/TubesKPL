using BarangKamu;
using System;

namespace BarangKamu
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBarang dataBarang = new DataBarang();
            dataBarang.Run();
        }
    }
}
    /*class Program
    {
        static void Main(string[] args)
        {
            DataBarang dataBarang = new DataBarang();
            dataBarang.LoadData();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("====|     Barang Kamu    |====");
                Console.WriteLine("------------------------------");
                Console.WriteLine("==== Aplikasi Data Barang ====");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Berikut Menu Yang Tersedia: ");
                Console.WriteLine("1. Tampilkan Barang");
                Console.WriteLine("2. Tambah Barang");
                Console.WriteLine("3. Ubah Barang");
                Console.WriteLine("4. Hapus Barang");
                Console.WriteLine("5. Hapus Semua Barang");
                Console.WriteLine("6. Keluar");
                Console.Write("Pilih menu (1-6): ");
                string pilihan = Console.ReadLine();
                Console.WriteLine();

                switch (pilihan)
                {
                    case "1":
                        dataBarang.TampilkanBarang();
                        break;
                    case "2":
                        dataBarang.TambahBarang();
                        break;
                    case "3":
                        dataBarang.UbahBarang();
                        break;
                    case "4":
                        dataBarang.HapusBarang();
                        break;
                    case "5":
                        dataBarang.HapusSemuaBarang();
                        break;
                    case "6":
                        exit = true;
                        dataBarang.SaveData();
                        Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}*/
