namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualRioGrandeDoSul
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualRioGrandeDoSul = 10;

        private const int PesoInicialRioGrandeDoSul = 2;

        private const int PesoMaximoRioGrandeDosul = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualRioGrandeDoSul(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualRioGrandeDoSul)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialRioGrandeDoSul, PesoMaximoRioGrandeDosul);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            int digitoVerificadorCalculado = 11 - (valor % 11);
            if (digitoVerificadorCalculado == 10 || digitoVerificadorCalculado == 11)
            {
                digitoVerificadorCalculado = 0;
            }

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}