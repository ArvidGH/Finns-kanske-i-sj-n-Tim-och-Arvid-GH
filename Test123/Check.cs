using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test123
{
    public class Check
    {
        public static int CheckP(List<int> PHand)
        {
            List<int> Place = new List<int>();
            int q = -1; // q = 
            for (int i = 2; i <= 14; i++)                     // i = kortet vi letar efter
            {
                int k = 0;
                for (int o = 0; o < PHand.Count; o++)     // o = platser vi letar på 
                {                   
                    if (PHand[o] == i)                     
                    {
                        k++;
                    }
                    if (k==4)
                    {
                        q = i;
                    }
                }
                Place.Clear();
            }
            return q;
        }
        public static int CheckC(List<int> CHand)
        {
            List<int> Place = new List<int>();
            int q = -1; // q = 
            for (int i = 2; i <= 14; i++)                     // i = kortet vi letar efter
            {
                int k = 0;
                for (int o = 0; o < CHand.Count; o++)     // o = platser vi letar på 
                {
                    if (CHand[o] == i)
                    {
                        k++;
                    }
                    if (k == 4)
                    {
                        q = i;
                    }
                }
                Place.Clear();
            }
            return q;

        }
    }
}
