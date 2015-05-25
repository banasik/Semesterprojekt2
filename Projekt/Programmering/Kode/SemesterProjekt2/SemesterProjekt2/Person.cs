using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt2
{
   class Person
   {
      public string navn;
      public string CPR;
      public int ID;
      

      public Person()
      { }
      
       public int getID()
      {
          return ID; 
      }
      public Person(string navn_input, string cprInput)
      {
         navn = navn_input;
         CPR = cprInput;
      }

   }
}
