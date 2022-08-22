namespace Core.MapObjects.Border
{
    public class BottomLeftBorder : BorderBase
    {
        public BottomLeftBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(BottomLeftBorder);
    }
}
