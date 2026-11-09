using Services;

namespace Menus;

public class MenuOrdenarProdutosPorNome : Menu
{
    private readonly ApiExternaService apiExternaService;

    public MenuOrdenarProdutosPorNome(ApiExternaService apiExternaService)
        : base("Ordenar Produtos Externos por Nome")
    {
        this.apiExternaService = apiExternaService;
    }

    public override void Executar()
    {
        apiExternaService.OrdenarProdutosPorNome();
    }
}
