using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;
using System.Windows.Forms;

namespace Dyplom_csharp_v2.Provider
{
    public class Provider
    {
        protected static IRobotApplication robApp;

        public static bool OpenConnection()
        {
            try
            {
                robApp = new RobotApplication();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                return false;
            }               
        }
        public static bool openProject(string path)
        {
            try
            {
                robApp.Project.Open(path);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                return false;
            }
        }
        public static void CloseConnection()
        {       
            robApp.Quit(0);
        }
    }
}
