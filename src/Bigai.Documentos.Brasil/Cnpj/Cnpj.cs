using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;

namespace Bigai.Documentos.Brasil
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar um Cnpj - Cadastro Nacional de Pessoas Jurídicas.
    /// </summary>
    public class Cnpj : Documento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número do Cnpj.
        /// </summary>
        public static readonly int TamanhoCnpj = 14;

        private const int _tamanhoBaseCnpj = 8;
        private const int _tamanhoOrdemCnpj = 4;
        private const int _pesoInicial = 2;
        private const int _pesoMaximo = 9;

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="Cnpj"/>.
        /// </summary>
        protected Cnpj() : base() { }

        private Cnpj(string numeroCnpj) : base(numeroCnpj, null)
        {
            if (!string.IsNullOrEmpty(NumeroDocumento))
            {
                if (NumeroDocumento.Length < TamanhoCnpj)
                    NumeroDocumento = NumeroDocumento.PadLeft(TamanhoCnpj, '0');
            }
        }

        /// <summary>
        /// Retorna uma instância de <see cref="Cnpj"/>.
        /// </summary>
        /// <param name="numeroCnpj">Número do cnpj, com ou sem máscara de edição.</param>
        /// <returns>Retorna uma instância de <see cref="Cnpj"/>.</returns>
        public static Cnpj Factory(string numeroCnpj)
        {
            return new Cnpj(numeroCnpj);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outroCnpj)
        {
            return NumeroDocumento == outroCnpj.NumeroDocumento;
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se o Cnpj é válido.
        /// </summary>
        /// <returns><c>true</c> se o número do Cnpj for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return CnpjEstaValido();
        }

        private bool CnpjEstaValido()
        {
            if (string.IsNullOrEmpty(NumeroDocumento) || NumeroDocumento.Length != TamanhoCnpj ||
                NumeroDocumento.TemCaracterRepetido() || !NumeroDocumento.EhUmNumeroPositivo() ||
                !VerificarOrdem())
            {
                return false;
            }

            int[] digitoDeControleCalculado = CalcularDigitoDeControle();
            int[] digitoDeControleInformado = ObterUltimosDoisDigitoDeControleInformado();

            return digitoDeControleInformado[0] == digitoDeControleCalculado[0] &&
                   digitoDeControleInformado[1] == digitoDeControleCalculado[1];
        }

        #endregion

        #region Métodos Privados

        private bool VerificarOrdem()
        {
            string ordemCnpj = NumeroDocumento.Substring(_tamanhoBaseCnpj, _tamanhoOrdemCnpj);

            return !(string.Equals(ordemCnpj, "0000"));
        }

        private int[] CalcularDigitoDeControle()
        {
            int[] digitoDeControleCalculado = { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                int posicaoInicial = 0;
                int tamanho = NumeroDocumento.Length - 2 + i;
                string baseCalculo = NumeroDocumento.Substring(posicaoInicial, tamanho);

                int soma = baseCalculo.AplicarPesoDaDireitaParaEsquerda(_pesoInicial, _pesoMaximo);

                digitoDeControleCalculado[i] = 11 - (soma % 11);
                if (digitoDeControleCalculado[i] >= 10)
                {
                    digitoDeControleCalculado[i] = 0;
                }
            }

            return digitoDeControleCalculado;
        }

        #endregion

    }
}
