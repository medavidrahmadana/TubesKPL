
using System.Diagnostics;

namespace dataBarangLibrary
{
    public class Class1
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
    }
}