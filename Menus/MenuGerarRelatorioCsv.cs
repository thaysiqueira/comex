using System.Text.Json;
using System.Text.Json.Serialization;
using Comex.GeneradorRelatorio;

namespace Menus;

/// <summary>
/// Opção de menu que lê o arquivo produtos.json persistido, trata os dados via LINQ
/// e gera um relatório CSV utilizando a biblioteca Comex.GeneradorRelatorio.
/// </summary>
public class MenuGerarRelatorioCsv : Menu
{
    private const string CaminhoJson = "produtos.json";
    private const string CaminhoCsv = "relatorio_produtos.csv";

    public MenuGerarRelatorioCsv()
        : base("Gerar Relatório CSV")
    {
    }

    public override void Executar()
    {
        if (!File.Exists(CaminhoJson))
        {
            Console.WriteLine($"\nArquivo '{CaminhoJson}' não encontrado. Execute a busca na API externa (opção 8) primeiro.");
            return;
        }

        string jsonBruto = File.ReadAllText(CaminhoJson);

        var produtosExternos = JsonSerializer.Deserialize<List<ProdutoJson>>(jsonBruto);

        if (produtosExternos is null || produtosExternos.Count == 0)
        {
            Console.WriteLine("\nNenhum produto encontrado no arquivo JSON.");
            return;
        }

        List<ProdutoRelatorioDto> produtos = produtosExternos
            .Where(produto => produto.Price > 0)
            .OrderByDescending(produto => produto.Price)
            .Select(produto => new ProdutoRelatorioDto
            {
                Nome = produto.Title,
                Descricao = produto.Description,
                PrecoUnitario = produto.Price,
                Quantidade = 0
            })
            .ToList();

        IGeradorRelatorio gerador = new GeradorCsv();
        string caminhoSalvo = gerador.Exportar(produtos, CaminhoCsv);

        Console.WriteLine($"\nRelatório gerado com sucesso! Total de produtos: {produtos.Count}");
        Console.WriteLine($"Arquivo salvo em: {caminhoSalvo}");
    }

    private class ProdutoJson
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
    }
}
