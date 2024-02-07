using EntityFNotes.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EntityFNotes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Cria uma coleção de serviços.
            ServiceCollection serviceCollection = new ServiceCollection();

            // ConfigurationBuilder serve para criar configurações para o aplicativo.
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName) // Define o diretório base para a busca de arquivos da configuração.
                .AddJsonFile("appsettings.json") // Adiciona o .json como fonte de configuração.
                .Build(); // Constrói a instância de configuração final.

            // Registrando as classes na coleção de serviços.
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<DataContext>();

            var serviceProvider = serviceCollection.BuildServiceProvider(); // O provedor de serviços é usado para obter as instâncias de serviços registrados.
            var context = serviceProvider.GetService<DataContext>(); // Obtendo uma instância de DataContext.
            
        }
    }
}