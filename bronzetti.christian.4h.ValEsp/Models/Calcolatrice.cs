using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bronzetti.christian._4h.ValEsp.Models
{
    static class Calcolatrice
    {
            public static int Operazione(int op2, string operatore, int op1) // invertiti perchè vengono poppati
            {
                int ris = 0;
                switch (operatore)
                {
                    case "+":
                        ris = op1 + op2;
                        break;

                    case "-":
                        ris = op1 - op2;
                        break;

                    case "*":
                        ris = op1 * op2;
                        break;

                    case "/":
                        if (op2 != 0)
                            ris = op1 / op2;
                        else
                            throw new Exception("Errore, divisione per 0");
                        break;
                }
                return ris;
            }
        }
}
