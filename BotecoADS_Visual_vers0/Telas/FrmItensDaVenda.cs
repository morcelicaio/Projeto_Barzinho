using BotecoADS_Visual_vers0.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0.Telas {
    public partial class FrmItensDaVenda : Form {
        int codMesa, codVenda;
        List<Venda> vendasAtivas = new List<Venda>();
        List<ItensDaVenda> itensDaVenda = new List<ItensDaVenda>();
        List<Produto> produtos = new List<Produto>();
        List<Produto> porcoes = new List<Produto>();
        List<Venda> vendasFinalizadasBD = new List<Venda>(); // vem do frm relatorioVendas
        
        public FrmItensDaVenda() {
            InitializeComponent();
        }

        public FrmItensDaVenda(int codVenda, int codMesa) {   // construtor que carrega apenas as vendas que ja foram fechadas
            InitializeComponent();
            this.codVenda = codVenda;
            this.codMesa = codMesa;

            VendaDAO dao = new VendaDAO();
            this.vendasFinalizadasBD = dao.buscarVendas();            

            ProdutoDAO dao2 = new ProdutoDAO();
            produtos = dao2.buscarProdutos(); // preenchendo a lista com a busca feita no bd.            
            porcoes = dao2.buscarPorcoes();

            carregarItensVendaDaMesa("apenasVendasFinalizadas");
        }

            //construtor que está buscando apenas nas vendas ativas(abertas).
        public FrmItensDaVenda(List<Venda> vendasAtivas, int codigoMesa) {
            InitializeComponent();

            this.codMesa = codigoMesa;
            this.vendasAtivas = vendasAtivas;

            ProdutoDAO dao = new ProdutoDAO();
            produtos = dao.buscarProdutos(); // preenchendo a lista com a busca feita no bd.
            porcoes = dao.buscarPorcoes();

            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (vendasAtivas[i].CodigoDaMesa == codMesa) {
                    codVenda = vendasAtivas[i].CodigoDaVenda;  //pegando o cod dessa venda para setar la na tabela depois.
                }
            }

            carregarItensVendaDaMesa("apenasVendasAbertas");
        }


        public void carregarItensVendaDaMesa(string tipoDaConsulta) {
            switch (tipoDaConsulta) {
                case "apenasVendasAbertas":
                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == codMesa) { //pegando esta venda da lista de vendas ativas
                                                                       //executa todos os comandos e depois da o break.                    
                            ItensDaVendaDAO dao = new ItensDaVendaDAO();
                            itensDaVenda = dao.buscarItensDeUmaVenda(codVenda);

                            foreach (ItensDaVenda item in itensDaVenda) {
                                String nomeProduto = "";
                                double valorUnitario = 0;
                                //um produto comum tem o pedido entregue na hora. Entao a horaPedido é = a da horaEntrega
                                if (item.HoraDoPedido.Equals(item.HoraDaEntrega)) {
                                    for (int k = 0; k < produtos.Count; k++) { //percorrendo a lista de produtos para recuperar o nome
                                                                               // e o valor unitário do produto para setar na tabela
                                        if (produtos[k].CodigoProduto == item.CodigoProduto) {
                                            nomeProduto = produtos[k].NomeDoProduto;
                                            valorUnitario = produtos[k].ValorUnitarioDoProduto;
                                            break;
                                        }

                                    }

                                    dgvItensDaVenda.Rows.Add(codVenda, codMesa, "Comum", nomeProduto, item.QtdeConsumida, valorUnitario.ToString("c"));

                                }   else {
                                        for (int k = 0; k < porcoes.Count; k++) { //percorrendo a lista de produtos para recuperar o nome
                                                                                   // e o valor unitário do produto para setar na tabela
                                            if (porcoes[k].CodigoProduto == item.CodigoProduto) {
                                                nomeProduto = porcoes[k].NomeDoProduto;
                                                valorUnitario = porcoes[k].ValorUnitarioDoProduto;
                                                break;
                                            }
                                        }

                                        dgvItensDaVenda.Rows.Add(codVenda, codMesa, "Porção", nomeProduto, item.QtdeConsumida, valorUnitario.ToString("c"));
                                    }
                            }

                            break;  //saindo da estrutura for.
                        }
                    }

                break;

                case "apenasVendasFinalizadas":
                    for (int i = 0; i < vendasFinalizadasBD.Count; i++) {
                        if (vendasFinalizadasBD[i].CodigoDaVenda == codVenda) { //pegando a venda com o codigo vindo
                                                                                // da tabela do frm anterior a esse.                    
                            ItensDaVendaDAO dao = new ItensDaVendaDAO();
                            itensDaVenda = dao.buscarItensDeUmaVenda(codVenda);

                            foreach (ItensDaVenda item in itensDaVenda) {                                
                                String nomeProduto = "";
                                double valorUnitario = 0;
                                //um produto comum tem o pedido entregue na hora. Entao a horaPedido é = a da horaEntrega
                                if (item.HoraDoPedido.Equals(item.HoraDaEntrega)) {
                                    for (int k = 0; k < produtos.Count; k++) { //percorrendo a lista de produtos para recuperar o nome
                                                                               // e o valor unitário do produto para setar na tabela
                                        if (produtos[k].CodigoProduto == item.CodigoProduto) {
                                            nomeProduto = produtos[k].NomeDoProduto;
                                            valorUnitario = produtos[k].ValorUnitarioDoProduto;
                                            break;
                                        }

                                    }

                                    dgvItensDaVenda.Rows.Add(codVenda, codMesa, "Comum", nomeProduto, item.QtdeConsumida, valorUnitario.ToString("c"));

                                }   else {
                                        for (int k = 0; k < porcoes.Count; k++) { //percorrendo a lista de produtos para recuperar o nome
                                                                              // e o valor unitário do produto para setar na tabela
                                            if (porcoes[k].CodigoProduto == item.CodigoProduto) {
                                                nomeProduto = porcoes[k].NomeDoProduto;
                                                valorUnitario = porcoes[k].ValorUnitarioDoProduto;
                                                break;
                                            }

                                        }

                                        dgvItensDaVenda.Rows.Add(codVenda, codMesa, "Porção", nomeProduto, item.QtdeConsumida, valorUnitario.ToString("c"));
                                    }
                            }

                            break;  //saindo da estrutura for.
                        }
                    }

                break;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
