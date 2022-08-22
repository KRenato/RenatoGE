using Core.Interfaces;

namespace Core.Input
{
    public class InputActionMapService : IInputActionMapService
    {
        private readonly Dictionary<GameInput, Action> _actionMap = new();

        public void Subscribe(GameInput input, Action action)
        {
            if (!_actionMap.TryAdd(input, action))
            {
                throw new InvalidOperationException($"Duplicate {nameof(GameInput)}. Unable to add {input}.");
            }
        }

        public void Invoke(GameInput input)
        {
            if (_actionMap.TryGetValue(input, out Action? action) && action is not null)
            {
                action.Invoke();
                return;
            }

            throw new ArgumentOutOfRangeException(nameof(input));
        }
    }
}
