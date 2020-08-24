namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualMinasGerais
    {
        #region Constantes

        private const int TamanhoInscricaoEstadualMinasGerais = 13;

        private const int PesoInicialMinasGerais = 2;

        private const int PesoMaximoMinasGerais = 11;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualMinasGerais(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoInscricaoEstadualMinasGerais)
            {
                return false;
            }

            int posicaoInicial = 0;
            int tamanho = 3;
            string municipio = inscricaoEstadual.NumeroDocumento.Substring(posicaoInicial, tamanho);

            posicaoInicial = 3;
            tamanho = 8;
            string ordem = inscricaoEstadual.NumeroDocumento.Substring(posicaoInicial, tamanho);

            int[] digitoVerificadorCalculado = { 0, 0 };
            int[] digitoVerificadorInformado = inscricaoEstadual.ObterUltimosDoisDigitosDeControleInformados();
            string baseCalculo;

            // Controla os passos e a aplicação do peso
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    baseCalculo = municipio + "0" + ordem;

                    string aux = (AplicarPeso(baseCalculo)).ToString();
                    int posicao = aux.Length - 1;

                    digitoVerificadorCalculado[i] = 10 - int.Parse(aux[posicao].ToString());
                }

                // Calculo do segundo digíto.
                baseCalculo = municipio + ordem + digitoVerificadorCalculado[i++].ToString();

                int soma = inscricaoEstadual.AplicarPeso(baseCalculo, PesoInicialMinasGerais, PesoMaximoMinasGerais);

                digitoVerificadorCalculado[i] = (soma % 11) <= 1 ? 0 : 11 - (soma % 11);
            }

            // Compara os dígitos verificadores informado e calculado.
            return (digitoVerificadorInformado[0] == digitoVerificadorCalculado[0] && digitoVerificadorInformado[1] == digitoVerificadorCalculado[1]);
        }

        #endregion

        #region Métodos Privados

        private static int AplicarPeso(string numero)
        {
            int soma = 0;

            for (int i = numero.Length - 1, peso = PesoInicialMinasGerais; i >= 0; i--)
            {
                int n = int.Parse(numero[i].ToString());
                int v = n * peso--;

                soma += SomarNumeros(v);

                // Inicializa o valor do peso.
                if (peso < 1)
                {
                    peso = PesoInicialMinasGerais;
                };
            }

            return soma;
        }

        private static int SomarNumeros(int numero)
        {
            if (numero == 0)
            {
                return 0;
            }

            string digitos = numero.ToString();
            int soma = 0;

            for (int i = 0; i < digitos.Length; i++)
            {
                int n = int.Parse(digitos[i].ToString());
                soma += n;
            }

            return soma;
        }

        #endregion
    }
}