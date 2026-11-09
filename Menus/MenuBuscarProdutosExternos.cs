using Services;

namespace Menus;

public class MenuBuscarProdutosExternos : Menu
{
    private readonly ApiExternaService apiExternaService;

    public MenuBuscarProdutosExternos(ApiExternaService apiExternaService)
        : base("Buscar Produtos em API Externa")
    {
        this.apiExternaService = apiExternaService;
    }

    public override void Executar()
    {
        apiExternaService.BuscarProdutosExternosAsync().GetAwaiter().GetResult();
    }
}
