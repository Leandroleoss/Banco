using System;

namespace Banco
{
    public class Conta
    {
        public int NumeroConta { get; private set; }
        public string Nome;
        public double ValorInicial { get; private set; }
        public double Deposito { get; private set; }

        public Conta(int numeroconta, string nome, double valorinicial)
        {
            NumeroConta = numeroconta;
            Nome = nome;
            ValorInicial = valorinicial;
        }

        public void NovoDeposito (double deposito)
        {
            ValorInicial += deposito;
            Console.WriteLine(ValorInicial);
        }
    }
}

