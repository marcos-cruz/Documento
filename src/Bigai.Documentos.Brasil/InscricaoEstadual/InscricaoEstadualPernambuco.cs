namespace Bigai.Documentos.Brasil
{
    internal static class InscricaoEstadualPernambuco
    {
        #region Constantes

        private const int TamanhoMinimoInscricaoEstadualPernambuco = 9;

        private const int TamanhoMaximoInscricaoEstadualPernambuco = 14;
        
        private const int PesoInicialPernambuco = 2;

        private const int PesoMaximoPernambuco = 9;

        #endregion

        #region Métodos Públicos

        public static bool EhUmaInscricaoEstadualPernambuco(this InscricaoEstadual inscricaoEstadual)
        {
            if (inscricaoEstadual.NumeroDocumento.Length != TamanhoMinimoInscricaoEstadualPernambuco &&
                inscricaoEstadual.NumeroDocumento.Length != TamanhoMaximoInscricaoEstadualPernambuco)
            {
                return false;
            }

            if (inscricaoEstadual.NumeroDocumento.Length == TamanhoMinimoInscricaoEstadualPernambuco)
            {
                int[] digitoVerificadorInformado = inscricaoEstadual.ObterUltimosDoisDigitosDeControleInformados();
                
                return CalculaDigitoAtual(inscricaoEstadual.NumeroDocumento, digitoVerificadorInformado);
            }
            else
            {
                int digitoVerificadorInformado = inscricaoEstadual.ObterUltimoDigitoDeControleInformado();

                return CalculaDigitoAntigo(inscricaoEstadual.NumeroDocumento, digitoVerificadorInformado);
            }
        }

        #endregion

        #region Métodos Privados

        private static bool CalculaDigitoAntigo(string inscricaoEstadual, int digitoVerificarInformado)
        {
            int numero;
            int peso = PesoInicialPernambuco;
            int soma = 0;
            int posicaoInicial = 0;
            int tamanho = inscricaoEstadual.Length - 1;

            string baseCalculo = inscricaoEstadual.Substring(posicaoInicial, tamanho);

            // Pega cada dígito da ordem e aplica peso correspondente.
            for (int i = baseCalculo.Length - 1; i >= 0; i--)
            {
                numero = int.Parse(baseCalculo[i].ToString());

                soma += numero * peso++;

                if (peso > PesoMaximoPernambuco)
                {
                    peso = 1;
                }
            }

            int digitoVerificadorCalculado = 11 - (soma % 11);
            if (digitoVerificadorCalculado > 9)
            {
                digitoVerificadorCalculado -= 10;
            }

            return (digitoVerificarInformado == digitoVerificadorCalculado);
        }

        private static bool CalculaDigitoAtual(string inscricaoEstadual, int[] digitoVerificarInformado)
        {
            string inscricao = inscricaoEstadual;
            int i;                      // Controla aplicação de pesos.
            int j;                      // Controla os passos do calculo dos pesos.
            int numero;                 // Número que compõem a inscrição estdual.
            int peso;                   // Peso que deve ser aplicado a cada dígito.
            int soma;                   // Somatoria do calculo de (digito * peso)
            int[] digitoVerificadorCalculado = { 0, 0 };

            // Controla os passos e a aplicação do peso
            for (j = 0; j < 2; j++)
            {
                peso = PesoInicialPernambuco;
                soma = 0;

                // Pega cada dígito da ordem e aplica peso correspondente.
                for (i = inscricao.Length - 3 + j; i >= 0; i--)
                {
                    // Pega o dígito e converte para inteiro.
                    numero = int.Parse(inscricao[i].ToString());

                    // Aplica o peso ao número e acumula a somatória.
                    soma += numero * peso++;

                    // Inicializa o valor do peso.
                    if (peso > PesoMaximoPernambuco)
                    {
                        peso = PesoInicialPernambuco;
                    }
                }

                // Calcula o dígito verificador.
                digitoVerificadorCalculado[j] = (soma % 11) <= 1 ? 0 : 11 - (soma % 11);
            }

            return (digitoVerificarInformado[0] == digitoVerificadorCalculado[0] && digitoVerificarInformado[1] == digitoVerificadorCalculado[1]);
        }

        #endregion
    }
}