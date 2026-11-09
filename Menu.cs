using System;

/// <summary>
/// Classe base abstrata para todas as opções de menu do Comex.
/// Cada opção concreta herda desta classe e implementa <see cref="Executar"/>.
/// </summary>
public abstract class Menu
{
    /// <summary>
    /// Texto exibido para o usuário identificando a opção de menu.
    /// </summary>
    public string Titulo { get; }

    protected Menu(string titulo)
    {
        Titulo = titulo;
    }

    /// <summary>
    /// Executa a ação associada a esta opção de menu.
    /// </summary>
    public abstract void Executar();
}
