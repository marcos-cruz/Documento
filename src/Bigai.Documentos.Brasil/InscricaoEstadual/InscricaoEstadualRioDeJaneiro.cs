namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualRioDeJaneiro
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualRioDeJaneiro = 8;

        private const int PesoInicialRioDeJaneiro = 2;

        private const int PesoMaximoRioDeJaneiro = 7;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualRioDeJaneiro(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualRioDeJaneiro)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialRioDeJaneiro, PesoMaximoRioDeJaneiro);

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