using Core.Interfaces;

namespace Core.MapObjects.Border
{
    public abstract class BorderBase : IMappable
    {
        protected BorderBase(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public abstract string SymbolKey { get; }

        public Coordinate Coordinate { get; }

        public bool IsCollidable => true;
    }
}
