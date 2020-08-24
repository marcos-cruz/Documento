namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualGoias
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualGoias = 9;

        private const int PesoInicialGoias = 2;

        private const int PesoMaximoGoias = 9;

        private const string CodigoGoias10 = "10";
        private const string CodigoGoias11 = "11";
        private const string CodigoGoias15 = "15";

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualGoias(this InscricaoEstadual inscricaoEstadual)
        {
            if ((inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualGoias) ||
                !inscricaoEstadual.IniciaCom(CodigoGoias10) && !inscricaoEstadual.IniciaCom(CodigoGoias11) && !inscricaoEstadual.IniciaCom(CodigoGoias15))
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.NumeroDocumento.Length - 1;

            string baseCalculo = inscricaoEstadual.ObterBaseDeCalculo(posicaoInicial, tamanho);

            int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialGoias, PesoMaximoGoias);

            int digitoVerificadorCalculado = CalcularDigitoDeControle(soma, inscricaoEstadual.NumeroDocumento);

            int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

            return (digitoVerificadorInformado == digitoVerificadorCalculado);
        }

        #endregion

        #region Métodos Privados

        private static int CalcularDigitoDeControle(int valor, string inscricao)
        {
            int digitoVerificadorCalculado = (valor % 11);
            int numeroBase = int.Parse(inscricao.Substring(0, 8));

            if (numeroBase == 11094402)
            {
                int posicao = inscricao.Length - 1;
                if (inscricao[posicao] == '0' || inscricao[posicao] == '1')
                {
                    digitoVerificadorCalculado = int.Parse(inscricao[posicao].ToString());
                }
            }
            else if (digitoVerificadorCalculado == 1)
            {
                digitoVerificadorCalculado = 0;
                if (numeroBase >= 10103105 && numeroBase <= 10119997)
                    digitoVerificadorCalculado = 1;
            }
            else
                digitoVerificadorCalculado = 11 - (valor % 11);

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}