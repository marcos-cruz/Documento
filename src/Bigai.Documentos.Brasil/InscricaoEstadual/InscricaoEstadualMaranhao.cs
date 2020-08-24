namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualMaranhao
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualMaranhao = 9;

        private const string CodigoEstadoMaranhao = "12";

        private const int PesoInicialMaranhao = 2;

        private const int PesoMaximoMaranhao = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualMaranhao(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualMaranhao || !inscricaoEstadual.IniciaCom(CodigoEstadoMaranhao))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialMaranhao, PesoMaximoMaranhao);

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