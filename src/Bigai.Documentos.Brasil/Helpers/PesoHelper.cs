using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Bigai.Documentos.Brasil.Tests")]
namespace Bigai.Documentos.Brasil.Helpers
{
    internal static class PesoHelper
    {
        /// <summary>
        /// Determina a somatória resultante da multiplicação de cada digito de um número pelo peso correspondente,
        /// iniciando da direita do número para a esquerda.
        /// </summary>
        /// <param name="numero">Representa o valor para o calculo do peso, sem máscara de edição.</param>
        /// <param name="pesoInicial">Representa o valor inicial do peso que será aplicado ao número.</param>
        /// <param name="pesoMaximo">Representa o valor máximo que o peso pode assumir.</param>
        /// <returns>Retorna a somatória resultante do peso multiplicado por cada digito do número.</returns>
        internal static int AplicarPesoDaDireitaParaEsquerda(this string numero, int pesoInicial, int pesoMaximo)
        {
            int soma = 0;

            if (!string.IsNullOrEmpty(numero))
            {
                for (int i = numero.Length - 1, p = pesoInicial; i >= 0; i--)
                {
                    soma += int.Parse(numero[i].ToString()) * p++;

                    if (p > pesoMaximo)
                        p = pesoInicial;
                }
            }

            return soma;
        }

        /// <summary>
        /// Determina a somatória resultante da multiplicação de cada digito de um número pelo peso correspondente,
        /// iniciando da direita do número para a esquerda.
        /// </summary>
        /// <param name="numero">Representa o valor para o calculo do peso.</param>
        /// <param name="peso">Representa um array com os valores dos pesos que serão aplicados a cada digito do número.</param>
        /// <returns>Retorna a somatória resultante do peso multiplicado por cada digito do número.</returns>
        internal static int AplicarPesoDaDireitaParaEsquerda(this string numero, int[] peso)
        {
            int soma = 0;

            if (!string.IsNullOrEmpty(numero) && peso != null && peso.Length > 0)
            {
                for (int i = numero.Length - 1, j = peso.Length; i >= 0 && j >= i; i--)
                {
                    soma += int.Parse(numero[i].ToString()) * peso[i];
                }
            }

            return soma;
        }

        /// <summary>
        /// Determina a somatória resultante da multiplicação de cada digito de um número pelo peso correspondente,
        /// iniciando da esquerda do número para a direita.
        /// </summary>
        /// <param name="numero">Representa o valor para o calculo do peso.</param>
        /// <param name="peso">Representa um array com os valores dos pesos que serão aplicados a cada digito do número.</param>
        /// <returns>Retorna a somatória resultante do peso multiplicado por cada digito do número.</returns>
        internal static int AplicarPesoDaEsquerdaParaDireita(this string numero, int[] peso)
        {
            int soma = 0;

            if (!string.IsNullOrEmpty(numero) && peso != null && peso.Length > 0)
            {
                for (int i = 0, j = (numero.Length - 1), k = peso.Length; i < j && i < k; i++)
                    soma += int.Parse(numero[i].ToString()) * peso[i];
            }

            return soma;
        }
    }
}
