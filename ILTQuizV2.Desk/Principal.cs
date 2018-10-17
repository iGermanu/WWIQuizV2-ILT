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
        int id_pergatual;
        int id_resp;
        int pontuacao = 0;
        int categoriaatual;
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

        public void VisibilidadeBotoezinhos(bool Ativar)
        {
            if (Ativar)
            {
                Btn_prox.Visible = true;
                Btn_pular.Visible = true;
                Btn_dica.Visible = true;
            }
            else
            {
                Btn_prox.Visible = false;
                Btn_pular.Visible = false;
                Btn_dica.Visible = false;
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

        public void PuxarResposta()
        {
            string resposta = "SELECT resposta FROM resposta ";
            resposta += "WHERE id_resp = " + id_resp;
            DataSet resultado = _database.Search(resposta);
            resposta = resultado.Tables["tbl_resultado"].Rows[0]["resposta"].ToString();
            Btn_alternativa1.Text = resposta;
            id_resp++;
            resposta = "SELECT resposta FROM resposta ";
            resposta += "WHERE id_resp = " + id_resp;
            resultado = _database.Search(resposta);
            resposta = resultado.Tables["tbl_resultado"].Rows[0]["resposta"].ToString();
            Btn_alternativa2.Text = resposta;
            id_resp++;
            resposta = "SELECT resposta FROM resposta ";
            resposta += "WHERE id_resp = " + id_resp;
            resultado = _database.Search(resposta);
            resposta = resultado.Tables["tbl_resultado"].Rows[0]["resposta"].ToString();
            Btn_alternativa3.Text = resposta;
            id_resp++;
            resposta = "SELECT resposta FROM resposta ";
            resposta += "WHERE id_resp = " + id_resp;
            resultado = _database.Search(resposta);
            resposta = resultado.Tables["tbl_resultado"].Rows[0]["resposta"].ToString();
            Btn_alternativa4.Text = resposta;
            id_resp++;
        }

        public void PrepararPergunta(string Topico, int Categoria)
        {
            AtivarBotoes(false);
            Lbl_topico.Text = Topico;
            categoriaatual = Categoria;

            // PUXA A PERGUNTA DO BANCO DE DADOS
            string perg = "SELECT id_perg, pergunta FROM pergunta ";
            perg += "WHERE id_perg = (SELECT MIN(id_perg) FROM pergunta WHERE categoria = " + Categoria + ")";
            DataSet resultado = _database.Search(perg);
            id_pergatual = Convert.ToInt32(resultado.Tables["tbl_resultado"].Rows[0]["id_perg"]);
            string pergunta = resultado.Tables["tbl_resultado"].Rows[0]["pergunta"].ToString();
            Lbl_pergunta.Text = pergunta;

            // PUXA AS RESPOSTAS DO BANCO DE DADOS
            string resp = "SELECT id_resp FROM resposta ";
            resp += "WHERE fk_perg = (SELECT MIN(id_perg) FROM pergunta WHERE categoria = " + Categoria + ")";
            resultado = _database.Search(resp);
            resp = resultado.Tables["tbl_resultado"].Rows[0]["id_resp"].ToString();
            id_resp = Convert.ToInt32(resp);
            PuxarResposta();

            Pn_perguntas.Visible = true;
        }

        public void HabilitaAlternativas(bool Ativar)
        {
            if (Ativar)
            {
                Btn_alternativa1.Enabled = true;
                Btn_alternativa2.Enabled = true;
                Btn_alternativa3.Enabled = true;
                Btn_alternativa4.Enabled = true;
            }
            else
            {
                Btn_alternativa1.Enabled = false;
                Btn_alternativa2.Enabled = false;
                Btn_alternativa3.Enabled = false;
                Btn_alternativa4.Enabled = false;
            }
        }

        public void VerificarAlternativa(Button Alternativa)
        {
            // DESABILITA O CLIQUE NOS BOTÕES
            Btn_dica.Enabled = false;
            Btn_pular.Enabled = false;
            HabilitaAlternativas(false);

            string Resposta = Alternativa.Text;
            string strSQL = "SELECT correta FROM resposta ";
            strSQL += "WHERE resposta = '" + Resposta + "'";
            DataSet resultado = _database.Search(strSQL);
            bool correta = Convert.ToBoolean(resultado.Tables["tbl_resultado"].Rows[0]["correta"]);

            if (correta)
            {
                Alternativa.BackColor = Color.Green;
                Alternativa.FlatAppearance.MouseOverBackColor = Color.Green;
                Alternativa.FlatAppearance.MouseDownBackColor = Color.Green;
                pontuacao += 20;
            }
            else
            {
                Alternativa.BackColor = Color.Red;
                Alternativa.FlatAppearance.MouseOverBackColor = Color.Red;
                Alternativa.FlatAppearance.MouseDownBackColor = Color.Red;
                if (pontuacao > 10)
                {
                    pontuacao -= 10;
                }
                else
                {
                    pontuacao = 0;
                }
            }
            Lbl_pontuacao.Text = pontuacao.ToString();
            Btn_prox.Enabled = true;
        }

        public void ProximaPergunta()
        {
            id_pergatual++;
            Btn_prox.Enabled = false;

            //RESETA OS BOTÕES DE ALTERNATIVA
            Btn_alternativa1.BackColor = Color.White;
            Btn_alternativa1.FlatAppearance.MouseOverBackColor = Color.White;
            Btn_alternativa1.FlatAppearance.MouseDownBackColor = Color.White;
            Btn_alternativa2.BackColor = Color.White;
            Btn_alternativa2.FlatAppearance.MouseOverBackColor = Color.White;
            Btn_alternativa2.FlatAppearance.MouseDownBackColor = Color.White;
            Btn_alternativa3.BackColor = Color.White;
            Btn_alternativa3.FlatAppearance.MouseOverBackColor = Color.White;
            Btn_alternativa3.FlatAppearance.MouseDownBackColor = Color.White;
            Btn_alternativa4.BackColor = Color.White;
            Btn_alternativa4.FlatAppearance.MouseOverBackColor = Color.White;
            Btn_alternativa4.FlatAppearance.MouseDownBackColor = Color.White;
            HabilitaAlternativas(true);
            
            string perg = "SELECT categoria FROM pergunta ";
            perg += "WHERE id_perg = " + id_pergatual;
            DataSet resultado = _database.Search(perg);
            int categoria = Convert.ToInt32(resultado.Tables["tbl_resultado"].Rows[0]["categoria"]);

            if (categoria == categoriaatual)
            {
                //PUXA PERGUNTA
                perg = "SELECT pergunta FROM pergunta ";
                perg += "WHERE id_perg = " + id_pergatual;
                resultado = _database.Search(perg);
                string pergunta = resultado.Tables["tbl_resultado"].Rows[0]["pergunta"].ToString();
                Lbl_pergunta.Text = pergunta;

                //PUXA RESPOSTAS
                PuxarResposta();
                BottomButtons(true);
            }
            else
            {
                Pn_perguntas.Visible = false;
                Pn_fim.Visible = true;
                VisibilidadeBotoezinhos(false);
                AtivarBotoes(true);
                BottomButtons(false);
            }
        }
        #endregion

        #region BOTÕES DOS TÓPICOS
        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_inicio.Visible = true;
            AtivarBotoes(true);
            Btn_inicio.Enabled = false;
            if (Pn_fim.Visible == true)
            {
                Pn_fim.Visible = false;
            }
            VisibilidadeBotoezinhos(false);
        }

        private void Btn_armamento_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_armamento.Visible = true;
            AtivarBotoes(true);
            Btn_armamento.Enabled = false;
            if (Pn_fim.Visible == true)
            {
                Pn_fim.Visible = false;
            }
            VisibilidadeBotoezinhos(true);
        }

        private void Btn_historia_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_historia.Visible = true;
            AtivarBotoes(true);
            Btn_historia.Enabled = false;
            if (Pn_fim.Visible == true)
            {
                Pn_fim.Visible = false;
            }
            VisibilidadeBotoezinhos(true);
        }

        private void Btn_veiculos_Click(object sender, EventArgs e)
        {
            MudarTopico();
            Pn_veiculos.Visible = true;
            AtivarBotoes(true);
            Btn_veiculos.Enabled = false;
            if (Pn_fim.Visible == true)
            {
                Pn_fim.Visible = false;
            }
            VisibilidadeBotoezinhos(true);
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
            VerificarAlternativa((Button)sender);
        }

        #endregion

        #region BOTÕES DE BAIXO
        private void Btn_prox_Click(object sender, EventArgs e)
        {
            ProximaPergunta();
        }

        private void Btn_pular_Click(object sender, EventArgs e)
        {
            id_pergatual++;
            Btn_prox.Enabled = false;

            string perg = "SELECT categoria FROM pergunta ";
            perg += "WHERE id_perg = " + id_pergatual;
            DataSet resultado = _database.Search(perg);
            int categoria = Convert.ToInt32(resultado.Tables["tbl_resultado"].Rows[0]["categoria"]);

            if (categoria == categoriaatual)
            {
                //PUXA PERGUNTA
                perg = "SELECT pergunta FROM pergunta ";
                perg += "WHERE id_perg = " + id_pergatual;
                resultado = _database.Search(perg);
                string pergunta = resultado.Tables["tbl_resultado"].Rows[0]["pergunta"].ToString();
                Lbl_pergunta.Text = pergunta;

                //PUXA RESPOSTAS
                PuxarResposta();
                BottomButtons(true);
            }
            else
            {
                Pn_perguntas.Visible = false;
                Pn_fim.Visible = true;
                VisibilidadeBotoezinhos(false);
                AtivarBotoes(true);
                BottomButtons(false);
            }
        }

        private void Btn_dica_Click(object sender, EventArgs e)
        {
            string dca = "SELECT dica FROM pergunta ";
            dca += "WHERE id_perg = " + id_pergatual;
            DataSet resultado = _database.Search(dca);
            string dica = resultado.Tables["tbl_resultado"].Rows[0]["dica"].ToString();

            if (pontuacao > 5)
            {
                pontuacao -= 5;
            }
            else
            {
                pontuacao = 0;
            }
            Lbl_pontuacao.Text = pontuacao.ToString();
            MessageBox.Show(dica, "Dica", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
