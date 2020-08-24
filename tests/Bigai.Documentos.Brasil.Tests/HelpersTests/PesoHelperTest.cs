using Bigai.Documentos.Brasil.Helpers;
using Xunit;

namespace Bigai.Documentos.Brasil.Tests.HelpersTests
{
    public class PesoHelperTest
    {
        [Theory]
        [InlineData("02270949000137", 2, 9, 203)]
        [InlineData("05637516812", 2, 11, 308)]
        public void AplicarPesoDaDireitaParaEsquerda_QuandoTemPesoInicial(string valorInformado, int pesoInicial, int pesoMaximo, int somaEsperada)
        {
            // Act
            int somaRetornada = valorInformado.AplicarPesoDaDireitaParaEsquerda(pesoInicial, pesoMaximo);

            // Assert
            Assert.Equal(somaEsperada, somaRetornada);
        }

        [Fact]
        public void AplicarPesoDaDireitaParaEsquerda_QuandoTemArrayPesos()
        {
            // Arrange
            string valorInformado = "11004249";
            int[] pesoInformado = { 1, 3, 4, 5, 6, 7, 8, 10 };
            int somaEsperada = 164;

            // Act
            int somaRetornada = valorInformado.AplicarPesoDaDireitaParaEsquerda(pesoInformado);

            // Assert
            Assert.Equal(somaEsperada, somaRetornada);
        }

        [Fact]
        public void AplicarPesoDaEsquerdaParaDireita_QuandoTemArrayPesos()
        {
            // Arrange
            string valorInformado = "24985967438";
            int[] pesoInformado = { 7, 4, 1, 8, 5, 2, 1, 6, 3, 7, 4 };
            int somaEsperada = 227;

            // Act
            int somaRetornada = valorInformado.AplicarPesoDaEsquerdaParaDireita(pesoInformado);

            // Assert
            Assert.Equal(somaEsperada, somaRetornada);
        }
    }
}
