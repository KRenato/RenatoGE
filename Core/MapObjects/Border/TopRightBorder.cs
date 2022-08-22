namespace Core.MapObjects.Border
{
    public class TopRightBorder : BorderBase
    {
        public TopRightBorder(Coordinate coordinate) : base(coordinate) { }

        public override string SymbolKey => nameof(TopRightBorder);
    }
}
