using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO; // Serve para poder usar o File.Exists()  no código.

namespace BotecoADS_Visual_vers0.DAO {
    public class Conexao {

        private static string conexao = "Data Source=DataBaseBar.db";        

        public SQLiteConnection criarConexao() {
            try {
                SQLiteConnection conn = new SQLiteConnection(conexao);
                return conn;

            }   catch (SQLiteException ex) {
                    Console.WriteLine("Erro ao criar a conexão com o banco de dados: " + ex.Message);
                    throw new SQLiteException(ex.ToString()); //lançando a exceção.
                }
        }

    }
}     

            /*
        public void criarBancoDeDados(SQLiteConnection conexaoAberta) {
            //bool bancoCriado = false;
            private SQLiteConnection conn = conexaoAberta; // recebendo a conexao que foi aberta.
            
            try{

            }   catch(){
                
                }   finally{
                    
                    }
        }
        }*/
            //try {
                //if (!File.Exists(nomeBanco)) { // se nao houver esse banco criando ainda, então ele entra no if
                    //SQLiteConnection.CreateFile(nomeBanco); // criando o arquivo do banco de dados.
                     
                    //SQLiteConnection conn = new SQLiteConnection(conexao); // criando uma conexao usando o SQLite.

                    //conn.Open(); // abrindo uma conexão com o banco.

                    // uma string builder pode ser modificada sem preencher mais memória, diferente de um tipo string 
                    //onde a cada modificação (concatenação), o tipo string cria uma nova string (que é a modificada)
                    // na memória.
                    //StringBuilder sql = new StringBuilder();

                    //adicionando linhas neste comando sql.
                    /* FUNCIONANDO NORMAL
                    sql.AppendLine("CREATE TABLE Mesa (" +
                          "[codMesa] INTEGER PRIMARY KEY AUTOINCREMENT " +
                       ")" 
                      );
                      */

                    /*    //FUNCIONANDO NORMAL TBM APENAS SE NAO FOR CRIADA JUNTO COM A TABELA MESA.
                    sql.AppendLine("CREATE TABLE Produto (" +
                                      "[codProduto] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "[nomeProduto] VARCHAR(60) NOT NULL," +
                                      "[qtdProduto] INTEGER NOT NULL," +
                                      "[valorUnitarioProduto] NUMERIC(10,2)," +
                                      "[horaPedido] TEXT," +
                                      "[horaEntrega] TEXT" +
                                   ")"
                                  );
                                  */

                    // criando um comando sql(cmd) para ser executado.
                    // E Passando a conexão para o objeto command (cmd)
                    //SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), conn);

                    //try {
                    //cmd.ExecuteNonQuery(); // executando o comando sql criado.
                                    //bancoCriado = true;
                                //}   catch (SQLiteException ex) {
                                        //bancoCriado = false;
                                        //Console.WriteLine("Erro na execução do cmd: " + ex.Message);
                                    //}   finally {
                                            //conn.Close(); // fechando a conexão com o banco que foi aberta.
                                        //}

                

                            //}   catch (SQLiteException e) {
                            //      bancoCriado = false;
                            //    Console.WriteLine("Erro na criação do banco de dados: " + e.Message);
                            //}

                //}
                            //return bancoCriado;
        //}



