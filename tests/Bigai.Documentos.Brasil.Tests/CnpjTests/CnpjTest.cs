using Xunit;

namespace Bigai.Documentos.Brasil.Tests.CnpjTests
{
    public class CnpjTest
    {
        [Theory]
        [InlineData("02.270.949/0001-37")]
        [InlineData("02270949000137")]
        [InlineData("2.270.949/0001-37")]
        public void Cnpj_DeveSerValido_True(string numeroCnpj)
        {
            // Arrange
            Cnpj cnpj;

            // Act
            cnpj = Cnpj.Factory(numeroCnpj);

            // Assert
            Assert.NotNull(cnpj);
            Assert.True(cnpj.EstaValido());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("02.270.949/0001-73")]
        [InlineData("02270949000173")]
        [InlineData("2.270.949/0001-73")]
        public void Cnpj_DeveSerValido_False(string numeroCnpj)
        {
            // Arrange
            Cnpj cnpj;

            // Act
            cnpj = Cnpj.Factory(numeroCnpj);

            // Assert
            Assert.NotNull(cnpj);
            Assert.False(cnpj.EstaValido());
        }

        [Fact]
        public void Cnpj_DeveSerIgual_True()
        {
            // Arrange
            Cnpj cnpj1;
            Cnpj cnpj2;
            Cnpj cnpj3;

            // Act
            cnpj1 = Cnpj.Factory("02.270.949/0001-37");
            cnpj2 = Cnpj.Factory("02.270.949/0001-37");
            cnpj3 = cnpj1;

            // Assert
            Assert.True(cnpj1 == cnpj2);
            Assert.True(cnpj2 == cnpj3);
        }

        [Fact]
        public void Cnpj_DeveSerDiferente_True()
        {
            // Arrange
            Cnpj cnpj1;
            Cnpj cnpj2;
            Cnpj cnpj3;

            // Act
            cnpj1 = Cnpj.Factory("02.270.949/0001-37");
            cnpj2 = Cnpj.Factory("63.935.829/0001-04");
            cnpj3 = cnpj1;

            // Assert
            Assert.True(cnpj1 != cnpj2);
            Assert.True(cnpj2 != cnpj3);
        }

        [Fact]
        public void Cnpj_QuandoCnpjsSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var cnpj1 = Cnpj.Factory("02.270.949/0001-37");
            var cnpj2 = Cnpj.Factory("02.270.949/0001-37");

            // Act
            var hashcode1 = cnpj1.GetHashCode();
            var hashcode2 = cnpj2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void Cnpj_QuandoCnpjsSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var cnpj1 = Cnpj.Factory("02.270.949/0001-37");
            var cnpj2 = Cnpj.Factory("63.935.829/0001-04");

            // Act
            var hashcode1 = cnpj1.GetHashCode();
            var hashcode2 = cnpj2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Fact]
        public void Cnpj_DeveFormatarCorretamente()
        {
            // Arrange
            string numeroCnpjEsperado = "02.270.949/0001-37";
            Cnpj cnpj;
            cnpj = Cnpj.Factory(numeroCnpjEsperado);

            // Act
            string cnpjFormatado = cnpj.ToCnpjFormat();

            // Assert
            Assert.Equal(numeroCnpjEsperado, cnpjFormatado);
        }
    }
}
