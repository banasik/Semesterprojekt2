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


        public Logiklag()
        {
            data = new Datalag();
            datacollector = new NI_DAQVoltage();
            sample = //samples
            Hz = //metoden til hertz

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
            int sample;
            int puls;
            sample = 
            puls = sample * AntalRtakker(); 

            return puls;
        }

        //analyse af vores signal; 

        public bool analyseSig()
        {
            double minValue = datacollector.currentVoltageSeq.Min();
            int stakker = 0;
            int rTakker;
            rTakker = AntalRtakker(); 

            foreach (double i in datacollector.currentVoltageSeq)
            {

            }

            if (stakker * 2 > rTakker) //ret den her til, alt afhængig af hvordan EKG rent faktisk ser ud
            {
                return false;
            }

            else
                return true;
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
    }
}
