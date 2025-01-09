using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace contatos
{
    class Contato
    {
        private string cellNumber; //numero do celular
        private string email; //email
        private string name; //nome

        //Construtor da classe, precisa receber 3 argumentos para criar um objeto do tipo Contato
        public Contato(string number, string email, string name)
        {
            this.cellNumber = number;
            this.email = email;
            this.name = name;
        }
        //Lista para armazenar os contatos registrados
        public static List<Contato> listaContatos = new List<Contato>();
        //Método para adicionar um contato na lista, recebe um objeto do tipo Contato como argumento
        public void adicionarContato(Contato contato)
        {
            listaContatos.Add(contato);
        }
        //Método para mostrar todos os contatos registrados
        public static void mostrarContatos()
        {
            foreach (var item in listaContatos)
            {
                Console.WriteLine("Nome: " + item.name);
                Console.WriteLine("Email: " + item.email);
                Console.WriteLine("Numero: " + item.cellNumber);
            }
        }
        //Método para buscar um contato pelo nome, recebe o nome do contato desejado como argumento
        public static Contato buscarContatoNome(string name)
        {
            foreach (Contato item in listaContatos)
            {
                if (item.name == name)
                {
                    Console.WriteLine("Contato: " + item.name + ", Email: " + item.email + ", Telefone: " + item.cellNumber);
                    return item;
                }
            }
            return null;
        }
        //Método para buscar um contato pelo número, recebe o número do contato desejado como argumento
        public static Contato buscarContatoNumero(string Numero)
        {
            foreach (Contato item in listaContatos)
            {
                if (item.cellNumber == Numero)
                {
                    Console.WriteLine("Contato encontrado: " + item.name + ", Email: " + item.email + ", Telefone: " + item.cellNumber);
                    return item;
                }
            }
            return null;
        }
        //Método que limpa a lista de contatos, ou seja, remove todos os contatos cadastrados
        public static void removerContatos()
        {
            listaContatos.Clear();
        }

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
                    Console.WriteLine("║ 5 - Remover Contatos               ║");
                    Console.WriteLine("║ 6 - Sair                           ║");
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
                            Contato contato = new Contato(numero, email, nome);
                            contato.adicionarContato(contato);
                            break;
                        case 2:
                            //Mostra todos os contatos cadastrados
                            Console.WriteLine("Lista de Contatos");
                            Contato.mostrarContatos();
                            break;
                        case 3:
                            //Busca um contato pelo nome
                            Console.WriteLine("Digite o nome do contato");
                            string nomeBusca = Console.ReadLine();
                            Contato.buscarContatoNome(nomeBusca);
                            break;
                        case 4:
                            //Busca um contato pelo número
                            Console.WriteLine("Digite o número do contato");
                            string numeroBusca = Console.ReadLine();
                            Contato.buscarContatoNumero(numeroBusca);
                            break;
                        case 5:
                            //Remove todos os contatos, mas antes faz uma verificação de segurança para evitar que o usuário exclua todos os contatos por acidente
                            Console.WriteLine("Você tem certeza que deseja remover todos os contatos?");
                            Console.Write("1 - Sim");
                            Console.Write("2 - Não");
                            //lê a opção escolhida pelo usuário
                            int opcaoRemover = int.Parse(Console.ReadLine());
                            if (opcaoRemover == 1)
                                Contato.removerContatos();
                            break;
                        case 6:
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
}