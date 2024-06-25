using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Modelo.Entidade;

public class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public Pessoa(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public override string ToString()
    {
        return $"{this.Nome},{this.Email}";
    }
    public string Adicionar(string nome, string email)
    {
        this.Nome = nome;
        this.Email = email;

        return $"{this.Nome}, {this.Email}";
    }
}

