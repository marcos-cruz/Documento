using Bigai.Documentos.Brasil.Generics;
using Xunit;

namespace Bigai.Documentos.Brasil.Tests.GenericsTests
{
    public class ValueObjectTest
    {
        #region Teste de Criação da Classe

        class TesteValueObject : ValueObject<TesteValueObject>
        {
            public string PropriedadePublica { get; set; }
            protected string PropriedadeProtegida { get; set; }
            private string PropriedadePrivada { get; set; }

            public int CampoPublico;
            protected int CampoProtegido;
            private int CampoPrivado;

            public TesteValueObject() { }

            public TesteValueObject(string propriedadePublica, string propriedadeProtegida, string propriedadePrivada, int campoPublico, int campoProtegido, int campoPrivado)
            {
                PropriedadePublica = propriedadePublica;
                PropriedadeProtegida = propriedadeProtegida;
                PropriedadePrivada = propriedadePrivada;
                CampoPublico = campoPublico;
                CampoProtegido = campoProtegido;
                CampoPrivado = campoPrivado;
            }

            protected override bool EqualsCore(TesteValueObject obj)
            {
                return PropriedadePublica == obj.PropriedadePublica &&
                       PropriedadeProtegida == obj.PropriedadeProtegida &&
                       PropriedadePrivada == obj.PropriedadePrivada &&
                       CampoPublico == obj.CampoPublico &&
                       CampoProtegido == obj.CampoProtegido &&
                       CampoPrivado == obj.CampoPrivado;
            }
        }

        [Fact]
        public void Equals_QuandoNaoPopulado_DeveSerConsideradoIgual()
        {
            // Arrange
            TesteValueObject valor1 = new TesteValueObject();
            TesteValueObject valor2 = new TesteValueObject();

            // Act
            bool igual = valor1.Equals(valor2);

            // Assert
            Assert.True(igual);
        }

        [Fact]
        public void Equals_QuandoParcialmentePopulado_DeveSerConsideradoIgual()
        {
            // Arrange
            TesteValueObject valor1 = new TesteValueObject();
            TesteValueObject valor2 = new TesteValueObject();
            valor1.CampoPublico = 1;
            valor1.PropriedadePublica = "teste";
            valor2.CampoPublico = 1;
            valor2.PropriedadePublica = "teste";

            // Act
            bool igual = valor1.Equals(valor2);

            // Assert
            Assert.True(igual);
        }

        [Fact]
        public void Equals_QuandoTotalmentePopulado_DeveSerConsideradoIgual()
        {
            // Arrange
            TesteValueObject valor1 = new TesteValueObject("um", "dois", "três", 1, 2, 3);
            TesteValueObject valor2 = new TesteValueObject("um", "dois", "três", 1, 2, 3);

            // Act
            bool igual = valor1.Equals(valor2);

            // Assert
            Assert.True(igual);
        }

        [Fact]
        public void Equals_QuandoUmNaoEhPopulado_E_OutroEhPopulado_DeveSerConsideradoDiferente()
        {
            // Arrange
            var valor1 = new TesteValueObject();
            var valor2 = new TesteValueObject
            {
                CampoPublico = 2
            };

            // Act
            bool igual = valor1.Equals(valor2);

            // Assert
            Assert.False(igual);
        }

        [Fact]
        public void GetHashCode_QuandoObjetosSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var valor1 = new TesteValueObject("um", "dois", "três", 1, 2, 3);
            var valor2 = new TesteValueObject("um", "dois", "três", 1, 2, 3);

            // Act
            var hashcode1 = valor1.GetHashCode();
            var hashcode2 = valor2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void GetHashCode_QuandoObjetosSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var valor1 = new TesteValueObject("um", "dois", "três", 1, 2, 3);
            var valor2 = new TesteValueObject("hum", "dois", "três", 1, 2, 3);

            // Act
            var hashcode1 = valor1.GetHashCode();
            var hashcode2 = valor2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        #endregion

        #region Teste de Herança

        class UmValor : ValueObject<UmValor>
        {
            public int Num;

            protected override bool EqualsCore(UmValor obj)
            {
                return Num == obj.Num;
            }
        }

        class OutroValor : UmValor
        {
        }

        [Fact]
        public void Heranca_ObjetosDeTiposDiferentes_NaoDevemSerIguaisMesmoSendoSubClasse()
        {
            // Arrange
            var valor1 = new UmValor();
            var valor2 = new OutroValor();

            // Act
            bool igual = valor1.Equals(valor2);

            // Assert
            Assert.False(igual);
        }

        #endregion

        #region Teste de Composição/Recursividade

        class Recursive : ValueObject<Recursive>
        {
            public Recursive Recurse { get; set; }
            public string Terminal;

            protected override bool EqualsCore(Recursive obj)
            {
                return Terminal == obj.Terminal;
            }
        }

        [Fact]
        public void ValueObject_Nesting()
        {
            // Arrange
            var valor1 = new Recursive();
            var valor2 = new Recursive();
            var valorAninhado1 = new Recursive() { Terminal = "teste" };
            var valorAninhado2 = new Recursive() { Terminal = "teste" };

            // Act
            valor1.Recurse = valorAninhado1;
            valor2.Recurse = valorAninhado2;

            // Assert
            Assert.True(valor1.Equals(valor2));
            Assert.Equal(valor1.GetHashCode(), valor2.GetHashCode());
        }

        #endregion
    }
}