using Services;

namespace Menus;

public class MenuFecharCompra : Menu
{
    private readonly ClienteService clienteService;

    public MenuFecharCompra(ClienteService clienteService)
        : base("Fechar Compra")
    {
        this.clienteService = clienteService;
    }

    public override void Executar()
    {
        clienteService.FecharCompra();
    }
}
