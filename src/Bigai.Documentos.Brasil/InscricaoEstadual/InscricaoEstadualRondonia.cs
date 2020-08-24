namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualRondonia
    {
        #region Constantes

        private const int TamanhoMinimoInscricaoEstadualRondonia = 9;

        private const int TamanhoMaximoInscricaoEstadualRondonia = 14;

        private const int PesoInicialRondonia = 2;

        private const int PesoMaximoRondonia = 10;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualRondonia(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoMinimoInscricaoEstadualRondonia &&
                inscricaoEstadual.NumeroDocumento.Length != TamanhoMaximoInscricaoEstadualRondonia)
            {
                return false;
            }

            string baseCalculo = inscricaoEstadual.NumeroDocumento;
            int posicaoInicial;
            int tamanho;

            if (baseCalculo.Length == TamanhoMinimoInscricaoEstadualRondonia)
            {
                posicaoInicial = 3;
                tamanho = baseCalculo.Length - posicaoInicial;
                baseCalculo = baseCalculo.Substring(posicaoInicial, tamanho);
            }

            posicaoInicial = 0;
            tamanho = baseCalculo.Length - 1;
            baseCalculo = baseCalculo.Substring(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialRondonia, PesoMaximoRondonia);

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
            {
                digitoVerificadorCalculado -= 10;
            }

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}