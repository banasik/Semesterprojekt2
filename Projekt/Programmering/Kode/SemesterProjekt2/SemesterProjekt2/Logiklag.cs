using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;


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
          return (kode.Equals(data.getKode(navn)));
       }


        public bool checkCPR(string CPR)
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
            datacollector.deviceName = "Dev1/ai0";
            datacollector.getVoltageSeqBlocking();
            return datacollector.currentVoltageSeq;
            
        }
    }
}
