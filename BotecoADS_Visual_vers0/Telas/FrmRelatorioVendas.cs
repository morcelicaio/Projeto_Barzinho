using BotecoADS_Visual_vers0.DAO;
using BotecoADS_Visual_vers0.Telas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotecoADS_Visual_vers0 {
    public partial class FrmRelatorioVendas : Form {        
        List<Venda> vendas = new List<Venda>();

        public FrmRelatorioVendas() {
            InitializeComponent();

            VendaDAO dao = new VendaDAO();
            this.vendas = dao.buscarVendas();         

            carregarTabelaDeVendasFinalizadas();
        }        

        public void carregarTabelaDeVendasFinalizadas() {
            foreach (Venda v in vendas) {
                if (v.HoraDeFechaVenda != "") { // só vendas finalizadas tem a hora da venda setada.
                    dgvListarVendas.Rows.Add(v.CodigoDaVenda, v.CodigoDaMesa, v.DataDaVenda, v.HoraDeAbreVenda,
                                                              v.HoraDeFechaVenda, v.ValorTotalVenda.ToString("c")
                                            );       
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void dgvListarVendas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            int indice = e.RowIndex; //pegando o índice da célula que foi clicada 2 vezes.
            int codVenda, codMesa;

            if(indice >= 0) {                
                codVenda = Convert.ToInt32(dgvListarVendas.CurrentRow.Cells[0].Value);//cód da venda da linha da tabela.
                codMesa = Convert.ToInt32(dgvListarVendas.CurrentRow.Cells[1].Value);//cód da venda da linha da tabela.                

                if (codVenda != 0) {
                    FrmItensDaVenda f = new FrmItensDaVenda(codVenda, codMesa);
                    f.StartPosition = FormStartPosition.CenterScreen; // centralizando o formulário na tela.
                    f.ShowDialog();

                }   else {
                    MessageBox.Show("Não foi possível realizar a operação.\n\n" +
                                     "Selecione uma venda para efetuar a consulta!");
                    }
            }            
        }
    }
}
