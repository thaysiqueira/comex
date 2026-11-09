using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Models;

namespace Services;

public class ApiExternaService
{
    private const string UrlProdutos = "https://fakestoreapi.com/products";

    private static readonly HttpClient httpClient = new HttpClient();

    private List<Produto> produtosConsultados = new List<Produto>();

    public async Task BuscarProdutosExternosAsync()
    {
        Console.WriteLine("\nConsultando API externa de produtos...\n");

        try
        {
            HttpResponseMessage resposta = await httpClient.GetAsync(UrlProdutos);
            resposta.EnsureSuccessStatusCode();

            string jsonBruto = await resposta.Content.ReadAsStringAsync();

            File.WriteAllText("produtos.json", jsonBruto);
            Console.WriteLine("Conteúdo bruto da API salvo em 'produtos.json'.\n");

            var produtosExternos = JsonSerializer.Deserialize<List<ProdutoExterno>>(jsonBruto);

            if (produtosExternos is null || produtosExternos.Count == 0)
            {
                Console.WriteLine("Nenhum produto retornado pela API externa.");
                return;
            }

            List<Produto> produtos = produtosExternos
                .Select(p => new Produto(p.Title, p.Category, p.Price, 0))
                .ToList();

            produtosConsultados = produtos;

            Console.WriteLine($"Consulta realizada com sucesso! Total de produtos encontrados: {produtos.Count}\n");
            foreach (var produto in produtos)
            {
                produto.ExibirDescricao();
            }

            Console.WriteLine("\nBusca na API externa finalizada com sucesso.");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao conectar com a API externa: {ex.Message}");
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"A requisição à API externa excedeu o tempo limite: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao interpretar a resposta da API externa: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado ao consultar a API externa: {ex.Message}");
        }
    }

    public void OrdenarProdutosPorNome()
    {
        if (produtosConsultados.Count == 0)
        {
            Console.WriteLine("\nNenhum produto consultado. Realize a busca na API externa primeiro.");
            return;
        }

        var produtosOrdenados = produtosConsultados
            .OrderBy(produto => produto.Nome)
            .ToList();

        Console.WriteLine("\nProdutos ordenados por nome (título):\n");
        foreach (var produto in produtosOrdenados)
        {
            produto.ExibirDescricao();
        }
    }

    public void OrdenarProdutosPorPreco()
    {
        if (produtosConsultados.Count == 0)
        {
            Console.WriteLine("\nNenhum produto consultado. Realize a busca na API externa primeiro.");
            return;
        }

        var produtosOrdenados = produtosConsultados
            .OrderBy(produto => produto.PrecoUnitario)
            .ToList();

        Console.WriteLine("\nProdutos ordenados por preço:\n");
        foreach (var produto in produtosOrdenados)
        {
            produto.ExibirDescricao();
        }
    }

    private class ProdutoExterno
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

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
