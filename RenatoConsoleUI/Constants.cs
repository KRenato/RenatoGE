namespace ConsoleUI
{
    public static class Constants
    {
        public static class Sequences
        {
            public static string Escape => "\u001b";

            public static string Termination => $"{Escape}\u005c";

            public static string HideCursor => $"{Escape}[?25l";

            public static string SetTitle => $"{Escape}]0;";

            public static string SetCharsetDec => $"{Escape}(0";

            public static string SetTextRed => $"{Escape}[31m";

            public static string ResetTextColor => $"{Escape}[0m";
        }
    }
}
