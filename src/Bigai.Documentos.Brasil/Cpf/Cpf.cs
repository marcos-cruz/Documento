using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;

namespace Bigai.Documentos.Brasil.Cpf
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar um Cpf - Cadastro de Pessoas Físicas.
    /// </summary>
    public class Cpf : Documento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número do Cpf.
        /// </summary>
        public static readonly int TamanhoCpf = 11;

        private const int _pesoInicial = 2;
        private const int _pesoMaximo = 11;

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="Cpf"/>.
        /// </summary>
        protected Cpf() : base() { }

        private Cpf(string numeroCpf) : base(numeroCpf, null)
        {
            if (!string.IsNullOrEmpty(NumeroDocumento))
            {
                if (NumeroDocumento.Length < TamanhoCpf)
                    NumeroDocumento = NumeroDocumento.PadLeft(TamanhoCpf, '0');
            }
        }

        /// <summary>
        /// Retorna uma instância de <see cref="Cpf"/>.
        /// </summary>
        /// <param name="numeroCpf">Número do Cpf, com ou sem máscara de edição.</param>
        /// <returns>Retorna uma instância de <see cref="Cpf"/>.</returns>
        public static Cpf Factory(string numeroCpf)
        {
            return new Cpf(numeroCpf);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outroCpf)
        {
            return NumeroDocumento == outroCpf.NumeroDocumento;
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se o Cpf é válido.
        /// </summary>
        /// <returns><c>true</c> se o número do Cpf for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return CpfEstaValido();
        }

        private bool CpfEstaValido()
        {
            if (string.IsNullOrEmpty(NumeroDocumento) || NumeroDocumento.Length != TamanhoCpf ||
                NumeroDocumento.TemCaracterRepetido() || !NumeroDocumento.EhUmNumeroPositivo())
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

        private int[] CalcularDigitoDeControle()
        {
            int[] digitoVerificadorCalculado = { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                int posicaoInicial = 0;
                int tamanho = NumeroDocumento.Length - 2 + i;
                string baseCalculo = NumeroDocumento.Substring(posicaoInicial, tamanho);

                int soma = baseCalculo.AplicarPesoDaDireitaParaEsquerda(_pesoInicial, _pesoMaximo);

                digitoVerificadorCalculado[i] = 11 - (soma % 11);

                if (digitoVerificadorCalculado[i] >= 10)
                    digitoVerificadorCalculado[i] = 0;
            }

            return digitoVerificadorCalculado;
        }

        #endregion
    }
}
