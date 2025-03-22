using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetraU
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game(800, 640)) 
            {
                game.Run(60.0); 
            }
        }
    }
}
