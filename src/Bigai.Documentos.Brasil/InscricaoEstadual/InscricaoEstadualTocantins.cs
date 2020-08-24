namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualTocantins
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualTocantins = 11;

        private const int PesoInicialTocantins = 2;

        private const int PesoMaximoTocantins = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualTocantins(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualTocantins)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = 2;
            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            posicaoInicial = 4;
            tamanho = inscricaoEstadual.NumeroDocumento.Length - 5;
            baseCalculo += inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialTocantins, PesoMaximoTocantins);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 11) < 2 ? 0 : 11 - (valor % 11);
        }

        #endregion
    }
}