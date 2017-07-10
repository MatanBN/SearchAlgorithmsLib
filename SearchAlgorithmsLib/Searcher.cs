
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public abstract class Searcher : ISearcher
    {
        protected ICollection<State<Position>> openList;
        protected int evaluatedNodes;

        public Searcher()
        {
            evaluatedNodes = 0;
        }

        protected bool openContains(State<Position> state)
        {
            foreach (State<Position> s in openList)
            {
                if (state.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        protected State<Position> getStateFromOpen(State<Position> state)
        {
            foreach(State<Position> s in openList)
            {
                if (state.Equals(s))
                {
                    return s;
                }
            }
            return null;
        }

        protected void removeItem(State<Position> s)
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
        public abstract Solution search(ISearchable searchable);

        protected Solution backTrace(State<Position> state)
        {
            State<Position> s = state;
            StringBuilder sob = new StringBuilder();
            while (s != null)
            {
                sob.Insert(0,s.ToString() + " ");
                
                s = s.StatePapa;
            }
            return new Solution(sob.ToString(), evaluatedNodes);
        }
    }


}
