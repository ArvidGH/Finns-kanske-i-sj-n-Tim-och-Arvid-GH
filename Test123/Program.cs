using System.Numerics;

namespace Test123
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till finns (kanske) i sjön!");
            Console.WriteLine("När du frågar om ett kort får du skriva i bokstäver");
            Console.WriteLine("Du kommer att få se dina kort hela tiden och dem kommer att visas i sifferform");
            Console.WriteLine("11 = knäckt");
            Console.WriteLine("12 = dam");
            Console.WriteLine("13 = kung");
            Console.WriteLine("14 = ess");
            Console.WriteLine("Klicka enter för att starta!");
            Console.ReadLine();
            Console.Clear();
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

            while (PHand.Count + CHand.Count + Deck.Count > 0)
            {

                if (Deck.Count > 0)
                {
                    if (PHand.Count == 0)
                    {
                        int card = rnd.Next(Deck.Count);
                        PHand.Add(Deck[card]);
                        Deck.Remove(Deck[card]);
                        Console.WriteLine("Du hade inga kort så du fick ett ur sjön!");
                    }
                    if (CHand.Count == 0)
                    {
                        int card = rnd.Next(Deck.Count);
                        CHand.Add(Deck[card]);
                        Deck.Remove(Deck[card]);
                        Console.WriteLine("Datorn hade inga kort så den fick ett ur sjön!");
                    }
                }



                Console.WriteLine("Dina poäng är: " + PHandP);
                Console.WriteLine("Datorns poäng är: " + CHandP);
                Console.WriteLine("Dina kort är:");
                PHand.ForEach(i => Console.Write("{0}\t", i));

                Console.WriteLine(" ");
                Console.WriteLine("Fråga efter ett kort (i bokstäver)");
                int askint = 0;
                bool askvalid = false;
                while (askvalid == false)
                {
                    bool switchvalid = false;
                    while (switchvalid == false)
                    {
                        askint = 0;
                        string askcard = Console.ReadLine();

                        switch (askcard)                        //Kod för att konvertera text till nummer  V 
                        {
                            case "två":
                                askint = 2;
                                switchvalid = true;
                                break;
                            case "tre":
                                askint = 3;
                                switchvalid = true;
                                break;
                            case "fyra":
                                askint = 4;
                                switchvalid = true;
                                break;
                            case "fem":
                                askint = 5;
                                switchvalid = true;
                                break;
                            case "sex":
                                askint = 6;
                                switchvalid = true;
                                break;
                            case "sju":
                                askint = 7;
                                switchvalid = true;
                                break;
                            case "åtta":
                                askint = 8;
                                switchvalid = true;
                                break;
                            case "nio":
                                askint = 9;
                                switchvalid = true;
                                break;
                            case "tio":
                                askint = 10;
                                switchvalid = true;
                                break;
                            case "knäckt":
                                askint = 11;
                                switchvalid = true;
                                break;
                            case "dam":
                                askint = 12;
                                switchvalid = true;
                                break;
                            case "kung":
                                askint = 13;
                                switchvalid = true;
                                break;
                            case "ess":
                                askint = 14;
                                switchvalid = true;
                                break;
                            default:
                                Console.WriteLine("Du skrev fel, skriv igen!");

                                break;
                        }
                    }
                    for (int o = 0; o < PHand.Count; o++)     // o = platser vi letar på 
                    {
                        if (PHand[o] == askint)
                        {
                            askvalid = true;
                        }

                    }
                    if (askvalid == false)
                    {
                        Console.WriteLine("Du har inte detta kortet (skriv igen)");
                    }
                }
                bool Cvalid = false;
                // Cvalid = Computer has card, ask is valid
                while (Cvalid == false)
                {
                    List<int> Place = new List<int>();          // Place = lista med index för de platser där matchande/valid kort har funnits hos datorn

                    for (int o = 0; o < CHand.Count; o++)       // o = platser vi letar på 
                    {
                        if (CHand[o] == askint)
                        {

                            Place.Add(o);
                        }

                    }
                    if (Place.Count > 0)
                    {
                        Console.WriteLine("Datorn hade kortet du frågade efter!");
                        for (int o = Place.Count; o > 0; o--)
                        {
                            PHand.Add(CHand[Place[o - 1]]);
                            CHand.Remove(CHand[Place[o - 1]]);
                        }
                    }
                    else
                    {
                        if (Deck.Count > 0)
                        {
                            Console.WriteLine("Finns i sjön! (Datorn har inte kortet)");
                            int card = rnd.Next(Deck.Count);
                            Console.WriteLine("Du tog upp " + Deck[card]);
                            PHand.Add(Deck[card]);
                            Deck.Remove(Deck[card]);

                        }
                        else
                        {
                            Console.WriteLine("Sjön är tom!");
                        }
                    }
                    PHand.Sort();
                    Cvalid = true;
                }
                //Dator frågar
                if (CHand.Count > 0)
                {
                int CAskcard = rnd.Next(CHand.Count);
                bool Pvalid = false;    //Pvalid = player has card, 
                while (Pvalid == false)
                {
                    Console.WriteLine("Datorn frågar om " + CHand[CAskcard]);
                    List<int> Place = new List<int>();          // Place = lista med index för de platser där matchande/valid kort har funnits hos datorn
                    for (int o = 0; o < PHand.Count; o++)       // o = platser vi letar på 
                    {
                        if (PHand[o] == CHand[CAskcard])
                        {
                            Place.Add(o);
                        }
                    }
                    if (Place.Count > 0)
                    {
                        Console.WriteLine("Du har kortet datorn frågar om och den tar de från dig");
                        for (int o = Place.Count; o > 0; o--)
                        {
                            CHand.Add(PHand[Place[o - 1]]);
                            PHand.Remove(PHand[Place[o - 1]]);
                        }
                    }
                    else
                    {
                        if (Deck.Count > 0)
                        {
                            Console.WriteLine("Finns i sjön! (Du har inte kortet)");
                            int card = rnd.Next(Deck.Count);
                            CHand.Add(Deck[card]);
                            Deck.Remove(Deck[card]);

                        }
                    }
                    CHand.Sort();
                    Pvalid = true;
                }
            }
                int p = Check.CheckP(PHand);    // p 

                int c = Check.CheckC(CHand);    // c 
                //player check
                if (p > -1)
                {
                    List<int> Place1 = new List<int>();          // Place = lista med index för de platser där matchande/valid kort har funnits hos datorn
                    for (int o = 0; o < PHand.Count; o++)       // o = platser vi letar på 
                    {
                        if (PHand[o] == p)
                        {
                            Place1.Add(o);
                        }
                    }
                    if (Place1.Count > 0)
                    {
                        for (int o = Place1.Count; o > 0; o--)
                        {
                            PHand.Remove(PHand[Place1[o - 1]]);
                        }
                    }
                    PHandP++;
                    Console.WriteLine("Du fick poäng för fyra stycken av kortet " + p);
                }
                //Computer check
                if (c > -1)
                {
                    List<int> Place2 = new List<int>();          // Place = lista med index för de platser där matchande/valid kort har funnits hos datorn
                    for (int o = 0; o < CHand.Count; o++)       // o = platser vi letar på 
                    {
                        if (CHand[o] == c)
                        {
                            Place2.Add(o);
                        }
                    }
                    if (Place2.Count > 0)
                    {
                        for (int o = Place2.Count; o > 0; o--)
                        {
                            CHand.Remove(CHand[Place2[o - 1]]);
                        }
                    }
                    CHandP++;
                    Console.WriteLine("Datorn fick poäng för fyra stycken av kortet " + c);
                }
                Console.ReadLine();
                Console.Clear();
            }
            if (PHandP > CHandP)
            {
                Console.WriteLine("Grattis du vann!");
            }
            if (CHandP > PHandP)
            {
                Console.WriteLine("Du torska mot en bot!");
            }
        }
    }
}