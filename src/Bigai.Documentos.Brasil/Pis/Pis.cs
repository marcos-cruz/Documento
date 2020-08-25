using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;
using System;

namespace Bigai.Documentos.Brasil
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar um Pis - Programa de Integração Social.
    /// </summary>
    public class Pis : Documento
    {
        #region Constantes

        private const int _tamanhoPis = 11;

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="Pis"/>.
        /// </summary>
        protected Pis() : base() { }

        private Pis(string numeroPis) : base(numeroPis, null)
        {
            if (!string.IsNullOrEmpty(NumeroDocumento))
            {
                if (NumeroDocumento.Length < _tamanhoPis)
                    NumeroDocumento = NumeroDocumento.PadLeft(_tamanhoPis, '0');
            }
        }

        /// <summary>
        /// Retorna uma instância de <see cref="Pis"/>.
        /// </summary>
        /// <param name="numeroPis">Número do Pis, com ou sem máscara de edição.</param>
        /// <returns>Retorna uma instância de <see cref="Pis"/>.</returns>
        public static Pis Factory(string numeroPis)
        {
            return new Pis(numeroPis);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outroPis)
        {
            return NumeroDocumento == outroPis.NumeroDocumento;
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se o Pis é válido.
        /// </summary>
        /// <returns><c>true</c> se o número do Pis for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return PisEstaValido();
        }

        private bool PisEstaValido()
        {
            if (string.IsNullOrEmpty(NumeroDocumento) || NumeroDocumento.Length != _tamanhoPis ||
                NumeroDocumento.TemCaracterRepetido() || !NumeroDocumento.EhUmNumeroPositivo())
            {
                return false;
            }

            int digitoDeControleCalculado = CalcularDigitoDeControle();
            int digitoDeControleInformado = ObterDigitoDeControleInformado();

            return digitoDeControleCalculado == digitoDeControleInformado;
        }

        #endregion

        #region Métodos Privados

        private int CalcularDigitoDeControle()
        {
            int[] peso = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = NumeroDocumento.AplicarPesoDaEsquerdaParaDireita(peso);

            return (soma % 11) < 2 ? 0 : 11 - (soma % 11);
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Determina e aplica uma máscara de edição para o número do Pis.
        /// </summary>
        /// <returns>Retorna o número do Pis formatado com a máscara de edição.</returns>
        public string ToPisFormat()
        {
            return long.TryParse(NumeroDocumento.RemoverMascaraEdicao().Trim(), out long numero) ? Convert.ToUInt64(numero).ToString(@"000\.000\.000\-00") : "";
        }

        #endregion
    }
}
