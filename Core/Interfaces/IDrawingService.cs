namespace Core.Interfaces
{
    public interface IDrawingService
    {
        void Draw(IEnumerable<IMappable> mapObjects);
    }
}