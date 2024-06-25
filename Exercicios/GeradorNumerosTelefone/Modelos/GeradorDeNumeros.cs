namespace GeradorNumerosTelefone.Modelos;

public static class GeradorDeNumeros
{
   public static string GeraNumeroMovel()
    {
        Random rnd = new Random();

        var num = rnd.Next(10000000, 99999999).ToString();

        return $"9{num}";
    }

    public static string GeraNumeroFixo()
    {
        //(Formato: 2XXX-XXXX; 3XXX-XXXX; 4XXX-XXXX; 5XXX-XXXX)
        Random rnd = new Random();

        var NumFix = rnd.Next(2, 6).ToString();
        var num = rnd.Next(1000000, 9999999).ToString();
        return $"{NumFix}{num}";
    }

    public static string GeraNumeroNaoDefinido()
    {
        Random random = new Random();

        var tipoNumeroSorteado = random.Next(1, 2);
        if (tipoNumeroSorteado == 1)
            return GeraNumeroFixo();
        else 
            return GeraNumeroMovel();
    }

}
