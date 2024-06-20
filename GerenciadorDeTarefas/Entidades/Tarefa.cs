using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GerenciadorDeTarefas.Modelo.Entidade;

public class Tarefa
{
    public string Titulo { get; set; }
    public DateTime CriadoEm { get; private set; }
    public Pessoa Responsavel { get; set; }

    public Tarefa(string titulo, Pessoa responsavel)
    {
        Titulo = titulo;
        CriadoEm = DateTime.Now;
        Responsavel = responsavel;
    }

    public override string ToString()
    {
        return $"Tarefa: {Titulo}, Criado em: {CriadoEm}, Responsável: {Responsavel.Nome}";
    }
}
