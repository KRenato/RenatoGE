using ConsoleUI.Services;
using Core;
using Core.Extensions;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public class Startup
    {
        private readonly IGameEngine _engine;

        public Startup(IGameEngine engine)
        {
            _engine = engine;
        }

        public void Start()
        {
            Console.Write($"{Constants.Sequences.SetTitle}RenatoGE by Kevin Renato{Constants.Sequences.Termination}");
            Console.Write(Constants.Sequences.HideCursor);

            int width = 60;
            int height = 30;

            var engineTask = _engine.StartAsync(new Coordinate(1, 1), width, height);

            do
            {
                var keyInfo = Console.ReadKey(true);
                var gameInput = KeyMappingService.GetGameInput(keyInfo);
                if (gameInput.HasValue)
                {
                    _engine.ProcessInput(gameInput.Value);
                }
            } while (_engine.IsRunning);

            engineTask.Wait();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Startup, Startup>();
            services.AddRenatoGEServices();
            services.AddSingleton<ISymbolMappingService, SymbolMappingService>();
            services.AddSingleton<IDrawingService, DrawingService>();
        }
    }
}
