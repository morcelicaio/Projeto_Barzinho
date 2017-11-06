using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace BotecoADS_Visual_vers0.DAO {
    public class ProdutoDAO {
        private SQLiteConnection conn;       

        public ProdutoDAO() {
            conn = new Conexao().criarConexao(); // criando uma conexão com o banco de dados.
        }

        public void cadastrarProduto(Produto p) { // cadastra tanto produto quanto porção aqui.
            try {
                // verificando se o estado da conexão é fechado no momento.
                if (conn.State == ConnectionState.Closed) {
                    conn.Open(); // se o estado é fechado, aqui se abre a conexão com o banco de dados.

                    SQLiteCommand cmd;
                    // criando um comando sql(cmd) para ser executado e passando a conexão para o objeto command (cmd)
                    cmd = new SQLiteCommand(
                                "INSERT INTO Produto (nomeProduto, tipoProduto, qtdProduto, valorUnitarioProduto)" +
                                "VALUES (@nomeProduto, @tipoProduto, @qtdProduto, @valorUnitarioProduto)", conn
                              );

                    //Tratando a parte de segurança (SQL Injection)
                    //Esta linha ñ permite que um possível comando sql colocado 
                    //no textField da tela seja executado no banco de dados.
                    cmd.Parameters.AddWithValue("nomeProduto", p.NomeDoProduto.Trim());
                    cmd.Parameters.AddWithValue("tipoProduto", p.TipoDoProduto.Trim());
                    cmd.Parameters.AddWithValue("qtdProduto", p.QtdeProduto);
                    cmd.Parameters.AddWithValue("valorUnitarioProduto", p.ValorUnitarioDoProduto);

                    cmd.ExecuteNonQuery(); // executando a operação de INSERT no banco                    
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no cadastro do produto. "+e.Message);
                }   finally {
                        conn.Close(); //fechando a consulta com o banco de dados
                    }                
        }

        // OK AQUI
        public void alterarProduto(Produto p) {
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(
                        "UPDATE Produto " +
                        "SET nomeProduto= @nomeProduto, tipoProduto= @tipoProduto, qtdProduto= @qtdProduto, valorUnitarioProduto= @valorUnitarioProduto " +                        
                        "WHERE codProduto=" + p.CodigoProduto, conn
                    );

                    //Tratando a parte de segurança (SQL Injection)
                    //Esta linha ñ permite que um possível comando sql colocado 
                    //no textField da tela seja executado no banco de dados.
                    cmd.Parameters.AddWithValue("nomeProduto", p.NomeDoProduto);
                    cmd.Parameters.AddWithValue("tipoProduto", p.TipoDoProduto);
                    cmd.Parameters.AddWithValue("qtdProduto", p.QtdeProduto);
                    cmd.Parameters.AddWithValue("valorUnitarioProduto", p.ValorUnitarioDoProduto);

                    cmd.ExecuteNonQuery(); // executando a operação de UPDATE no banco
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na alteração do produto! " + e.Message);
                }   finally {
                        conn.Close(); //fechando a conexão com o banco de dados.
                    }
        }

        /*
        public void alterarPorcao(Porcao p) { // atualizando o estoque no banco
            try {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(
                        "UPDATE Porcao " +
                        "SET nomeProduto= @nomeProduto, qtdProduto= @qtdProduto, valorUnitarioProduto= @valorUnitarioProduto " +
                        "WHERE codProduto=" + p.CodigoProduto, conn
                    );

                    //Tratando a parte de segurança (SQL Injection)
                    //Esta linha ñ permite que um possível comando sql colocado 
                    //no textField da tela seja executado no banco de dados.
                    cmd.Parameters.AddWithValue("nomeProduto", p.NomeDoProduto);
                    cmd.Parameters.AddWithValue("qtdProduto", p.QtdeProduto);
                    cmd.Parameters.AddWithValue("valorUnitarioProduto", p.ValorUnitarioDoProduto);

                    cmd.ExecuteNonQuery(); // executando a operação de UPDATE no banco
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro no cadastro da venda! " + e.Message);
                }   finally {
                        conn.Close(); //fechando a conexão com o banco de dados.
                    }
        }                       */

        public List<Produto> buscarProdutos() {
            List<Produto> produtos = null;            

            try {
                conn.Open();
                produtos = new List<Produto>();

                SQLiteCommand cdm2 = new SQLiteCommand(
                            "SELECT * FROM Produto ", conn
                        );

                SQLiteDataReader dr = cdm2.ExecuteReader();

                while (dr.Read()) {
                    int codigo; string nome; string tipo; int qtd; double valorUnitario;

                    codigo = Convert.ToInt32(dr["codProduto"]);
                    nome = dr["nomeProduto"].ToString();
                    tipo = dr["tipoProduto"].ToString();
                    qtd = Convert.ToInt32(dr["qtdProduto"]);
                    valorUnitario = Convert.ToDouble(dr["valorUnitarioProduto"]);

                    Produto p = new Produto();
                    p.CodigoProduto = codigo;
                    p.NomeDoProduto = nome;
                    p.TipoDoProduto = tipo;
                    p.QtdeProduto = qtd;
                    p.ValorUnitarioDoProduto = valorUnitario;

                    produtos.Add(p);
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na busca dos produtos. " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return produtos;
        }

        // OK
        public List<Produto> buscarProdutos(string s) {  
            List<Produto> produtos = null;

            try {
                conn.Open();
                produtos = new List<Produto>();

                SQLiteCommand cdm2 = new SQLiteCommand(
                            "SELECT * FROM Produto " +
                            "WHERE nomeProduto LIKE '"+s+"%'", conn
                        );

                SQLiteDataReader dr = cdm2.ExecuteReader();

                while (dr.Read()) {

                    Produto p = new Produto();
                    p.CodigoProduto = Convert.ToInt32(dr["codProduto"]);
                    p.NomeDoProduto = dr["nomeProduto"].ToString();
                    p.TipoDoProduto = dr["tipoProduto"].ToString();
                    p.QtdeProduto = Convert.ToInt32(dr["qtdProduto"]);
                    p.ValorUnitarioDoProduto = Convert.ToDouble(dr["valorUnitarioProduto"]);

                    produtos.Add(p);
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na busca do produto. " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return produtos;
        }

        public List<Produto> buscarPorcoes() {
            List<Produto> porcoes = null;

            try {
                conn.Open();
                porcoes = new List<Produto>();

                SQLiteCommand cdm2 = new SQLiteCommand(
                            "SELECT * FROM Produto ", conn
                        );

                SQLiteDataReader dr = cdm2.ExecuteReader();

                while (dr.Read()) {
                    Porcao p = new Porcao();
                    p.CodigoProduto = Convert.ToInt32(dr["codProduto"]);
                    p.NomeDoProduto = dr["nomeProduto"].ToString();
                    p.TipoDoProduto = dr["tipoProduto"].ToString();
                    p.QtdeProduto = Convert.ToInt32(dr["qtdProduto"]);
                    p.ValorUnitarioDoProduto = Convert.ToDouble(dr["valorUnitarioProduto"]);

                    if (p.TipoDoProduto.Equals("porcao")) {
                        porcoes.Add(p);                      // se o tipo do produto for porção entao add na lista.
                    }                    
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro ao realizar a busca das porçoes. " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return porcoes;
        }

        public List<Produto> buscarPorcoes(string s) {
            List<Produto> porcoes = null;

            try {
                conn.Open();
                porcoes = new List<Produto>();

                SQLiteCommand cdm2 = new SQLiteCommand(
                                                        "SELECT * FROM Produto " +
                                                        "WHERE nomeProduto LIKE '" + s + "%'", conn
                                                      );

                SQLiteDataReader dr = cdm2.ExecuteReader();

                while (dr.Read()) {

                    Porcao p = new Porcao();
                    p.CodigoProduto = Convert.ToInt32(dr["codProduto"]);
                    p.NomeDoProduto = dr["nomeProduto"].ToString();
                    p.TipoDoProduto = dr["tipoProduto"].ToString();
                    p.QtdeProduto = Convert.ToInt32(dr["qtdProduto"]);
                    p.ValorUnitarioDoProduto = Convert.ToDouble(dr["valorUnitarioProduto"]);

                    if (p.TipoDoProduto.Equals("porcao")) {
                        porcoes.Add(p);                      // se o tipo do produto for porção entao add na lista.
                    }
                }

            }   catch (SQLiteException e) {
                    Console.WriteLine("Erro na busca das porçoes. " + e.Message);
                }   finally {
                        conn.Close();
                    }

            return porcoes;
        }
    }
}