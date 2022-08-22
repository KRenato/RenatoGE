namespace Core.Interfaces
{
    public interface IMappable
    {
        string SymbolKey { get; }

        Coordinate Coordinate { get; }

        bool IsCollidable { get; }
    }
}
