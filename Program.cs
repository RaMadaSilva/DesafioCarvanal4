using System.Text;

namespace DesafioCarnaval4;
class Program
{
    static readonly double[] cedulas = { 200, 100, 50, 20, 10, 5, 2, 1 };
    static void Main(string[] args)
    {
        try
        {
            Console.Write("- Valor Final da Compra: R$ ");
            double.TryParse(Console.ReadLine(), out double valorCompra);
            Console.Write("- Pagamento: R$ ");
            double.TryParse(Console.ReadLine(), out double pagamento);
            if (pagamento < valorCompra)
                throw new ValorNegativoException("valor da pago inferior ao valor da compra");
            var troco = ValorTroco(pagamento, valorCompra);
            var dinheiro = DarToco(troco);
            Console.WriteLine($"- Troco: \n{dinheiro}");
        }
        catch (ValorNegativoException vn)
        {
            Console.WriteLine("error de valores: " + vn.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("erro Interno : " + e.Message);
        }
    }

    static double ValorTroco(double pagamento, double valorCompra)
        => pagamento - valorCompra;


    static string DarToco(double _troco)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var cedula in cedulas)
        {
            int quantidade = (int)(_troco / cedula);
            if (quantidade > 0)
            {
                _troco -= (quantidade * cedula);
                sb.Append($"   - {quantidade} nota de {cedula} reais\n");
            }
        }
        return sb.ToString();
    }
}

public class ValorNegativoException : Exception
{
    public ValorNegativoException(string message) : base(message)
    {
    }
}
