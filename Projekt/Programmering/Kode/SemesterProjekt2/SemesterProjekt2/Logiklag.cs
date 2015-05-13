using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;  //udleveret class (forbindelse til DAQ)


namespace SemesterProjekt2
{
    class Logiklag
    {
        private Datalag data;
        private List<string> lliste;
        public NI_DAQVoltage datacollector;
        public double baseline;
        public int sample;
        public double hz;
        public string CPR;
        public int ID; 

        public Logiklag()
        {
            data = new Datalag();
            datacollector = new NI_DAQVoltage();
            sample = datacollector.samplesPerChannel;  //samples                                     Mangler reference
            hz = datacollector.sampleRateInHz;//metoden til hertz                                    Mangler reference

        }

        public int AntalRtakker()                                       //Her findes hvor mange rtakker der er i vores måling
        {
            int Rtakker = 0;
            double maxVærdi = datacollector.currentVoltageSeq.Max(); 
            double tærskel = 0.8 * maxVærdi;
            double rTakVærdi = tærskel;
            bool pause = false;                                         //Denne bestemmer hvorvidt om optællingen skal pause. Dette er fordi vi ellers ville have en masse 'ekstra' rtakker, som ikke eksisterer. 


            foreach (double i in datacollector.currentVoltageSeq)
            {
                if (!pause)                                             //Hvis pause er falsk, skal tjekke, om i ligger over tærsklen, og lægge en rtak oveni, hvis det passer.  
                {
                    if (i > tærskel)
                    {
                        Rtakker++;
                        pause = true;                                   //Herefter bliver pause sat til falsk, sådan at vi først får den næste rtak, når i er under vores tærskel.
                    }
                }
                else                                                    //Når i falder under tærskel, bliver pause sat til rigtigt igen, så vi er klar til næste rtak
                {
                    if (i < tærskel)
                    {
                        pause = false;
                    }
                }

            }

            return Rtakker; 
        }

        public int getPuls()
        {
            int puls;
            sample = 
            puls = sample * AntalRtakker(); 

            return puls;
        }

        //analyse af vores signal; 

        public bool analyseSig()
        {
            alglib.complex[] array;                                             //bruger nyt bibliotek
            alglib.fftr1d(datacollector.currentVoltageSeqArray, out array);     //laver vores signal om til et komplekst array. Får alle de harmoniske svingninger (Fourier trans) 
            List<double> frekvensliste = new List<double>();

            for (int i = 0; i < array.Length; i++)
            {
                double frekvens = i * (sample / array.Length / 2.0);                                      //Dividerer med to for at få fordoblingen af frekvenserne væk. 
                frekvensliste.Add(frekvens);
            }

            if()
            {
                return true;
            }

            else return false; 
 
        }

       public bool getKode(string navn, int kode)
       {
          return (kode.Equals(data.getKode(navn))); //checker om indtastet password passer med username i db.
       }


       public bool checkCPR(string CPR) //checker om indtastet CPR passer med CPR i db.
       {
           lliste = data.GetCPR();

           foreach (var item in lliste)
           {

               if (CPR == item)
               {
                   return true;
               }
           }

           return false;             
       }


        public List<double> kørEKG()
        {
            datacollector = new NI_DAQVoltage();
            datacollector.deviceName = "Dev1/ai0";  //device1/indgang på DAQ som kommer fra AD
            datacollector.getVoltageSeqBlocking();
            return datacollector.currentVoltageSeq; //liste fra DAQ. 
            
        }

       //public bool gemData()
       //{
       //   return (data.FlytTilSQL());
       //}
       public bool gemMålingPåPerson(int patientID, List<double> måling, DateTime tidForMåling)
       {
          return (data.GemMålingPåPerson(patientID, GetBytes(måling), tidForMåling));
       }

       public bool GemEKGDATA(List<double> måling, float samplerate_hz, long interval_sek, string data_format, string bin_eller_tekst, string maaleformat_type, DateTime start_tid)
       {
          return (data.GemEKGDATA(GetBytes(måling), samplerate_hz, interval_sek, data_format, bin_eller_tekst, maaleformat_type, start_tid));
       }

       public bool GemEKGMaeling(DateTime dato, int antal_maalinger, string medarbejdernr, string organisation)
       {
          return (data.GemEKGMaeling(dato, antal_maalinger, medarbejdernr, organisation));
       }

       public Person HentPersonMedCPR(string CPR)
       {
           return data.GetPersonMedCPR(CPR);
       }

       //Konverterer List<Double> til byte[] (Som skal bruges for at gemme i sql-db). Bliver brugt ovenfor
       // google-link: http://stackoverflow.com/questions/6952923/conversion-double-array-to-byte-array
       static byte[] GetBytes(List<double> values)
       {
          return values.ToArray().SelectMany(value => BitConverter.GetBytes(value)).ToArray();
       }

    }
}
