using System;
using System.Collections.Generic;
using System.Linq;
public class CardGame
{
    public static void Main(string[] args)
    {
            Console.WriteLine("Game of Cards started");
            List<string> spades = Cards("S");
            List<string> hearts = Cards("H");
            List<string> diamonds = Cards("D");
            List<string> clubs = Cards("C");

            //list the data inside input.txt file 
            String[] lines = File.ReadAllLines(@"input.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            
            //create a list of string
            List<string> deck = clubs.Concat(diamonds).Concat(hearts).Concat(spades).ToList();

            //create 5 players for the game
            string[] players = new string[5] { "Lillian", "Moagi", "Phomello", "Minky", "Liam" };

            //get card for the deck
            Random random = new Random();

            int round = 1;

            //while loop for the number of rounds in the game
            while (round < 5)
            {
                string winner = "";
                int maximum_point = 0;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nRound {0}", round);
                Console.ResetColor();


                foreach (string player in players)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(">> {0}", player);
                    Console.ResetColor();

                int card1_index = random.Next(deck.Count);
                string card1 = deck[card1_index];
                deck.Remove(card1);

                int card2_index = random.Next(deck.Count);
                string card2 = deck[card2_index];
                deck.Remove(card2);

                int card3_index = random.Next(deck.Count);
                string card3 = deck[card3_index];
                deck.Remove(card3);

                int card4_index = random.Next(deck.Count);
                string card4 = deck[card4_index];
                deck.Remove(card4);

                int card5_index = random.Next(deck.Count);
                string card5 = deck[card5_index];
                deck.Remove(card5);


                int card1_point = Point(card1);
                Console.WriteLine(card1);
                int card2_point = Point(card2);
                Console.WriteLine(card2);
                int card3_point = Point(card3);
                Console.WriteLine(card3);
                int card4_point = Point(card4);
                Console.WriteLine(card4);
                int card5_point = Point(card5);
                Console.WriteLine(card5);


                int total_points = card1_point + card2_point + card3_point + card4_point + card5_point;
                Console.WriteLine(">> {0} Point ", total_points);
                Console.WriteLine();

                if (total_points > maximum_point)
                {
                    maximum_point = total_points;
                    winner = player;
                }
                else if (total_points == maximum_point)
                {
                    winner += "," + player + ":" + maximum_point;
                    Console.WriteLine(winner);

                    // Console.WriteLine(player + ',' + player + ":" + maximum_point);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}" + ":" + maximum_point);
                Console.ResetColor();

                round++;
            }

    }

    public static List<string> Cards(string symbol)
    {
        List<string> cards = new List<string>();

        for (int i = 0; i < cards.Count; i++)
        {
            cards.Add(symbol + "" + i);
        }
        cards.Add(symbol + "" + "J");
        cards.Add(symbol + "" + "Q");
        cards.Add(symbol + "" + "K");
        cards.Add(symbol + "" + "A");

        return cards;

    }

    public static int Point(string card)
    {
        int point;
        string[] splited = card.Split(' ');
      
        if (splited[0] == "J")
        {
            point = 11;
        }
        else if (splited[0] == "Q")
        {
            point = 12;
        }
        else if (splited[0] == "K")
        {
            point = 13;
        }
        else if (splited[0] == "A")
        {
            point = 1;
        }
        else
        {
                point = int.Parse(splited[1]);
                // point = -1;
        }

        return point++;

    }
}

