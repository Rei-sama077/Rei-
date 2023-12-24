using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace YTCFW
{


    public class Gen
    {
        public static string AnimatedText { get; private set; }
        private const string TopLeftCorner = "▄";
        private const string TopRightCorner = "▄";
        private const string BottomLeftCorner = "▀";
        private const string BottomRightCorner = "▀";
        private const string VerticalLine = "█";

        private string[] _lines;

        public void SetLines(params string[] lines)
        {
            _lines = lines;
        }

        public void SetLinesLeft(params string[] lines)
        {
            Console.Clear();
            int rightPadding = Math.Max(Console.WindowWidth - lines.Max(line => line.Length) - 0, 30);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n" + new string('\t', rightPadding));

            _lines = lines;
        }


        public void SetLinesRight(params string[] lines)
        {
            Console.Clear();
            int rightPadding = Math.Max(Console.WindowWidth - lines.Max(line => line.Length) - 2, 0);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n" + new string('\t', rightPadding));
            _lines = lines;
        }


        public void PrintC(params string[] lines)
        {
            SetLines(lines);
            Console.WriteLine(this.ToString());
        }
        public void PrintL(params string[] lines)
        {
            SetLinesLeft(lines);
            Console.WriteLine(this.ToString());
        }

        public void PrintR(params string[] lines)
        {
            SetLinesRight(lines);
            Console.WriteLine(this.ToString());
        }


        public void ClearLines()
        {
            _lines = null;
        }

        private int GetMaxLineWidth()
        {
            if (_lines == null || _lines.Length == 0)
                return 0;

            return _lines.Max(line => line.Length);
        }

        private StringBuilder CreateTopLine(int maxLineWidth, StringBuilder formattedBox)
        {
            int consoleWidth = Console.WindowWidth;
            int leftPadding = (consoleWidth - maxLineWidth) / 2;

            formattedBox.AppendLine($"{new string(' ', leftPadding)}{TopLeftCorner}{new string('▄', maxLineWidth)}{TopRightCorner}");
            return formattedBox;
        }

        private StringBuilder CreateBottomLine(int maxLineWidth, StringBuilder formattedBox)
        {
            int consoleWidth = Console.WindowWidth;
            int leftPadding = (consoleWidth - maxLineWidth) / 2;

            formattedBox.AppendLine($"{new string(' ', leftPadding)}{BottomLeftCorner}{new string('▀', maxLineWidth)}{BottomRightCorner}");
            return formattedBox;
        }

        private StringBuilder CreateLine(string line, int maxLineWidth, StringBuilder formattedBox)
        {
            int consoleWidth = Console.WindowWidth;
            int leftPadding = (consoleWidth - maxLineWidth) / 2;
            var padding = new string(' ', (maxLineWidth - line.Length) / 2);

            formattedBox.AppendLine($"{new string(' ', leftPadding)}{VerticalLine}{padding}{line}{padding}{VerticalLine}");
            return formattedBox;
        }

        public override string ToString()
        {
            if (_lines == null || _lines.Length == 0)
                return string.Empty;

            var formattedBox = new StringBuilder();
            var maxLineWidth = GetMaxLineWidth();

            formattedBox = CreateTopLine(maxLineWidth, formattedBox);

            foreach (var line in _lines)
            {
                formattedBox = CreateLine(line, maxLineWidth, formattedBox);
            }

            formattedBox = CreateBottomLine(maxLineWidth, formattedBox);

            return formattedBox.ToString();
        }



        public static void PrintAscii(string[] lines)
        {
            int maxWidth = lines.Max(line => line.Length);
            int leftPadding = (Console.WindowWidth - maxWidth) / 2;
            leftPadding = leftPadding < 0 ? 0 : leftPadding;

            foreach (string line in lines)
            {
                Console.WriteLine(new string(' ', leftPadding) + line);
            }
        }

        public static void AnimateText(string text, int consoleWidth)
        {
            Console.Clear();

            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                foreach (char c in line)
                {

                    Console.Write(c);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
               Thread.Sleep(1000);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.S)
                    {

                        break;
                    }
                }
            }
        }
    }
}





        