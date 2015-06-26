using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string blackCardsInput;
                string whiteCardsInput;

                Console.Write("Input: " + NewLine +
                    "Black: ");
                blackCardsInput = Console.ReadLine();

                Console.Write("White: ");
                whiteCardsInput = Console.ReadLine();

                var blackCards = Converter.ToCardsList(blackCardsInput);
                var whiteCards = Converter.ToCardsList(whiteCardsInput);

                Console.WriteLine(PokerHandsDual.GetResultDual(blackCards, whiteCards));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string NewLine
        {
            get { return Environment.NewLine; }
        }
    }
}
