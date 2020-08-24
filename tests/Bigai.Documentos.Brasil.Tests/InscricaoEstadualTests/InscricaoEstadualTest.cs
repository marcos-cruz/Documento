using Xunit;

namespace Bigai.Documentos.Brasil.Tests.InscricaoEstadualTests
{
    public class InscricaoEstadualTest
    {
        #region Constantes

        private const string ACRE = "AC";
        private const string ALAGOAS = "AL";
        private const string AMAPA = "AP";
        private const string AMAZONAS = "AM";
        private const string BAHIA = "BA";
        private const string CEARA = "CE";
        private const string DISTRITO_FEDERAL = "DF";
        private const string ESPIRITO_SANTO = "ES";
        private const string GOIAS = "GO";
        private const string MARANHAO = "MA";
        private const string MATO_GROSSO = "MT";
        private const string MATO_GROSSO_SUL = "MS";
        private const string MINAS_GERAIS = "MG";
        private const string PARA = "PA";
        private const string PARAIBA = "PB";
        private const string PARANA = "PR";
        private const string PERNAMBUCO = "PE";
        private const string PIAUI = "PI";
        private const string RIO_DE_JANEIRO = "RJ";
        private const string RIO_GRANDE_DO_NORTE = "RN";
        private const string RIO_GRANDE_DO_SUL = "RS";
        private const string RONDONIA = "RO";
        private const string RORAIMA = "RR";
        private const string SANTA_CATARINA = "SC";
        private const string SAO_PAULO = "SP";
        private const string SERGIPE = "SE";
        private const string TOCANTINS = "TO";

        #endregion

        [Theory]
        [InlineData("ISENTO", ACRE)]
        [InlineData("ISENTO", ALAGOAS)]
        [InlineData("ISENTO", AMAPA)]
        [InlineData("ISENTO", AMAZONAS)]
        [InlineData("ISENTO", BAHIA)]
        [InlineData("ISENTO", CEARA)]
        [InlineData("ISENTO", DISTRITO_FEDERAL)]
        [InlineData("ISENTO", ESPIRITO_SANTO)]
        [InlineData("ISENTO", GOIAS)]
        [InlineData("ISENTO", MARANHAO)]
        [InlineData("ISENTO", MATO_GROSSO)]
        [InlineData("ISENTO", MATO_GROSSO_SUL)]
        [InlineData("ISENTO", MINAS_GERAIS)]
        [InlineData("ISENTO", PARA)]
        [InlineData("ISENTO", PARAIBA)]
        [InlineData("ISENTO", PARANA)]
        [InlineData("ISENTO", PERNAMBUCO)]
        [InlineData("ISENTO", PIAUI)]
        [InlineData("ISENTO", RIO_DE_JANEIRO)]
        [InlineData("ISENTO", RIO_GRANDE_DO_NORTE)]
        [InlineData("ISENTO", RIO_GRANDE_DO_SUL)]
        [InlineData("ISENTO", RONDONIA)]
        [InlineData("ISENTO", RORAIMA)]
        [InlineData("ISENTO", SANTA_CATARINA)]
        [InlineData("ISENTO", SAO_PAULO)]
        [InlineData("ISENTO", SERGIPE)]
        [InlineData("ISENTO", TOCANTINS)]
        [InlineData("01.004.823/001-12", ACRE)]
        [InlineData("0100482300112", ACRE)]
        [InlineData("24.0.00004-8", ALAGOAS)]
        [InlineData("240000048", ALAGOAS)]
        [InlineData("03.012345-9", AMAPA)]
        [InlineData("030123459", AMAPA)]
        [InlineData("87.949.244-9", AMAZONAS)]
        [InlineData("879492449", AMAZONAS)]
        [InlineData("123456-63", BAHIA)]
        [InlineData("12345663", BAHIA)]
        [InlineData("612345-57", BAHIA)]
        [InlineData("1000003-06", BAHIA)]
        [InlineData("06000001-5", CEARA)]
        [InlineData("060000015", CEARA)]
        [InlineData("073.00001.001-09", DISTRITO_FEDERAL)]
        [InlineData("0730000100109", DISTRITO_FEDERAL)]
        [InlineData("90660823-6", ESPIRITO_SANTO)]
        [InlineData("906608236", ESPIRITO_SANTO)]
        [InlineData("10.987.654-7", GOIAS)]
        [InlineData("109876547", GOIAS)]
        [InlineData("11.094.402-0", GOIAS)]
        [InlineData("10.103.105-1", GOIAS)]
        [InlineData("10.119.997-1", GOIAS)]
        [InlineData("12.000038-5", MARANHAO)]
        [InlineData("120000385", MARANHAO)]
        [InlineData("0013000001-9", MATO_GROSSO)]
        [InlineData("00130000019", MATO_GROSSO)]
        [InlineData("28123456-6", MATO_GROSSO_SUL)]
        [InlineData("281234566", MATO_GROSSO_SUL)]
        [InlineData("062.307.904/0081", MINAS_GERAIS)]
        [InlineData("0623079040081", MINAS_GERAIS)]
        [InlineData("15-999999-5", PARA)]
        [InlineData("159999995", PARA)]
        [InlineData("06000001-5", PARAIBA)]
        [InlineData("060000015", PARAIBA)]
        [InlineData("123.45678-50", PARANA)]
        [InlineData("1234567850", PARANA)]
        [InlineData("0321418-40", PERNAMBUCO)]
        [InlineData("032141840", PERNAMBUCO)]
        [InlineData("18.1.001.0000004-9", PERNAMBUCO)]
        [InlineData("18100100000049", PERNAMBUCO)]
        [InlineData("01234567-9", PIAUI)]
        [InlineData("012345679", PIAUI)]
        [InlineData("69.455.18-2", RIO_DE_JANEIRO)]
        [InlineData("69455182", RIO_DE_JANEIRO)]
        [InlineData("20.040.040-1", RIO_GRANDE_DO_NORTE)]
        [InlineData("200400401", RIO_GRANDE_DO_NORTE)]
        [InlineData("20.0.040.040-0", RIO_GRANDE_DO_NORTE)]
        [InlineData("2000400400", RIO_GRANDE_DO_NORTE)]
        [InlineData("224/3658792", RIO_GRANDE_DO_SUL)]
        [InlineData("2243658792", RIO_GRANDE_DO_SUL)]
        [InlineData("101.62521-3", RONDONIA)]
        [InlineData("101625213", RONDONIA)]
        [InlineData("0000000062521-3", RONDONIA)]
        [InlineData("00000000625213", RONDONIA)]
        [InlineData("24006628-1", RORAIMA)]
        [InlineData("240066281", RORAIMA)]
        [InlineData("251.040.852", SANTA_CATARINA)]
        [InlineData("251040852", SANTA_CATARINA)]
        [InlineData("110.042.490.114", SAO_PAULO)]
        [InlineData("110042490114", SAO_PAULO)]
        [InlineData("P-01100424.3/002", SAO_PAULO)]
        [InlineData("P011004243002", SAO_PAULO)]
        [InlineData("27123456-3", SERGIPE)]
        [InlineData("271234563", SERGIPE)]
        [InlineData("29.01.022783.6", TOCANTINS)]
        [InlineData("29010227836", TOCANTINS)]
        public void InscricaoEstadual_DeveSerValido_True(string inscricao, string uf)
        {
            // Arrange
            InscricaoEstadual inscricaoEstadual;

            // Act
            inscricaoEstadual = InscricaoEstadual.Factory(inscricao, uf);

            // Assert
            Assert.NotNull(inscricaoEstadual);
            Assert.True(inscricaoEstadual.EstaValido());
        }

