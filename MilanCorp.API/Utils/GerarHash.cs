using System;

namespace MilanCorp.API.Utils
{
    public class GerarHash
    {
        //METODO QUE VAI GERAR O CODIGO
        public static string GerarCodigo()
        {
            int Tamanho = 10; // Numero de digitos do codigo
            string codigo = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int numero = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((numero >= 48 && numero <= 57) || (numero >= 97 && numero <= 122))
                {
                    string _char = ((char)numero).ToString();
                    if (!codigo.Contains(_char))
                    {
                        codigo += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return codigo;
        }
    }
}
