using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMind;

namespace GameSamplerun
{
    class Program
    {
        static void Main(string[] args)
        {
            Mastermind mm = new Mastermind();
            mm.code_Genaration();
            mm.Getting_input();
        }
    }
}
