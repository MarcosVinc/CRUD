﻿using BacanaBurgues.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BacanaBurguesCrud
{
    public partial class TelaProduto : MetroFramework.Forms.MetroForm
    {
        public TelaProduto()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new BacanaBurgues();
            f.Closed += (s, args) => this.Close();
        }

        private void CarregarProdutos() 
        {
            var x = new RepositorioDeProduto();           
            var produtos = x.Consulta();
            dataGridView1.DataSource = produtos;



        }
    }
}
