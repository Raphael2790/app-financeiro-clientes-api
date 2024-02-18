using System.Text.RegularExpressions;

namespace AppFinanceiro.AgioBank.Domain.ValueObjects;
public class Telefone
{
    private const string pattern = @"^\+\d{2} \(\d{2}\) \d{5}-\d{4}$";
    private Regex regex = new Regex(pattern, RegexOptions.Compiled);

    public string CodPais { get; private set; }
    public string DDD { get; private set; }
    public string Numero { get; private set; }
    public bool EValido { get; set; }

    public Telefone(string telefone)
    {
        EValido = Validar(telefone);

        if(EValido)
        {
            CodPais = telefone[1..2];
            DDD = telefone[4..5];
            Numero = telefone[7..];
        }
    }
    private bool Validar(string telefone) => regex.IsMatch(telefone);
}
