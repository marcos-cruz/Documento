namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualAcre
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualAcre = 13;

        private const string CodigoEstadoAcre = "01";

        private const int PesoInicialAcre = 2;

        private const int PesoMaximoAcre = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualAcre(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualAcre || !inscricaoEstadual.IniciaCom(CodigoEstadoAcre))
            {
                return false;
            }

            int[] digitoVerificadorCalculado = { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                int posicaoInicial = 0;
                int tamanho = inscricaoEstadual.NumeroDocumento.Length - 2 + i;

                string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

                int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialAcre, PesoMaximoAcre);

                digitoVerificadorCalculado[i] = CalcularDigitoDeControle(soma % 11);
            }

            int[] digitoVerificadorInformado = inscricaoEstadual.ObterUltimosDoisDigitosDeControleInformados();

            return (digitoVerificadorInformado[0] == digitoVerificadorCalculado[0] && digitoVerificadorInformado[1] == digitoVerificadorCalculado[1]);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            return (11 - (valor % 11)) >= 10 ? 0 : (11 - (valor % 11));
        }

        #endregion
    }
}
