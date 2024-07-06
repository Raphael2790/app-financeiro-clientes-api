using AppFinanceiro.AgioBank.Domain.Common;
using AppFinanceiro.AgioBank.Domain.Validators;

namespace AppFinanceiro.AgioBank.Domain.ValueObjects;
public class Telefone(string telefone) : ObjetoNotificavel
{    
    private const int Length = 19;

    public string CodPais { get; private set; } = string.IsNullOrEmpty(telefone) || telefone.Length != Length ? string.Empty : telefone[1..3];
    public string DDD { get; private set; } = string.IsNullOrEmpty(telefone) || telefone.Length != Length ? string.Empty : telefone[5..7]; 
    public string Numero { get; private set; } = string.IsNullOrEmpty(telefone) || telefone.Length != Length ? string.Empty : telefone[9..];
    public bool EValido { get; set; }

    public override string ToString()
    {
        return $"+{CodPais} ({DDD}) {Numero}";
    }

    public void Validar()
    {
        base.Validar(TelefoneValidador.Instance, this);
    }
}
