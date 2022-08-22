using Core.Interfaces;
using Core.MapObjects.Border;

namespace Core
{
    public class RenderArea : IRenderArea
    {
        private readonly RenderMap _renderMap = new();

        public Coordinate Origin { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Coordinate TopRight
        {
            get
            {
                int x = Origin.X + Width - 1;
                return new Coordinate(x, Origin.Y);
            }
        }

        public Coordinate BottomLeft
        {
            get
            {
                int y = Origin.Y + Height - 1;
                return new Coordinate(Origin.X, y);
            }
        }

        public Coordinate BottomRight
        {
            get
            {
                int x = Origin.X + Width - 1;
                int y = Origin.Y + Height - 1;
                return new Coordinate(x, y);
            }
        }

        public IEnumerable<IMappable> MapObjects => _renderMap.ToArray();

        public void Initialize(Coordinate origin, int width, int height)
        {
            Origin = origin;
            Width = width;
            Height = height;
            _renderMap.Clear();
            SetBorder();
        }

        public void SetMapObject(IMappable mapObject)
        {
            if (_renderMap.Contains(mapObject))
            {
                _renderMap.Remove(mapObject);
            }
            _renderMap.Add(mapObject);
        }

        private void SetBorder()
        {
            _renderMap.Add(new TopLeftBorder(Origin));
            _renderMap.Add(new TopRightBorder(TopRight));
            _renderMap.Add(new BottomLeftBorder(BottomLeft));
            _renderMap.Add(new BottomRightBorder(BottomRight));

            int maxDimension = Height > Width ? Height : Width;

            for (int i = 1; i < maxDimension - 1; i++)
            {
                if (i < Width - 1)
                {
                    _renderMap.Add(new HorizontalBorder(new Coordinate(Origin.X + i, Origin.Y)));
                    _renderMap.Add(new HorizontalBorder(new Coordinate(Origin.X + i, Origin.Y + Height - 1)));
                }

                if (i < Height - 1)
                {
                    _renderMap.Add(new VerticalBorder(new Coordinate(Origin.X, Origin.Y + i)));
                    _renderMap.Add(new VerticalBorder(new Coordinate(Origin.X + Width - 1, Origin.Y + i)));
                }
            }
        }
    }
}
