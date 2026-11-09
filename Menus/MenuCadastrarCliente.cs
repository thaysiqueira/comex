using Services;

namespace Menus;

public class MenuCadastrarCliente : Menu
{
    private readonly ClienteService clienteService;

    public MenuCadastrarCliente(ClienteService clienteService)
        : base("Cadastrar Cliente")
    {
        this.clienteService = clienteService;
    }

    public override void Executar()
    {
        clienteService.CadastrarCliente();
    }
}
