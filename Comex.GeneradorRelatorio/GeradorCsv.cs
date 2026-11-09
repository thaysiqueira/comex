using System.Globalization;
using System.Text;

namespace Comex.GeneradorRelatorio;

/// <summary>
/// Implementação de <see cref="IGeradorRelatorio"/> que exporta os dados
/// dos produtos em formato CSV.
/// </summary>
public class GeradorCsv : IGeradorRelatorio
{
    /// <summary>
    /// Exporta a coleção de produtos para um arquivo no formato CSV.
    /// </summary>
    /// <param name="produtos">Coleção de produtos a serem exportados.</param>
    /// <param name="caminhoArquivo">Caminho (relativo ou absoluto) do arquivo .csv a ser gerado.</param>
    /// <returns>O caminho absoluto do arquivo .csv gerado.</returns>
    public string Exportar(IEnumerable<ProdutoRelatorioDto> produtos, string caminhoArquivo)
    {
        ArgumentNullException.ThrowIfNull(produtos);

        if (string.IsNullOrWhiteSpace(caminhoArquivo))
            throw new ArgumentException("O caminho do arquivo é obrigatório.", nameof(caminhoArquivo));

        var conteudo = new StringBuilder();
        conteudo.AppendLine("Nome;Descricao;PrecoUnitario;Quantidade");

        foreach (var produto in produtos)
        {
            conteudo.AppendLine(string.Join(';',
                Escapar(produto.Nome),
                Escapar(produto.Descricao),
                produto.PrecoUnitario.ToString(CultureInfo.InvariantCulture),
                produto.Quantidade.ToString(CultureInfo.InvariantCulture)));
        }

        File.WriteAllText(caminhoArquivo, conteudo.ToString(), Encoding.UTF8);

        return Path.GetFullPath(caminhoArquivo);
    }

    /// <summary>
    /// Escapa um valor de texto para uso seguro em uma célula CSV.
    /// </summary>
    /// <param name="valor">Valor de texto a ser escapado.</param>
    /// <returns>O valor pronto para ser escrito no arquivo CSV.</returns>
    private static string Escapar(string valor)
    {
        valor ??= string.Empty;

        if (valor.Contains(';') || valor.Contains('"') || valor.Contains('\n'))
            return $"\"{valor.Replace("\"", "\"\"")}\"";

        return valor;
    }
}
