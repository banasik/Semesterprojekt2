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
        //private List<double> EKGliste;
        public NI_DAQVoltage datacollector; 


        public Logiklag()
        {
            data = new Datalag();
            datacollector = new NI_DAQVoltage();
            
        }

        //public double AntalRtakker()
        //{
        //    int Rtakkerdata = 0;
        //    double tærskel = 0.8;

        //    double værdi = 0;
        //    double rTakVærdi = tærskel;
        //    int index = 0;
        //    int tid = 0;
        //    bool first = true;

        //    for (int i = 0; i < Dlag.GetDataListFromDaq.dataCollector.currentVoltageSeq.count; i++)
        //    {

        //        if (Dlag.GetDataListFromDaq[i] >= rTakVærdi)
        //        {
        //            rTakVærdi = Dlag.GetDataListFromDaq[i];
        //            first = true;
        //            index++;
        //            //Rtakkerdata++;
        //        }
        //        else if (dataCollector.currentVoltageSeq[i] < rTakVærdi)
        //        {
        //            if (first == true)
        //            {
        //                first = false;
        //                Rtakkerdata++;
        //                tid = index * 4;
        //                if (Rtakkerdata > 7)
        //                    index = 0;
        //            }
        //            index++;
        //            if (dataCollector.currentVoltageSeq[i] < tærskel)
        //            {
        //                rTakVærdi = tærskel;
        //            }
        //        }

        //    }

        //    return tid;
        //    //return Rtakkerdata;

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

       public bool gemData()
       {
          return (data.FlytTilSQL());
       }
       public bool gemMålingPåPerson(int patientID, List<double> måling, DateTime tidForMåling)
       {
          return (data.GemMålingPåPerson(patientID, GetBytes(måling), tidForMåling));
       }

       //Konverterer List<Double> til byte[] (Som skal bruges for at gemme i sql-db). Bliver brugt ovenfor
       // google-link: http://stackoverflow.com/questions/6952923/conversion-double-array-to-byte-array
       static byte[] GetBytes(List<double> values)
       {
          return values.ToArray().SelectMany(value => BitConverter.GetBytes(value)).ToArray();
       }

    }
}
