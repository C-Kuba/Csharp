using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dyplom_csharp_v2.Model;

namespace Dyplom_csharp_v2.Provider.Elements
{
    class Element:Provider
    {
        public List<int>[] getData()
        {
            int number = 2;
            List<int>[] lista = new List<int>[number];
            
            for (int i = 0; i < number; i++)
                lista[i] = new List<int>();

            int numberOfNodes = robApp.Project.Structure.Nodes.FreeNumber;
            int numberOfFe = robApp.Project.Structure.FiniteElems.GetAll().Count;

            lista[0].Add(numberOfNodes);
            lista[1].Add(numberOfFe);
       
            return lista;
        }

        public void saveToDataBase(List<int>[] listOfElems, element elems, DataModel dbObj)
        {
            int nEles = listOfElems.ElementAt(0).Count;
            
            for(int i=0; i<nEles; i++)
            {
                foreach (var lista in listOfElems)
                {
                    if (listOfElems[0] == lista) elems.count_of_nodes = lista[i];
                    if (listOfElems[1] == lista) elems.count_of_moments = lista[i];
                }
                dbObj.element.Add(elems);
                dbObj.SaveChanges();
            }

        }
    }
}
