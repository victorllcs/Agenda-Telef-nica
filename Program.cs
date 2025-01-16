using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Reflection.Metadata;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;

namespace contatos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Está dentro de um while para não parar de executar o programa enquanto o usuário utiliza
            bool exec = true;
            while (exec == true)
            {
                //Menu de opções
                int opcao;
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║ Bem vindo a sua agenda de contatos ║ ");
                Console.WriteLine("║ Escolha uma das opções abaixo      ║");
                Console.WriteLine("║ 1 - Adicionar Contato              ║");
                Console.WriteLine("║ 2 - Mostrar Contatos               ║");
                Console.WriteLine("║ 3 - Buscar Contato por Nome        ║");
                Console.WriteLine("║ 4 - Buscar Contato por Numero      ║");
                Console.WriteLine("║ 5 - Atualizar Contato              ║");
                Console.WriteLine("║ 6 - Remover Contato                ║");
                Console.WriteLine("║ 7 - Apagar todos os contatos       ║");
                Console.WriteLine("║ 8 - Sair                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                //lê a opção escolhida pelo usuário
                opcao = int.Parse(Console.ReadLine());
                //Switch case para chamar os métodos de acordo com a opção escolhida
                switch (opcao)
                {
                    case 1:
                        //Cadastro de um novo contato
                        Console.WriteLine("Digite o nome do contato");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o número do contato");
                        string numero = Console.ReadLine();
                        Console.WriteLine("Digite o email do contato");
                        string email = Console.ReadLine();
                        Contato.adicionarContato(nome,numero,email);
                        break;
                    case 2:
                        //Mostra todos os contatos cadastrados
                        Console.WriteLine("Lista de Contatos:");
                        Console.WriteLine("==================");
                        Contato.mostrarContatos();
                        break;
                    case 3:
                        //Busca um contato pelo nome
                        Console.WriteLine("Digite o nome do contato");
                        string nomeBusca = Console.ReadLine();
                        Console.WriteLine("=========================");
                        Contato.buscarPorNome(nomeBusca);
                        break;
                    case 4:
                        //Busca um contato pelo número
                        Console.WriteLine("Digite o número do contato");
                        string numeroBusca = Console.ReadLine();
                        Console.WriteLine("==========================");
                        Contato.buscarPorNumero(numeroBusca);
                        break;
                    case 5:
                        Console.WriteLine("Informe o nome do contato:");
                        string contactName = Console.ReadLine();
                        Console.WriteLine("Você deseja atualizar os dados do contato?\n 1-Sim  2-Não");
                        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha == 1)
                        {
                        Console.WriteLine("Informe o novo nome do contao:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Informe o novo número do contato:");
                        string newNumber = Console.ReadLine();
                        Console.WriteLine("Informe o novo E-mail do contato:");
                        string newEmail = Console.ReadLine();
                        Contato.AtualizarContato(contactName,newName,newNumber,newEmail);
                        }
                        else
                        break;
                    break;
                    case 6:
                        Console.WriteLine("Digite o nome do contato que você deseja apagar:");
                        string deleteName = Console.ReadLine();
                        Console.WriteLine("Tem certeza que deseja apagar o contato?\n 1-Sim  2-Não");
                        if (int.TryParse(Console.ReadLine(), out escolha) && escolha == 1)
                            Contato.removerContatoNome(deleteName);
                        else
                            break;
                    break;
                    case 7:
                        Console.WriteLine("Você tem certeza que quer apagar TODOS os seus contatos??\n 1-Sim  2-Não");
                        if (int.TryParse(Console.ReadLine(), out escolha) && escolha == 1)
                            Contato.removerTodosContatos();
                        else
                            break;
                    break; 
                    case 8:
                        //Encerra o programa
                        exec = false;
                        break;
                    default:
                        //Caso o usuário digite uma opção inválida
                        Console.WriteLine("Opção inválida");
                        break;
                }

            }
        }
    }

}
