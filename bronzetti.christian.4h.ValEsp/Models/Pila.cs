using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bronzetti.christian._4h.ValEsp.Models
{
    class Pila
    {
        int _cimaPila; //testa
        List<string> _elementi;
        public Pila()
        {
            _cimaPila = 0;
            _elementi = new List<string>();
        }

        public void Push(string daPushare)
        => _elementi.Insert(_cimaPila++, daPushare);

        public string Pop()
        {
            string retVal = _elementi[--_cimaPila];
            _elementi.RemoveAt(_cimaPila);
            return retVal;
        }

        public bool IsEmpty()
        {
            if (_elementi.Count == 0)
                return true;
            else
                return false;
        }
        public int GetLenght()
        => _elementi.Count;

        public string Top()
        {
            int cima = _cimaPila - 1;
            return _elementi[cima];
        }

    }
}
