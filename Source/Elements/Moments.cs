using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotOM;
using Dyplom_csharp_v2.Model;

namespace Dyplom_csharp_v2.Provider.Elements
{
    class Moments : Provider
    {
        private int Count()
        {
            IRobotCollection case_col = robApp.Project.Structure.Cases.GetAll();
            int nCase = case_col.Count;

            return nCase;
        }

        public List<double>[] getData()
        {
            int numOfMoments = 4;
            int nCase = 6; 

            List<double>[] lista = new List<double>[numOfMoments];
            
            for(int i=0; i<numOfMoments; i++)
            {
                lista[i] = new List<double>();
            }

            IRobotCollection fe_col = robApp.Project.Structure.FiniteElems.GetAll();
            int numberOfFe = fe_col.Count;

            for (int i=1; i<= numberOfFe; i++)
            {
                RobotFeResultParams param = new RobotFeResultParams();
                param.Case = nCase;
                param.Element = i;

                IRobotFeResultComplex results;
                results = robApp.Project.Structure.Results.FiniteElems.Complex(param);
                
                lista[0].Add(results.MXX_BOTTOM);
                lista[1].Add(results.MXX_TOP);
                lista[2].Add(results.MYY_BOTTOM);
                lista[3].Add(results.MYY_TOP);    
            }

            return lista;
        }

        public void saveToDataBase(List<double>[] listOfMoments, moment Mm, DataModel dbObj)
        {
            int nMoments = listOfMoments[0].Count;

            for (int i = 0; i < nMoments; i++)
            {
                foreach (var lista in listOfMoments)
                {
                    if (listOfMoments[0] == lista) Mm.Mxx_Bottom = lista[i];
                    if (listOfMoments[1] == lista) Mm.Mxx_Top = lista[i];
                    if (listOfMoments[2] == lista) Mm.Myy_Bottom = lista[i];
                    if (listOfMoments[3] == lista) Mm.Myy_Top = lista[i];
                }
                dbObj.moment.Add(Mm);
                dbObj.SaveChanges();
            }
        }
    }
}
