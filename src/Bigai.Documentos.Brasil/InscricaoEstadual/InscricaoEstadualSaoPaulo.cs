using Bigai.Documentos.Brasil.Helpers;

namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualSaoPaulo
    {
        #region Constantes

        private const int TamanhoMinimoInscricaoEstadualSaoPaulo = 12;

        private const int TamanhoMaximoInscricaoEstadualSaoPaulo = 13;

        private const int PesoInicialSaoPaulo = 2;

        private const int PesoMaximoSaoPaulo = 10;

        private const char ProdutorRural = 'P';

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualSaoPaulo(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoMinimoInscricaoEstadualSaoPaulo &&
                inscricaoEstadual.NumeroDocumento.Length != TamanhoMaximoInscricaoEstadualSaoPaulo)
            {
                return false;
            }

            if (inscricaoEstadual.NumeroDocumento[0] == ProdutorRural)
            {
                return EhProdutorRural(inscricaoEstadual.NumeroDocumento);
            }

            return EhIndustriaOuComercio(inscricaoEstadual);
        }

        #endregion

        #region Métodos Privados

        private static bool EhProdutorRural(string inscricao)
        {
            string baseCalculo = inscricao.Substring(1, 8);

            int digitoVerificadorInformado = int.Parse(inscricao[9].ToString());

            int soma = AplicarPeso(baseCalculo);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            return digitoVerificadorInformado == digitoVerificadorCalculado;
        }

        private static bool EhIndustriaOuComercio(this InscricaoEstadual inscricaoEstadual)
        {
            int[] digitoVerificadorCalculado = { 0, 0 };

            int[] digitoVerificadorInformado = { int.Parse(inscricaoEstadual.NumeroDocumento[8].ToString()),
                                                 int.Parse(inscricaoEstadual.NumeroDocumento[11].ToString()) };

            int posicaoInicial = 0;
            int tamanho;
            string baseCalculo;

            for (int i = 0; i < 2; i++)
            {
                int soma;

                if (i == 0)
                {
                    tamanho = 8;
                    baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

                    soma = AplicarPeso(baseCalculo);
                }
                else
                {
                    tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;
                    baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

                    soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialSaoPaulo, PesoMaximoSaoPaulo);
                }

                digitoVerificadorCalculado[i] = CalcularDigitoDeControle(soma);
            }

            return (digitoVerificadorInformado[0] == digitoVerificadorCalculado[0] && digitoVerificadorInformado[1] == digitoVerificadorCalculado[1]);
        }

        private static int AplicarPeso(string num)
        {
            int[] peso = { 1, 3, 4, 5, 6, 7, 8, 10 };

            return PesoHelper.AplicarPesoDaDireitaParaEsquerda(num, peso);
        }

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 11) >= 10 ? ((valor % 11) - 10) : (valor % 11);
        }

        #endregion
    }
}