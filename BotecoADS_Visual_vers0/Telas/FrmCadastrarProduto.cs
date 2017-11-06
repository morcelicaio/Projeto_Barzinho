using BotecoADS_Visual_vers0.DAO;
using System;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmCadastrarProduto : Form {

        public FrmCadastrarProduto() {
            InitializeComponent();            
        }

        private void limparCampos() {
            tfNomeProduto.Text = "";
            tfQtdProduto.Text = "";
            tfValorProduto.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e) {           
            this.Close();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e) {            
            string nomeProduto;            
            int qtdProduto;
            double valorProduto;            

            if (rbProdutoComum.Checked || rbPorcao.Checked) { // se algum radio button está selecionado ele entra.                
                nomeProduto = tfNomeProduto.Text.Trim();//O Trim elimina os espaços vindos da string.(usa no bd depois)
                
                if( (tfNomeProduto.Text == "") || (tfQtdProduto.Text == "" ) || (tfValorProduto.Text == "") ) {
                    MessageBox.Show("Preencha corretamente todos os campos requeridos antes de realizar o cadastro!");                    
                }   else {
                        qtdProduto = int.Parse(tfQtdProduto.Text);
                        valorProduto = Convert.ToDouble(tfValorProduto.Text);
                        //valorProduto = double.Parse(tfValorProduto.Text);                        

                        Produto p = new Produto(); // criando e preenchendo o objeto
                        p.NomeDoProduto = nomeProduto;
                        p.QtdeProduto = qtdProduto;
                        p.ValorUnitarioDoProduto = valorProduto;

                        if (rbProdutoComum.Checked) {
                            p.TipoDoProduto = "comum"; // ñ criei uma variável pq o tipoProduto ja escrevo aqui direto.
                        }   else {
                                p.TipoDoProduto = "porcao";
                            }

                        ProdutoDAO dao = new ProdutoDAO(); // criando um objeto que faz a ligação com o banco de dados.
                        dao.cadastrarProduto(p);  // acessando o banco e cadastrando o produto.

                        MessageBox.Show("Produto cadastrado com sucesso!");
                        limparCampos();                      
                    }               

            }   else {
                    MessageBox.Show("Preencha todos os campos requeridos antes de realizar o cadastro!");
                }                                     
        }                

            // só vai permitir digitar letras no campo.
        private void tfNomeProduto_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == ' ') {
                e.Handled = false;
            }
        }

        // só vai permitir digitar números, a vírgula e a tecla backspace no campo. O 8 é o basckpace na tabela ascii
        private void tfValorProduto_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ',' || e.KeyChar == 8) {
                e.Handled = false; // no false ele permite digitar no campo.
            }   else {
                    e.Handled = true;
                }
        }

        // só vai permitir digitar números no campo.
        private void tfQtdProduto_KeyUp(object sender, KeyEventArgs e) {
            if (Char.IsDigit(Convert.ToChar(e.KeyValue)) && Convert.ToChar(e.KeyValue) != '-') { // se o caracter digitado for um número ele entra.                
                e.Handled = false; //permitindo aparecer o caracter digitado no textbox

                if (tfQtdProduto.Text.Equals("0")) { // fazendo validação se inserir 0 no campo de quantidade pedida. 
                    MessageBox.Show("Insira apenas números maiores que 0 para o estoque do produto!");
                    tfQtdProduto.Clear();
                }

            }   else {
                    MessageBox.Show("Não é permitido valores negativos neste campo.");
                }
        }
    }
}
