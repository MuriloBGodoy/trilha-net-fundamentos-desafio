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
            // Pede para o usuário digitar uma placa (ReadLine) e adiciona na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Nenhum veículo foi cadastrado.");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine($"O veículo {placa} já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} cadastrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pede para o usuário digitar a placa e armazena na variável placa
            string placa = (Console.ReadLine() ?? string.Empty).Trim();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Valor inválido. Digite um número inteiro de horas (0 ou mais):");
                }

                // Realiza o cálculo: "precoInicial + precoPorHora * horas"
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remove a placa digitada da lista de veículos
                veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());

                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal:N2}");
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
                // Laço de repetição, exibindo os veículos estacionados
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
