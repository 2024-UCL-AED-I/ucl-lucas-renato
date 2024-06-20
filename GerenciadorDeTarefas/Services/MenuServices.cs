using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GerenciadorDeTarefas.Modelo.Entidade;
using System;
using System.Collections.Generic;

namespace GerenciadorDeTarefas.Services
{
    public class MenuService
    {
        private List<Tarefa> tarefas;
        private List<Pessoa> pessoas;

        public MenuService()
        {
            tarefas = new List<Tarefa>();
            pessoas = new List<Pessoa>();
        }

        public void DisplayMenu()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Remover Tarefa");
                Console.WriteLine("3. Listar Tarefas");
                Console.WriteLine("4. Adicionar Pessoa");
                Console.WriteLine("5. Listar Pessoas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarTarefa();
                        break;
                    case 2:
                        RemoverTarefa();
                        break;
                    case 3:
                        ListarTarefas();
                        break;
                    case 4:
                        AdicionarPessoa();
                        break;
                    case 5:
                        ListarPessoas();
                        break;
                    case 6:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private void AdicionarTarefa()
        {
            Console.Write("Título da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Responsável (Nome do Responsável): ");
            string nomeResponsavel = Console.ReadLine();

            var responsavel = pessoas.Find(p => p.Nome == nomeResponsavel);

            if (responsavel == null)
            {
                Console.WriteLine("Pessoa não encontrada. Tarefa não adicionada.");
                return;
            }

            Tarefa tarefa = new Tarefa(titulo, responsavel);
            tarefas.Add(tarefa);
            Console.WriteLine("Tarefa adicionada com sucesso.");
        }

        private void RemoverTarefa()
        {
            Console.Write("Título da Tarefa a ser removida: ");
            string titulo = Console.ReadLine();

            Tarefa tarefa = tarefas.Find(t => t.Titulo == titulo);

            if (tarefa != null)
            {
                tarefas.Remove(tarefa);
                Console.WriteLine("Tarefa removida com sucesso.");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        private void ListarTarefas()
        {
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa);
            }
        }

        private void AdicionarPessoa()
        {
            Console.Write("Nome da Pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("Email da Pessoa: ");
            string email = Console.ReadLine();

            Pessoa pessoa = new Pessoa(nome, email);
            pessoas.Add(pessoa);

            Console.WriteLine("Pessoa adicionada com sucesso.");
        }

        private void ListarPessoas()
        {
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine(pessoa);
            }
        }
    }
}

