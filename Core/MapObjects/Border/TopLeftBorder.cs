namespace Core.MapObjects.Border
{
    public class TopLeftBorder : BorderBase
    {
        public TopLeftBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(TopLeftBorder);
    }
}
