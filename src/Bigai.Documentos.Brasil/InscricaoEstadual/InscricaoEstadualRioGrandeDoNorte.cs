namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualRioGrandeDoNorte
    {
        #region Constantes

        private const int TamanhoMinimoInscricaoEstadualRioGrandeDoNorte = 9;

        private const int TamanhoMaximoInscricaoEstadualRioGrandeDoNorte = 10;

        private const string CodigoEstadoRioGrandeDoNorte = "20";

        private const int PesoInicialRioGrandeDoNorte = 2;

        private const int PesoMaximoRioGrandeDoNorte = 10;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualRioGrandeDoNorte(this InscricaoEstadual inscricaoEstadual)
        {
            if ((inscricaoEstadual.NumeroDocumento.Length != TamanhoMinimoInscricaoEstadualRioGrandeDoNorte &&
                inscricaoEstadual.NumeroDocumento.Length != TamanhoMaximoInscricaoEstadualRioGrandeDoNorte) ||
                !inscricaoEstadual.IniciaCom(CodigoEstadoRioGrandeDoNorte))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = 10 * inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialRioGrandeDoNorte, PesoMaximoRioGrandeDoNorte);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 11) == 10 ? 0 : (valor % 11);
        }

        #endregion
    }
}