namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualSantaCatarina
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualSantaCatarina = 9;

        private const int PesoInicialSantaCatarina = 2;

        private const int PesoMaximoSantaCatarina = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualSantaCatarina(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualSantaCatarina)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialSantaCatarina, PesoMaximoSantaCatarina);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 11) <= 1 ? 0 : 11 - (valor % 11);
        }

        #endregion
    }
}