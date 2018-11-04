using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Matrix
    {
        private List<Package> packages;
        private List<Event> events;
        private List<State> states;
        private List<Phase> phases;
        bool[,] matrix;

        public Matrix(List<Package> pack, List<Event> even, List<State> state, List<Phase> phase)
        {
            packages = pack;
            events = even;
            states = state;
            Phases = phase;
            RebuildMatrix();
        }

        public Matrix(List<Package> pack)
        {
            packages = pack;
            events = new List<Event>();
            states = new List<State>();
            Phases = new List<Phase>();
            RebuildMatrix();
        }

        public bool[,] GetMatrix { get => matrix; }
        public List<Package> Packages { get => packages; }
        public List<State> States { get => states; set => states = value; }
        public List<Event> Events { get => events; set => events = value; }
        public List<Phase> Phases { get => phases; set => phases = value; }

        private void RebuildMatrix()
        {
            matrix = new bool[Events.Count + States.Count + Phases.Count, Packages.Count];
            Workspace.Workspace.Instance.NotifyColleagues<object>("matrix", null);
        }

        public void Set(int Id, int packageNumber, bool param)
        {
            matrix[Id, packageNumber] = param;
        }

        public void AddMatrixElement(object element)
        {
            if (element is State)
            {
                States.Add(element as State);
                RebuildMatrix();
            }
            if (element is Event)
            {
                Events.Add(element as Event);
                RebuildMatrix();
            }
            if (element is Phase)
            {
                Phases.Add(element as Phase);
                RebuildMatrix();
            }
            if (element is Package)
            {
                Packages.Add(element as Package);
                RebuildMatrix();
            }
        }

        public void AddMatrixElement(List<object> elements)
        {
            foreach (object element in elements)
            {
                if (element is State)
                {
                    States.Add(element as State);
                }
                if (element is Event)
                {
                    Events.Add(element as Event);
                }
                if (element is Phase)
                {
                    Phases.Add(element as Phase);
                }
                if (element is Package)
                {
                    Packages.Add(element as Package);
                }
            }
            RebuildMatrix();
        }

        public List<Parameter> GetParameterFromPackages(string parameterName)
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (Package p in packages)
            {
                Parameter temp = p.GetParameter(parameterName);
                if (temp != null)
                {
                    parameters.Add(temp);
                }
            }
            return parameters;
        }

        public int[] GetMatrixElementRow(int id)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(matrix[id, i]);
            }
            return array;
        }

        public object GetMatrixElementById(int id)
        {
            foreach (State s in States)
            {
                if (s.ElementId == id)
                {
                    return s;
                }
            }
            foreach (Event e in Events)
            {
                if (e.ElementId == id)
                {
                    return e;
                }
            }
            foreach (Phase p in Phases)
            {
                if (p.ElementId == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
