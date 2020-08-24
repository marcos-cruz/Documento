namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualDistritoFederal
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualDistritoFederal = 13;

        private const string CodigoDistritoFederal = "07";

        private const int PesoInicialDistritoFederal = 2;

        private const int PesoMaximoDistritoFederal = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualDistritoFederal(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualDistritoFederal || !inscricaoEstadual.IniciaCom(CodigoDistritoFederal))
            {
                return false;
            }


            int[] digitoVerificadorInformado = inscricaoEstadual.ObterUltimosDoisDigitosDeControleInformados();
            int[] digitoVerificadorCalculado = { 0, 0 };

            // Controla a quantidade de dígitos verificadores.
            for (int i = 0; i < 2; i++)
            {
                int posicaoInicial = 0;
                int tamanho = inscricaoEstadual.NumeroDocumento.Length - 2 + i;

                string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

                int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialDistritoFederal, PesoMaximoDistritoFederal);

                digitoVerificadorCalculado[i] = CalcularDigitoDeControle(soma);
            }

            return digitoVerificadorInformado[0] == digitoVerificadorCalculado[0] && digitoVerificadorInformado[1] == digitoVerificadorCalculado[1];
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