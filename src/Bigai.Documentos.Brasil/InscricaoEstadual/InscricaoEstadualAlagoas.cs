namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualAlagoas
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualAlagoas = 9;

        private const string CodigoEstadoAlagoas = "24";

        private const int PesoInicialAlagoas = 2;

        private const int PesoMaximoAlagoas = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualAlagoas(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualAlagoas || !inscricaoEstadual.IniciaCom(CodigoEstadoAlagoas))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;
            
            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialAlagoas, PesoMaximoAlagoas) * 10;

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return digitoVerificadorInformado == digitoVerificadorCalculado;
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 11) == 10 ? 0 : (valor % 11); ;
        }

        #endregion
    }
}