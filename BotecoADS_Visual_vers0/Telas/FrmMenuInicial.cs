using BotecoADS_Visual_vers0.DAO;
using BotecoADS_Visual_vers0.Telas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmMenuInicial : Form {        
        private List<Mesa> mesasDoBar;
        private List<Venda> vendasAtivas;  // quando se abre uma venda ela se torna uma venda ativa.  
        private List<Venda> vendasFinalizadas;  // qdo se fecha 1 venda ela deixa de ser ativa e vira uma venda finalizada.          

        GerenciaBar gerencia = new GerenciaBar(); //classe auxiliar                
        
        public FrmMenuInicial() {
            InitializeComponent();        //Ele inicializa todos os componentes do formulário (labels, painéis, etc..)
                            
            gerencia.criarMesas();       //Deixando as mesas do bar criadas a partir do menu inicial.            
            this.mesasDoBar = gerencia.MesasDoBar;      // pega todas as mesas do bar independe de mesa livre ou ocupada
            this.vendasAtivas = gerencia.VendasAtivas;  
            this.vendasFinalizadas = gerencia.VendasFinalizadas;            

            new CriaBancoDeDadosDAO().criarBancoDeDados(); //criando banco de dados se não houver ainda.                
        }
                       
        private void btnCadastrarProduto_Click(object sender, EventArgs e) {
            FrmCadastrarProduto f = new FrmCadastrarProduto();
            f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
            f.ShowDialog();                        
        }

        private void btnConferirEstoque_Click(object sender, EventArgs e) {
            FrmConferirEstoque f = new FrmConferirEstoque();
            f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
            f.ShowDialog();
        }        

        private void btnGerarRelatorioVendas_Click(object sender, EventArgs e) {
            FrmRelatorioVendas f = new FrmRelatorioVendas();
            f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
            f.ShowDialog();
        }

        private void btnAbrirVenda_Click(object sender, EventArgs e) {
            String abrirVenda = "abrirVenda"; // passando uma string como parâmetro para ser validada 
                                              // no construtor do form. FrmAbrirVenda.
            FrmEscolherMesa f = new FrmEscolherMesa(abrirVenda, mesasDoBar, vendasAtivas, vendasFinalizadas);
            f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
            f.ShowDialog();
                          //depois que clica no botao voltar do fmrEscolherMesa  vem para a linha de baixo do codigo.              
        }

        private void btnInserirNaVenda_Click(object sender, EventArgs e) {
            if (vendasAtivas.Count > 0) {
                FrmInserirProdVenda f = new FrmInserirProdVenda(mesasDoBar, vendasAtivas);
                f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                f.ShowDialog();
            }   else {
                    MessageBox.Show("Não existe nenhuma venda ativa no momento.\n\n"  +
                                    "É necessário ter uma venda aberta para realizar esta operação.");
                }
        }

        private void btnFecharVenda_Click(object sender, EventArgs e) {
            if (vendasAtivas.Count > 0) {
                String fecharVenda = "fecharVenda"; // passando uma string como parâmetro para ser validada 
                                                    // no construtor do form. FrmEscolherMesa.
                FrmEscolherMesa f = new FrmEscolherMesa(fecharVenda, mesasDoBar, vendasAtivas, vendasFinalizadas);
                f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                f.ShowDialog();
            }   else {
                    MessageBox.Show("Não existe nenhuma venda ativa no momento.\n\n"  +
                                "É necessário ter uma venda aberta para realizar esta operação.");
                }
        }

        private void btnEntregarPorcao_Click(object sender, EventArgs e) {
            if (vendasAtivas.Count > 0) {
                FrmEntregarPorcao f = new FrmEntregarPorcao(vendasAtivas);
                f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                f.ShowDialog();
            }   else {
                    MessageBox.Show("Não existe nenhuma venda ativa no momento.\n\n" +
                            "É necessário ter uma venda aberta para realizar esta operação.");
                }
        }

        private void btnVendasAtivas_Click(object sender, EventArgs e) {
            String vendasEmAberto = "vendasEmAberto"; // passando uma string como parâmetro para ser validada 
                                                      // no construtor do form. FrmEscolherMesa.
            if (vendasAtivas.Count > 0) {
                FrmEscolherMesa f = new FrmEscolherMesa(vendasEmAberto, mesasDoBar, vendasAtivas, vendasFinalizadas);
                f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                f.ShowDialog();
            }   else {
                    MessageBox.Show("Não existe nenhuma venda aberta no momento.\n\n" +
                                    "É necessário ter uma venda aberta para realizar esta operação.");
                }
        }

        private void btnSair_Click(object sender, EventArgs e) {
            if(vendasAtivas.Count == 0) {
                this.Dispose();
            }   else {
                    MessageBox.Show("Não é possível fechar o bar com vendas abertas.\n\n" +
                                "É necessário finalizar todas as vendas antes do encerramento!");
                }                
        }
    }
}