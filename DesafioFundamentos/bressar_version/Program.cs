// Versão do Bressar à partir de um código que fiz em Python(só removi o "flask" e deixei a lógica)
// Sistema de Estacionamento(veículos)
// Versão feita em C#

using System;
using System.Collections.Generic;

class Estacionamento
{
    
    private decimal precoInicial;
    private decimal precoHora;
    private List<string> listaVeiculos;

    public Estacionamento(decimal precoInicial = 1.0M, decimal precoHora = 1.0M)
    {
        this.precoInicial = precoInicial;
        this.precoHora = precoHora;
        this.listaVeiculos = new List<string>();
    }

    private void Linha(string padrao = "-", int valor = 0)
    {
        Console.WriteLine(new string(padrao[0], valor));
    }

    private void ValoresEntrada()
    {
        while (true)
        {
            try
            {
                Console.Write("Digite a taxa inicial: € ");
                precoInicial = Convert.ToDecimal(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("ERRO! Valor inválido, Digite novamente");
                Linha("-", 40);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Digite o valor da hora: € ");
                precoHora = Convert.ToDecimal(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("ERRO! Valor inválido, Digite novamente");
                Linha("-", 40);
            }
        }

        int quantidadeHoras = 0;
        while (true)
        {
            try
            {
                Console.Write("Digite a quantidade de horas: ");
                quantidadeHoras = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("ERRO! Valor inválido, Digite novamente");
                Linha("-", 40);
            }
        }

        decimal totalAPagar = precoInicial + (precoHora * quantidadeHoras);

        Linha("-", 40);
        Console.WriteLine($"Taxa de estacionamento: € {precoInicial:F2}");
        Console.WriteLine($"Valor da Hora: € {precoHora:F2}");
        Console.WriteLine($"Tempo de permanência: {quantidadeHoras} horas");
        Console.WriteLine($"TOTAL A PAGAR: € {totalAPagar:F2}");
        Linha("-", 40);
    }

    public void AdicionarVeiculo()
    {
        while (true)
        {
            Console.WriteLine("Digite a placa do veículo para estacionar, usando a formatação [XXX1111], 3 letras e 4 números:");
            string placaVeiculo = Console.ReadLine().Trim().ToUpper();

            if (placaVeiculo.Length == 7 && char.IsLetter(placaVeiculo[0]) && char.IsLetter(placaVeiculo[1]) && char.IsLetter(placaVeiculo[2]) && char.IsDigit(placaVeiculo[3]))
            {
                listaVeiculos.Add(placaVeiculo);
                Console.WriteLine("-> Veículo cadastrado");
                Linha("-", 40);
                break;
            }
            else
            {
                Console.WriteLine("Formato de placa inválido! A placa deve ter 3 letras seguidas de 4 números.");
                Linha("-", 40);
            }
        }
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa para remover o veículo:");
        string removerVeiculo = Console.ReadLine().Trim().ToUpper();

        if (!listaVeiculos.Contains(removerVeiculo))
        {
            Console.WriteLine("Veículo não encontrado!");
        }
        else
        {
            listaVeiculos.Remove(removerVeiculo);
            Console.WriteLine("Veículo Removido!");
            Linha("-", 40);
            ValoresEntrada();
        }
    }

    public void ListarVeiculos()
    {
        if (listaVeiculos.Count == 0)
        {
            Console.WriteLine("Não há veículos listados");
        }
        else
        {
            Linha("-", 40);
            Console.WriteLine("OS VEÍCULOS ESTACIONADOS SÃO:");
            foreach (string placa in listaVeiculos)
            {
                Console.WriteLine($"Placa: {placa}");
            }
            Linha("-", 40);
        }
    }

    public void MenuOpcoes()
    {
        while (true)
        {
            Linha("-", 40);
            Console.WriteLine(@"DIGITE SUA OPÇÃO:
[1] -> Cadastrar Veículo
[2] -> Remover Veículo
[3] -> Listar Veículos
[4] -> Encerrar");
            Linha("-", 40);

            string escolha = Console.ReadLine();

            if (escolha.Length != 1 || !"1234".Contains(escolha))
            {
                Console.WriteLine("ERRO! Escolha um número entre 1 e 4");
                Linha("-", 40);
                continue;
            }

            switch (escolha)
            {
                case "1":
                    AdicionarVeiculo();
                    break;
                case "2":
                    RemoverVeiculo();
                    break;
                case "3":
                    ListarVeiculos();
                    break;
                case "4":
                    Linha("-", 40);
                    Console.WriteLine("Encerrando o programa");
                    Linha("-", 40);
                    return;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Configurar a codificação UTF-8 no console
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Estacionamento estacionamento = new Estacionamento(0, 1.5M);
        estacionamento.MenuOpcoes();
    }
}