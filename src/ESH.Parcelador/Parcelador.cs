using ESH.Parcelador.Interfaces;
using System;

namespace ESH.Parcelador
{
    public class Parcelador : IParcelador
    {
        /// <summary>
        /// Função que gera parcelas
        /// </summary>
        /// <param name="valorTotal">Valor total a ser parcelado</param>
        /// <param name="qtdParcelas">numero de parcelas</param>
        /// <returns>Array com valores das parcelas</returns>
        /// <exception cref="ArgumentException">Valor total deve ser maior que zero</exception>
        /// <exception cref="ArgumentException">Qtd Parcelas deve ser maior que zero</exception>
        public decimal[] GerarParcelas(decimal valorTotal, int qtdParcelas)
        {
            Validar(valorTotal, qtdParcelas);

            decimal[] resultado = new decimal[qtdParcelas];

            decimal parcela = decimal.Round(decimal.Divide(valorTotal, Convert.ToDecimal(qtdParcelas)), 2);
            decimal sobra = decimal.Round(decimal.Subtract(valorTotal, decimal.Multiply(parcela, qtdParcelas)), 2);

            for (int i = 0; i < qtdParcelas; i++)
            {
                resultado[i] = parcela;

                if (i == 0)
                    resultado[i] = parcela + sobra;
            }

            return resultado;
        }

        private void Validar(decimal valorTotal, int qtdParcelas)
        {
            if (qtdParcelas <= 0)
            {
                throw new ArgumentException("Quantidade de parcelas deve ser maior que zero");
            }

            if (valorTotal <= 0)
            {
                throw new ArgumentException("Valor total deve ser maior que zero");
            }
        }
    }
}
