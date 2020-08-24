using Bigai.Documentos.Brasil.Generics;
using Bigai.Documentos.Brasil.Helpers;
using System;

namespace Bigai.Documentos.Brasil
{
    /// <summary>
    /// Esta classe contém métodos para criar e validar uma Inscrição Estadual.
    /// </summary>
    public class InscricaoEstadual : Documento
    {
        #region Constantes

        /// <summary>
        /// Tamanho máximo do número da Inscrição Estadual.
        /// </summary>
        public static readonly int TamanhoInscricaoEstadual = 15;

        private const string _isento = "ISENTO";

        #endregion

        #region Construtor

        /// <summary>
        /// Retorna uma instância de <see cref="InscricaoEstadual"/>.
        /// </summary>
        protected InscricaoEstadual() : base() { }

        private InscricaoEstadual(string numeroInscricaoEstadual, string estadoEmissorInscricaoEstadual) : base(numeroInscricaoEstadual, estadoEmissorInscricaoEstadual)
        {
        }

        /// <summary>
        /// Retorna uma instância de <see cref="InscricaoEstadual"/>.
        /// </summary>
        /// <param name="numeroInscricaoEstadual">Número da inscrição estadual, com ou sem máscara de edição.</param>
        /// <param name="estadoEmissorInscricaoEstadual">Sigla do estado emissor composta por 2 letras, segundo a norma ISO-3166.</param>
        /// <returns>Retorna uma instância de <see cref="InscricaoEstadual"/>.</returns>
        public static InscricaoEstadual Factory(string numeroInscricaoEstadual, string estadoEmissorInscricaoEstadual)
        {
            return new InscricaoEstadual(numeroInscricaoEstadual, estadoEmissorInscricaoEstadual);
        }

        #endregion

        #region Comparação

        protected override bool EqualsCore(Documento outraInscricao)
        {
            return (NumeroDocumento == outraInscricao.NumeroDocumento &&
                    EstadoEmissor == outraInscricao.EstadoEmissor);
        }

        #endregion

        #region Consistência

        /// <summary>
        /// Determina se a Inscrição Estadual é válida.
        /// </summary>
        /// <returns><c>true</c> se o número da Inscrição Estadual for válido, caso contrário <c>false</c>.</returns>
        public override bool EstaValido()
        {
            return InscricaoEstadualEstaValida();
        }

        private bool InscricaoEstadualEstaValida()
        {
            bool inscricaoValida = false;

            if (string.IsNullOrEmpty(NumeroDocumento) || NumeroDocumento.TemCaracterRepetido() || !EstadoEmissor.EhUmaUf())
            {
                return false;
            }

            if (NumeroDocumento.Equals(_isento))
            {
                return true;
            }

            if (!NumeroDocumento.EhUmNumeroPositivo() && NumeroDocumento[0] != 'P')
            {
                return false;
            }

            switch (EstadoEmissor)
            {
                case "AC":
                    inscricaoValida = InscricaoEstadualAcre.EhUmaInscricaoEstadualAcre(this);
                    break;
                case "AL":
                    inscricaoValida = InscricaoEstadualAlagoas.EhUmaInscricaoEstadualAlagoas(this);
                    break;
                case "AP":
                    inscricaoValida = InscricaoEstadualAmapa.EhUmaInscricaoEstadualAmapa(this);
                    break;
                case "AM":
                    inscricaoValida = InscricaoEstadualAmazonas.EhUmaInscricaoEstadualAmazonas(this);
                    break;
                case "BA":
                    inscricaoValida = InscricaoEstadualBahia.EhUmaInscricaoEstadualBahia(this);
                    break;
                case "CE":
                    inscricaoValida = InscricaoEstadualCeara.EhUmaInscricaoEstadualCeara(this);
                    break;
                case "DF":
                    inscricaoValida = InscricaoEstadualDistritoFederal.EhUmaInscricaoEstadualDistritoFederal(this);
                    break;
                case "ES":
                    inscricaoValida = InscricaoEstadualEspiritoSanto.EhUmaInscricaoEstadualEspiritoSanto(this);
                    break;
                case "GO":
                    inscricaoValida = InscricaoEstadualGoias.EhUmaInscricaoEstadualGoias(this);
                    break;
                case "MA":
                    inscricaoValida = InscricaoEstadualMaranhao.EhUmaInscricaoEstadualMaranhao(this);
                    break;
                case "MT":
                    inscricaoValida = InscricaoEstadualMatoGrosso.EhUmaInscricaoEstadualMatoGrosso(this);
                    break;
                case "MS":
                    inscricaoValida = InscricaoEstadualMatoGrossoDoSul.EhUmaInscricaoEstadualMatoGrossoDoSul(this);
                    break;
                case "MG":
                    inscricaoValida = InscricaoEstadualMinasGerais.EhUmaInscricaoEstadualMinasGerais(this);
                    break;
                case "PA":
                    inscricaoValida = InscricaoEstadualPara.EhUmaInscricaoEstadualPara(this);
                    break;
                case "PB":
                    inscricaoValida = InscricaoEstadualParaiba.EhUmaInscricaoEstadualParaiba(this);
                    break;
                case "PR":
                    inscricaoValida = InscricaoEstadualParana.EhUmaInscricaoEstadualParana(this);
                    break;
                case "PE":
                    inscricaoValida = InscricaoEstadualPernambuco.EhUmaInscricaoEstadualPernambuco(this);
                    break;
                case "PI":
                    inscricaoValida = InscricaoEstadualPiaui.EhUmaInscricaoEstadualPiaui(this);
                    break;
                case "RJ":
                    inscricaoValida = InscricaoEstadualRioDeJaneiro.EhUmaInscricaoEstadualRioDeJaneiro(this);
                    break;
                case "RN":
                    inscricaoValida = InscricaoEstadualRioGrandeDoNorte.EhUmaInscricaoEstadualRioGrandeDoNorte(this);
                    break;
                case "RS":
                    inscricaoValida = InscricaoEstadualRioGrandeDoSul.EhUmaInscricaoEstadualRioGrandeDoSul(this);
                    break;
                case "RO":
                    inscricaoValida = InscricaoEstadualRondonia.EhUmaInscricaoEstadualRondonia(this);
                    break;
                case "RR":
                    inscricaoValida = InscricaoEstadualRoraima.EhUmaInscricaoEstadualRoraima(this);
                    break;
                case "SC":
                    inscricaoValida = InscricaoEstadualSantaCatarina.EhUmaInscricaoEstadualSantaCatarina(this);
                    break;
                case "SP":
                    inscricaoValida = InscricaoEstadualSaoPaulo.EhUmaInscricaoEstadualSaoPaulo(this);
                    break;
                case "SE":
                    inscricaoValida = InscricaoEstadualSergipe.EhUmaInscricaoEstadualSergipe(this);
                    break;
                case "TO":
                    inscricaoValida = InscricaoEstadualTocantins.EhUmaInscricaoEstadualTocantins(this);
                    break;
            }

            return inscricaoValida;
        }

