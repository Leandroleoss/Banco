using System;
using System.Globalization;

namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();
            Funcoes.CadastrarConta(contas);
            Funcoes.ExibirContas(contas);
            Funcoes.DepositoConta(contas);
        }
    }
}