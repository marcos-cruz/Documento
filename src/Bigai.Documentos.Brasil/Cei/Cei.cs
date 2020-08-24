using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;
using System;

namespace Bigai.Documentos.Brasil
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar um Cei - Cadastro Específico do INSS.
    /// </summary>
    public class Cei : Documento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número do Cei.
        /// </summary>
        public static readonly int TamanhoCei = 12;

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="Cei"/>.
        /// </summary>
        protected Cei() : base() { }

        private Cei(string numeroCei) : base(numeroCei, null)
        {
            if (!string.IsNullOrEmpty(NumeroDocumento))
            {
                if (NumeroDocumento.Length < TamanhoCei)
                    NumeroDocumento = NumeroDocumento.PadLeft(TamanhoCei, '0');
            }
        }

        /// <summary>
        /// Retorna uma instância de <see cref="Cei"/>.
        /// </summary>
        /// <param name="numeroCei">Número do Cei, com ou sem máscara de edição.</param>
        /// <returns>Retorna uma instância de <see cref="Cei"/>.</returns>
        public static Cei Factory(string numeroCei)
        {
            return new Cei(numeroCei);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outroCei)
        {
            return NumeroDocumento == outroCei.NumeroDocumento;
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se o Cei é válido.
        /// </summary>
        /// <returns><c>true</c> se o número do Cei for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return CeiEstaValido();
        }

        private bool CeiEstaValido()
        {
            if (string.IsNullOrEmpty(NumeroDocumento) || NumeroDocumento.Length != TamanhoCei ||
                NumeroDocumento.TemCaracterRepetido() || !NumeroDocumento.EhUmNumeroPositivo())
            {
                return false;
            }

            int digitoDeControleCalculado = CalcularDigitoDeControle();
            int digitoDeControleInformado = ObterUltimoDigitoDeControleInformado();

            return digitoDeControleInformado == digitoDeControleCalculado;
        }

        #endregion

        #region Métodos Privados

        private int CalcularDigitoDeControle()
        {
            int digitoVerificadorCalculado;
            int[] pesos = new int[11] { 7, 4, 1, 8, 5, 2, 1, 6, 3, 7, 4 };
            int soma = NumeroDocumento.AplicarPesoDaEsquerdaParaDireita(pesos);

            int dezena = (soma / 10);
            int unidade = soma - ((soma / 10) * 10);
            soma = dezena + unidade;

            unidade = soma - ((soma / 10) * 10);

            digitoVerificadorCalculado = 10 - unidade;

            return digitoVerificadorCalculado;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Determina e aplica uma máscara de edição para o número do Cei.
        /// </summary>
        /// <returns>Retorna o número do Cei formatado com a máscara de edição.</returns>
        public string ToCeiFormat()
        {
            if (!CeiEstaValido())
            {
                return NumeroDocumento;
            }

            return long.TryParse(NumeroDocumento.RemoverMascaraEdicao().Trim(), out long numero) ? Convert.ToUInt64(numero).ToString(@"00\.000\.00000\/00") : "";
        }

        #endregion
    }
}
