using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;
using Dyplom_csharp_v2.Model;

namespace Dyplom_csharp_v2.Provider.Elements
{
    public class MeshPoint : Provider
    {
        public List<double>[] getData()
        {
            List<double>[] lista = new List<double>[3];
            lista[0] = new List<double>();
            lista[1] = new List<double>();
            lista[2] = new List<double>();

            IRobotNodeServer nd = robApp.Project.Structure.Nodes; 
            IRobotCollection nodes_col = nd.GetAll();
            int licznik = 1;

            for (int i = 1; i <= Count(); i++)
            {
                if(nd.Exist(i) == 0)
                {
                    lista[0].Add(0);
                    lista[1].Add(0);
                    lista[2].Add(0);
                }
                else
                {
                    var node = nodes_col.Get(licznik);
                    lista[0].Add(node.X);
                    lista[1].Add(node.Y);
                    lista[2].Add(node.Z);
                    licznik += 1;
                }          
            }
            return lista;
        }

        private int Count()
        {
            IRobotNodeServer nodes_col = robApp.Project.Structure.Nodes;
            int nNodes = nodes_col.FreeNumber;
           
            return nNodes;
        }

        public void saveToDataBase(List<double>[] listOfNodes, nodes nds, DataModel dbObj)
        {
            int nNodes = listOfNodes[0].Count;

            for (int i = 0; i < nNodes; i++)
            {
                foreach (var lista in listOfNodes)
                {
                    if (listOfNodes[0] == lista) nds.x = lista[i];
                    if (listOfNodes[1] == lista) nds.y = lista[i];
                    if (listOfNodes[2] == lista) nds.z = lista[i];
                }
                dbObj.nodes.Add(nds);
                dbObj.SaveChanges();
               
            }
        }
    }
}
