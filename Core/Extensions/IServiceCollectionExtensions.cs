using Core.Input;
using Core.Interfaces;
using Core.MapObjects.Characters;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRenatoGEServices(this IServiceCollection services)
        {
            services.AddSingleton<IGameEngine, GameEngine>();
            services.AddSingleton<IPlayerCharacter, PlayerCharacter>();
            services.AddSingleton<IInputActionMapService, InputActionMapService>();
            services.AddSingleton<IRenderArea, RenderArea>();
        }
    }
}
