using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Bigai.Documentos.Brasil.Tests")]
namespace Bigai.Documentos.Brasil.Helpers
{
    internal static class DocumentoHelper
    {
        internal static string[] estadosBrasileiros = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
        internal static string[] domicilioEleitoral = { "24", "17", "25", "22", "05", "07", "20", "14", "10", "11", "18", "19", "02", "13", "12", "06", "08", "15", "03", "16", "04", "23", "26", "09", "01", "21", "27" };
        
        /// <summary>
        /// Remove os caracteres '.', '-' e '/' utilizados na edição de um documento.
        /// </summary>
        /// <param name="valor">Representa o valor para remover os caracteres de edição.</param>
        /// <returns>Retorna o valor sem os caracteres de edição.</returns>
        internal static string RemoverMascaraEdicao(this string valor)
        {
            return string.IsNullOrEmpty(valor) ? valor : valor
                .Replace(".", "")
                .Replace("-", "")
                .Replace("/", "");
        }

        /// <summary>
        /// Determina se uma variável foi preenchida com o mesmo caracter, por exemplo, 1111111 ou aaaaaaa.
        /// </summary>
        /// <param name="valor">Representa o valor que será verificado o preenchimento.</param>
        /// <returns>Retorna <c>true</c> se estiver preenchido com caracteres repetidos, caso contrário <c>false</c>.</returns>
        internal static bool TemCaracterRepetido(this string valor)
        {
            bool temCaracterRepetido = false;

            if (!string.IsNullOrEmpty(valor) && valor.Length > 1)
            {
                temCaracterRepetido = true;
                int j = valor.Length;

                for (int i = 1; i < j && temCaracterRepetido; i++)
                {
                    if (valor[i] != valor[0])
                        temCaracterRepetido = false;
                }
            }

            return temCaracterRepetido;
        }

        /// <summary>
        /// Determina se uma string esta preenchida somente com digitos de 0 a 9.
        /// </summary>
        /// <param name="valor">Representa o valor que será verificado o preenchimento.</param>
        /// <returns>Retorna <c>true</c> se estiver preenchida somente com números, caso contrário <c>false</c>.</returns>
        internal static bool EhUmNumeroPositivo(this string valor)
        {
            bool inteiroPositivo = false;

            if (!string.IsNullOrEmpty(valor))
            {
                inteiroPositivo = long.TryParse(valor, out long n);
                if (n < 0)
                    inteiroPositivo = false;
            }
            return inteiroPositivo;
        }

        /// <summary>
        /// Determina se uma sigla pertence corresponde a sigla de um estado brasileiro.
        /// </summary>
        /// <param name="uf">Sigla do estado composta por 2 letras, segundo a norma ISO-3166.</param>
        /// <returns>Retorna <c>true</c> se a sigla pertencer a um estado brasileiro, caso contrário <c>false</c>.</returns>
        internal static bool EhUmaUf(this string uf)
        {
            bool valido = false;

            if (!string.IsNullOrEmpty(uf))
            {
                for (int i = 0, j = estadosBrasileiros.Length; i < j; i++)
                {
                    if (uf == estadosBrasileiros[i])
                    {
                        valido = true;
                        i = j;
                    }
                }
            }
            return valido;
        }

        /// <summary>
        /// Determina a sigla do estado que corresponde ao código do domicilio eleitoral.
        /// </summary>
        /// <param name="codigoDomicilioEleitoral">Código do domicilio eleitoral.</param>
        /// <returns>Retorna a sigla do estado composta por 2 letras, segundo a norma ISO-3166, se o domicilio pertencer
        /// a um estado no território nacional, caso contrário o próprio código de domício eleitoral.</returns>
        internal static string ToDomicilioEleitoral(this string codigoDomicilioEleitoral)
        {
            string ufDomicilioEleitoral = codigoDomicilioEleitoral;

            if (!string.IsNullOrEmpty(codigoDomicilioEleitoral))
            {
                for (int i = 0, j = domicilioEleitoral.Length; i < j; i++)
                {
                    if (codigoDomicilioEleitoral == domicilioEleitoral[i])
                    {
                        ufDomicilioEleitoral = estadosBrasileiros[i];
                        i = j;
                    }
                }
            }

            return ufDomicilioEleitoral;
        }
    }
}
