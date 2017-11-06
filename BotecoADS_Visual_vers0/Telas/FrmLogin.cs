using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmLogin : Form {
        public FrmLogin() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    
            btnLogin.Enabled = false;        //Deixando o botão de login desabilitado enquanto o textfield estiver vazio. 
        }

        private void btnAcessar_Click(object sender, EventArgs e) {
            string senha;

            senha = tfSenha.Text;

            if (senha == "root") {                                
                FrmMenuInicial f = new FrmMenuInicial();
                f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                f.ShowDialog();
                this.Dispose(); // depois de abrir o menu, o dispose fecha a tela de login.
            }   else {
                    MessageBox.Show("Senha incorreta. Tente novamente.");
                }
        }

        private void tfSenha_KeyUp(object sender, KeyEventArgs e) {
            // verificando a cada vez que soltar o dedo do teclado na inserção da senha
            if (tfSenha.Text.Equals("")) {
                btnLogin.Enabled = false;
            }   else {
                    btnLogin.Enabled = true;
                }
        }

        private void btnSair(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}