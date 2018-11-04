using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;

namespace ACAA.Engines
{
    class StateEngine
    {
        Matrix matrix;

        public StateEngine(Matrix m)
        {
            matrix = m;
        }

        public void Analyze()
        {
            foreach (State state in matrix.States)
            {
                foreach (Package package in matrix.Packages)
                {
                    matrix.Set(state.StateId, package.packageNumber,state.Check(package));
                }
            }
        }
    }
}
