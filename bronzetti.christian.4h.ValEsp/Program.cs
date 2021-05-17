using System;
using Pastel;
using bronzetti.christian._4h.ValEsp.Models;

namespace bronzetti.christian._4h.ValEsp
{
    class Program
    {
        static void Main(string[] args)
        {
            //stringa infissa trasformata in postfissa, operazioni accettate: +,-,*,/ 
            string infissa = "22/(5+6)";
            string[] postFissa = PostFissa.DaInfissaToPostFissas(infissa);

            //stampa risultato
            Console.WriteLine($"Conversione di {infissa} a postfissa");
            foreach (string s in postFissa)
                Console.Write(s);

            try
            {
                //calcolo operazione
                Console.WriteLine($"\nRisulato: {PostFissa.CalcolaOperazione(postFissa)}");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