        [Theory]
        [InlineData("", ACRE)]
        [InlineData("", ALAGOAS)]
        [InlineData("", AMAPA)]
        [InlineData("", AMAZONAS)]
        [InlineData("", BAHIA)]
        [InlineData("", CEARA)]
        [InlineData("", DISTRITO_FEDERAL)]
        [InlineData("", ESPIRITO_SANTO)]
        [InlineData("", GOIAS)]
        [InlineData("", MARANHAO)]
        [InlineData("", MATO_GROSSO)]
        [InlineData("", MATO_GROSSO_SUL)]
        [InlineData("", MINAS_GERAIS)]
        [InlineData("", PARA)]
        [InlineData("", PARAIBA)]
        [InlineData("", PARANA)]
        [InlineData("", PERNAMBUCO)]
        [InlineData("", PIAUI)]
        [InlineData("", RIO_DE_JANEIRO)]
        [InlineData("", RIO_GRANDE_DO_NORTE)]
        [InlineData("", RIO_GRANDE_DO_SUL)]
        [InlineData("", RONDONIA)]
        [InlineData("", RORAIMA)]
        [InlineData("", SANTA_CATARINA)]
        [InlineData("", SAO_PAULO)]
        [InlineData("", SERGIPE)]
        [InlineData("", TOCANTINS)]
        [InlineData("01.004.823/001-21", ACRE)]
        [InlineData("240000084", ALAGOAS)]
        [InlineData("030123495", AMAPA)]
        [InlineData("87.949.249-4", AMAZONAS)]
        [InlineData("123456-36", BAHIA)]
        [InlineData("612345-75", BAHIA)]
        [InlineData("1000003-60", BAHIA)]
        [InlineData("06000005-1", CEARA)]
        [InlineData("073.00001.001-90", DISTRITO_FEDERAL)]
        [InlineData("90660826-3", ESPIRITO_SANTO)]
        [InlineData("10.987.657-4", GOIAS)]
        [InlineData("11.094.400-2", GOIAS)]
        [InlineData("10.103.101-5", GOIAS)]
        [InlineData("10.119.991-7", GOIAS)]
        [InlineData("120000358", MARANHAO)]
        [InlineData("0013000009-1", MATO_GROSSO)]
        [InlineData("281234665", MATO_GROSSO_SUL)]
        [InlineData("062.307.904/0018", MINAS_GERAIS)]
        [InlineData("15-999995-9", PARA)]
        [InlineData("06000005-1", PARAIBA)]
        [InlineData("123.45678-05", PARANA)]
        [InlineData("0321418-04", PERNAMBUCO)]
        [InlineData("18.1.001.0000009-4", PERNAMBUCO)]
        [InlineData("012345697", PIAUI)]
        [InlineData("69.455.12-8", RIO_DE_JANEIRO)]
        [InlineData("20.040.014-0", RIO_GRANDE_DO_NORTE)]
        [InlineData("20.0.040.000-4", RIO_GRANDE_DO_NORTE)]
        [InlineData("224/3658729", RIO_GRANDE_DO_SUL)]
        [InlineData("101.62523-1", RONDONIA)]
        [InlineData("0000000062523-1", RONDONIA)]
        [InlineData("24006612-8", RORAIMA)]
        [InlineData("251.040.825", SANTA_CATARINA)]
        [InlineData("110.042.490.141", SAO_PAULO)]
        [InlineData("p-01100424.2/003", SAO_PAULO)]
        [InlineData("27123453-6", SERGIPE)]
        [InlineData("29.01.022786.3", TOCANTINS)]
        public void InscricaoEstadual_DeveSerValido_False(string inscricao, string uf)
        {
            // Arrange
            InscricaoEstadual inscricaoEstadual;

            // Act
            inscricaoEstadual = InscricaoEstadual.Factory(inscricao, uf);

            // Assert
            Assert.NotNull(inscricaoEstadual);
            Assert.False(inscricaoEstadual.EstaValido());
        }

