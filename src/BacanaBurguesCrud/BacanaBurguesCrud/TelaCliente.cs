﻿using System;
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
    public partial class TelaCliente : MetroFramework.Forms.MetroForm
    {
        public TelaCliente()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new BacanaBurgues();
            f.Closed += (s, args) => this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdicionarCliente novaform = new AdicionarCliente();
            novaform.Show();
        }
    }
}
/* his.Hide();
   Form f = new BacanaBurgues();
   f.Closed += (s, args) => this.Close();
*/