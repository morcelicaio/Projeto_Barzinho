using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace BotecoADS_Visual_vers0.DAO {
    public class ItensDaVendaDAO {
        private SQLiteConnection conn;

        public ItensDaVendaDAO() {
            conn = new Conexao().criarConexao(); // criando uma conexão com o banco de dados.
        }

        public void cadastrarItemDaVenda(ItensDaVenda item) {
            try {
                // verificando se o estado da conexão é fechado no momento.
                if (conn.State == ConnectionState.Closed) {
                    conn.Open(); // se o estado é fechado, aqui se abre a conexão com o banco de dados.

                    // criando um comando sql(cmd) para ser executado e passando a conexão para o objeto command (cmd)
                    SQLiteCommand cmd = new SQLiteCommand(
                        "INSERT INTO ItensDaVenda (codVenda, codProduto, qtdConsumida, horaPedido, horaEntrega)" +
                        "VALUES (@codVenda, @codProduto, @qtdConsumida, @horaPedido, @horaEntrega)", conn
                    );                   

                    //Tratando a parte de segurança (SQL Injection)
                    //Esta linha ñ permite que um possível comando sql colocado 
                    //no textField da tela seja executado no banco de dados.
                    cmd.Parameters.AddWithValue("codVenda", item.CodigoVenda);
                    cmd.Parameters.AddWithValue("codProduto", item.CodigoProduto);
                    cmd.Parameters.AddWithValue("qtdConsumida", item.QtdeConsumida);
                    cmd.Parameters.AddWithValue("horaPedido", item.HoraDoPedido);
                    cmd.Parameters.AddWithValue("horaEntrega", item.HoraDaEntrega);

                    cmd.ExecuteNonQuery(); // executando a operação de INSERT no banco
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no cadastro do item da venda. " + e.Message);
                }   finally {
                        conn.Close(); //fechando a consulta com o banco de dados
                    }
        }

        //Aqui eu estou usando para setar a hora da entrega da porção!
        public void alterarItemDaVenda(ItensDaVenda v,  int codigoVenda, int codPorcao) {
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                                               
                    SQLiteCommand cmd = new SQLiteCommand(
                        "UPDATE ItensDaVenda " +
                        "SET codVenda= @codVenda, codProduto= @codProduto, qtdConsumida= @qtdConsumida, horaPedido= @horaPedido, horaEntrega= @horaEntrega " +
                        "WHERE codVenda=" + codigoVenda + " AND horaPedido='" +v.HoraDoPedido+ "' AND codProduto= " + codPorcao, conn
                    );

                    cmd.Parameters.AddWithValue("codVenda", v.CodigoVenda);
                    cmd.Parameters.AddWithValue("codProduto", v.CodigoProduto);
                    cmd.Parameters.AddWithValue("qtdConsumida", v.QtdeConsumida);
                    cmd.Parameters.AddWithValue("horaPedido", v.HoraDoPedido);  // hora que fez o pedido na mesa.
                    cmd.Parameters.AddWithValue("horaEntrega", v.HoraDaEntrega);
                    
                    cmd.ExecuteNonQuery(); // executando a operação de UPDATE no banco                    
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro ao alterar a porção da mesa! " + e.Message);
                }   finally {
                        conn.Close(); //fechando a conexão com o banco de dados.
                    }
        }
                                    //OK
        public List<ItensDaVenda> buscarItensDeUmaVenda(int codigoVenda) {
            List<ItensDaVenda> itensDaVenda = null;

            try {
                conn.Open();
                itensDaVenda = new List<ItensDaVenda>();

                SQLiteCommand cdm2 = new SQLiteCommand(
                            "SELECT * FROM ItensDaVenda  WHERE codVenda="+codigoVenda, conn
                        );

                SQLiteDataReader dr = cdm2.ExecuteReader();

                while (dr.Read()) {
                    ItensDaVenda item = new ItensDaVenda();

                    item.CodigoVenda = Convert.ToInt32(dr["codVenda"]);
                    item.CodigoProduto = Convert.ToInt32(dr["codProduto"]);
                    item.QtdeConsumida = Convert.ToInt32(dr["qtdConsumida"]);
                    item.HoraDoPedido = dr["horaPedido"].ToString();
                    item.HoraDaEntrega = dr["horaEntrega"].ToString();

                    itensDaVenda.Add(item);
                }
                
            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na busca dos itens da venda. " + e.Message);
                }   finally {                        
                        conn.Close();
                    }

            return itensDaVenda;
        }                    
    }
}
 