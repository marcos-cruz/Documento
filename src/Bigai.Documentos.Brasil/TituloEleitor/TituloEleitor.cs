using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;
using System;

namespace Bigai.Documentos.Brasil
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar um Título de Eleitor.
    /// </summary>
    public class TituloEleitor : Documento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número do título do eleitor.
        /// </summary>
        public static readonly int TamanhoTituloEleitor = 12;

        /// <summary>
        /// Tamanho máximo do número da zona eleitoral.
        /// </summary>
        public static readonly int TamanhoZonaEleitoral = 5;

        /// <summary>
        /// Tamanho máximo do número da seção eleitorial.
        /// </summary>
        public static readonly int TamanhoSecaoEleitoral = 5;

        #endregion

        #region Propriedades

        /// <summary>
        /// Representa o número da zona eleitoral.
        /// </summary>
        public virtual string ZonaEleitoral { get; protected set; }

        /// <summary>
        /// Representa o número da seção eleitoral.
        /// </summary>
        public virtual string SecaoEleitoral { get; protected set; }

        /// <summary>
        /// Representa o código do domicilio eleitoral, onde o título do eletor foi expedido.
        /// </summary>
        public virtual string DomicilioEleitoral { get; private set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="TituloEleitor"/>.
        /// </summary>
        protected TituloEleitor() : base() { }

        private TituloEleitor(string numeroTitulo, string zonaEleitoral, string secaoEleitoral) : base(numeroTitulo, null)
        {
            if (!string.IsNullOrEmpty(NumeroDocumento))
            {
                if (NumeroDocumento.Length < TamanhoTituloEleitor)
                    NumeroDocumento = NumeroDocumento.PadLeft(TamanhoTituloEleitor, '0');

                DomicilioEleitoral = NumeroDocumento.Substring(NumeroDocumento.Length - 4, 2);
                EstadoEmissor = DomicilioEleitoral.ToDomicilioEleitoral();
            }

            ZonaEleitoral = !string.IsNullOrEmpty(zonaEleitoral) ? zonaEleitoral.RemoverMascaraEdicao() : "";
            SecaoEleitoral = !string.IsNullOrEmpty(secaoEleitoral) ? secaoEleitoral.RemoverMascaraEdicao() : "";
        }

        /// <summary>
        /// Retorna uma instância de <see cref="TituloEleitor"/>.
        /// </summary>
        /// <param name="numeroTitulo">Número do título de eleitor, com ou sem máscara de edição.</param>
        /// <param name="zonaEleitoral">Número da zona eleitoral, com ou sem máscara de edição.</param>
        /// <param name="secaoEleitoral">Número da seção eleitoral, com ou sem máscara de edição.</param>
        /// <returns>Retorna uma instância de <see cref="TituloEleitor"/>.</returns>
        public static TituloEleitor Factory(string numeroTitulo, string zonaEleitoral, string secaoEleitoral)
        {
            return new TituloEleitor(numeroTitulo, zonaEleitoral, secaoEleitoral);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outroTitulo)
        {
            TituloEleitor titulo = outroTitulo as TituloEleitor;

            return (NumeroDocumento == titulo.NumeroDocumento &&
                    ZonaEleitoral == titulo.ZonaEleitoral &&
                    SecaoEleitoral == titulo.SecaoEleitoral);
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se o Título de eleitor é válido.
        /// </summary>
        /// <returns><c>true</c> se o número do Cpf for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return TituloEleitorEstaValido();
        }

        private bool TituloEleitorEstaValido()
        {
            if (string.IsNullOrEmpty(NumeroDocumento) || string.IsNullOrEmpty(ZonaEleitoral) ||
                string.IsNullOrEmpty(SecaoEleitoral) || NumeroDocumento.Length != TamanhoTituloEleitor ||
                NumeroDocumento.TemCaracterRepetido() || !NumeroDocumento.EhUmNumeroPositivo() ||
                !CodigoEstadoEmissorEhValido())
            {
                return false;
            }

            int[] digitoDeControleCalculado = CalcularDigitoDeControle();
            int[] digitoDeControleInformado = ObterUltimosDoisDigitoDeControleInformados();

            return digitoDeControleCalculado[0] == digitoDeControleInformado[0] && digitoDeControleCalculado[1] == digitoDeControleInformado[1];
        }

        #endregion

        #region Metodos Privados

        private bool CodigoEstadoEmissorEhValido()
        {
            bool estadoEmissorValido = true;
            const int CodigoDomicilioEleitoralSp = 1;
            const int CodigoDomicilioEleitoralExterior = 28;

            if (NumeroDocumento.Length == TamanhoTituloEleitor)
            {
                int posicaoInicial = NumeroDocumento.Length - 4;
                int tamanho = 2;
                int codigoDomicilioEleitoral = int.Parse(NumeroDocumento.Substring(posicaoInicial, tamanho));
                
                if (codigoDomicilioEleitoral < CodigoDomicilioEleitoralSp || codigoDomicilioEleitoral > CodigoDomicilioEleitoralExterior)
                {
                    estadoEmissorValido = false;
                }
            }

            return estadoEmissorValido;
        }

        private int[] CalcularDigitoDeControle()
        {
            int[] digitoVerificadorCalculado = { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                int peso = 2;
                const int pesoMaximo = 10;
                int inicio = 0;
                int tamanho = NumeroDocumento.Length - 4;
                string baseCalculo = NumeroDocumento.Substring(inicio, tamanho);

                if (i > 0)
                {
                    peso = 7;
                    inicio = NumeroDocumento.Length - 4;
                    tamanho = 3;
                    baseCalculo = NumeroDocumento.Substring(inicio, tamanho);
                }

                int soma = baseCalculo.AplicarPesoDaEsquerdaParaDireita(peso, pesoMaximo);

                digitoVerificadorCalculado[i] = (soma % 11) >= 10 ? 0 : (soma % 11);
            }

            return digitoVerificadorCalculado;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Determina e aplica uma máscara de edição para o número do título de eleitor.
        /// </summary>
        /// <returns>Retorna o número do título de eleitor formatado com a máscara de edição.</returns>
        public string ToTituloEleitorFormat()
        {
            return long.TryParse(NumeroDocumento.RemoverMascaraEdicao().Trim(), out long numero) ? Convert.ToUInt64(numero).ToString(@"000\.000\.000\-00") : "";
        }

        #endregion
    }
}
