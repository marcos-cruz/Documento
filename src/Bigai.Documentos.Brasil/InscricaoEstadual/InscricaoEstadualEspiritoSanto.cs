namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualEspiritoSanto
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualEspiritoSanto = 9;

        private const int PesoInicialEspiritoSanto = 2;

        private const int PesoMaximoEspiritoSanto = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualEspiritoSanto(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualEspiritoSanto)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialEspiritoSanto, PesoMaximoEspiritoSanto);

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