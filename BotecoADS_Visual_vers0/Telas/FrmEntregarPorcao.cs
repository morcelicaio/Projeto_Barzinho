using BotecoADS_Visual_vers0.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0.Telas {
    public partial class FrmEntregarPorcao : Form {
        private int nroMesa;

        List<MesaVisual> mesasVisuais = new List<MesaVisual>();
        List<Venda> vendasAtivas;        

        public FrmEntregarPorcao() {
            InitializeComponent();
        }

        public FrmEntregarPorcao(List<Venda> vendasAtivas ) {
            InitializeComponent();
            this.vendasAtivas = vendasAtivas;            

            // Criando as mesas visuais para trabalhar com os elementos do formulário: buttons, labels etc..
            MesaVisual mv1 = new MesaVisual();
            mv1.IdMesa = 1;
            mv1.NroMesa = lbMesa1;
            mv1.IsMesaDisponivel = lbMesa1Ocupacao;
            mv1.PainelMesa = panelMesa1;
            mv1.BotaoMesa = btnEscolherMesa1;

            mesasVisuais.Add(mv1);

            MesaVisual mv2 = new MesaVisual();
            mv2.IdMesa = 2;
            mv2.NroMesa = lbMesa2;
            mv2.IsMesaDisponivel = lbMesa2Ocupacao;
            mv2.PainelMesa = panelMesa2;
            mv2.BotaoMesa = btnEscolherMesa2;

            mesasVisuais.Add(mv2);

            MesaVisual mv3 = new MesaVisual();
            mv3.IdMesa = 3;
            mv3.NroMesa = lbMesa3;
            mv3.IsMesaDisponivel = lbMesa3Ocupacao;
            mv3.PainelMesa = panelMesa3;
            mv3.BotaoMesa = btnEscolherMesa3;

            mesasVisuais.Add(mv3);

            MesaVisual mv4 = new MesaVisual();
            mv4.IdMesa = 4;
            mv4.NroMesa = lbMesa4;
            mv4.IsMesaDisponivel = lbMesa4Ocupacao;
            mv4.PainelMesa = panelMesa4;
            mv4.BotaoMesa = btnEscolherMesa4;

            mesasVisuais.Add(mv4);

            MesaVisual mv5 = new MesaVisual();
            mv5.IdMesa = 5;
            mv5.NroMesa = lbMesa5;
            mv5.IsMesaDisponivel = lbMesa5Ocupacao;
            mv5.PainelMesa = panelMesa5;
            mv5.BotaoMesa = btnEscolherMesa5;

            mesasVisuais.Add(mv5);

            MesaVisual mv6 = new MesaVisual();
            mv6.IdMesa = 6;
            mv6.NroMesa = lbMesa6;
            mv6.IsMesaDisponivel = lbMesa6Ocupacao;
            mv6.PainelMesa = panelMesa6;
            mv6.BotaoMesa = btnEscolherMesa6;

            mesasVisuais.Add(mv6);

            carregarMesas(); //carregando as mesas com seus componentes 

            dgvListarPorcoes.Enabled = false;            
            btnConfirmarEntrega.Enabled = false;
        }

        public void carregarMesas() {
                //Primeiro desabilita os componentes de todas as mesas.
                for (int i = 0; i < mesasVisuais.Count; i++) {
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

                //E depois muda os componentes das mesas ocupadas.
                for (int i = 0; i < mesasVisuais.Count; i++) {
                    for (int j = 0; j < vendasAtivas.Count; j++) { //pegando a venda pertencente àquela mesa.
                        if (vendasAtivas[j].CodigoDaMesa == mesasVisuais[i].IdMesa) {
                            mesasVisuais[i].carregarComponentesParaMesasOcupadas();
                        }
                    }
                }            
        }

        public void carregarPorcoesParaEntregarDaMesa(int nroMesa) {
            string nomePorcao;     double valorUnitario;

            List<ItensDaVenda> itensDaVenda = new List<ItensDaVenda>();
            List<Produto> porcoes = new List<Produto>();

            ProdutoDAO dao2 = new ProdutoDAO();
            porcoes = dao2.buscarPorcoes();
            
            ItensDaVendaDAO dao = new ItensDaVendaDAO();
                       
            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (vendasAtivas[i].CodigoDaMesa == nroMesa) {  //pegando a venda desta mesa.
                    itensDaVenda = dao.buscarItensDeUmaVenda(vendasAtivas[i].CodigoDaVenda);

                    for (int j = 0; j < itensDaVenda.Count; j++) { // verificando quais produtos são desta venda.
                        if (vendasAtivas[i].CodigoDaVenda == itensDaVenda[j].CodigoVenda) {
                            if (itensDaVenda[j].HoraDaEntrega == "") { //verificando se é o produto é uma porção.

                                for (int k = 0; k < porcoes.Count; k++) { // pegando o nome e o valor unitário desta porção
                                    if (porcoes[k].CodigoProduto == itensDaVenda[j].CodigoProduto) {
                                        nomePorcao = porcoes[k].NomeDoProduto;
                                        valorUnitario = porcoes[k].ValorUnitarioDoProduto;

                                        dgvListarPorcoes.Rows.Add(itensDaVenda[j].CodigoProduto, nomePorcao, itensDaVenda[j].QtdeConsumida, valorUnitario.ToString("c"));
                                        //aqui adiciono na linha da tabela                                        
                                    }
                                }

                            }
                        }
                    }

                    break;
                }
            }            
        }        

        private void btnVoltar_Click_1(object sender, EventArgs e) {
            this.Close();
        }

        private void btnEscolherMesa1_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 1;
            carregarPorcoesParaEntregarDaMesa(nroMesa);
            dgvListarPorcoes.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa1.Enabled = false;
            }   else {                    
                    dgvListarPorcoes.Enabled = true;
                    dgvListarPorcoes.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada
                    btnConfirmarEntrega.Enabled = false;
                }
        }

        private void btnEscolherMesa2_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 2;
            carregarPorcoesParaEntregarDaMesa(nroMesa);

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa2.Enabled = false;
            }   else {
                    dgvListarPorcoes.Enabled = true;
                    btnConfirmarEntrega.Enabled = true;
                }
        }

        private void btnEscolherMesa3_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 3;
            carregarPorcoesParaEntregarDaMesa(nroMesa);

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa3.Enabled = false;
            }   else {
                    dgvListarPorcoes.Enabled = true;
                    btnConfirmarEntrega.Enabled = true;
                }
        }

        private void btnEscolherMesa4_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 4;
            carregarPorcoesParaEntregarDaMesa(nroMesa);

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa4.Enabled = false;
            }   else {
                    dgvListarPorcoes.Enabled = true;
                    btnConfirmarEntrega.Enabled = true;
                }
        }

        private void btnEscolherMesa5_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 5;
            carregarPorcoesParaEntregarDaMesa(nroMesa);

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa5.Enabled = false;
            }   else {
                    dgvListarPorcoes.Enabled = true;
                    btnConfirmarEntrega.Enabled = true;
                }
        }

        private void btnEscolherMesa6_Click(object sender, EventArgs e) {
            dgvListarPorcoes.Rows.Clear();
            nroMesa = 6;
            carregarPorcoesParaEntregarDaMesa(nroMesa);

            if (dgvListarPorcoes.RowCount == 0) {
                MessageBox.Show("Não existem porções na cozinha para esta mesa!\nFaça o pedido da porção antes!");
                btnEscolherMesa6.Enabled = false;
            }   else {
                    dgvListarPorcoes.Enabled = true;
                    btnConfirmarEntrega.Enabled = true;
                }
        }
        
        // OK                                         
        private void btnConfirmarEntrega_Click(object sender, EventArgs e) {
            int codPorcao;
            codPorcao = Convert.ToInt32(dgvListarPorcoes.CurrentRow.Cells[0].Value);//codigo da porcao da linha da tabela.

            List<ItensDaVenda> itensDaVenda = new List<ItensDaVenda>();
            ItensDaVendaDAO dao = new ItensDaVendaDAO();

            for (int i = 0; i < vendasAtivas.Count; i++) {
                if (vendasAtivas[i].CodigoDaMesa == nroMesa) { //pegando a venda desta mesa.
                    itensDaVenda = dao.buscarItensDeUmaVenda(vendasAtivas[i].CodigoDaVenda);

                    for (int j = 0; j < itensDaVenda.Count; j++) { //pegando o item correto da venda para alterar
                        if (itensDaVenda[j].CodigoProduto == codPorcao) { //se for igual ao codigo da porcao que vem da tabela.
                            itensDaVenda[j].HoraDaEntrega = DateTime.Now.ToShortTimeString();//setando a hr de entrega da porcao. 
                                                                                  
                            dao.alterarItemDaVenda(itensDaVenda[j], itensDaVenda[j].CodigoVenda, codPorcao); //alterando a hr de entrega da porcao.
                            MessageBox.Show("A porção foi entregue!");

                            dgvListarPorcoes.Rows.Clear();
                            //dgvListarPorcoes.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada
                            btnConfirmarEntrega.Enabled = false; // desabilitando o botao de confirmar entrega.
                            carregarPorcoesParaEntregarDaMesa(nroMesa);
                            break; //sai da segunda estrutura for
                        }                                             
                    }

                    break;     //sai da primeira estrutura for
                }                
            }                
        }

        private void dgvListarPorcoes_CellClick(object sender, DataGridViewCellEventArgs e) {
            int codPorcao;
            codPorcao = Convert.ToInt32(dgvListarPorcoes.CurrentRow.Cells[0].Value);//codigo da porcao da linha da tabela.

            if(codPorcao > 0) {
                btnConfirmarEntrega.Enabled = true;
            }
        }
    }
}
