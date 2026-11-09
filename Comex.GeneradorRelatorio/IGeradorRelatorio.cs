namespace Comex.GeneradorRelatorio;

/// <summary>
/// Define o contrato para geradores de relatório de produtos, permitindo
/// implementações desacopladas que seguem o Princípio Aberto/Fechado (OCP).
/// </summary>
public interface IGeradorRelatorio
{
    /// <summary>
    /// Exporta a coleção de produtos para um arquivo de relatório.
    /// </summary>
    /// <param name="produtos">Coleção de produtos a serem exportados.</param>
    /// <param name="caminhoArquivo">Caminho (relativo ou absoluto) do arquivo a ser gerado.</param>
    /// <returns>O caminho absoluto do arquivo de relatório gerado.</returns>
    string Exportar(IEnumerable<ProdutoRelatorioDto> produtos, string caminhoArquivo);
}
