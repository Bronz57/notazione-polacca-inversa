using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastel;

namespace bronzetti.christian._4h.ValEsp.Models
{
    static class PostFissa
    {
        public static string[] DaInfissaToPostFissas(string espInfissa)
        {
            Pila stack = new Pila(); //stack

            List<string> strPostFissa = new List<String>();
            string[] infissaArray = ToStringArray(espInfissa);

            foreach (string s in infissaArray)
            {
                if (s == null)
                    break;

                //accodo numero alla stringa parziale se è un operando
                if (Int32.TryParse(s, out int num))
                {
                    strPostFissa.Add(s);
                }
                else if (ControlloOperatore(s)) //else if perchè non va controllata a priori ma solo in caso non venga soddisfatta la prima
                {
                    if (stack.IsEmpty())
                    { //se è un operatore lo metto nello stack controllando che sia vuoto
                        stack.Push(s);
                    }
                    else if (CalcolaPrecendenzaOperatore(stack.Top()) >= CalcolaPrecendenzaOperatore(s)) //controllo precendenza operazione
                    {
                        strPostFissa.Add(stack.Pop()); //aggiungo operatore
                        stack.Push(s); //comunque pusho  nello stack quello controllato nella stringa
                    }
                    else
                    {
                        stack.Push(s);
                    }
                }
                else if (s.Equals("(")) //se trova una parentesi la mette nello stack
                {
                    stack.Push(s);
                }
                else //finchè si chiude la tonda, aggiungo gli operatori precedentemente salvati nello stack
                {
                    while (stack.Top() != "(")
                        strPostFissa.Add(stack.Pop());

                    stack.Pop(); //è rimasta la parentesi
                }
            }

            //se lo stack non è privo di operatori li accodo seguendo l'ordine
            if (!stack.IsEmpty())
                while (!stack.IsEmpty())
                    strPostFissa.Add(stack.Pop());

            return strPostFissa.ToArray();
        }

        static bool ControlloOperatore(string op)
        {
            string[] operatori = new string[] { "+", "-", "*", "/" };
            bool f = false;

            foreach (string s in operatori)
            {
                if (!op.Equals(s))
                    f = true;
                else
                {
                    f = false;
                    break;
                }
            }

            if (!f)
                return true;
            else
                return false;
        }
        static string[] ToStringArray(string str)
        {
            string[] retVal = new string[str.Length];

            int k = 0;
            int incrementoDoppio = 0;
            bool f = false;
            foreach (char c in str)
            {
                if (Int32.TryParse(c.ToString(), out int cifra))
                {
                    f = true;
                    retVal[k] += c;
                }
                else
                    f = false;

                if (!f)
                {
                    k++;
                    retVal[k] = c.ToString();
                    incrementoDoppio++;

                    if (incrementoDoppio > 1)
                        k++;
                }
            }
            return retVal;

        }
        static int CalcolaPrecendenzaOperatore(string operatore) //da 1 a 2  in ordine di importanza 1 è il più importante
        {
            //switch case o if , preferisco switch
            switch (operatore)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;
            }

            return 0;

        }
        static public int CalcolaOperazione(string[] esp)
        {
            Pila stack = new Pila();
            int ris = 0;

            //carico stack
            foreach (string s in esp)
                if (Int32.TryParse(s, out int num))
                    stack.Push(num.ToString());


            //valuto operatore
            foreach (string s in esp)
                if (!Int32.TryParse(s, out int num))
                {
                    try
                    {
                        ris = Calcolatrice.Operazione(Convert.ToInt32(stack.Pop()), s, Convert.ToInt32(stack.Pop()));
                    }
                    catch
                    {
                        throw new Exception("\n\nOPS... Qualcosa è andato storto... Riprova a scrivere il calcolo".Pastel("#FF0000"));
                    }
                    stack.Push(ris.ToString());
                }

            return ris;
        }
    }
}
