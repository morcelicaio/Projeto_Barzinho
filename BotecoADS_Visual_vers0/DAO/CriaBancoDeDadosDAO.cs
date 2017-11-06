using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotecoADS_Visual_vers0.DAO {
    public class CriaBancoDeDadosDAO {
        private SQLiteConnection conn;
        private static string nomeBanco = "DataBaseBar.db";

        public CriaBancoDeDadosDAO(){
            conn = new Conexao().criarConexao();  //criando uma conexão com o banco de dados.
        }

        public void criarBancoDeDados() {            
            try {
                if (!File.Exists(nomeBanco)) { // se nao houver esse banco criado ainda, então ele entra no if
                    SQLiteConnection.CreateFile(nomeBanco); // criando o arquivo do banco de dados.

                    conn.Open(); //abrindo uma conexão com o banco.

                    // uma string builder pode ser modificada sem preencher mais memória, diferente de um tipo string 
                    //onde a cada modificação (concatenação), o tipo string cria uma nova string (que é a modificada)
                    // na memória.
                    StringBuilder sql = new StringBuilder();

                    //Executando o PRAGMA (ele permite as chaves estrangeiras funcionarem no banco)
                    sql.AppendLine("PRAGMA FOREIGN_KEYS = ON;");

                    SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    sql.Clear(); //limpando a variável sql para inserir uma nova string

                    //adicionando linhas neste comando sql.
                    sql.AppendLine("CREATE TABLE Mesa (" +
                                      "[codMesa] INTEGER PRIMARY KEY AUTOINCREMENT" +                                      
                                   ")"
                                  );

                    // criando um comando sql(cmd) para ser executado.
                    // E Passando a conexão para o objeto command (cmd)
                    cmd = new SQLiteCommand(sql.ToString(), conn);  //instanciando um novo objeto cmd                    
                    cmd.ExecuteNonQuery(); // executando o comando sql criado.
                    sql.Clear();

                    //adicionando linhas neste comando sql.
                    sql.AppendLine("CREATE TABLE Produto (" +
                                      "[codProduto] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "[tipoProduto] VARCHAR(30) NOT NULL," +
                                      "[nomeProduto] VARCHAR(60) NOT NULL," +
                                      "[qtdProduto] INTEGER NOT NULL," +
                                      "[valorUnitarioProduto] REAL" +                                      
                                   ")"
                                  );
                    
                    // criando um comando sql(cmd) para ser executado e passando a conexão para o objeto command (cmd)
                    cmd = new SQLiteCommand(sql.ToString(), conn);  //instanciando um novo objeto cmd                    
                    cmd.ExecuteNonQuery(); // executando o comando sql criado.
                    sql.Clear();                    

                    sql.AppendLine("CREATE TABLE Venda (" +
                                      "[codVenda] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "[codMesa] INTEGER NOT NULL," +
                                      "[dataVenda] TEXT," +
                                      "[horaAbreVenda] TEXT," +
                                      "[horaFechaVenda] TEXT," +                                      
                                      "[valorTotal] NUMERIC(10,2)," +
                                      "FOREIGN KEY (codMesa) REFERENCES Mesa(codMesa)" +
                                   ")"
                                  );

                    cmd = new SQLiteCommand(sql.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    sql.Clear();

                    sql.AppendLine("CREATE TABLE ItensDaVenda (" +
                                      "[codVenda] INTEGER," +
                                      "[codProduto] INTEGER," +
                                      "[qtdConsumida] INTEGER NOT NULL," +
                                      "[horaPedido] TEXT NOT NULL," +
                                      "[horaEntrega] TEXT," +
                                      //"PRIMARY KEY (codVenda, codProduto)," +
                                      "FOREIGN KEY (codVenda) REFERENCES Venda(codVenda)," +
                                      "FOREIGN KEY (codProduto) REFERENCES Produto(codProduto)" +
                                   ")"
                                  );

                    cmd = new SQLiteCommand(sql.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    sql.Clear();

                    //bancoCriado = true;                    
                }

            }   catch (SQLiteException e) {
                    //bancoCriado = false;
                    Console.WriteLine("Erro na criação do banco de dados: " + e.Message);
                }   finally {
                        conn.Close();
                    }
        }

    }
}
