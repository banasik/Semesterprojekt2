using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;

namespace TestprogramSTPRj
{
    class Program
    {
        public static NI_DAQVoltage datacollector;
        public static int sample;

        static void Main(string[] args)
        {

            datacollector = new NI_DAQVoltage();
            sample = datacollector.samplesPerChannel;
            int plads = 1; 

            alglib.complex[] array;                                             //bruger nyt bibliotek
            alglib.fftr1d(datacollector.currentVoltageSeqArray, out array);     //laver vores signal om til et komplekst array. Får alle de harmoniske svingninger (Fourier trans) 
            List<double> frekvensliste = new List<double>();

            for (int i = 0; i < array.Length; i++)
            {
                double frekvens = i * (sample / array.Length / 2.0);            //Dividerer med to for at få fordoblingen af frekvenserne væk. 
                frekvensliste.Add(frekvens);
            }

            foreach (double i in frekvensliste)
	        {
		    Console.WriteLine(plads + "; " + i);
            plads++; 
	        }

            plads = 1;

            foreach (double i in frekvensliste)
            {
                Console.WriteLine(plads + "; " + i);
                plads++; 
            }

        }
    }
}
