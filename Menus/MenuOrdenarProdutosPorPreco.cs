using Services;

namespace Menus;

public class MenuOrdenarProdutosPorPreco : Menu
{
    private readonly ApiExternaService apiExternaService;

    public MenuOrdenarProdutosPorPreco(ApiExternaService apiExternaService)
        : base("Ordenar Produtos Externos por Preço")
    {
        this.apiExternaService = apiExternaService;
    }

    public override void Executar()
    {
        apiExternaService.OrdenarProdutosPorPreco();
    }
}
