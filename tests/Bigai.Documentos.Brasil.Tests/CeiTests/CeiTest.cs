using Xunit;

namespace Bigai.Documentos.Brasil.Tests.CeiTests
{
    public class CeiTest
    {
        [Theory]
        [InlineData("24.985.96743/86")]
        [InlineData("249859674386")]
        public void Cei_DeveSerValido_True(string numeroCei)
        {
            // Arrange
            Cei Cei;

            // Act
            Cei = Cei.Factory(numeroCei);

            // Assert
            Assert.NotNull(Cei);
            Assert.True(Cei.EstaValido());
        }

        [Theory]
        [InlineData("")]
        [InlineData("24.985.96743/68")]
        [InlineData("249859674368")]
        public void Cei_DeveSerValido_False(string numeroCei)
        {
            // Arrange
            Cei Cei;

            // Act
            Cei = Cei.Factory(numeroCei);

            // Assert
            Assert.NotNull(Cei);
            Assert.False(Cei.EstaValido());
        }

        [Fact]
        public void Cei_DeveSerIgual_True()
        {
            // Arrange
            Cei Cei1;
            Cei Cei2;
            Cei Cei3;

            // Act
            Cei1 = Cei.Factory("24.985.96743/86");
            Cei2 = Cei.Factory("24.985.96743/86");
            Cei3 = Cei1;

            // Assert
            Assert.True(Cei1 == Cei2);
            Assert.True(Cei2 == Cei3);
        }

        [Fact]
        public void Cei_DeveSerDiferente_True()
        {
            // Arrange
            Cei Cei1;
            Cei Cei2;
            Cei Cei3;

            // Act
            Cei1 = Cei.Factory("24.985.96743/86");
            Cei2 = Cei.Factory("27.247.25187/86");
            Cei3 = Cei1;

            // Assert
            Assert.True(Cei1 != Cei2);
            Assert.True(Cei2 != Cei3);
        }

        [Fact]
        public void Cei_QuandoCeisSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var Cei1 = Cei.Factory("20.381.44217/87");
            var Cei2 = Cei.Factory("203814421787");

            // Act
            var hashcode1 = Cei1.GetHashCode();
            var hashcode2 = Cei2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void Cei_QuandoCeisSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var Cei1 = Cei.Factory("20.381.44217/87");
            var Cei2 = Cei.Factory("27.247.25187/86");

            // Act
            var hashcode1 = Cei1.GetHashCode();
            var hashcode2 = Cei2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Fact]
        public void Cei_DeveFormatarCorretamente()
        {
            // Arrange
            string numeroCeiEsperado = "27.247.25187/86";
            Cei Cei;
            Cei = Cei.Factory(numeroCeiEsperado);

            // Act
            string CeiFormatado = Cei.ToCeiFormat();

            // Assert
            Assert.Equal(numeroCeiEsperado, CeiFormatado);
        }
    }
}
