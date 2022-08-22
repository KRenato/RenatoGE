using Core.Interfaces;
using Core.MapObjects;
using Core.MapObjects.Border;
using Core.MapObjects.Characters;

namespace ConsoleUI.Services
{
    public class SymbolMappingService : ISymbolMappingService
    {
        public string GetSymbol(string name) => name switch
        {
            nameof(TopLeftBorder) => GetDecString("l"),
            nameof(TopRightBorder) => GetDecString("k"),
            nameof(BottomLeftBorder) => GetDecString("m"),
            nameof(BottomRightBorder) => GetDecString("j"),
            nameof(VerticalBorder) => GetDecString("x"),
            nameof(HorizontalBorder) => GetDecString("q"),
            nameof(PlayerCharacter) => GetRedTextString("*"),
            nameof(EmptySpace) => " ",
            _ => throw new ArgumentOutOfRangeException(nameof(name))
        };

        private static string GetDecString(string decString)
        {
            return $"{Constants.Sequences.SetCharsetDec}{decString}";
        }

        private static string GetRedTextString(string redTextString)
        {
            return $"{Constants.Sequences.SetTextRed}{redTextString}{Constants.Sequences.ResetTextColor}";
        }
    }
}
