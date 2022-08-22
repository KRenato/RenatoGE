using Core.Input;

namespace Core.Interfaces
{
    public interface IInputActionMapService
    {
        void Invoke(GameInput input);
        void Subscribe(GameInput input, Action action);
    }
}