using Core.Interfaces;

namespace Core.MapObjects.Characters.Monsters
{
    public class VampireBat : CharacterBase
    {
        public VampireBat(IRenderArea renderArea) : base(renderArea) { }

        public override string SymbolKey => nameof(VampireBat);
    }
}