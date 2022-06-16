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
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
        }

        public Urunler Urunler { get; set; }
        public bool Güncelleme { get; set; } = false;


        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            return true;

        }



        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (!ErrorControl(txtUrun)) return;
            if (!ErrorControl(cbKategori)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(nmStok)) return;
            if (!ErrorControl(cbBirim)) return;
            if (!ErrorControl(txtDetay)) return;

            Urunler.Ad = txtUrun.Text;
            Urunler.Kategori = cbKategori.Text;
            Urunler.Fiyat = (double)nmFiyat.Value;
            Urunler.Stok = (double)nmStok.Value;
            Urunler.Birim = cbBirim.Text;
            Urunler.Detay = txtDetay.Text;


            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Urun_Load(object sender, EventArgs e)
        {
            txtID.Text = Urunler.ID.ToString();
            if (Güncelleme)
            {
                txtUrun.Text = Urunler.Ad;
                cbKategori.Text = Urunler.Kategori;
                nmFiyat.Value = (decimal)Urunler.Fiyat;
                nmStok.Value = (decimal)Urunler.Stok;
                cbBirim.Text = Urunler.Birim;
                txtDetay.Text = Urunler.Detay;
            }
        }
    }
}

