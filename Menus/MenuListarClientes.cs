using Services;

namespace Menus;

public class MenuListarClientes : Menu
{
    private readonly ClienteService clienteService;

    public MenuListarClientes(ClienteService clienteService)
        : base("Listar Clientes")
    {
        this.clienteService = clienteService;
    }

    public override void Executar()
    {
        clienteService.ListarClientes();
    }
}
