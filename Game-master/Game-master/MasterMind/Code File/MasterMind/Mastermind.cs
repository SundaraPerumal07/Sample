using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class Mastermind
    {
        int _count;
        int _blackcount;
        int _whitecount;
    
        private List<int> Secret_code = new List<int>(4);
        //private int[] Secret_code = new int[4];
        private List<int[]> input = new List<int[]>(8);
       
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public bool Isempty
        {
            get
            {
                if (Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int Blackcount
        {
            get { return _blackcount; }
            set { _blackcount = value; }
        }
        public int Whitecount
        {
            get { return _whitecount; }
            set { _whitecount = value; }
        }
        public Mastermind()
        {
            Count = 7;
            Blackcount = 0;
            Whitecount = 0;
        }

        private static int random()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void code_Genaration()
        {  
            while (Secret_code.Count < 4)
            {
                int r = random();
                if (!Secret_code.Contains(r))
                {
                    Secret_code.Add(r);
                }
            }
            //foreach (int x in Secret_code)
            //{
            //    Console.WriteLine(x + " ");
            //}
        }

        public void Getting_input()
        {
            while (Count > 0)
            {
                int[] arr = new int[4];
                int x = 1;
                for (int i = 0; i < 4; i++)
                {
                    int n=1;
                    while (n > 0)
                    {
                        Console.WriteLine("Enter the "+x+" number :");
                        int a = Convert.ToInt32(Console.ReadLine());
                        if (a > 0 && a < 7)
                        {
                            arr[i] = a;
                            n--;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 1 to 6.");
                        }      
                    }
                    x++;
                }
                input.Add(arr);
                CheckingContains(7-Count);
                if (winning_State(Blackcount) == true)
                {
                    Console.WriteLine("win");
                    return;
                }
                Count--;
            }
            Console.WriteLine(Losing_state());
        }

        private void CheckingContains(int turn)
        {
             Blackcount = 0;
             Whitecount = 0;
            for (int i = 0; i < Secret_code.Count; i++)
            {
                if (input[turn][i] == Secret_code[i])
                {
                    Blackcount++;
                    if (Blackcount == 4)
                    {
                        winning_State(Blackcount);
                        return;
                    }
                }
                else if(Secret_code.Contains(input[turn][i]) == true)
                {
                    Whitecount++;
                }
            }
            Gives_clue(Blackcount, Whitecount);
        }

        private void Gives_clue(int black, int white)
        {
            Blackcount = black;
            Console.WriteLine("the Black Count is :"+Blackcount);
            Whitecount = white;
            Console.WriteLine("the white count is :"+Whitecount);
        }

        public bool winning_State(int black)
        {
            bool state = false;
            if (black == 4)
            {
                state = true;
            }
            else
            {
                state = false;
            }
            return state;
        }

        public string Losing_state()
        {
            string state = "";
            if (Count == 0)
            {
                state = "Lose";
            }
            else
            {
                state = "Win";
            }
            return state;
        }
    }
}
