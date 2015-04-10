using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt2
{
    class Logiklag
    {

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
    }
}
