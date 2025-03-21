using Common;
using GuardiansOfTheCode.Enemies;
using GuardiansOfTheCode.Facades;
using GuardiansOfTheCode.Player;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton(AnsiConsole.Console);
serviceCollection.AddSingleton(new HttpClient());
serviceCollection.AddTransient<GameBoard>();
serviceCollection.AddTransient<ICardService, CardService>();
serviceCollection.AddTransient<PrimaryPlayer>();
serviceCollection.AddTransient<GameBoardFacade>();
var registrar = new DependencyInjectionRegistrar(serviceCollection);
var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<PlayCommand>("play");
});

return await app.RunAsync(args);
