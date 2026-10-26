using System;
using System.Globalization;
using System.Text.Json;

namespace Banco
{
    internal class Funcoes
    {

        public static List<Conta> CarregarDoArquivo()
        {
            string path = "contas.json";

            try
            {
                if (!File.Exists(path))
                {
                    return new List<Conta>();
                }

                string json = File.ReadAllText(path);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Conta>();
                }

                List<Conta> contasCarregadas = JsonSerializer.Deserialize<List<Conta>>(json);
                return contasCarregadas ?? new List<Conta>();

            }
            catch (IOException e)
            {
                Console.WriteLine("An error accurred");
                Console.WriteLine(e.Message);
                return new List<Conta>();
            }
        }

        public static void SalvarEmArquivo(List<Conta> contas)
        {
            string caminho = "contas.json";
            var opcoes = new JsonSerializerOptions { WriteIndented = true }; //formatação
            string json = JsonSerializer.Serialize(contas, opcoes); //converte em texto json
            File.WriteAllText(caminho, json);
        }


        public static void CadastrarConta(List<Conta> contas)
        {
            Console.Write("Entre o número da conta: ");
            int numeroconta = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Entre o titular da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            string respostaStr = Console.ReadLine();

            char resposta = string.IsNullOrEmpty(respostaStr) ? 'N' : respostaStr[0];
            double valorinicial = 0.0;


            if (resposta == 'S' || resposta == 's')
            {


                Console.Write("Entre o valor de depósito inicial: ");
                valorinicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            Conta usuarios = new Conta(numeroconta, nome, valorinicial);
            contas.Add(usuarios);
            SalvarEmArquivo(contas);
        }

        public static void ExibirContas(List<Conta> contas)
        {

            for (int i = 0; i < contas.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Dados da conta:");
                Console.WriteLine($"Conta  {contas[i].NumeroConta}"
                    + $", Titular:  {contas[i].Nome}"
                    + $", Saldo: $  {contas[i].ValorInicial:F2}");
            }
        }

        public static void DepositoConta(List<Conta> contas)
        {

        }

    }
}
