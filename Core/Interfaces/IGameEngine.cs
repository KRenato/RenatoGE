using Core.Input;

namespace Core.Interfaces
{
    public interface IGameEngine
    {
        bool IsRunning { get; }

        void ProcessInput(GameInput input);
        Task StartAsync(Coordinate origin, int width, int height, int delay = 100);
        void Stop();
    }
}