using Core;
using Core.Interfaces;
using System.Text;

namespace ConsoleUI.Services
{
    public class DrawingService : IDrawingService
    {
        private readonly ISymbolMappingService _symbolMappingService;

        public DrawingService(ISymbolMappingService symbolMappingService)
        {
            _symbolMappingService = symbolMappingService;
        }

        public void Draw(IEnumerable<IMappable> mapObjects)
        {
            var buffer = CreateBuffer(mapObjects);

            Console.Write(buffer.ToString());
        }

        private StringBuilder CreateBuffer(IEnumerable<IMappable> mapObjects)
        {
            var buffer = new StringBuilder();

            foreach (var mapObject in mapObjects)
            {
                buffer.Append(GetCursorPositionSequence(mapObject.Coordinate));
                var symbol = _symbolMappingService.GetSymbol(mapObject.SymbolKey);

                buffer.Append(symbol);
            }

            return buffer;
        }

        private static string GetCursorPositionSequence(Coordinate coordinate)
        {
            return $"{Constants.Sequences.Escape}[{coordinate.Y};{coordinate.X}H";
        }
    }
}
