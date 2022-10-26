using System.Numerics;

namespace Test123
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = 2;
            List<int> Deck = new List<int>();
            for (int i = 0; i < 13; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    Deck.Add(a);

                }
                a++;
            }
            //Points per player
            int PHandP = 0;
            int CHandP = 0;



            //Deck.ForEach(i => Console.Write("{0}\t", i));
            /*
            int askint = 0;

            string askcard = Console.ReadLine();
            switch (askcard)                        //Kod för att konvertera text till nummer  V 
            {
                case "två":
                    askint = 2;
                    break;
                case "tre":
                    askint = 3;
                    break;
                case "fyra":
                    askint = 4;
                    break;
                case "fem":
                    askint = 5;
                    break;
                case "sex":
                    askint = 6;
                    break;
                case "sju":
                    askint = 7;
                    break;
                case "åtta":
                    askint = 8;
                    break;
                case "nio":
                    askint = 9;
                    break;
                case "tio":
                    askint = 10;
                    break;
                case "knäckt":
                    askint = 11;
                    break;
                case "dam":
                    askint = 12;
                    break;
                case "kung":
                    askint = 13;
                    break;
                case "ess":
                    askint = 14;
                    break;
            }*/
            Random rnd = new Random();
            List<int> PHand = new List<int>();
            List<int> CHand = new List<int>();
            //Plockar kortfrån kortlek till spelaren
            for (int i = 0; i < 7; i++)
            {
                int card = rnd.Next(Deck.Count);
                PHand.Add(Deck[card]);
                Deck.Remove(Deck[card]);

            }
            //Datorn kort från kortlek
            for (int i = 0; i < 7; i++)
            {
                int card = rnd.Next(Deck.Count);
                CHand.Add(Deck[card]);
                Deck.Remove(Deck[card]);

            }
            CHand.Sort();
            PHand.Sort();

            //Gameloop   
            while (PHand.Count + CHand.Count + Deck.Count > 1)
            {
                Game.Test();
            }
            

            /*PHand.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("---");
            CHand.ForEach(i => Console.Write("{0}\t", i));         //<-- DEBUG/Test kod
            Console.WriteLine("---");*/
            //Deck.ForEach(i => Console.Write("{0}\t", i));

            int p = CheckP(PHand);
            PHandP += p;
            Console.WriteLine(PHandP);
            int c = CheckC(CHand);
            CHandP += c;

            
        }

        static int CheckP(List<int> PHand)
        {
            int p = 0;
            for (int i = 2;i <= 14;i++)                     // i = kortet vi letar efter
            {
                for (int o = 0; o < PHand.Count; o++)     // o = platser vi letar på 
                {
                    int k = 0;
                    if (PHand[o]==i)
                    { k++; }
                    if (k >= 4)
                    {p++;}
                }
            }


            return p;
        }
        static int CheckC(List<int> CHand)
        {
            int p = 0;
            for (int i = 2; i <= 14; i++)                     // i = kortet vi letar efter
            {
                for (int o = 0; o < CHand.Count; o++)     // o = platser vi letar på 
                {
                    int k = 0;
                    if (CHand[o] == i)
                    { k++; }
                    if (k >= 4)
                    { p++; }
                }
            }
            return p;
        }
    }
}