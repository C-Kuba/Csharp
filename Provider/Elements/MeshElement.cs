using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotOM;
using Dyplom_csharp_v2.Model;

namespace Dyplom_csharp_v2.Provider.Elements
{
    class MeshElement : Provider
    {
        public List<int>[] getData()
        {
            int n = 4;
            List<int>[] lista = new List<int>[4];

            for(int i=0; i<n; i++)
                lista[i] = new List<int>();
            
            IRobotCollection fe_col = robApp.Project.Structure.FiniteElems.GetAll();

            for(int i=1; i<=Count(); i++)
            {
                var fe = fe_col.Get(i);
                IRobotFiniteElementNodes EleNodes = fe.Nodes;
                int nNodes = EleNodes.Count;

                for (int j = 1; j <= nNodes; j++)
                    lista[j - 1].Add(EleNodes.Get(j));
            }
            
            return lista;
        }

        private int Count()
        {
            IRobotCollection fe_col = robApp.Project.Structure.FiniteElems.GetAll();
            int numberOfFe = fe_col.Count;

            return numberOfFe;
        }

        public void saveToDataBase(List<int>[] listOfEles, meshele ele, DataModel dbObj)
        {
            int element = dbObj.element.Select(s => s.idelement).ToList().LastOrDefault();

            int nEles = (int)dbObj.element.Select(s => s.count_of_moments).ToList().LastOrDefault();

            int countOfNodes = (int)dbObj.element.Select(s => s.count_of_nodes).ToList().Sum();
            int countOfMomts = (int)dbObj.element.Select(s => s.count_of_moments).ToList().Sum();

            countOfNodes -= (int)dbObj.element.Select(s => s.count_of_nodes).ToList().LastOrDefault();
            countOfMomts -= (int)dbObj.element.Select(s => s.count_of_moments).ToList().LastOrDefault();

            for (int i = 0; i < nEles; i++)
            {
                foreach (var lista in listOfEles)
                {    
                    if (listOfEles[0] == lista) ele.Nodes_Node_id = lista[i] + countOfNodes;
                    if (listOfEles[1] == lista) ele.Nodes_Node_id1 = lista[i] + countOfNodes;
                    if (listOfEles[2] == lista) ele.Nodes_Node_id2 = lista[i] + countOfNodes;
                    if (listOfEles[3] == lista) ele.Nodes_Node_id3 = lista[i] + countOfNodes;
                    ele.moment_idmoment = i + 1 + countOfMomts;
                    ele.element_idelement = element;

                }
                dbObj.meshele.Add(ele);
                dbObj.SaveChanges();
            }
        }
    }
}
