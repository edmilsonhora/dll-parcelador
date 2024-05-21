using ESH.Parcelador.Interfaces;

namespace ESH.Parcelador.Testes.UnitTestes
{
    public class ParceladorTestes
    {
        [Fact(DisplayName = "Ao passar valor zero deve lancar exception")]
        public void Teste1()
        {
            IParcelador sut = new Parcelador();

            var result = Assert.Throws<ArgumentException>(() => sut.GerarParcelas(0, 2));

            Assert.Equal("Valor total deve ser maior que zero", result.Message);
        }

        [Fact(DisplayName = "Ao passar qtd parcelas zero deve lancar exception")]
        public void Teste2()
        {
            IParcelador sut = new Parcelador();

            var result = Assert.Throws<ArgumentException>(() => sut.GerarParcelas(20m, 0));

            Assert.Equal("Quantidade de parcelas deve ser maior que zero", result.Message);
        }

        [Fact(DisplayName = "Ao passar qtd parcelas negativa deve lancar exception")]
        public void Teste3()
        {
            IParcelador sut = new Parcelador();

            var result = Assert.Throws<ArgumentException>(() => sut.GerarParcelas(20m, -3));

            Assert.Equal("Quantidade de parcelas deve ser maior que zero", result.Message);
        }

        [Fact(DisplayName = "Ao passar valor negativo deve lancar exception")]
        public void Teste4()
        {
            IParcelador sut = new Parcelador();

            var result = Assert.Throws<ArgumentException>(() => sut.GerarParcelas(-230m, 2));

            Assert.Equal("Valor total deve ser maior que zero", result.Message);
        }

        [Fact(DisplayName = "Ao passar valores as parcelas devem ser geradas")]
        public void Teste5()
        {
            IParcelador sut = new Parcelador();

            var result = sut.GerarParcelas(50m, 2);

            Assert.Equal(25m, result[0]);
            Assert.Equal(25m, result[1]);
        }

        [Theory(DisplayName = "Ao passar varios valores as parcelas devem ser geradas")]
        [InlineData(20, 2, new string[] { "10", "10" })]
        [InlineData(40, 2, new string[] { "20", "20" })]
        [InlineData(100, 3, new string[] { "33,34", "33,33", "33,33" })]
        public void Teste6(decimal valor, int qtd, string[] resultado)
        {
            IParcelador sut = new Parcelador();

            var result = sut.GerarParcelas(valor, qtd);

            Assert.Equal(resultado[0], result[0].ToString());
            Assert.Equal(resultado[1], result[1].ToString());
        }
    }
}
