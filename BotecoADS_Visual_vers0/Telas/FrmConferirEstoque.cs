using BotecoADS_Visual_vers0.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmConferirEstoque : Form {
        private List<Produto> produtos = new List<Produto>();
        //private List<Porcao> porcoes = new List<Porcao>();

        public FrmConferirEstoque() {
            InitializeComponent();

            ProdutoDAO dao = new ProdutoDAO();
            produtos = dao.buscarProdutos(); // preenchendo a lista com a busca feita no bd.
            //porcoes = dao.buscarPorcoes();                        
        }

        public void carregarTabela() { // carregando a tabela com os produtos cadastrados.
            dgvListarProdutos.Columns[0].HeaderText = "Código"; //alterando o nome da coluna do datagrid pelo indice 

            if (rbProduto.Checked) {                                  
                dgvListarProdutos.Columns[1].HeaderText = "Nome do Produto";              
                foreach (Produto p in produtos) {
                    if (p.TipoDoProduto.Equals("comum")){
                        dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("c"));
                    }                    
                }   

            }   else {                    
                    dgvListarProdutos.Columns[1].HeaderText = "Nome da Porção";
                    foreach (Produto p in produtos) {
                        if (p.TipoDoProduto.Equals("porcao")) {
                            dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("c"));
                        }
                    }
                }
        }

        public void carregarTabelaEspecifica() { // busca os produtos apenas com as letras que o usuário digita
            List<Produto> produtosEspecificos = new List<Produto>();
            //List<Porcao> porcoesEspecificas = new List<Porcao>();

            ProdutoDAO dao = new ProdutoDAO();
            produtosEspecificos = dao.buscarProdutos(tfBuscarProduto.Text);
            //porcoesEspecificas = dao.buscarPorcoes(tfBuscarProduto.Text);

            dgvListarProdutos.Rows.Clear();

            dgvListarProdutos.Columns[0].HeaderText = "Código"; //alterando o nome da coluna do dtgrid pelo indice 
            if (rbProduto.Checked) {                  
                dgvListarProdutos.Columns[1].HeaderText = "Nome do Produto";                //da coluna.
                foreach (Produto p in produtosEspecificos) {
                    if (p.TipoDoProduto.Equals("comum")) {
                        dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("c"));
                    }                                        
                }

            }   else {                    
                    dgvListarProdutos.Columns[1].HeaderText = "Nome da Porção";
                    foreach (Produto p in produtosEspecificos) {
                        if (p.TipoDoProduto.Equals("porcao")) {
                            dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("c"));
                        }                    
                    }
                }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Close();
        }
                    //eventos do text field
        private void tfBuscarProduto_KeyUp(object sender, KeyEventArgs e) {
            // busca os produtos apenas com as letras que o usuário digita
            carregarTabelaEspecifica();
        }

        private void tfBuscarProduto_MouseClick(object sender, MouseEventArgs e) {
            tfBuscarProduto.Clear();
        }

        // evento do clique no radioButton Produto Comum
        private void rbProduto_MouseClick(object sender, MouseEventArgs e) {
            dgvListarProdutos.Rows.Clear();
            carregarTabela();
        }

        // evento do clique no radioButton Porção
        private void rbPorcao_MouseClick(object sender, MouseEventArgs e) {
            dgvListarProdutos.Rows.Clear();
            carregarTabela();
        }
    }
}
