using Xunit;

namespace Bigai.Documentos.Brasil.Tests.CpfTests
{
    public class CpfTest
    {
        [Theory]
        [InlineData("056.375.168-12")]
        [InlineData("05637516812")]
        [InlineData("56.375.168-12")]
        public void Cpf_DeveSerValido_True(string numeroCpf)
        {
            // Arrange
            Cpf Cpf;

            // Act
            Cpf = Cpf.Factory(numeroCpf);

            // Assert
            Assert.NotNull(Cpf);
            Assert.True(Cpf.EstaValido());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("056.375.168-21")]
        [InlineData("05637516821")]
        [InlineData("56.375.168-21")]
        public void Cpf_DeveSerValido_False(string numeroCpf)
        {
            // Arrange
            Cpf Cpf;

            // Act
            Cpf = Cpf.Factory(numeroCpf);

            // Assert
            Assert.NotNull(Cpf);
            Assert.False(Cpf.EstaValido());
        }

        [Fact]
        public void Cpf_DeveSerIgual_True()
        {
            // Arrange
            Cpf cpf1;
            Cpf cpf2;
            Cpf cpf3;

            // Act
            cpf1 = Cpf.Factory("056.375.168-12");
            cpf2 = Cpf.Factory("056.375.168-12");
            cpf3 = cpf1;

            // Assert
            Assert.True(cpf1 == cpf2);
            Assert.True(cpf2 == cpf3);
        }

        [Fact]
        public void Cpf_DeveSerDiferente_True()
        {
            // Arrange
            Cpf cpf1;
            Cpf cpf2;
            Cpf cpf3;

            // Act
            cpf1 = Cpf.Factory("056.375.168-12");
            cpf2 = Cpf.Factory("100.295.188-60");
            cpf3 = cpf1;

            // Assert
            Assert.True(cpf1 != cpf2);
            Assert.True(cpf2 != cpf3);
        }

        [Fact]
        public void Cpf_QuandoCpfsSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var Cpf1 = Cpf.Factory("056.375.168-12");
            var Cpf2 = Cpf.Factory("05637516812");

            // Act
            var hashcode1 = Cpf1.GetHashCode();
            var hashcode2 = Cpf2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void Cpf_QuandoCpfsSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var Cpf1 = Cpf.Factory("056.375.168-12");
            var Cpf2 = Cpf.Factory("100.295.118-60");

            // Act
            var hashcode1 = Cpf1.GetHashCode();
            var hashcode2 = Cpf2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Fact]
        public void Cpf_DeveFormatarCorretamente()
        {
            // Arrange
            string numeroCpfEsperado = "056.375.168-12";
            Cpf Cpf;
            Cpf = Cpf.Factory(numeroCpfEsperado);

            // Act
            string CpfFormatado = Cpf.ToCpfFormat();

            // Assert
            Assert.Equal(numeroCpfEsperado, CpfFormatado);
        }
    }
}
