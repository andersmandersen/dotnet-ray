using System;
using System.Threading.Tasks;
using Velcon.Ray;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            new Ray().ClearScreen();
            await new Ray().PauseAsync();
            new Ray().Charles();
            new Ray("Hallo world!").Green();            
        }        
    }
}
