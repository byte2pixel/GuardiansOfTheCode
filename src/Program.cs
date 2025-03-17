using GuardiansOfTheCode.Enemies;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton(AnsiConsole.Console);
serviceCollection.AddSingleton<EnemyFactory>();
serviceCollection.AddTransient<GameBoard>();
var registrar = new DependencyInjectionRegistrar(serviceCollection);
var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<PlayCommand>("play");
});

return await app.RunAsync(args);
