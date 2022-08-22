using Core.Input;
using Core.Interfaces;

namespace Core.MapObjects.Characters
{
    public class PlayerCharacter : CharacterBase, IPlayerCharacter
    {
        public PlayerCharacter(IInputActionMapService actionMapService, IRenderArea renderArea) : base(renderArea)
        {
            actionMapService.Subscribe(GameInput.MoveLeft, MoveLeft);
            actionMapService.Subscribe(GameInput.MoveRight, MoveRight);
            actionMapService.Subscribe(GameInput.MoveUp, MoveUp);
            actionMapService.Subscribe(GameInput.MoveDown, MoveDown);
        }

        public override string SymbolKey => nameof(PlayerCharacter);
    }
}
