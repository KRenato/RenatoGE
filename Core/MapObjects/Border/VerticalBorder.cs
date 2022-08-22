namespace Core.MapObjects.Border
{
    public class VerticalBorder : BorderBase
    {
        public VerticalBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(VerticalBorder);
    }
}
