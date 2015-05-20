using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;
using System.IO; 

namespace TestprogramSTPRj
{
    class Program
    {
        public static NI_DAQVoltage datacollector;
        public static List<double> amplitude;
        public static List<double> specifikamplitude;
        public static List<double> frekvensliste;
        public static int sample;
        public static double thresh; 

        static void Main(string[] args)
        {
            datacollector = new NI_DAQVoltage();
            datacollector.deviceName = "Dev1/ai0";
            datacollector.getVoltageSeqBlocking();
            sample = datacollector.samplesPerChannel; 
            int plads = 1;
            amplitude = new List<double>();
            specifikamplitude = new List<double>(); 
            alglib.complex[] array;                                             //bruger nyt bibliotek
            alglib.fftr1d(datacollector.currentVoltageSeqArray, out array);     //laver vores signal om til et komplekst array. Får alle de harmoniske svingninger (Fourier trans) 
            frekvensliste = new List<double>();
            thresh = 5.60; 

            for (int i = 0; i < array.Length; i++)
            {
                double frekvens = i * (sample / array.Length / 2.0);            //Dividerer med to for at få fordoblingen af frekvenserne væk. 
                frekvensliste.Add(frekvens);
            }

            plads = 1; 

            for (int i = 0; i < array.Length; i++)
            {
                double amp = (Math.Sqrt(Math.Pow(array[i].x, 2)+Math.Pow(array[i].y, 2)));
                amplitude.Add(amp);
            }

            FileStream output3 = new FileStream("C:\\Users\\Sara\\Desktop\\Semesterprojekt2\\Projekt\\Programmering\\Kode\\Testprogram\\TestprogramSTPRj\\vektorlisten.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fileWriter3 = new StreamWriter(output3);

            Console.WriteLine("Længdeliste; ");
            Console.WriteLine(" ");


            foreach (alglib.complex i in array)
            {
                fileWriter3.WriteLine(plads + "; " + i.x + "\n " + i.y);
                plads++;
            }

            fileWriter3.Close();
            plads = 1;

            FileStream output = new FileStream("C:\\Users\\Sara\\Desktop\\Semesterprojekt2\\Projekt\\Programmering\\Kode\\Testprogram\\TestprogramSTPRj\\frekvenslisten.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fileWriter = new StreamWriter(output);

            Console.WriteLine("Frekvensliste; ");
            Console.WriteLine(" ");


            foreach (double i in frekvensliste)
            {
                fileWriter.WriteLine(plads + "; " + i);
                plads++;
            }

            fileWriter.Close(); 

            plads = 1;
            Console.WriteLine("Amplitudeliste; ");
            Console.WriteLine(" ");

            FileStream output2 = new FileStream("C:\\Users\\Sara\\Desktop\\Semesterprojekt2\\Projekt\\Programmering\\Kode\\Testprogram\\TestprogramSTPRj\\vektorliste.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fileWriter2 = new StreamWriter(output2);

            foreach (double i in amplitude)
            {
                fileWriter2.WriteLine(plads + "; " + i);
                plads++;
            }

            fileWriter2.Close();

            for (int i = 600; i < 802; i++)
			{
                specifikamplitude.Add(amplitude[i]);  
			}

           for (int i = 0; i < specifikamplitude.Count; i++)
            {
                double vaerdi;
                vaerdi = specifikamplitude[i]; 

                if(vaerdi > thresh)
                {
                    Console.WriteLine("Atrieflimmer!!" + i + "\n " + specifikamplitude[i]); 
                }
            }

        }
    }
}
