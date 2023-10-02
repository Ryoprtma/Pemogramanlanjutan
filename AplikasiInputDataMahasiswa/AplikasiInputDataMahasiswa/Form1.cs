using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public class Mahasiswa
        {
            public string Nim, Nama, Kelas, Nilaihuruf;
            public int Nilai;
        }
        public Form1()
        {
            InitializeComponent();
            InsialisasiListView();


        }

        private void InsialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilaihuruf", 200, HorizontalAlignment.Center);

        }

        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();

            txtNilai.Text = "0";
            txtNim.Focus();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();

            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);
            if (mhs.Nilai >= 0 && mhs.Nilai <= 20)
            {
                mhs.Nilaihuruf = "E";
            }
            else if (mhs.Nilai >= 21 && mhs.Nilai <= 40)
            {
                mhs.Nilaihuruf = "D";
            }
            else if (mhs.Nilai >= 41 && mhs.Nilai <= 60)
            {
                mhs.Nilaihuruf = "C";
            }
            else if (mhs.Nilai >= 61 && mhs.Nilai <= 80)
            {
                mhs.Nilaihuruf = "B";
            }
            else if (mhs.Nilai >= 81 && mhs.Nilai <= 100)
            {
                mhs.Nilaihuruf = "A";
            }
            list.Add(mhs);
            var msg = "Data mahasiswa berhasil disimpan.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            ResetForm();
        }

        private void TampilkanData()
        {
            lvwMahasiswa.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.Nilaihuruf);

                lvwMahasiswa.Items.Add(item);
            }
        }
        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

            if (lvwMahasiswa.SelectedItems.Count > 0)
            {

                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin  dihapus ? ", "Konfirmasi",

                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {

                    var index = lvwMahasiswa.SelectedIndices[0];

                    list.RemoveAt(index);

                    TampilkanData();
                }
            }
            else
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}