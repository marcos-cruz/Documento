namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualRoraima
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualRoraima = 9;

        private const string CodigoEstadoRoraima = "24";

        private const int PesoInicialRoraima = 8;

        private const int PesoMinimoRoraima = 1;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualRoraima(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualRoraima || 
                !inscricaoEstadual.IniciaCom(CodigoEstadoRoraima))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = AplicarPeso(baseCalculo, PesoInicialRoraima, PesoMinimoRoraima);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int AplicarPeso(string num, int peso, int limite)
        {
            int i,
                p = peso,
                n,
                s = 0;

            for (i = num.Length - 1; i >= 0; i--)
            {
                n = int.Parse(num[i].ToString());
                s += n * p--;

                if (p < limite) p = peso;
            }
            return s;
        }

        private static int CalcularDigitoDeControle(int valor)
        {
            return (valor % 9);
        }

        #endregion
    }
}