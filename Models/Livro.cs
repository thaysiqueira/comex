using Models;

public class Livro : Produto
{
	public Livro(string nome, string descricao, decimal precoUnitario, int quantidade,
        string isbn, int totalDePaginas)
        : base(nome, descricao, precoUnitario, quantidade)
    {
		Isbn = isbn;
		TotalDePaginas = totalDePaginas;
	}

	public string Isbn { get; private set; }
	public int TotalDePaginas { get; private set; }

	public override void ExibirDescricao()
    {
        Console.WriteLine($"ISBN: {Isbn}, Total de Páginas: {TotalDePaginas}");
    }
}
