using BotecoADS_Visual_vers0.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmInserirProdVenda : Form {
        private List<Produto> produtos = new List<Produto>();                

        List<MesaVisual> mesasVisuais = new List<MesaVisual>();        
        List<Venda> vendasAtivas;        

        public FrmInserirProdVenda() {
            InitializeComponent();
        }

        public FrmInserirProdVenda(List<Mesa> mesasDoBar, List<Venda> vendasAtivas) {
            InitializeComponent();   // ele inicializa todos os componentes do formulário (labels, painéis, etc..)
            
            this.vendasAtivas = vendasAtivas; // pegando a referencia que veio do form menu                                    

            // Criando as mesas visuais para trabalhar com os elementos do formulário: buttons, labels etc..
            MesaVisual mv1 = new MesaVisual();
            mv1.IdMesa = 1;
            mv1.NroMesa = lbMesa1;
            mv1.IsMesaDisponivel = lbMesaOcupacao; // todos deste label estão visible false no formulário.
            mv1.PainelMesa = panelMesa1;
            mv1.BotaoMesa = btnMesa1;

            mesasVisuais.Add(mv1);

            MesaVisual mv2 = new MesaVisual();
            mv2.IdMesa = 2;
            mv2.NroMesa = lbMesa2;
            mv2.IsMesaDisponivel = lbMesaOcupacao;
            mv2.PainelMesa = panelMesa2;
            mv2.BotaoMesa = btnMesa2;

            mesasVisuais.Add(mv2);

            MesaVisual mv3 = new MesaVisual();
            mv3.IdMesa = 3;
            mv3.NroMesa = lbMesa3;
            mv3.IsMesaDisponivel = lbMesaOcupacao;
            mv3.PainelMesa = panelMesa3;
            mv3.BotaoMesa = btnMesa3;

            mesasVisuais.Add(mv3);

            MesaVisual mv4 = new MesaVisual();
            mv4.IdMesa = 4;
            mv4.NroMesa = lbMesa4;
            mv4.IsMesaDisponivel = lbMesaOcupacao;
            mv4.PainelMesa = panelMesa4;
            mv4.BotaoMesa = btnMesa4;

            mesasVisuais.Add(mv4);

            MesaVisual mv5 = new MesaVisual();
            mv5.IdMesa = 5;
            mv5.NroMesa = lbMesa5;
            mv5.IsMesaDisponivel = lbMesaOcupacao;
            mv5.PainelMesa = panelMesa5;
            mv5.BotaoMesa = btnMesa5;
            
            mesasVisuais.Add(mv5);

            MesaVisual mv6 = new MesaVisual();
            mv6.IdMesa = 6;
            mv6.NroMesa = lbMesa6;
            mv6.IsMesaDisponivel = lbMesaOcupacao;
            mv6.PainelMesa = panelMesa6;
            mv6.BotaoMesa = btnMesa6;

            mesasVisuais.Add(mv6);

            tfQtd.Enabled = false;
            carregarMesasDesabilitadas(); // carrega as mesas no seu estado correto (abertas ou fechadas), porém desabilitadas.                                               
        }

        public void carregarMesasHabilitadas() {
                //Mudando os componentes das mesas ocupadas.
            for (int i = 0; i < mesasVisuais.Count; i++) {
                for (int j = 0; j < vendasAtivas.Count; j++) { //pegando a venda pertencente àquela mesa.
                    if (vendasAtivas[j].CodigoDaMesa == mesasVisuais[i].IdMesa) {
                        mesasVisuais[i].carregarComponentesParaMesasOcupadas();
                    }
                }
            }
        }

        public void carregarMesasDesabilitadas() {            
            //Aqui, primeiro é mudado os componentes das mesas ocupadas.
            for (int i = 0; i < mesasVisuais.Count; i++) {
                for (int j = 0; j < vendasAtivas.Count; j++) { //pegando a venda pertencente àquela mesa.
                    if (vendasAtivas[j].CodigoDaMesa == mesasVisuais[i].IdMesa) {
                        mesasVisuais[i].carregarComponentesParaMesasOcupadas();
                    }
                }
            }

            //Depois desabilita os componentes de todas as mesas e só habilita depois de inseridos os dados nos campos do form.
            for (int i = 0; i < mesasVisuais.Count; i++) {
                mesasVisuais[i].desabilitarComponentesDaMesaVisual();
            }
        }        

        public void carregarTabela() { // carregando a tabela com os produtos cadastrados.  
            ProdutoDAO dao = new ProdutoDAO();
            produtos = dao.buscarProdutos();            

            dgvListarProdutos.Columns[0].HeaderText = "Código"; //alterando o nome da coluna do dtgrid pelo indice   
            if (rbProduto.Checked) { //checando o radio button selecionado para carregar a tabela com o tipo do produto.
                dgvListarProdutos.Columns[1].HeaderText = "Nome do Produto";    //seta a string no índice da coluna.
                foreach (Produto p in produtos) {
                    if(p.TipoDoProduto.Equals("comum")) {
                        dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("N2"));
                    }                    
                }

            }   else {                    
                    dgvListarProdutos.Columns[1].HeaderText = "Nome da Porção";
                    foreach (Produto p in produtos) {
                        if (p.TipoDoProduto.Equals("porcao")) {
                            dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("N2"));
                        }
                    }
                }            
        }

        public void carregarTabelaEspecifica() { // busca os produtos apenas com as letras que o usuário digita
            List<Produto> produtosEspecificos = new List<Produto>();            

            ProdutoDAO dao = new ProdutoDAO();
            produtosEspecificos = dao.buscarProdutos(tfBuscarProduto.Text);            

            dgvListarProdutos.Rows.Clear();

            dgvListarProdutos.Columns[0].HeaderText = "Código"; //alterando o nome da coluna do dtgrid pelo indice
            if (rbProduto.Checked) {                   
                dgvListarProdutos.Columns[1].HeaderText = "Nome do Produto";                //da coluna.
                foreach (Produto p in produtosEspecificos) {
                    if (p.TipoDoProduto.Equals("comum")) {
                        dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("N2"));
                    }
                }

            }   else {                    
                    dgvListarProdutos.Columns[1].HeaderText = "Nome da Porção";
                    foreach (Produto p in produtosEspecificos) {
                        if (p.TipoDoProduto.Equals("comum")) {
                            dgvListarProdutos.Rows.Add(p.CodigoProduto, p.NomeDoProduto, p.QtdeProduto, p.ValorUnitarioDoProduto.ToString("N2"));
                        }
                    }
                }
        }
        
        private void btnMesa1_Click(object sender, EventArgs e) {           
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if (tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {                    
                    qtdeDesejada = 0;
                }
            
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);            
                
            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();                
                for (int i = 0; i < vendasAtivas.Count; i++) {        //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 1) {
                             //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));                        

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;   //seta o codigo da venda  no item da venda.
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                                    //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();                

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                item.HoraDoPedido = DateTime.Now.ToShortTimeString();//get somente na hora q pediu o prodott na mesa.

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";                                      
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.                    
                }   else {
                        p.TipoDoProduto = "porcao";                                                                                               
                        item.HoraDaEntrega = "";                        
                }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);  //alterando o valor do produto no estoque.  

                item.CodigoProduto = codProduto;   // código do produto que pegou da tabela.
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);                                                

                dgvListarProdutos.Rows.Clear();
                carregarTabela();                
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[0].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }                                    
        }

        private void btnMesa2_Click(object sender, EventArgs e) {
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if (tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {
                    qtdeDesejada = 0;
                }
            
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//pegando a qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();
                for (int i = 0; i < vendasAtivas.Count; i++) { //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 2) {
                        //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();                

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.
                }   else {
                        p.TipoDoProduto = "porcao";
                        item.HoraDaEntrega = "";
                    }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);

                item.CodigoProduto = codProduto;//codProduto;
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);

                dgvListarProdutos.Rows.Clear();
                carregarTabela();
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[1].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }
        }

        private void btnMesa3_Click(object sender, EventArgs e) {
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if(tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {
                    qtdeDesejada = 0;
                }
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//pegando a qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();
                for (int i = 0; i < vendasAtivas.Count; i++) { //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 3) {
                        //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.
                }   else {
                        p.TipoDoProduto = "porcao";
                        item.HoraDaEntrega = "";
                    }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);

                item.CodigoProduto = codProduto;//codProduto;
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);

                dgvListarProdutos.Rows.Clear();
                carregarTabela();
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[2].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }
        }

        private void btnMesa4_Click(object sender, EventArgs e) {
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if (tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {
                    qtdeDesejada = 0;
                }
            
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//pegando a qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();
                for (int i = 0; i < vendasAtivas.Count; i++) { //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 4) {
                        //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.
                }   else {
                        p.TipoDoProduto = "porcao";
                        item.HoraDaEntrega = "";
                    }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);

                item.CodigoProduto = codProduto;//codProduto;
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);

                dgvListarProdutos.Rows.Clear();
                carregarTabela();
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[3].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }
        }

        private void btnMesa5_Click(object sender, EventArgs e) {
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if (tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {
                    qtdeDesejada = 0;
                }
            
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//pegando a qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();
                for (int i = 0; i < vendasAtivas.Count; i++) { //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 5) {
                        //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.
                }   else {
                        p.TipoDoProduto = "porcao";
                        item.HoraDaEntrega = "";
                    }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);

                item.CodigoProduto = codProduto;//codProduto;
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);

                dgvListarProdutos.Rows.Clear();
                carregarTabela();
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[4].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }
        }

        private void btnMesa6_Click(object sender, EventArgs e) {
            int qtdeDesejada, qtdEstoque, codProduto;
            double precoProduto;

            if (tfQtd.TextLength > 0) {
                qtdeDesejada = Convert.ToInt32(tfQtd.Text);
            }   else {
                    qtdeDesejada = 0;
                }
            
            qtdEstoque = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[2].Value);//pegando a qtd do produto da linha da tabela.
            precoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

            if (qtdeDesejada > 0 && qtdeDesejada <= qtdEstoque) {// verificando se o estoque do produto escolhido é válido
                qtdEstoque = (qtdEstoque - qtdeDesejada); // atualizando estoque

                ItensDaVenda item = new ItensDaVenda();
                for (int i = 0; i < vendasAtivas.Count; i++) { //pegando a venda desta mesa.
                    if (vendasAtivas[i].CodigoDaMesa == 6) {
                        //atualizando o valor total da venda.
                        vendasAtivas[i].ValorTotalVenda = (vendasAtivas[i].ValorTotalVenda + (qtdeDesejada * precoProduto));

                        item.CodigoVenda = vendasAtivas[i].CodigoDaVenda;
                        break;  // quando ele encontrar esta venda, aqui ele sai da estrutura for.
                    }
                }
                //pegando o codigo do produto direto da tabela
                codProduto = Convert.ToInt32(dgvListarProdutos.CurrentRow.Cells[0].Value);

                ItensDaVendaDAO itemdao = new ItensDaVendaDAO();

                Produto p = new Produto();
                p.CodigoProduto = codProduto; //usando o codProduto da tabela para setar no objeto.
                p.NomeDoProduto = dgvListarProdutos.CurrentRow.Cells[1].Value.ToString();
                p.QtdeProduto = qtdEstoque;
                p.ValorUnitarioDoProduto = Convert.ToDouble(dgvListarProdutos.CurrentRow.Cells[3].Value);

                if (rbProduto.Checked) {
                    p.TipoDoProduto = "comum";
                    item.HoraDaEntrega = DateTime.Now.ToShortTimeString();//get somente na hora q entregou o prodt na mesa.
                }   else {
                        p.TipoDoProduto = "porcao";
                        item.HoraDaEntrega = "";
                    }

                ProdutoDAO dao = new ProdutoDAO();
                dao.alterarProduto(p);

                item.CodigoProduto = codProduto;//codProduto;
                item.QtdeConsumida = Convert.ToInt32(tfQtd.Text);
                item.HoraDoPedido = DateTime.Now.ToShortTimeString(); //get somente na hora          
                itemdao.cadastrarItemDaVenda(item);

                dgvListarProdutos.Rows.Clear();
                carregarTabela();
                dgvListarProdutos.ClearSelection();  // deixando a tabela sem nenhuma linha selecionada 
                tfQtd.Clear();
                tfQtd.Enabled = false;

                MessageBox.Show("O produto foi inserido na venda!");

                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

            }   else {
                    MessageBox.Show("Estoque insuficiente para esta quantidade do produto.");
                    mesasVisuais[5].desabilitarComponentesDaMesaVisual();
                    tfQtd.Clear();
                }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Close();
        }

                //DAQUI PRA BAIXO É TUDO EVENTOS DOS COMPONENTES.
        private void tfBuscarProduto_KeyUp(object sender, KeyEventArgs e) {
            carregarTabelaEspecifica(); // busca os produtos apenas com as letras que o usuário digita
        }

        private void tfBuscarProduto_MouseClick(object sender, MouseEventArgs e) {
            tfBuscarProduto.Clear();
        }

            //evento de quando se solta a tecla pressionada
        private void tfQtd_KeyUp(object sender, KeyEventArgs e) {            
            if (tfQtd.Text.Equals("")) {
                for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }
            }

            if (Char.IsDigit(Convert.ToChar(e.KeyValue))) { // se o caracter digitado for um número ele entra.
                e.Handled = false; //permitindo aparecer o caracter digitado no textbox

                if(tfQtd.Text.Equals("0")) { // fazendo validação se inserir 0 no campo de quantidade pedida. 
                    MessageBox.Show("Insira apenas números maiores que 0 ou menores que o estoque do produto!");
                    tfQtd.Clear();
                }   else {
                        carregarMesasHabilitadas();
                    }                   

            }   else {
                    MessageBox.Show("Não é permitido letras neste campo.");
                    tfQtd.Clear(); // se nao for um dígito o campo é esvaziado.
                    for (int i = 0; i < mesasVisuais.Count; i++) { //deixando todas as mesas com os botoes desabilitados
                        mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                    }
                }           
        } 

        private void dgvListarProdutos_CellClick(object sender, DataGridViewCellEventArgs e) {
            tfQtd.Enabled = true;
        }

        private void rbProduto_MouseClick(object sender, MouseEventArgs e) {
            dgvListarProdutos.Rows.Clear();
            carregarTabela();
        }

        private void rbPorcao_MouseClick(object sender, MouseEventArgs e) {
            dgvListarProdutos.Rows.Clear();
            carregarTabela();
        }
    }
}
