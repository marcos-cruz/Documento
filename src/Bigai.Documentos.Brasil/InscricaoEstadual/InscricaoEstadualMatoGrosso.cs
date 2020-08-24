namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualMatoGrosso
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualMatoGrosso = 11;

        private const int PesoInicialMatoGrosso = 2;

        private const int PesoMaximoMatoGrosso = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualMatoGrosso(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualMatoGrosso)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialMatoGrosso, PesoMaximoMatoGrosso);

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