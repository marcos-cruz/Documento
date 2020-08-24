namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualCeara
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualCeara = 9;

        private const int PesoInicialCeara = 2;

        private const int PesoMaximoCeara = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualCeara(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualCeara)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;
            
            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialCeara, PesoMaximoCeara);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor)
        {
            int digitoVerificadorCalculado = 11 - (valor % 11);
            if (digitoVerificadorCalculado == 10 || digitoVerificadorCalculado == 11)
                digitoVerificadorCalculado = 0;

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}