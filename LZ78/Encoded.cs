using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ78
{
    class Encoded
    {
        int index;
        char character;

        public Encoded(int index, char character)
        {
            this.Index = index;
            this.Character = character;
        }

        public int Index { get => index; set => index = value; }
        public char Character { get => character; set => character = value; }
    }
}
