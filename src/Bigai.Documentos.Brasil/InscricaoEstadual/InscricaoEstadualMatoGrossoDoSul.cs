namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualMatoGrossoDoSul
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualMatoGrossoDoSul = 9;

        private const string CodigoEstadoMatoGrossoDoSul = "28";

        private const int PesoInicialMatoGrossoDoSul = 2;

        private const int PesoMaximoMatoGrossoDoSul = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualMatoGrossoDoSul(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualMatoGrossoDoSul || !inscricaoEstadual.IniciaCom(CodigoEstadoMatoGrossoDoSul))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialMatoGrossoDoSul, PesoMaximoMatoGrossoDoSul);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            int digitoVerificadorCalculado = (valor % 11);
            if (digitoVerificadorCalculado > 0)
            {
                digitoVerificadorCalculado = 11 - (valor % 11);
                if (digitoVerificadorCalculado > 9)
                    digitoVerificadorCalculado = 0;
            }

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}