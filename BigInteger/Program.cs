using System;
using System.Numerics;

namespace BigInt
{
    class Program
    {

        const string KONSTANTE = "131400";
        static string kontoNummer = "1234567890";
        static string kontoBLZ = "70090100";

        static void Main(string[] args)
        {
            kontoUndBLZ(kontoNummer, kontoBLZ);
        }

        static void kontoUndBLZ(string knr, string blz)
        {
            genIBANChecksum(blz + knr);
        }

        static void genIBANChecksum(string iban)
        {
            string checkNumber = iban + KONSTANTE;
            if (!BigInteger.TryParse(checkNumber, out _))
            {
                Console.WriteLine("Kein BigBoy");
            }
            else
            {
                BigInteger bigboy = BigInteger.Parse(checkNumber);
                var psum = 98 - (bigboy % 97);
                if(psum < 10)
                {
                    genGermanIBAN("0" + psum.ToString());
                }
                else
                {
                    genGermanIBAN(psum.ToString());
                }
            }
        }

        static void genGermanIBAN(string psum)
        {
            string gerIBAN = "DE" + psum + kontoBLZ + kontoNummer;

            Console.WriteLine(gerIBAN);
        }
    }
}
