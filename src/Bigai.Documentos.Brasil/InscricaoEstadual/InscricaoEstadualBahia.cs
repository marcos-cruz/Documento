namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualBahia
    {
        #region Constantes

        private const int TamanhoMinimoInscricaoEstadualBahia = 8;

        private const int TamanhoMaximoInscricaoEstadualBahia = 9;

        private const int PesoInicialBahia = 2;

        private const int PesoMaximoBahia = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualBahia(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoMinimoInscricaoEstadualBahia &&
                inscricaoEstadual.NumeroDocumento.Length != TamanhoMaximoInscricaoEstadualBahia)
            {
                return false;
            }

            int[] digitoVerificadorCalculado = { 0, 0 };
            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 2;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            for (int i = 1; i >= 0; i--)
            {
                bool primeiroDigito = i == 1;

                int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialBahia, PesoMaximoBahia);

                digitoVerificadorCalculado[i] = CalcularDigitoDeControle(soma, baseCalculo[0], primeiroDigito);

                baseCalculo += digitoVerificadorCalculado[i];
            }

            int[] digitoVerificadorInformado = inscricaoEstadual.ObterUltimosDoisDigitosDeControleInformados();

            return (digitoVerificadorInformado[0] == digitoVerificadorCalculado[0] && digitoVerificadorInformado[1] == digitoVerificadorCalculado[1]);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor, char digito, bool primeiroDigito)
        {
            int digitoVerificadorCalculado;

            if (digito == '0' || digito == '1' || digito == '2' || digito == '3' ||
                digito == '4' || digito == '5' || digito == '8')
                digitoVerificadorCalculado = ((valor % 10) == 0) ? 0 : 10 - (valor % 10);
            else
                digitoVerificadorCalculado = primeiroDigito && (11 - (valor % 11) <= 1) ? 0 : (11 - (valor % 11));

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}