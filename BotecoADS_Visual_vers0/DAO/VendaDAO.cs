using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BotecoADS_Visual_vers0.DAO {
    public class VendaDAO {
        private SQLiteConnection conn;        

        public VendaDAO() {
            //if (conn == null) {
                conn = new Conexao().criarConexao(); // instanciando uma nova conexao e criando uma nova conexao.
            //}
        }

        public void cadastrarVenda(Venda v) {
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(
                        "INSERT INTO Venda (codMesa, dataVenda, horaAbreVenda, horaFechaVenda, valorTotal)" +
                        "VALUES (@codMesa, @dataVenda, @horaAbreVenda, @horaFechaVenda, @valorTotal)", conn                        
                    );

                    //Tratando a parte de segurança (SQL Injection). Esta linha ñ permite que 1 possível comando sql colocado 
                    //no textField da tela seja executado no banco de dados.
                    cmd.Parameters.AddWithValue("codMesa", v.CodigoDaMesa);
                    cmd.Parameters.AddWithValue("dataVenda", v.DataDaVenda);
                    cmd.Parameters.AddWithValue("horaAbreVenda", v.HoraDeAbreVenda);
                    cmd.Parameters.AddWithValue("horaFechaVenda", v.HoraDeFechaVenda);                    
                    cmd.Parameters.AddWithValue("valorTotal", v.ValorTotalVenda);                    
                    
                    cmd.ExecuteNonQuery(); // executando a operação de INSERT no banco
                }
            
            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no cadastro da venda! "+e.Message);
                }   finally {
                        conn.Close(); //fechando a conexão com o banco de dados.
                    }

        }

        public void alterarVenda(Venda v) { // setando a hora em que a venda é fechada no banco
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                    
                    SQLiteCommand cmd = new SQLiteCommand(
                        "UPDATE Venda " +
                        "SET codMesa= @codMesa, dataVenda= @dataVenda, horaAbreVenda= @horaAbreVenda, horaFechaVenda= @horaFechaVenda, valorTotal= @valorTotal " +
                        "WHERE codVenda=" + v.CodigoDaVenda, conn 
                    );

                    cmd.Parameters.AddWithValue("codMesa", v.CodigoDaMesa);
                    cmd.Parameters.AddWithValue("dataVenda", v.DataDaVenda);
                    cmd.Parameters.AddWithValue("horaAbreVenda", v.HoraDeAbreVenda);
                    cmd.Parameters.AddWithValue("horaFechaVenda", v.HoraDeFechaVenda);                    
                    cmd.Parameters.AddWithValue("valorTotal", v.ValorTotalVenda);

                    cmd.ExecuteNonQuery(); // executando a operação de UPDATE no banco                    
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no cadastro da venda! " + e.Message);
                }   finally {
                        conn.Close(); //fechando a conexão com o banco de dados.
                    }
        }
        
        public List<Venda> buscarVendas() {
            List<Venda> vendas = new List<Venda>();

            try {
                conn.Open();                

                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Venda", conn    
                );

                SQLiteDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    int codVenda; int codMesa; string horaInicioVenda; string horaFimVenda; string dataVenda; double valorTotal;

                    codVenda = Convert.ToInt32(dr["codVenda"]);
                    codMesa = Convert.ToInt32(dr["codMesa"]);
                    horaInicioVenda = dr["horaAbreVenda"].ToString();
                    horaFimVenda = dr["horaFechaVenda"].ToString();
                    dataVenda = dr["dataVenda"].ToString();
                    valorTotal = Convert.ToDouble(dr["valorTotal"]);

                    Venda v = new Venda(); // instanciando e populando o objeto.
                    v.CodigoDaVenda = codVenda;
                    v.CodigoDaMesa = codMesa;
                    v.HoraDeAbreVenda = horaInicioVenda;
                    v.HoraDeFechaVenda = horaFimVenda;
                    v.DataDaVenda = dataVenda;
                    v.ValorTotalVenda = valorTotal;

                    vendas.Add(v);
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na busca das vendas! " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return vendas;
        }
        
        public int buscarCodigoDaVenda() {  //pegando o código da última venda cadastrada.          
            try {
                conn.Open();                

                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT codVenda FROM Venda WHERE codVenda=(SELECT MAX(codVenda) FROM Venda)", conn
                );

                SQLiteDataReader dr = cmd.ExecuteReader();

                int codigoDaVenda;

                while (dr.Read()) {
                    codigoDaVenda = Convert.ToInt32(dr["codVenda"]);
                    return codigoDaVenda; // retornando o objeto
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no retorna da venda! " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return -1;
        }
    }
}
