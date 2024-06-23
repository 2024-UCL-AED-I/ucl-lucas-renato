using GerenciadorDeTarefas.Services;
using GerenciadorDeTarefas.Modelo;
using GerenciadorDeTarefas.Modelo.Entidade;
using System;

namespace GerenciadorDeTarefas;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MenuPrincipal();
    }
}

