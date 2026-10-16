using System;

public class Endereco
{
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
    public string Numero { get; set; }

    public Endereco(string estado, string cidade, string bairro, string rua, string numero, string complemento = "")
    {
        if (string.IsNullOrWhiteSpace(estado))
            throw new ArgumentException("O estado é obrigatório.", nameof(estado));

        if (string.IsNullOrWhiteSpace(cidade))
            throw new ArgumentException("A cidade é obrigatória.", nameof(cidade));

        if (string.IsNullOrWhiteSpace(rua))
            throw new ArgumentException("A rua é obrigatória.", nameof(rua));

        Estado = estado;
        Cidade = cidade;
        Bairro = bairro;
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
    }

    public override string ToString()
    {
        var complemento = string.IsNullOrWhiteSpace(Complemento) ? "" : $" - {Complemento}";
        return $"{Rua}, {Numero}{complemento} - {Bairro}, {Cidade}/{Estado}";
    }
}
