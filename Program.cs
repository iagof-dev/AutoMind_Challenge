using AutoMind_challenge.Manager;
using AutoMind_challenge.Models;
using System;
using System.Runtime.CompilerServices;

namespace AutoMind_challenge
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Objeto para manter guardar os registros de usuários.
            UsuarioManager userManager = new UsuarioManager();
            //Titulo da janela do programa.
            Console.Title = "AutoMind - Desafio Técnico";

            // Loop para manter que o menu sempre esteja a mostra após utilizar uma opção.
            while (true)
            {

                //Listagem de opções que o usuário poderá utilizar.
                Console.Clear();
                Console.WriteLine("AutoMind - Desafio Técnico");
                Console.WriteLine("\n[1] - Registrar novo usuário.");
                Console.WriteLine("[2] - Listar todos usuários.");
                Console.WriteLine("[3] - Buscar usuário.");
                Console.WriteLine("[0] - Sair.");
                Console.WriteLine("\nEscolha uma opção: ");
                Console.Write(">");
                int selected_option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                //Switch para cada opção do menu.
                switch (selected_option)
                {

                    // Código de inserção de usuário
                    case 1:
                        Usuario newUser = new Usuario();
                        Console.WriteLine("Registro de usuário");
                        bool emailInput = false;
                        try
                        {
                            Console.WriteLine("\nDigite o nome:");
                            Console.Write(">");
                            newUser.name = Console.ReadLine();
                            while (!emailInput)
                            {
                                Console.WriteLine("Digite o E-mail:");
                                Console.Write(">");
                                newUser.email_address = Console.ReadLine();
                                if (newUser.email_address.Contains("@") || newUser.email_address.Contains("."))
                                {
                                    emailInput = true;
                                }
                            }

                            Console.WriteLine("Digite a idade:");
                            Console.Write(">");
                            newUser.age = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Registro de usuário");
                            Console.WriteLine($"Nome: {newUser.name}.");
                            Console.WriteLine($"Endereço de E-mail: {newUser.email_address}.");
                            Console.WriteLine($"Idade: {newUser.age} anos.");
                            Console.WriteLine("\nConfirma o registro? (S/N)");
                            if (Console.ReadLine().ToUpper() == "S")
                            {
                                userManager.AddUser(newUser);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    // Código de listagem de todos os usuários
                    case 2:
                        Console.WriteLine("Listagem de usuários\n============================");
                        List<Usuario> userList = userManager.getUsers();
                        if (userList.Count <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nenhum usuário registrado.");
                            Console.ResetColor();
                        }
                        else
                        {
                            foreach (Usuario usuario in userList)
                            {
                                Console.WriteLine($"| {usuario.name} - {usuario.email_address} - {usuario.age} anos |");
                            }
                        }
                        Console.WriteLine("============================");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey(true);
                        break;


                    // Código de busca de usuário pelo nome.
                    case 3:
                        bool searchLoop = true;
                        while (searchLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Busca de usuário");
                            Console.WriteLine("\nDigite o nome do Usuário:");
                            Console.Write(">");
                            string userNameInput = Console.ReadLine();

                            Console.WriteLine($"Buscando por: " + userNameInput);

                            List<Usuario> usersList = userManager.getUsers();

                            Console.WriteLine("\n============================");

                            bool isFound = false;

                            foreach (Usuario user in usersList)
                            {
                                if (user.name.ToLower().Contains(userNameInput.ToLower()))
                                {
                                    Console.WriteLine($"Nome: {user.name}");
                                    Console.WriteLine($"E-mail: {user.email_address}");
                                    Console.WriteLine($"Idade: {user.age}");
                                    isFound = true;
                                }
                            }

                            if (!isFound)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhum usuário encontrado!");
                                Console.ResetColor();
                            }

                            Console.WriteLine("============================");
                            Console.WriteLine("\nDeseja efetuar mais uma busca? (S/N)");
                            Console.Write(">");
                            string result = Console.ReadLine();
                            if (result.ToUpper() == "N")
                            {
                                searchLoop = false;
                            }
                        }

                        break;


                      /*
                         case -1:
                             Usuario u1 = new Usuario();
                             u1.name = "Iago Fragnan";
                             u1.email_address = "iago.fragnan@gmail.com";
                             u1.age = 18;

                             Usuario u2 = new Usuario();
                             u2.name = "Lucas Silva";
                             u2.email_address = "lucas.silva@email.com";
                             u2.age = 22;

                             Usuario u3 = new Usuario();
                             u3.name = "Mariana Souza";
                             u3.email_address = "mariana.souza@email.com";
                             u3.age = 25;

                             Usuario u4 = new Usuario();
                             u4.name = "Carlos Oliveira";
                             u4.email_address = "carlos.oliveira@email.com";
                             u4.age = 30;

                             userManager.AddUser(u1);
                             userManager.AddUser(u2);
                             userManager.AddUser(u3);
                             userManager.AddUser(u4);
                             break;

                         */




                    // Código para sair do programa.
                    case 0:
                        Environment.Exit(0);
                        break;

                    // Código para caso o usuário escrever errado na hora de escolher uma opção inválida.
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }

            }

        }


    }
}
