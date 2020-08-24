namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualAmapa
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualAmapa = 9;

        private const string CodigoEstadoAmapa = "03";

        private const int PesoInicialAmapa = 2;

        private const int PesoMaximoAmapa = 9;

        #endregion

        #region Variaveis Privadas

        private static int P;

        private static int D;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualAmapa(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualAmapa || !inscricaoEstadual.IniciaCom(CodigoEstadoAmapa))
            {
                return false;
            }

            IdentificarRange(inscricaoEstadual.NumeroDocumento);

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = P + inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialAmapa, PesoMaximoAmapa);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return digitoVerificadorInformado == digitoVerificadorCalculado;
        }

        #endregion

        #region Métodos Privados

        private static void IdentificarRange(string inscricao)
        {
            int numeroBase = int.Parse(inscricao.Substring(0, 8));

            P = D = 0;

            if (numeroBase >= 03000001 && numeroBase <= 03017000)
            {
                P = 5;
                D = 0;
            }
            else if (numeroBase >= 03017001 && numeroBase <= 03019022)
            {
                P = 9;
                D = 1;
            }
            else if (numeroBase >= 03019023)
            {
                P = 0;
                D = 0;
            }
        }

        private static int CalcularDigitoDeControle(int valor)
        {
            int digitoVerificadorCalculado = 11 - (valor % 11);
            if (digitoVerificadorCalculado == 10)
                digitoVerificadorCalculado = 0;
            else if (digitoVerificadorCalculado == 11)
                digitoVerificadorCalculado = D;

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}