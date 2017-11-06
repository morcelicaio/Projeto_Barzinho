using System.Windows.Forms;
using System.Drawing;

namespace BotecoADS_Visual_vers0 {
    public class MesaVisual {
        private int idMesa;
        private Label nroMesa;
        private Label isMesaDisponivel;
        private Panel painelMesa;
        private Button botaoMesa;

        public int IdMesa {
            get {
                return idMesa;
            }
            set {
                idMesa = value;
            }
        }

        public Label NroMesa {
            get {
                return nroMesa;
            }
            set {
                nroMesa = value;
            }
        }

        public Label IsMesaDisponivel {
            get {
                return isMesaDisponivel;
            }
            set {
                isMesaDisponivel = value;
            }
        }

        public Panel PainelMesa {
            get {
                return painelMesa;
            }
            set {
                painelMesa = value;
            }
        }

        public Button BotaoMesa {
            get {
                return botaoMesa;
            }
            set {
                botaoMesa = value;
            }

        }

        //Este método realiza as configurações da mesa. Por exemplo a cor da mesa e se ela está disponível ou ocupada.
        public void carregarComponentesParaMesasLivres(){
            nroMesa.ForeColor = Color.DarkGreen;
            isMesaDisponivel.Text = "Disponível";
            isMesaDisponivel.ForeColor = Color.DarkGreen;

            painelMesa.BackColor = Color.DarkGreen;
        
            botaoMesa.Image = Image.FromFile("F:\\IFSP - ADS - 3° SEM - 2016\\Linguagem de Programacao-2\\Projeto-semestral\\Icones-do-sistema\\mesa-livre.png");
            //botaoMesa.Image = Image.FromFile("E:\\IFSP - ADS - 3° SEM - 2016\\Linguagem de Programacao-2\\Projeto-semestral\\Icones-Sistema--telaFinal\\mesa-livre.png");

            botaoMesa.Enabled = true;
            painelMesa.Enabled = true;            
        }

        //Este método realiza as configurações da mesa. Por exemplo a cor da mesa e se ela está disponível ou ocupada. 
        public void carregarComponentesParaMesasOcupadas() {
            nroMesa.ForeColor = Color.Red;                     // alterando a cor
            isMesaDisponivel.Text = "Indisponível";           // alterando o texto
            isMesaDisponivel.ForeColor = Color.Red;          // alterando a cor

            painelMesa.BackColor = Color.Red;               //alterando a cor de fundo do painel
            botaoMesa.Image = Image.FromFile("F:\\IFSP - ADS - 3° SEM - 2016\\Linguagem de Programacao-2\\Projeto-semestral\\Icones-do-sistema\\mesa-ocupada.png");

            botaoMesa.Enabled = true; // desabilitando o botão na tela.
            painelMesa.Enabled = true; // desabilitando o painel na tela. 
        }

        //Alterando o estado da mesa entre aberta e fechada. 
        //Ele também verifica qual o formulário que chamou o FrmEscolherMesa e realiza as condições.            
        public void alterarEstadoDaMesa(string formQueChamou) {

            switch (formQueChamou) { // no abrir venda eu desabilito as mesas que já contém uma venda aberta.
                case "abrirVenda":
                    nroMesa.ForeColor = Color.Red;                     // alterando a cor
                    isMesaDisponivel.Text = "Indisponível";           // alterando o texto
                    isMesaDisponivel.ForeColor = Color.Red;          // alterando a cor

                    painelMesa.BackColor = Color.Red;               //alterando a cor de fundo do painel
                    botaoMesa.Image = Image.FromFile("F:\\IFSP - ADS - 3° SEM - 2016\\Linguagem de Programacao-2\\Projeto-semestral\\Icones-do-sistema\\mesa-ocupada.png");

                    botaoMesa.Enabled = false; // desabilitando o botão na tela.
                    painelMesa.Enabled = false; // desabilitando o painel na tela. 
                    break;

                case "fecharVenda":
                    nroMesa.ForeColor = Color.DarkGreen;                     
                    isMesaDisponivel.Text = "Disponível";           
                    isMesaDisponivel.ForeColor = Color.DarkGreen;          

                    painelMesa.BackColor = Color.DarkGreen;               
                    botaoMesa.Image = Image.FromFile("F:\\IFSP - ADS - 3° SEM - 2016\\Linguagem de Programacao-2\\Projeto-semestral\\Icones-do-sistema\\mesa-livre.png");

                    botaoMesa.Enabled = false; 
                    painelMesa.Enabled = false; 
                    break;
            }
        }
                        
                            //habilita os comps.  das vendas ativas na tela
        public void habilitarComponentesDaMesaVisual() {
                botaoMesa.Enabled = true; // desabilitando o botão na tela.
                painelMesa.Enabled = true; // desabilitando o painel na tela.   
        }

        public void desabilitarComponentesDaMesaVisual() {
            botaoMesa.Enabled = false; // desabilitando o botão na tela.
            painelMesa.Enabled = false; // desabilitando o painel na tela.   
        }

    }            
}
