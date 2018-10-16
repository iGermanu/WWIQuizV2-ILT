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

        public void AtivarBotoes(bool Ativar)
        {
            if (Ativar)
            {
                Btn_inicio.Enabled = true;
                Btn_armamento.Enabled = true;
                Btn_historia.Enabled = true;
                Btn_veiculos.Enabled = true;
            }
            else
            {
                Btn_inicio.Enabled = false;
                Btn_armamento.Enabled = false;
                Btn_historia.Enabled = false;
                Btn_veiculos.Enabled = false;
            }
        }

        public void BottomButtons(bool Ativar)
        {
            if (Ativar)
            {
                Btn_pular.Enabled = true;
                Btn_dica.Enabled = true;
            }
            else
            {
                Btn_pular.Enabled = false;
                Btn_dica.Enabled = false;
            }
        }

        public void AtivarProxima(bool Ativar)
        {
            if (Ativar)
            {
                Btn_prox.Enabled = true;
            }
            else
            {
                Btn_prox.Enabled = false;
            }
        }

        public void PrepararPergunta(string Topico, int Categoria)
        {
            AtivarBotoes(false);
            Lbl_topico.Text = Topico;
            // PUXA A PERGUNTA DO BANCO DE DADOS
            string strSQL = "SELECT pergunta FROM pergunta ";
            strSQL += "WHERE id_perg = (SELECT MIN(id_perg) FROM pergunta WHERE categoria = " + Categoria + ")";
            DataSet resultado = _database.Search(strSQL);
            string pergunta = resultado.Tables["tbl_resultado"].Rows[0]["pergunta"].ToString();
            Lbl_pergunta.Text = pergunta;

            // PUXA AS RESPOSTAS DO BANCO DE DADOS
            string id_resp = "SELECT id_resp FROM resposta ";
            id_resp += "WHERE fk_perg = (SELECT MIN(id_resp) FROM resposta WHERE categoria = " + Categoria + ")";

            string resposta1 = "SELECT resposta FROM resposta ";
            resposta1 += "WHERE id_resp = ";


            Pn_perguntas.Visible = true;
        }

        public void DesativarAlternativa(Button Alternativa)
        {
            Btn_alternativa1.Enabled = false;
            Btn_alternativa2.Enabled = false;
            Btn_alternativa3.Enabled = false;
            Btn_alternativa4.Enabled = false;
            Alternativa.Enabled = true;
        }
        #endregion

        #region BOTÕES DOS TÓPICOS
        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_inicio.Visible = true;
            AtivarBotoes(true);
            Btn_inicio.Enabled = false;
        }

        private void Btn_armamento_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_armamento.Visible = true;
            AtivarBotoes(true);
            Btn_armamento.Enabled = false;
        }

        private void Btn_historia_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_historia.Visible = true;
            AtivarBotoes(true);
            Btn_historia.Enabled = false;
        }

        private void Btn_veiculos_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_veiculos.Visible = true;
            AtivarBotoes(true);
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

        #region BOTÕES DE INICIO
        private void Btn_playarmamento_Click(object sender, EventArgs e)
        {
            Pn_playarmamento.Visible = false;
            Pn_armamento.Visible = false;
            BottomButtons(true);
            PrepararPergunta("armamento", 1);
        }

        private void Btn_playveiculos_Click(object sender, EventArgs e)
        {
            Pn_playveiculos.Visible = false;
            Pn_veiculos.Visible = false;
            BottomButtons(true);
            PrepararPergunta("veículos", 2);
        }

        private void Btn_playhistoria_Click(object sender, EventArgs e)
        {
            Pn_playhistoria.Visible = false;
            Pn_historia.Visible = false;
            BottomButtons(true);
            PrepararPergunta("história", 3);
        }

        #endregion

        #region ALTERNATIVAS
        private void Btn_alternativa1_Click(object sender, EventArgs e)
        {
            DesativarAlternativa((Button)sender);
        }

        private void Btn_alternativa2_Click(object sender, EventArgs e)
        {
            DesativarAlternativa((Button)sender);
        }

        private void Btn_alternativa3_Click(object sender, EventArgs e)
        {
            DesativarAlternativa((Button)sender);
        }

        private void Btn_alternativa4_Click(object sender, EventArgs e)
        {
            DesativarAlternativa((Button)sender);
        }
        #endregion
    }
}
