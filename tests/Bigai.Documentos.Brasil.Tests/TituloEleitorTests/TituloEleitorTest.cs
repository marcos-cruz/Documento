using Xunit;

namespace Bigai.Documentos.Brasil.Tests.TituloEleitorTests
{
    public class TituloEleitorTest
    {
        [Theory]
        [InlineData("539.731.801-67", "156", "0005")]
        [InlineData("43.568.709-06", "56", "15")]
        public void TituloEleitor_DeveSerValido_True(string numeroTitulo, string zonaEleitoral, string secaoEleitoral)
        {
            // Arrange
            TituloEleitor titulo;

            // Act
            titulo = TituloEleitor.Factory(numeroTitulo, zonaEleitoral, secaoEleitoral);

            // Assert
            Assert.NotNull(titulo);
            Assert.True(titulo.EstaValido());
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("539.731.801-67", null, "0005")]
        [InlineData("539.731.801-67", "156", null)]
        [InlineData(null, "56", "15")]
        public void TituloEleitor_DeveSerValido_False(string numeroTitulo, string zonaEleitoral, string secaoEleitoral)
        {
            // Arrange
            TituloEleitor titulo;

            // Act
            titulo = TituloEleitor.Factory(numeroTitulo, zonaEleitoral, secaoEleitoral);

            // Assert
            Assert.NotNull(titulo);
            Assert.False(titulo.EstaValido());
        }

        [Fact]
        public void TituloEleitor_DeveSerIgual_True()
        {
            // Arrange
            TituloEleitor titulo1;
            TituloEleitor titulo2;
            TituloEleitor titulo3;

            // Act
            titulo1 = TituloEleitor.Factory("539.731.801-67", "156", "0005");
            titulo2 = TituloEleitor.Factory("539.731.801-67", "156", "0005");
            titulo3 = titulo1;

            // Assert
            Assert.True(titulo1 == titulo2);
            Assert.True(titulo2 == titulo3);
        }

        [Fact]
        public void TituloEleitor_DeveSerDiferente_True()
        {
            // Arrange
            TituloEleitor titulo1;
            TituloEleitor titulo2;
            TituloEleitor titulo3;

            // Act
            titulo1 = TituloEleitor.Factory("539.731.801-67", "156", "0005");
            titulo2 = TituloEleitor.Factory("43.568.709-06", "56", "15");
            titulo3 = titulo1;

            // Assert
            Assert.True(titulo1 != titulo2);
            Assert.True(titulo2 != titulo3);
        }

        [Fact]
        public void TituloEleitor_QuandoTiulosSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var titulo1 = TituloEleitor.Factory("539.731.801-67", "156", "0005");
            var titulo2 = TituloEleitor.Factory("539.731.801-67", "156", "0005");

            // Act
            var hashcode1 = titulo1.GetHashCode();
            var hashcode2 = titulo2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void TituloEleitor_QuandoTitulosSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var titulo1 = TituloEleitor.Factory("539.731.801-67", "156", "0005");
            var titulo2 = TituloEleitor.Factory("43.568.709-06", "56", "15");

            // Act
            var hashcode1 = titulo1.GetHashCode();
            var hashcode2 = titulo2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Fact]
        public void TituloEleitor_DeveFormatarCorretamente()
        {
            // Arrange
            string tituloEleitorEsperado = "539.731.801-67";
            TituloEleitor titulo;
            titulo = TituloEleitor.Factory(tituloEleitorEsperado, "156", "0005");

            // Act
            string tituloEleitorFormatado = titulo.ToTituloEleitorFormat();

            // Assert
            Assert.Equal(tituloEleitorEsperado, tituloEleitorFormatado);
        }
    }
}
