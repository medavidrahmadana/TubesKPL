using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BarangKamuGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Tambah data barang
        private void button1_Click(object sender, EventArgs e)
        {
            // menerima inputan pada text box
            string inputnama = inputNama.Text;
            string inputjumlah = inputJumlah.Text;

            // menambah data ke table data barang
            dataBarang.Rows.Add(inputnama, inputjumlah);

            // menghapus isi text box
            inputNama.Text = "";
            inputJumlah.Text = "";
            //SaveDataToXml();
        }

        //Delete data barang
        private void button3_Click(object sender, EventArgs e)
        {
            // Get the current selected row index
            int rowIndex = dataBarang.CurrentRow.Index;

            // Remove the row from the data grid view
            dataBarang.Rows.RemoveAt(rowIndex);
            //SaveDataToXml();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //inputNama
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //inputJumlah
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Update data barang
        private void button2_Click(object sender, EventArgs e)
        {
            // Get the input text from the text boxes
            string inputnama = inputNama.Text;
            string inputjumlah = inputJumlah.Text;

            // Get the current selected row index
            int rowIndex = dataBarang.CurrentRow.Index;

            // Update the values of the cells in the selected row
            dataBarang.Rows[rowIndex].Cells[0].Value = inputnama;
            dataBarang.Rows[rowIndex].Cells[1].Value = inputjumlah;

            // Clear the text boxes
            inputNama.Text = "";
            inputJumlah.Text = "";
            //SaveDataToXml();
        }

        //Table yang berfungsi menerima nama barang dan jumlah barang colum 1 = NamaBarang, colum 2 = JummlahBarang
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Delete all data barang
        private void deleteAll_Click(object sender, EventArgs e)
        {
            // Clear all the rows from the data grid view
            dataBarang.Rows.Clear();
        }
        // Menyimpan data ke file XML
        /*private void SaveDataToXml()
        {
            DataTable dataTable = new DataTable("dataBarang");

            // Menambahkan kolom ke DataTable
            dataTable.Columns.Add("NamaBarang");
            dataTable.Columns.Add("JumlahBarang");

            // Menambahkan baris ke DataTable
            foreach (DataGridViewRow row in dataBarang.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["NamaBarang"] = row.Cells[0].Value.ToString();
                dataRow["JumlahBarang"] = row.Cells[1].Value.ToString();
                dataTable.Rows.Add(dataRow);
            }

            // Menyimpan DataTable ke file XML
            dataTable.WriteXml("data_barang.xml");
        }
        // Load data barang dari file XML
        private void LoadDataFromXml()
        {
            // Clear all the rows from the data grid view
            dataBarang.Rows.Clear();

            // Load the XML file into a DataSet
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("data_barang.xml");

            // Get the DataTable from the DataSet
            DataTable dataTable = dataSet.Tables["dataBarang"];

            // Add each row in the DataTable to the data grid view
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string namaBarang = dataRow["NamaBarang"].ToString();
                string jumlahBarang = dataRow["JumlahBarang"].ToString();
                dataBarang.Rows.Add(namaBarang, jumlahBarang);
            }
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadDataFromXml();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
