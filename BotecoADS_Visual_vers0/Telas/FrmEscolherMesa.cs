using BotecoADS_Visual_vers0.DAO;
using BotecoADS_Visual_vers0.Telas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmEscolherMesa : Form {               
        String estadoDaChamada = ""; // recebe o valor que chega pelo parâmetro do construtor.        

        List<MesaVisual> mesasVisuais = new List<MesaVisual>();
        List<Mesa> mesasDoBar;
        List<Venda> vendasAtivas;
        List<Venda> vendasFinalizadas;        

        public FrmEscolherMesa() {
            InitializeComponent();
        }

        //recebendo a informacao de qual formulário fez a chamada, todas as mesas do bar, quais vendas estão ativas 
                                                                            // e quais as vendas estão finalizadas
        public FrmEscolherMesa(String formQueChamou, List<Mesa> mesasDoBar, List<Venda> vendasAtivas, List<Venda> vendasFinalizadas) {
            InitializeComponent();   // ele inicializa todos os componentes do formulário (labels, painéis, etc..)

            this.mesasDoBar = mesasDoBar;  // pegando a referencia que veio do form menu
            this.vendasAtivas = vendasAtivas;
            this.vendasFinalizadas = vendasFinalizadas;

            estadoDaChamada = formQueChamou;   //Aqui recebe abrirVenda, fecharVenda, entregarPorcao ou vendasEmAberto.
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
            
            carregarMesas(estadoDaChamada); //carregando as mesas com seus componentes 
        }
           
        public void carregarMesas(string formQueChamou) {
                                    // nesse if  não está incluso o abrirVenda.  O abrirVenda está no else.
            if (formQueChamou == "fecharVenda" || formQueChamou == "entregarPorcao" || formQueChamou == "vendasEmAberto") {
                //Primeiro desabilita os componentes de todas as mesas.
                for (int i = 0; i < mesasVisuais.Count; i++) {
                    mesasVisuais[i].desabilitarComponentesDaMesaVisual();
                }

                //E depois muda os componentes das mesas ocupadas.
                for (int i = 0; i < mesasVisuais.Count; i++) {  
                    for (int j = 0; j < vendasAtivas.Count; j++) { //pegando a venda pertencente àquela mesa.
                        if (vendasAtivas[j].CodigoDaMesa == mesasVisuais[i].IdMesa) {
                            mesasVisuais[i].carregarComponentesParaMesasOcupadas();      // form = fecharVenda
                        }
                    }
                }

            }   else {   // aqui é no caso de ser abrirVenda
                                 
                    //primeiro habilita os componentes de todas as mesas.
                    for (int i = 0; i < mesasVisuais.Count; i++) {
                        mesasVisuais[i].carregarComponentesParaMesasLivres();
                    }

                    //E depois muda os componentes das mesas ocupadas.
                    for (int i = 0; i < mesasVisuais.Count; i++) {
                        for (int j = 0; j < vendasAtivas.Count; j++) {    //pegando a venda pertencente àquela mesa.
                            if (vendasAtivas[j].CodigoDaMesa == mesasVisuais[i].IdMesa) {
                                mesasVisuais[i].alterarEstadoDaMesa(formQueChamou);     // form = abrirVenda
                            }
                        }
                    }
            }           
        }        

        private void btnEscolherMesa1_Click(object sender, EventArgs e) {            
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 1;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();        //get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString();   //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);                    

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);
                                            
                    //Esse laço serve para recuperar o código da venda que acabou de ser aberta e setar dentro da lista.
                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == 1) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();                                                        
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[0].alterarEstadoDaMesa("abrirVenda");  // funcionando ok !
                    this.Close(); // fechando formulário atual
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 1) {   // pegando a venda desta mesa. 

                            //Agora recupera os itens dessa venda para verificar se ainda existe alguma porção nao entregue.
                            //Não pode deixar fechar uma venda se ainda existir porções sendo feitas na cozinha para a mesa.
                            List<ItensDaVenda> itensVenda = new List<ItensDaVenda>();
                            ItensDaVendaDAO itensDAO = new ItensDaVendaDAO();

                            itensVenda = itensDAO.buscarItensDeUmaVenda(vendasAtivas[i].CodigoDaVenda);
                            bool existePorcoesDaMesaNaCozinha = false;

                            //Percorrendo a lista de itens da venda para verificar se existe alguma porção não entregue.
                            for(int j = 0; j < itensVenda.Count; j++) {
                                if (itensVenda[j].HoraDaEntrega == "") {
                                    existePorcoesDaMesaNaCozinha = true;
                                    break;
                                }
                            }

                            if (!existePorcoesDaMesaNaCozinha) {
                                vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //setando a hora
                                vendasFinalizadas.Add(vendasAtivas[i]);

                                VendaDAO dao2 = new VendaDAO();     //Aqui só serve para alterar a hora em que a venda foi
                                dao2.alterarVenda(vendasAtivas[i]); //finalizada pq qdo abre a venda, ela ja é salva no banco.

                                vendasAtivas.Remove(vendasAtivas[i]); // removendo esta venda da lista de vendas ativas.                            
                                MessageBox.Show("Venda finalizada com sucesso!");
                                mesasVisuais[0].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                                this.Close();
                            }   else {
                                    MessageBox.Show("Não é possível fechar a venda. "+ 
                                                    "Existe alguma porção na cozinha que ainda não foi entregue "+
                                                    "para essa mesa no momento.");
                                }
                            
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 1;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;                
            }                 
        }

        private void btnEscolherMesa2_Click(object sender, EventArgs e) {            
            
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 2;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();//get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);                   

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);

                    for (int i = 0; i < vendasAtivas.Count; i++) {                        
                        if (vendasAtivas[i].CodigoDaMesa == 2) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();                            
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[1].alterarEstadoDaMesa("abrirVenda");
                    this.Close();
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 2) {   // pegando a venda desta mesa. 
                            
                            vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                            vendasFinalizadas.Add(vendasAtivas[i]);

                            VendaDAO dao2 = new VendaDAO();
                            dao2.alterarVenda(vendasAtivas[i]);

                            vendasAtivas.Remove(vendasAtivas[i]); // removendo a venda da lista de vendas ativas.                            
                            MessageBox.Show("Venda finalizada com sucesso!");
                            mesasVisuais[1].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                            this.Close();
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 2;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;
            }            
        }

        private void btnEscolherMesa3_Click(object sender, EventArgs e) {
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 3;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();//get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);

                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == 3) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[2].alterarEstadoDaMesa("abrirVenda");
                    this.Close();
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 3) {   // pegando a venda desta mesa. 

                            vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                            vendasFinalizadas.Add(vendasAtivas[i]);

                            VendaDAO dao2 = new VendaDAO();
                            dao2.alterarVenda(vendasAtivas[i]);

                            vendasAtivas.Remove(vendasAtivas[i]); // removendo a venda da lista de vendas ativas.                            
                            MessageBox.Show("Venda finalizada com sucesso!");
                            mesasVisuais[2].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                            this.Close();
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 3;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;
            }
        }

        private void btnEscolherMesa4_Click(object sender, EventArgs e) {
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 4;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();//get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);

                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == 4) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[3].alterarEstadoDaMesa("abrirVenda");
                    this.Close();
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 4) {   // pegando a venda desta mesa. 

                            vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                            vendasFinalizadas.Add(vendasAtivas[i]);

                            VendaDAO dao2 = new VendaDAO();
                            dao2.alterarVenda(vendasAtivas[i]);

                            vendasAtivas.Remove(vendasAtivas[i]); // removendo a venda da lista de vendas ativas.                            
                            MessageBox.Show("Venda finalizada com sucesso!");
                            mesasVisuais[3].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                            this.Close();
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 4;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;
            }
        }

        private void btnEscolherMesa5_Click(object sender, EventArgs e) {
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 5;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();//get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);

                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == 5) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[3].alterarEstadoDaMesa("abrirVenda");
                    this.Close();
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 5) {   // pegando a venda desta mesa. 

                            vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                            vendasFinalizadas.Add(vendasAtivas[i]);

                            VendaDAO dao2 = new VendaDAO();
                            dao2.alterarVenda(vendasAtivas[i]);

                            vendasAtivas.Remove(vendasAtivas[i]); // removendo a venda da lista de vendas ativas.                            
                            MessageBox.Show("Venda finalizada com sucesso!");
                            mesasVisuais[4].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                            this.Close();
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 5;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;
            }
        }

        private void btnEscolherMesa6_Click(object sender, EventArgs e) {
            switch (estadoDaChamada) {
                case "abrirVenda":
                    Venda v = new Venda();
                    v.CodigoDaMesa = 6;
                    v.DataDaVenda = DateTime.Now.ToShortDateString();//get somente na data
                    v.HoraDeAbreVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                    v.ValorTotalVenda = 0;

                    vendasAtivas.Add(v);

                    VendaDAO dao = new VendaDAO();
                    dao.cadastrarVenda(v);

                    for (int i = 0; i < vendasAtivas.Count; i++) {
                        if (vendasAtivas[i].CodigoDaMesa == 6) {
                            vendasAtivas[i].CodigoDaVenda = dao.buscarCodigoDaVenda();
                            break; // saindo dessa estrutura for.
                        }
                    }

                    MessageBox.Show("Venda aberta com sucesso!");
                    mesasVisuais[3].alterarEstadoDaMesa("abrirVenda");
                    this.Close();
                    break; // saindo do case.

                case "fecharVenda":
                    for (int i = 0; i < vendasAtivas.Count; i++) { // percorrendo a lista das vendas ativas.
                        if (vendasAtivas[i].CodigoDaMesa == 6) {   // pegando a venda desta mesa. 

                            vendasAtivas[i].HoraDeFechaVenda = DateTime.Now.ToShortTimeString(); //get somente na hora.
                            vendasFinalizadas.Add(vendasAtivas[i]);

                            VendaDAO dao2 = new VendaDAO();
                            dao2.alterarVenda(vendasAtivas[i]);

                            vendasAtivas.Remove(vendasAtivas[i]); // removendo a venda da lista de vendas ativas.                            
                            MessageBox.Show("Venda finalizada com sucesso!");
                            mesasVisuais[5].alterarEstadoDaMesa("fecharVenda"); //deixando a mesa livre novamente.
                            this.Close();
                        }
                    }
                    break; // saindo do case.

                case "vendasEmAberto":
                    int codigoMesa = 6;
                    FrmItensDaVenda f = new FrmItensDaVenda(vendasAtivas, codigoMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();
                    break;               
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}