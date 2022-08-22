using ConsoleUI;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

Startup.ConfigureServices(services);

services
    .BuildServiceProvider()
    .GetService<Startup>()?
    .Start();