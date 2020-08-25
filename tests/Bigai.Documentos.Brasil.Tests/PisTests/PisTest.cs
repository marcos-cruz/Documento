using Xunit;

namespace Bigai.Documentos.Brasil.Tests.PisTests
{
    public class PisTest
    {
        [Theory]
        [InlineData("108.558.158-57")]
        [InlineData("10855815857")]
        public void Pis_DeveSerValido_True(string numeroPis)
        {
            // Arrange
            Pis pis;

            // Act
            pis = Pis.Factory(numeroPis);

            // Assert
            Assert.NotNull(pis);
            Assert.True(pis.EstaValido());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("108.558.158-75")]
        [InlineData("10855815875")]
        public void Pis_DeveSerValido_False(string numeroPis)
        {
            // Arrange
            Pis pis;

            // Act
            pis = Pis.Factory(numeroPis);

            // Assert
            Assert.NotNull(pis);
            Assert.False(pis.EstaValido());
        }

        [Fact]
        public void Pis_DeveSerIgual_True()
        {
            // Arrange
            Pis pis1;
            Pis pis2;
            Pis pis3;

            // Act
            pis1 = Pis.Factory("108.558.158-57");
            pis2 = Pis.Factory("10855815857");
            pis3 = pis1;

            // Assert
            Assert.True(pis1 == pis2);
            Assert.True(pis2 == pis3);
        }

        [Fact]
        public void Pis_DeveSerDiferente_True()
        {
            // Arrange
            Pis pis1;
            Pis pis2;
            Pis pis3;

            // Act
            pis1 = Pis.Factory("108.558.158-57");
            pis2 = Pis.Factory("120.844.879-53");
            pis3 = pis1;

            // Assert
            Assert.True(pis1 != pis2);
            Assert.True(pis2 != pis3);
        }

        [Fact]
        public void Pis_QuandoPisSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            Pis pis1 = Pis.Factory("108.558.158-57");
            Pis pis2 = Pis.Factory("108.558.158-57");

            // Act
            var hashcode1 = pis1.GetHashCode();
            var hashcode2 = pis2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void Pis_QuandoPisSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            Pis pis1 = Pis.Factory("108.558.158-57");
            Pis pis2 = Pis.Factory("120.844.879-53");

            // Act
            var hashcode1 = pis1.GetHashCode();
            var hashcode2 = pis2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Fact]
        public void Pis_DeveFormatarCorretamente()
        {
            // Arrange
            string numeroPisEsperado = "108.558.158-57";
            Pis pis;
            pis = Pis.Factory(numeroPisEsperado);

            // Act
            string pisFormatado = pis.ToPisFormat();

            // Assert
            Assert.Equal(numeroPisEsperado, pisFormatado);
        }
    }
}
