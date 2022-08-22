using Core.Interfaces;

namespace Core.MapObjects.Characters
{
    public abstract class CharacterBase : ICharacterBase
    {
        private readonly IRenderArea _renderArea;

        internal CharacterBase(IRenderArea renderArea)
        {
            _renderArea = renderArea;
        }

        public Coordinate Coordinate { get; private set; }

        public abstract string SymbolKey { get; }

        public virtual bool IsCollidable => true;

        public virtual void MoveLeft()
        {
            SetPosition(new Coordinate(Coordinate.X - 1, Coordinate.Y));
        }

        public virtual void MoveRight()
        {
            SetPosition(new Coordinate(Coordinate.X + 1, Coordinate.Y));
        }

        public virtual void MoveUp()
        {
            SetPosition(new Coordinate(Coordinate.X, Coordinate.Y - 1));
        }

        public virtual void MoveDown()
        {
            SetPosition(new Coordinate(Coordinate.X, Coordinate.Y + 1));
        }

        public void SetPosition(Coordinate coordinate)
        {
            if (!IsCollision(coordinate))
            {
                Coordinate = coordinate;
            }
        }

        private bool IsCollision(Coordinate coordinate)
        {
            return _renderArea.MapObjects.Any(o => o.Coordinate == coordinate && o.IsCollidable);
        }
    }
}
