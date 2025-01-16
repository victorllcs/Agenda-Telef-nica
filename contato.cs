using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Security.Policy;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Security;

//Classe onde ficarão os métodos e dados do contato para que ocorra a relação com o banco de dados.
//
public class Contato
{
    public string cellNumber; //numero do celular
    public string email; //email
    public string name; //nome

    //Método para adicionar um contato na lista, recebe um objeto do tipo Contato como argumento
    public static bool adicionarContato(string nome, string numero, string email)
    {
        try
        {
            using (MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco)) //Cria a string de conexão, batizada de coon
            {
                coon.Open(); //Abre o banco de dados, nesse caso para receber dados

                string insert = $"insert into contatos (nome,numero,email) values ('{nome}','{numero}','{email}')"; //String responsável por adicionar os dados no BD
                MySqlCommand comandoSql = coon.CreateCommand(); //Cria uma variável para abrir comandos no banco de dados
                comandoSql.CommandText = insert; //Cria o método de inserir dentro do banco de dados

                comandoSql.ExecuteNonQuery(); //Executa o comando criado acima
            }
            Console.WriteLine("Contato cadastrado com sucesso!!"); //Retorno de feedback para o usuário
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar com o banco de dados. {0}", ex.Message);
            return false;
        }
    }

    //Método para mostrar todos os contatos registrados
    public static void mostrarContatos()
    {
        try
        {
            //Abre a conexão com o banco de dados
            MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco);
            coon.Open();

            string select = "SELECT nome,numero,email from contatos"; //String que seleciona os dados dentro do banco
            using (MySqlCommand comandoSql = new MySqlCommand(select, coon)) //Usa os dados da conexão para estabelecer o comando de seleção dentro do banco de dados
            {
                using (MySqlDataReader reader = comandoSql.ExecuteReader()) //Utiliza o comando de leitura para ler os dados dentro do DB
                {
                    while (reader.Read()) //Enquanto possuir dados a ler no banco de dados
                    {
                        string nome = reader["nome"].ToString(); // Pega o dado salvo como "nome" dentro do DB, copia para a variável nome e transforma em texto
                        string numero = reader["numero"].ToString();// pega o dado salvo como "numero" dentro do BD, copia para a variável numero e transforma em texto 
                        string email = reader["email"].ToString(); //pega o dado salvo como "email" dentro do BD, copia para a variável email e transforma em texto

                        Console.WriteLine($"Nome: {nome}\nNúmero: {numero}\nEmail: {email}"); //Cria um texto para mostrar os dados
                        Console.WriteLine("===============================================");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro no banco de dados - Método mostrarContatos.{0}", ex.Message);
        }
    }

    //Método para buscar um contato pelo nome, recebe o nome do contato desejado como argumento
    public static void buscarPorNome(string name)
    {
        try
        {
            MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco);
            coon.Open();

            string select = $"SELECT nome, numero, email from contatos where nome ='{name}';";
            using (MySqlCommand comandoSql = new MySqlCommand(select, coon)) //Usa os dados da conexão para estabelecer o comando de seleção dentro do banco de dados
            {
                using (MySqlDataReader reader = comandoSql.ExecuteReader()) //Utiliza o comando de leitura para ler os dados dentro do DB
                {
                    while (reader.Read())
                    {
                        string nome = reader["nome"].ToString(); // Pega o dado salvo como "nome" dentro do DB, copia para a variável nome e transforma em texto
                        string numero = reader["numero"].ToString();// pega o dado salvo como "numero" dentro do BD, copia para a variável numero e transforma em texto 
                        string email = reader["email"].ToString(); //pega o dado salvo como "email" dentro do BD, copia para a variável email e transforma em texto

                        Console.WriteLine($"Nome: {nome}\nNúmero: {numero}\nEmail: {email}"); //Cria um texto para mostrar os dados
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro no banco de dados - Método buscarPorNome.{0}", ex.Message);
        }
    }
    //Método para buscar um contato pelo número, recebe o número do contato desejado como argumento
    public static void buscarPorNumero(string numeroBusca)
    {
        try
        {
            MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco);
            coon.Open();

            string select = $"SELECT nome, numero, email from contatos where numero ='{numeroBusca}';";
            using (MySqlCommand comandoSql = new MySqlCommand(select, coon)) //Usa os dados da conexão para estabelecer o comando de seleção dentro do banco de dados
            {
                using (MySqlDataReader reader = comandoSql.ExecuteReader()) //Utiliza o comando de leitura para ler os dados dentro do DB
                {
                    while (reader.Read())
                    {
                        string nome = reader["nome"].ToString(); // Pega o dado salvo como "nome" dentro do DB, copia para a variável nome e transforma em texto
                        string numero = reader["numero"].ToString();// pega o dado salvo como "numero" dentro do BD, copia para a variável numero e transforma em texto 
                        string email = reader["email"].ToString(); //pega o dado salvo como "email" dentro do BD, copia para a variável email e transforma em texto

                        Console.WriteLine($"Nome: {nome}\nNúmero: {numero}\nEmail: {email}"); //Cria um texto para mostrar os dados
                        Console.WriteLine("===============================================");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro no banco de dados - Método buscarPorNome.{0}", ex.Message);
        }
    }
    public static bool AtualizarContato(string nomeContato, string name, string number, string eMail)
    {
        try
        {
            using (MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco))
            {
                coon.Open();

                // Query de seleção
                string select = "SELECT nome, numero, email FROM contatos WHERE nome = @nomeContato;";
                using (MySqlCommand comandoSql = new MySqlCommand(select, coon))
                {
                    comandoSql.Parameters.AddWithValue("@nomeContato", nomeContato);

                    using (MySqlDataReader reader = comandoSql.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Pesquisa o contato no banco de dados
                            string nome = reader["nome"].ToString();
                            string numero = reader["numero"].ToString();
                            string email = reader["email"].ToString();
                            //Exibe as informações do contato pesquisado.
                            Console.WriteLine($"Nome: {nome}\nNúmero: {numero}\nEmail: {email}");
                        escolha: //label para retornar para a caixa de escolha caso a opção seja inválida
                                 //Abre a opção para o usuário editar as informações.
                            Console.WriteLine("Você deseja editar esse contato?\n1-Sim  2-Não");
                            //lê a informação inserida pelo usuário e coloca essa informação na variável "escolha"
                            //Se a variável escolha for igual a 1, ele excuta o trecho de código abaixo
                            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha == 1)
                            {
                                reader.Close(); // Fecha o leitor antes da atualização

                                // Query de atualização com parâmetros
                                string update = "UPDATE contatos SET nome = @name, numero = @number, email = @eMail WHERE nome = @nomeContato;";
                                using (MySqlCommand comandoUpdate = new MySqlCommand(update, coon))
                                {
                                    comandoUpdate.Parameters.AddWithValue("@name", name);
                                    comandoUpdate.Parameters.AddWithValue("@number", number);
                                    comandoUpdate.Parameters.AddWithValue("@eMail", eMail);
                                    comandoUpdate.Parameters.AddWithValue("@nomeContato", nomeContato);

                                    int colunasAfetadas = comandoUpdate.ExecuteNonQuery();
                                    //Verifica se alguma coluna foi afetada, se sim, mostra a mensagem de atualização
                                    if (colunasAfetadas > 0)
                                        Console.WriteLine("Contato atualizado com sucesso!");
                                    //Senão, mostra a mensagem que não atualizou nenhum contato
                                    else
                                        Console.WriteLine("Nenhum contato foi atualizado.");
                                }
                            }
                            //Mensagem mostrada caso o usuário insira o valor 2 na caixa de escolha
                            else if (escolha == 2)
                            {
                                Console.WriteLine("Operação cancelada!");
                            }
                            //Se caso o valor inserido não seja 1 ou 2, mostra que a opção é inválida
                            else
                            {
                                Console.WriteLine("Opção inválida");
                                goto escolha;
                            }
                        }
                        //Mensagem mostrada caso não ache nenhum contato no banco de dados.
                        else
                        {
                            Console.WriteLine("Contato não encontrado.");
                        }

                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar o banco de dados: {ex.Message}");
            return false;
        }
    }

    //Método que limpa a lista de contatos, ou seja, remove todos os contatos cadastrados
    public static bool removerContatoNome(string nomeContato)
    {
        try
        {
            MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco);
            coon.Open();

            string update = $"DELETE FROM contatos where nome = '{nomeContato}';";
            MySqlCommand comandoSql = coon.CreateCommand();
            comandoSql.CommandText = update;

            int linhasAfetadas = comandoSql.ExecuteNonQuery();
            if (linhasAfetadas > 0)
                Console.WriteLine("Contato deletado com sucesso");
            else
                Console.WriteLine("Erro ao deletar contato");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no banco de dados - Método removerContatoNome. {ex.Message}");
            return false;
        }
    }
    //Método que apaga todos os contatos
    public static bool removerTodosContatos()
    {
        try
        {
            using (MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco))
            {
                coon.Open();

                string query = "DELETE FROM contatos";
                using (MySqlCommand comandoSql = new MySqlCommand(query, coon))
                {
                    int linhasAfetadas = comandoSql.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine($"Todos os contatos foram removidos. Total de registros excluídos: {linhasAfetadas}");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum contato foi encontrado para remoção.");
                    }
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no banco de dados - Método RemoverTodosContatos: {ex.Message}");
            return false;
        }
    }

}