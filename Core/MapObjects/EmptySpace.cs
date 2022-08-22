using Core.Interfaces;

namespace Core.MapObjects
{
    public class EmptySpace : IMappable
    {
        public EmptySpace(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public string SymbolKey => nameof(EmptySpace);

        public Coordinate Coordinate { get; }

        public bool IsCollidable => false;
    }
}