        #endregion

        #region Métodos Internos

        internal bool IniciaCom(string valor)
        {
            return (NumeroDocumento.Substring(0, valor.Length) == valor);
        }

        internal string ObterBaseDeCalculo(int posicaoInicial, int tamanho)
        {
            int tamanhoDocumento;
            var numeroBase = "";

            if (!string.IsNullOrEmpty(NumeroDocumento) && posicaoInicial >= 0)
            {
                tamanhoDocumento = NumeroDocumento.Length;
                if (tamanhoDocumento > posicaoInicial && tamanho <= tamanhoDocumento)
                {
                    numeroBase = NumeroDocumento.Substring(posicaoInicial, tamanho);
                }
            }

            return numeroBase;
        }

        internal int AplicarPeso(string numero, int peso, int limite)
        {
            return numero.AplicarPesoDaDireitaParaEsquerda(peso, limite);
        }

        internal int[] ObterUltimosDoisDigitosDeControleInformados()
        {
            return ObterUltimosDoisDigitoDeControleInformados();
        }

        internal int ObterUltimoDigitoDeControleInformado()
        {
            return ObterDigitoDeControleInformado();
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Determina e aplica uma máscara de edição para o número da inscrição estadual, conforme o estado emissor.
        /// </summary>
        /// <returns>Retorna o número da inscrição estadual formatado com a máscara de edição.</returns>
        public string ToInscricaoEstadualFormat()
        {
            if (NumeroDocumento.Equals(_isento) || !InscricaoEstadualEstaValida())
            {
                return NumeroDocumento;
            }

            string ie = NumeroDocumento.RemoverMascaraEdicao().Trim();
            string inscricaoEditada = NumeroDocumento;

            switch (EstadoEmissor)
            {
                case "AC":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000\.000\/000\-00");
                    break;
                case "AL":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.0\.00000\-0");
                    break;
                case "AP":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000000\-0");
                    break;
                case "AM":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000\.000\-0");
                    break;
                case "BA":
                    if (ie.Length == 8)
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000000\-00");
                    }
                    else
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"0000000\-00");
                    }

                    break;
                case "CE":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "DF":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.00000\.000\-00");
                    break;
                case "ES":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "GO":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000\.000\-0");
                    break;
                case "MA":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000000\-0");
                    break;
                case "MT":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"0000000000\-0");
                    break;
                case "MS":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "MG":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.000\.000\/0000");
                    break;
                case "PA":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\-000000\-0");
                    break;
                case "PB":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "PR":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.00000\-00");
                    break;
                case "PE":
                    if (ie.Length == 9)
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"0000000\-00");
                    }
                    else
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.0\.000\.0000000\-0");
                    }

                    break;
                case "PI":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "RJ":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000\.00\-0");
                    break;
                case "RN":
                    if (ie.Length == 9)
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.000\.000\-0");
                    }
                    else
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.0\.000\.000\-0");
                    }

                    break;
                case "RS":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\/0000000");
                    break;
                case "RO":
                    if (ie.Length == 9)
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.00000\-0");
                    }
                    else
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"0000000000000\-0");
                    }

                    break;
                case "RR":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "SC":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.000\.000");
                    break;
                case "SP":
                    if (ie.Length == 12)
                    {
                        inscricaoEditada = Convert.ToUInt64(ie).ToString(@"000\.000\.000\.000");
                    }
                    else
                    {
                        ie = ie.Substring(1);
                        ie = Convert.ToUInt64(ie).ToString(@"00000000\.0\/000");
                        inscricaoEditada = NumeroDocumento[0].ToString() + "-" + ie;
                    }
                    break;
                case "SE":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00000000\-0");
                    break;
                case "TO":
                    inscricaoEditada = Convert.ToUInt64(ie).ToString(@"00\.00\.000000\.0");
                    break;
            }

            return inscricaoEditada;
        }

        #endregion
    }
}
