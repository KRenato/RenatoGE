namespace Core.MapObjects.Border
{
    public class BottomRightBorder : BorderBase
    {
        public BottomRightBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(BottomRightBorder);
    }
}
