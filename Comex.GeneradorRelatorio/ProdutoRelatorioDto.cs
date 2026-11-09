namespace Comex.GeneradorRelatorio;

/// <summary>
/// Representa os dados de um produto a serem incluídos em um relatório exportável.
/// </summary>
public class ProdutoRelatorioDto
{
    /// <summary>
    /// Nome do produto.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do produto.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Preço unitário do produto.
    /// </summary>
    public decimal PrecoUnitario { get; set; }

    /// <summary>
    /// Quantidade disponível do produto.
    /// </summary>
    public int Quantidade { get; set; }
}
