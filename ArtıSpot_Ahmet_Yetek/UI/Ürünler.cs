using ArtıSpot_Ahmet_Yetek.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtıSpot_Ahmet_Yetek.UI
{
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }
        public Urunler Urunler { get; set; }



        private void btnÜrünEkle_Click_1(object sender, EventArgs e)
        {

            Urun frm = new Urun()
            {
                Text = "Ürün Ekle",
                Urunler = new Urunler() { ID = Guid.NewGuid() },
            };

        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(frm.Urunler);

                if (b)
                {

                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }

        }

        private void btnÜrünDüzenle_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            Urun frm = new Urun()
            {
                Text = "Ürün Güncelle",
                Güncelleme = true,
                Urunler = new Urunler()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Stok = double.Parse(row.Cells[4].Value.ToString()),
                    Birim = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[6].Value.ToString(),

                },
            };

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunGüncelle(frm.Urunler);

                if (b)
                {
                    row.Cells[1].Value = frm.Urunler.Ad;
                    row.Cells[2].Value = frm.Urunler.Kategori;
                    row.Cells[3].Value = frm.Urunler.Fiyat;
                    row.Cells[4].Value = frm.Urunler.Stok;
                    row.Cells[5].Value = frm.Urunler.Birim;
                    row.Cells[6].Value = frm.Urunler.Detay;

                }

            }
        }

        private void btnÜrünSil_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }

            }
        }

        private void Ürünler_Load_1(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.UrunGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];


            Urunler = new Urunler()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Kategori = row.Cells[2].Value.ToString(),
                Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                Stok = double.Parse(row.Cells[4].Value.ToString()),
                Birim = row.Cells[5].Value.ToString(),
                Detay = row.Cells[6].Value.ToString(),


            };

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