        [Fact]
        public void InscricaoEstadual_DeveSerIgual_True()
        {
            // Arrange
            InscricaoEstadual inscricaoEstadual1;
            InscricaoEstadual inscricaoEstadual2;
            InscricaoEstadual inscricaoEstadual3;

            // Act
            inscricaoEstadual1 = InscricaoEstadual.Factory("110.042.490.114", SAO_PAULO);
            inscricaoEstadual2 = InscricaoEstadual.Factory("110.042.490.114", SAO_PAULO);
            inscricaoEstadual3 = inscricaoEstadual1;

            // Assert
            Assert.True(inscricaoEstadual1 == inscricaoEstadual2);
            Assert.True(inscricaoEstadual2 == inscricaoEstadual3);
        }

        [Fact]
        public void InscricaoEstadual_DeveSerDiferente_True()
        {
            // Arrange
            InscricaoEstadual inscricaoEstadual1;
            InscricaoEstadual inscricaoEstadual2;
            InscricaoEstadual inscricaoEstadual3;

            // Act
            inscricaoEstadual1 = InscricaoEstadual.Factory("110.042.490.114", SAO_PAULO);
            inscricaoEstadual2 = InscricaoEstadual.Factory("ISENTO", SAO_PAULO);
            inscricaoEstadual3 = inscricaoEstadual1;

            // Assert
            Assert.True(inscricaoEstadual1 != inscricaoEstadual2);
            Assert.True(inscricaoEstadual2 != inscricaoEstadual3);
        }

        [Fact]
        public void InscricaoEstadual_QuandoInscricoesEstaduaisSaoIguais_DeveGerarMesmoHashCode()
        {
            // Arrange
            var inscricaoEstadual1 = InscricaoEstadual.Factory("p-01100424.2/003", "SP");
            var inscricaoEstadual2 = InscricaoEstadual.Factory("P-01100424.2/003", "SP");

            // Act
            var hashcode1 = inscricaoEstadual1.GetHashCode();
            var hashcode2 = inscricaoEstadual2.GetHashCode();

            // Assert
            Assert.Equal(hashcode1, hashcode2);
        }

        [Fact]
        public void InscricaoEstadual_QuandoInscricoesEstaduaisSaoDiferentes_DeveGerarHashCodeDiferentes()
        {
            // Arrange
            var inscricaoEstadual1 = InscricaoEstadual.Factory("p-01100424.2/003", "SP");
            var inscricaoEstadual2 = InscricaoEstadual.Factory("110.042.490.141", "SP");

            // Act
            var hashcode1 = inscricaoEstadual1.GetHashCode();
            var hashcode2 = inscricaoEstadual2.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode1, hashcode2);
        }

