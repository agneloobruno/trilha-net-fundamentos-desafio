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

        // Função para adicionar veículo
        //Implementado!!!
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novoVeiculo = Console.ReadLine();

            bool veiculoExiste = veiculos.Any(x => x.ToUpper() == novoVeiculo.ToUpper());
            if (veiculoExiste)
            {
                Console.WriteLine("Veículo já está estacionado.");
                Console.WriteLine("O cadastro foi cancelado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
            else
            {
                veiculos.Add(novoVeiculo);
            }

            if (veiculos.Contains(novoVeiculo))
            {
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao adicionar veículo.");
            }
        }

        // Função para remover veículo
        //Implementado!!!
        public void RemoverVeiculo()
        {
            // Verifica se o veículo existe
            Console.WriteLine("Digite a placa do veículo para pesquisar:");
            string placa = Console.ReadLine();

            var veiculoEncontrado = veiculos.Where(x => x.ToUpper() == placa.ToUpper()).ToList();
            if (veiculoEncontrado.Any())
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(veiculoEncontrado[0]);
                Console.WriteLine($"O veículo {veiculoEncontrado[0]} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        // Função para listar veículos
        //Implementado!!!
        public void ListarVeiculos()
        {
            bool menuListarVeiculos = true;

            while (menuListarVeiculos)
            {
                Console.Clear();
                Console.WriteLine("================Veículos Estacionados================");
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Listar todos os veículos");
                Console.WriteLine("2 - Listar veículos por placa");
                Console.WriteLine("3 - Retornar ao menu principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListarTodosVeiculos();
                        break;

                    case "2":
                        ListarVeiculosPorPlaca();
                        break;
                    case "3":
                        menuListarVeiculos = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


                // Verifica se há veículos no estacionamento
                void ListarTodosVeiculos()
                {
                    Console.WriteLine("Os veículos estacionados são:");
                    foreach (var veiculo in veiculos)
                    {
                        Console.WriteLine(veiculo);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

                // Função para listar um veículo por placa
                void ListarVeiculosPorPlaca()
                {
                    Console.WriteLine("Digite a placa do veículo para pesquisar:");
                    string placa = Console.ReadLine();

                    var veiculoEncontrado = veiculos.Where(x => x.ToUpper() == placa.ToUpper()).ToList();
                    if (veiculoEncontrado.Any())
                    {
                        Console.WriteLine($"Veículo encontrado: {veiculoEncontrado[0]}");
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado.");
                    }

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
