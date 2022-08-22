using Core.Interfaces;

namespace Core
{
    public interface IRenderArea
    {
        Coordinate BottomLeft { get; }
        Coordinate BottomRight { get; }
        int Height { get; }
        IEnumerable<IMappable> MapObjects { get; }
        Coordinate Origin { get; }
        Coordinate TopRight { get; }
        int Width { get; }

        void Initialize(Coordinate origin, int width, int height);
        void SetMapObject(IMappable mapObject);
    }
}