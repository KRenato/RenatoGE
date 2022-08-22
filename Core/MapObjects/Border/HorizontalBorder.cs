namespace Core.MapObjects.Border
{
    public class HorizontalBorder : BorderBase
    {
        public HorizontalBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(HorizontalBorder);
    }
}
