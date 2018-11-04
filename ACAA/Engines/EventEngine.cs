using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;

namespace ACAA.Engines
{
    class EventEngine
    {
        Matrix matrix;

        public EventEngine(Matrix m)
        {
            matrix = m;
        }

        public void Analyze()
        {
            foreach (Event e in matrix.Events)
            {
                foreach (Package package in matrix.Packages)
                {
                    if ((matrix.Packages.IndexOf(package) - 1)>=0)
                    {
                        Package previousPackage = matrix.Packages[matrix.Packages.IndexOf(package) - 1];
                        bool checkResult = e.Check(previousPackage, package);
                        if (checkResult == true)
                        {
                            matrix.Set(e.EventId, previousPackage.packageNumber, checkResult);
                            matrix.Set(e.EventId, package.packageNumber, checkResult);
                        }
                    }
                }
            }
        }
    }
}
