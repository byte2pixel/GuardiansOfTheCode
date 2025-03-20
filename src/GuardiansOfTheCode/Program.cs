using Common;
using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Player;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton(AnsiConsole.Console);
serviceCollection.AddSingleton(new HttpClient());
serviceCollection.AddSingleton<EnemyFactory>(_ => new EnemyFactory(AnsiConsole.Console, 1));
serviceCollection.AddTransient<GameBoard>();
serviceCollection.AddTransient<IApiService, ApiService>();
serviceCollection.AddTransient<PrimaryPlayer>();
var registrar = new DependencyInjectionRegistrar(serviceCollection);
var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<PlayCommand>("play");
});

return await app.RunAsync(args);
