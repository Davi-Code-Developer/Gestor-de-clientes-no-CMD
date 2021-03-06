﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_de_clientes_no_CMD
{
    class Program
    {
        [System.Serializable] //Transforma os dados em bits
        struct Cliente //Criando um tipo de dados "Cliente" que recebe varios dados
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientes = new List<Cliente>(); //Criando uma lista de clientes que recebe a struct Cliente
        enum Menu //Opções do menu do usuario
        {
            Listagem = 1, Adicionar, Remover, Sair
        }
        static void Main(string[] args)
        {
            Carregar();
            Console.WriteLine("Sistema de gerenciamento de cliente - Digite sua opção:");
            for (bool op = false; op == false;)
            {
                Console.WriteLine("||Digite sua opção:||");
                Console.WriteLine("||1-Lista de clientes\n||2-Adicionar um cliente\n||3-Remover um cliente\n||4-Sair do programa");
                Menu opcao = (Menu)int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case Menu.Listagem:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        op = true;
                        break;
                }
                Console.Clear();
            }

        }
        static void Adicionar()
        {
            Console.Clear();
            Cliente cliente = new Cliente(); //Instanciando o cliente
            Console.WriteLine("__Cadastro de cliente__");
            Console.WriteLine("Digite o nome do cliente:");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            cliente.email = Console.ReadLine();
            Console.WriteLine("Digite o CPF do cliente:");
            cliente.cpf = Console.ReadLine();

            clientes.Add(cliente);//Adicionando os dados na lista clientes
            Salvar(); // chama afnção para salvar os novos dados
            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
            Console.WriteLine("Aperte enter para voltar ao menu");
            Console.ReadLine();

        }
        static void Listagem()
        {
            Console.Clear();
            if (clientes.Count > 0)
            {
                Console.WriteLine("Lista de clientes cadastrados:");
                int contador = 0;
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID: {contador}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"Email: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    Console.WriteLine("==============================");
                    contador++;
                }
                Console.WriteLine("Aperte enter para voltar ao menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
                Console.WriteLine("Aperte enter para voltar ao menu");
                Console.ReadLine();
            }
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("Clients.dat",FileMode.OpenOrCreate); //Criando um arquivo com formato binario
            BinaryFormatter enconder = new BinaryFormatter();
            enconder.Serialize(stream, clientes); //salvando a lista clientes dentro da stream
            stream.Close();

        }
        static void Carregar()
        {
            FileStream stream = new FileStream("Clients.dat", FileMode.OpenOrCreate); //Criando um arquivo com formato binario
            try
            {
                
                BinaryFormatter enconder = new BinaryFormatter();
                clientes = (List<Cliente>)enconder.Deserialize(stream); //salvando a lista clientes dentro da stream
                if(clientes == null)
                {
                    clientes = new List<Cliente>();
                }
            }
            catch(Exception e)
            {
                clientes = new List<Cliente>();
            }
            stream.Close();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do cliente para remove-lo");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id <= clientes.Count)
            {
                clientes.RemoveAt(id);
                Salvar();
                Console.WriteLine("Cliente removido com sucesso!");
                Console.WriteLine("Aperte enter para voltar ao menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("ID invalido! Digite novamente!");
                Console.ReadLine();
            }
        }
    }
}
