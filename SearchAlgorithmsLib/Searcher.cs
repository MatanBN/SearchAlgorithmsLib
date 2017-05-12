
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        protected ICollection<State<T>> openList;
        protected int evaluatedNodes;

        public Searcher()
        {
            evaluatedNodes = 0;
        }

        protected bool openContains(State<T> state)
        {
            foreach (State<T> s in openList)
            {
                if (state.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        protected State<T> getStateFromOpen(State<T> state)
        {
            foreach(State<T> s in openList)
            {
                if (state.Equals(s))
                {
                    return s;
                }
            }
            return null;
        }

        protected void removeItem(State<T> s)
        {
            openList.Remove(s);
        }

        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        // ISearcher’s methods: 

        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public abstract Solution search(ISearchable<T> searchable);

        protected Solution backTrace(State<T> state)
        {
            State<T> s = state;
            StringBuilder sob = new StringBuilder();
            while (s != null)
            {
                sob.Insert(0,s.ToString() + " ");
                
                s = s.StatePapa;
            }
            return new Solution(sob.ToString());
        }
    }


}
