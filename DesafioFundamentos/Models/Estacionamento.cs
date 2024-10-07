namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            //Console.WriteLine("Digite a placa do veículo para estacionar:");
                while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar, usando a formatação [XXX1111], 3 letras e 4 números:");
                string placa = Console.ReadLine().Trim().ToUpper();

                if (placa.Length == 7 && char.IsLetter(placa[0]) && char.IsLetter(placa[1]) && char.IsLetter(placa[2]) && char.IsDigit(placa[3]))
                {
                    veiculos.Add(placa);
                    Console.WriteLine("-> Veículo cadastrado");
                    break;
                }
                else
                {
                    Console.WriteLine("Formato de placa inválido! A placa deve ter 3 letras seguidas de 4 números.");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            //string placa = "";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                int horas = 0;
                while (true)
                {
                    try
                    {
                        Console.Write("Digite a quantidade de horas: ");
                        horas = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERRO! Valor inválido, Digite novamente");
                    }
                }
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal 
                decimal valorTotal = precoInicial + precoPorHora * horas;                
                // *IMPLEMENTE AQUI*
                // int horas = 0;
                // decimal valorTotal = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                if (!veiculos.Contains(placa))
                {
                    Console.WriteLine("Veículo não encontrado!");
                }
                else
                {
                    veiculos.Remove(placa);
        }
                // *IMPLEMENTE AQUI*
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                Console.WriteLine($"Placa: {placa}");
                }
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
