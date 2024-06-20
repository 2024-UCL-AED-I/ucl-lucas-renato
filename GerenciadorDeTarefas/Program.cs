using GerenciadorDeTarefas.Services;
using System;

namespace GerenciadorDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            menuService.DisplayMenu();
        }
    }
}

