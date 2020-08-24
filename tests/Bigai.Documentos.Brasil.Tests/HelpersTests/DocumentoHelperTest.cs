using Bigai.Documentos.Brasil.Helpers;
using Xunit;

namespace Bigai.Documentos.Brasil.Tests.HelpersTests
{
    public class DocumentoHelperTest
    {
        [Fact]
        public void RemoverMascaraEdicao_QuandoTemMascaraDeEdicao_DeveRemoverMascara()
        {
            // Arrange
            var valorInformado = "02.270.949/0001-37";
            var valorEsperado = "02270949000137";

            // Act
            var valorRetornado = valorInformado.RemoverMascaraEdicao();

            // Assert
            Assert.Equal(valorEsperado, valorRetornado);
        }
        
        [Fact]
        public void RemoverMascaraEdicao_QuandoNaoTemMascaraDeEdicao_DeveRetornarMesmoValor()
        {
            // Arrange
            var valorInformado = "02 270 949 0001 37";
            var valorEsperado = "02 270 949 0001 37";

            // Act
            var valorRetornado = valorInformado.RemoverMascaraEdicao();

            // Assert
            Assert.Equal(valorEsperado, valorRetornado);
        }

        [Theory]
        [InlineData("00000000000")]
        [InlineData("aaaaaaaaaaaaaaaa")]
        public void TemCaracterRepetido_QuandoTemCaracterRepeito_DeveRetornarTrue(string valorInformado)
        {
            // Assert
            Assert.True(valorInformado.TemCaracterRepetido());
        }
        
        [Theory]
        [InlineData("056.375.168-12")]
        [InlineData("Marcos Cruz")]
        public void TemCaracterRepetido_QuandoNaoTemCaracterRepeito_DeveRetornarFalse(string valorInformado)
        {
            // Assert
            Assert.False(valorInformado.TemCaracterRepetido());
        }

        [Theory]
        [InlineData("0123456789")]
        public void EhUmNumeroPositivo_DeveReconhecerComoNumeroPositito_True(string valorInformado)
        {
            // Assert
            Assert.True(valorInformado.EhUmNumeroPositivo());
        }

        [Theory]
        [InlineData("056.375.168,12")]
        [InlineData("-056.375.168,12")]
        [InlineData("166a")]
        public void EhUmNumeroPositivo_DeveReconhecerComoNumeroPositito_False(string valorInformado)
        {
            // Assert
            Assert.False(valorInformado.EhUmNumeroPositivo());
        }
    }
}
