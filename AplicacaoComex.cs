using System;
using System.Collections.Generic;

/// <summary>
/// Coordena a execução do sistema Comex, exibindo o dicionário de opções de menu
/// e delegando a execução para a opção escolhida de forma polimórfica.
/// </summary>
public class AplicacaoComex
{
    private readonly Dictionary<string, Menu> menus;

    public AplicacaoComex(Dictionary<string, Menu> menus)
    {
        this.menus = menus;
    }

    public void Executar()
    {
        string? opcao = "";

        while (opcao != "-1")
        {
            try
            {
                ExibirOpcoes();

                opcao = Console.ReadLine();
                Console.WriteLine($"Opção escolhida: {opcao}");

                if (opcao == "-1")
                {
                    break;
                }

                if (opcao is not null && menus.TryGetValue(opcao, out Menu? menu))
                {
                    menu.Executar();
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        Console.WriteLine("COMEX FINALIZADO!");
    }

    private void ExibirOpcoes()
    {
        Console.WriteLine("\n============= PROJETO COMEX =============");
        Console.WriteLine("\nEscolha uma opção:");

        foreach (var item in menus)
        {
            Console.WriteLine($"{item.Key} - {item.Value.Titulo}");
        }

        Console.WriteLine("-1 - Sair");
        Console.Write("> ");
    }
}
