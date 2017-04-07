using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dyplom_csharp_v2.Model;
using Dyplom_csharp_v2.Provider.Elements;
using System.Windows.Forms;

namespace Dyplom_csharp_v2.App
{
    public class Application
    {
        public bool start(string path)
        {
            if (Provider.Provider.OpenConnection())
            {
                if (Provider.Provider.openProject(path))
                {

                    Element elems = new Element();
                    elems.saveToDataBase(elems.getData(), new element(), new DataModel());

                    MeshPoint nodes = new MeshPoint();
                    nodes.saveToDataBase(nodes.getData(), new nodes(), new DataModel());

                    Moments mts = new Moments();
                    mts.saveToDataBase(mts.getData(), new moment(), new DataModel());

                    MeshElement element = new MeshElement();
                    element.saveToDataBase(element.getData(), new meshele(), new DataModel());

                    Provider.Provider.CloseConnection();
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie wczytano pliku ...");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Nie polaczono ...");
                return false;
            }

        }

    }
}