        [Theory]
        [InlineData("ISENTO", ACRE)]
        [InlineData("ISENTO", ALAGOAS)]
        [InlineData("ISENTO", AMAPA)]
        [InlineData("ISENTO", AMAZONAS)]
        [InlineData("ISENTO", BAHIA)]
        [InlineData("ISENTO", CEARA)]
        [InlineData("ISENTO", DISTRITO_FEDERAL)]
        [InlineData("ISENTO", ESPIRITO_SANTO)]
        [InlineData("ISENTO", GOIAS)]
        [InlineData("ISENTO", MARANHAO)]
        [InlineData("ISENTO", MATO_GROSSO)]
        [InlineData("ISENTO", MATO_GROSSO_SUL)]
        [InlineData("ISENTO", MINAS_GERAIS)]
        [InlineData("ISENTO", PARA)]
        [InlineData("ISENTO", PARAIBA)]
        [InlineData("ISENTO", PARANA)]
        [InlineData("ISENTO", PERNAMBUCO)]
        [InlineData("ISENTO", PIAUI)]
        [InlineData("ISENTO", RIO_DE_JANEIRO)]
        [InlineData("ISENTO", RIO_GRANDE_DO_NORTE)]
        [InlineData("ISENTO", RIO_GRANDE_DO_SUL)]
        [InlineData("ISENTO", RONDONIA)]
        [InlineData("ISENTO", RORAIMA)]
        [InlineData("ISENTO", SANTA_CATARINA)]
        [InlineData("ISENTO", SAO_PAULO)]
        [InlineData("ISENTO", SERGIPE)]
        [InlineData("ISENTO", TOCANTINS)]
        [InlineData("01.004.823/001-12", ACRE)]
        [InlineData("24.0.00004-8", ALAGOAS)]
        [InlineData("03.012345-9", AMAPA)]
        [InlineData("87.949.244-9", AMAZONAS)]
        [InlineData("123456-63", BAHIA)]
        [InlineData("612345-57", BAHIA)]
        [InlineData("1000003-06", BAHIA)]
        [InlineData("06000001-5", CEARA)]
        [InlineData("073.00001.001-09", DISTRITO_FEDERAL)]
        [InlineData("90660823-6", ESPIRITO_SANTO)]
        [InlineData("10.987.654-7", GOIAS)]
        [InlineData("11.094.402-0", GOIAS)]
        [InlineData("10.103.105-1", GOIAS)]
        [InlineData("10.119.997-1", GOIAS)]
        [InlineData("12.000038-5", MARANHAO)]
        [InlineData("0013000001-9", MATO_GROSSO)]
        [InlineData("28123456-6", MATO_GROSSO_SUL)]
        [InlineData("062.307.904/0081", MINAS_GERAIS)]
        [InlineData("15-999999-5", PARA)]
        [InlineData("06000001-5", PARAIBA)]
        [InlineData("123.45678-50", PARANA)]
        [InlineData("0321418-40", PERNAMBUCO)]
        [InlineData("18.1.001.0000004-9", PERNAMBUCO)]
        [InlineData("01234567-9", PIAUI)]
        [InlineData("69.455.18-2", RIO_DE_JANEIRO)]
        [InlineData("20.040.040-1", RIO_GRANDE_DO_NORTE)]
        [InlineData("20.0.040.040-0", RIO_GRANDE_DO_NORTE)]
        [InlineData("224/3658792", RIO_GRANDE_DO_SUL)]
        [InlineData("101.62521-3", RONDONIA)]
        [InlineData("0000000062521-3", RONDONIA)]
        [InlineData("24006628-1", RORAIMA)]
        [InlineData("251.040.852", SANTA_CATARINA)]
        [InlineData("110.042.490.114", SAO_PAULO)]
        [InlineData("P-01100424.3/002", SAO_PAULO)]
        [InlineData("27123456-3", SERGIPE)]
        [InlineData("29.01.022783.6", TOCANTINS)]
        public void InscricaoEstadual_DeveFormatarConformeEstadoEmissor(string inscricao, string uf)
        {
            // Arrange
            InscricaoEstadual inscricaoEstadual;
            inscricaoEstadual = InscricaoEstadual.Factory(inscricao, uf);

            // Act
            string inscricaoEstadualFormatada = inscricaoEstadual.ToInscricaoEstadualFormat();

            // Assert
            Assert.Equal(inscricao, inscricaoEstadualFormatada);
        }
    }
}
