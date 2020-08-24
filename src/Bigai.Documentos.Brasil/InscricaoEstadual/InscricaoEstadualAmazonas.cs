namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualAmazonas
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualAmazonas = 9;

        private const int PesoInicialAmazonas = 2;

        private const int PesoMaximoAmazonas = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualAmazonas(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualAmazonas)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialAmazonas, PesoMaximoAmazonas);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            int digitoVerificadorCalculado;

            if (valor < 11)
                digitoVerificadorCalculado = 11 - valor;
            else
                digitoVerificadorCalculado = (valor % 11) <= 1 ? 0 : 11 - (valor % 11);

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}