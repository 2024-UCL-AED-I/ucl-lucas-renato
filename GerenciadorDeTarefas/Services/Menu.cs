
using System;
using System.IO;
using System.Text;
using GerenciadorDeTarefas.Modelo.Entidade;
using System;
using System.Xml;



namespace GerenciadorDeTarefas.Services
{
    public class Menu
    {
        private List<Tarefa> tarefas;
        private List<Pessoa> pessoas;

        string arquivoTarefas = @"D:\Git Projeto\ucl-lucas-renato\GerenciadorDeTarefas\Arquivos\Tarefas.txt";
        string arquivoPessoas = @"D:\Git Projeto\ucl-lucas-renato\GerenciadorDeTarefas\Arquivos\Pessoas.txt";
        private string ArquivoTarefas = "Tarefas.txt";
        private string ArquivoPessoas = "Pessoas.txt";

        public Menu()
        {
            tarefas = new List<Tarefa>();
            pessoas = new List<Pessoa>();
        }

        public void MenuPrincipal()
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("=------Gerenciando Tarefas------=");
                Console.WriteLine("=================================");
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

        static void CarregarPessoas()
        {
            
            using (FileStream arquivoPessoa = new FileStream(@"D:\Git Projeto\ucl-lucas-renato\GerenciadorDeTarefas\Arquivos\Pessoas.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(arquivoPessoa, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string leitor = sr.ReadLine();
                    Console.WriteLine(leitor);
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
                ImprimeMensagemComConfirmacao("Pessoa não encontrada. Tarefa não adicionada.");
                return;
            }

            Tarefa tarefa = new Tarefa(titulo, responsavel);

            tarefas.Add(tarefa);

            ImprimeMensagemComConfirmacao("Tarefa adicionada com sucesso");
        }

        private void RemoverTarefa()
        {
            Console.Write("Título da Tarefa a ser removida: ");
            string titulo = Console.ReadLine();

            Tarefa tarefa = tarefas.Find(t => t.Titulo == titulo);

            if (tarefa != null)
            {
                tarefas.Remove(tarefa);
                ImprimeMensagemComConfirmacao("Tarefa removida com sucesso");
            }
            else
            {
                ImprimeMensagemComConfirmacao("Tarefa não encontrada");
            }
        }

        private void ListarTarefas()
        {
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa);
                ImprimeMensagemComConfirmacao("Clique em qualquer tecla para continuar.");
            }
        }

        private void AdicionarPessoa()
        {
            Console.Write("Nome da Pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("Email da Pessoa: ");
            string email = Console.ReadLine();

            Pessoa pessoa = new Pessoa(nome, email);

            FileStream arquivoPessoa = new FileStream(arquivoPessoas, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(arquivoPessoa, Encoding.UTF8);

            pessoas.Add(pessoa);

            sw.WriteLine(pessoa);
            sw.Close();
            arquivoPessoa.Close();

            ImprimeMensagemComConfirmacao("Pessoa adicionada com sucesso");
        }

        private void ListarPessoas()
        {
            CarregarPessoas();
            ImprimeMensagemComConfirmacao("Clique em qualquer tecla para continuar.");
        }


        private void ImprimeMensagemComConfirmacao(string mensagem)
        {
            Console.WriteLine($"{mensagem}. Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}






