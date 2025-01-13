using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Security;

//Classe onde ficarão os métodos e dados do contato para que ocorra a relação com o banco de dados.
 public class Contato
    {
        public string cellNumber; //numero do celular
        public string email; //email
        public string name; //nome
        
        //Método para adicionar um contato na lista, recebe um objeto do tipo Contato como argumento
        public static bool adicionarContato(string nome,string numero,string email)
        {
            try
            {
                using (MySqlConnection coon = new MySqlConnection(ConexaoBanco.conexaoBanco))
                {
                    coon.Open();

                    string insert = $"insert into contatos (nome,numero,email) values ('{nome}','{numero}','{email}')";
                    MySqlCommand comandoSql = coon.CreateCommand();
                    comandoSql.CommandText = insert;

                    comandoSql.ExecuteNonQuery();
                }               
                Console.WriteLine("Contato cadastrado com sucesso!!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados. {0}",ex.Message);
                return false;
            }
        }

        //Método para mostrar todos os contatos registrados
        // public static Contato mostrarContatos()
        // {
            
        // }
        // //Método para buscar um contato pelo nome, recebe o nome do contato desejado como argumento
        // public static Contato buscarPorNome(string name)
        // {
            
        // }
        //Método para buscar um contato pelo número, recebe o número do contato desejado como argumento
        public static bool atualizarContato()
        {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível acessar o banco de dados. {0}",ex.Message);
                return false;
            }
        }        
        
        //Método que limpa a lista de contatos, ou seja, remove todos os contatos cadastrados
        public static void removerContatos()
        {
            
        }
}
