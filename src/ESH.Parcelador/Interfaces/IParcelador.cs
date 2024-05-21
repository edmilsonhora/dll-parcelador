namespace ESH.Parcelador.Interfaces
{
    public interface IParcelador
    {
        /// <summary>
        /// Função que gera parcelas
        /// </summary>
        /// <param name="valorTotal">Valor total a ser parcelado</param>
        /// <param name="qtdParcelas">numero de parcelas</param>
        /// <returns>Array com valores das parcelas</returns>
        /// <exception cref="ArgumentException">Valor total deve ser maior que zero</exception>
        /// <exception cref="ArgumentException">Qtd Parcelas deve ser maior que zero</exception>
        decimal[] GerarParcelas(decimal valorTotal, int qtdParcelas);
    }
}
