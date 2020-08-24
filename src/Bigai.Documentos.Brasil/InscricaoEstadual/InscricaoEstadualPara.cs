namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualPara
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualPara = 9;

        private const string CodigoEstadoPara = "15";

        private const int PesoInicialPara = 2;

        private const int PesoMaximoPara = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualPara(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualPara || !inscricaoEstadual.IniciaCom(CodigoEstadoPara))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialPara, PesoMaximoPara);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return digitoVerificadorInformado == digitoVerificadorCalculado;
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