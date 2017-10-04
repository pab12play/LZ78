using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ78
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "DAD-DADA-DADDY-DADO";
            string text = args[0];
            Dictionary<string, Encoded> dictionary = new Dictionary<string, Encoded>();
            for(int index = 0; index < text.Length; index++)
            {
                if (dictionary.ContainsKey(text[index].ToString()))
                {
                    string word = text[index].ToString();
                    string nextChar = "";
                    while (dictionary.ContainsKey(word+nextChar))
                    {
                        if (nextCharExist(text, index))
                        {
                            word = word + nextChar;
                            nextChar = getNextChar(text, ref index);
                        }
                        else
                        {
                            break;
                        }
                    }
                    dictionary.Add(word+nextChar, new Encoded(getIndex(dictionary,word), text[index]));
                }
                else
                {
                    dictionary.Add(text[index].ToString(), new Encoded(0, text[index]));
                }
            }
            print(dictionary);
            Console.ReadLine();
        }

        static void print(Dictionary<string, Encoded> dictionary)
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("Salida\tIndex\tCadena");
            foreach (KeyValuePair<string, Encoded> pair in dictionary)
            {
                Console.WriteLine("<" + pair.Value.Index + ",C(" + pair.Value.Character + ")>\t" + i + "\t" + pair.Key);
                i++;
            }
        }

        static int getIndex(Dictionary<string, Encoded> dictionary,string word)
        {
            int i = 1;
            foreach(KeyValuePair<string,Encoded> pair in dictionary)
            {
                if (pair.Key.Equals(word))
                {
                    return i;
                }
                i++;
            }
            return 0;
        }

        static bool nextCharExist(string text, int index)
        {
            if (index < text.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string getNextChar(string text,ref int index)
        {
            return text[++index].ToString();
        }
    }
}
