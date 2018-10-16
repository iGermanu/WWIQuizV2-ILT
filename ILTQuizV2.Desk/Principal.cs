using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILTQuizV2.Desk
{
    public partial class Principal : Form
    {
        int X;
        int Y;
        private DB _database = new DB();
        public Principal()
        {
            InitializeComponent();
            _database.DBName = "iltquiz";
            _database.Connect();
        }

        #region METODOS
        public void MudarTopico()
        {
            Pn_armamento.Visible = false;
            Pn_historia.Visible = false;
            Pn_inicio.Visible = false;
            Pn_veiculos.Visible = false;
        }

        public void AtivarBotoes()
        {
            Btn_inicio.Enabled = true;
            Btn_armamento.Enabled = true;
            Btn_historia.Enabled = true;
            Btn_veiculos.Enabled = true;
        }
        #endregion

        #region BOTÕES DOS TÓPICOS
        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_inicio.Visible = true;
            AtivarBotoes();
            Btn_inicio.Enabled = false;
        }

        private void Btn_armamento_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_armamento.Visible = true;
            AtivarBotoes();
            Btn_armamento.Enabled = false;
        }

        private void Btn_historia_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_historia.Visible = true;
            AtivarBotoes();
            Btn_historia.Enabled = false;
        }

        private void Btn_veiculos_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_veiculos.Visible = true;
            AtivarBotoes();
            Btn_veiculos.Enabled = false;
        }
        #endregion

        #region FRESCURAS
        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
        #endregion
    }
}
