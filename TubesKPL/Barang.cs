using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
