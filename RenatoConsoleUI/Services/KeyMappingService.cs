using Core.Input;

namespace ConsoleUI.Services
{
    public class KeyMappingService
    {
        public static GameInput? GetGameInput(ConsoleKeyInfo keyInfo) => keyInfo.Key switch
        {
            ConsoleKey.A => GameInput.MoveLeft,
            ConsoleKey.D => GameInput.MoveRight,
            ConsoleKey.W => GameInput.MoveUp,
            ConsoleKey.S => GameInput.MoveDown,
            ConsoleKey.Escape => GameInput.EndGame,
            _ => null
        };
    }
}
