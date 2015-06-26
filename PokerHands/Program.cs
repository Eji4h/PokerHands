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
                Console.WriteLine("Input: ");

                var blackCards = GetInputAndConvertToOnHandCards("Black");
                var whiteCards = GetInputAndConvertToOnHandCards("White");

                Console.WriteLine(PokerHandsDual.GetResultDual(blackCards, whiteCards));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static List<Card> GetInputAndConvertToOnHandCards(string sideToDisplay)
        {
            Console.Write(sideToDisplay + ": ");
            string cardsInput = Console.ReadLine();

            return Converter.ToCardsList(cardsInput);
        }

        public static string NewLine
        {
            get { return Environment.NewLine; }
        }
    }
}
