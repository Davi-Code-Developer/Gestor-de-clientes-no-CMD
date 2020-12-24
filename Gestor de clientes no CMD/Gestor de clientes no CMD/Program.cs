using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_clientes_no_CMD
{
    class Program
    {
        enum Menu //Opções do menu do usuario
        {
            Listagem = 1, Adicionar, Remover, Sair
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Sistema de gerenciamento de cliente - Digite sua opção:");
            for (bool op = false; op == false;)
            {
                Console.WriteLine("||Digite sua opção:||");
                Console.WriteLine("||1-Lista de clientes\n||2-Adicionar um cliente\n||3-Remover um cliente\n||4-Sair do programa");
                Menu opcao = (Menu)int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case Menu.Adicionar:
                        break;
                    case Menu.Listagem:
                        break;
                    case Menu.Remover:
                        break;
                    case Menu.Sair:
                        op = true;
                        break;
                }
                Console.Clear();
            }

        }
    }
}
