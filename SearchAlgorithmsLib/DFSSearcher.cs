using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SearchAlgorithmsLib
{
    public class DFSSearcher<T> : Searcher<T>
    {

        public DFSSearcher()
        {
            openList = new ICollectionStack<State<T>>(new Stack<State<T>>());

        }
        public override Solution search(ISearchable<T> searchable)
        {
            addToOpenList(searchable.getInitialState());
            Dictionary<T,State<T>> labeled = new Dictionary<T, State<T>>();
            while (OpenListSize > 0 )
            {
                State<T> n = popOpenList();
                if (!labeled.ContainsKey(n.StateRepresentation) && !openContains(n))
                {

                    labeled.Add(n.StateRepresentation,n);
                    if (n.Equals(searchable.getGoalState()))
                        return backTrace(n); // private method, back traces through the parents
                                             // calling the delegated method, returns a list of states with n as a parent
                    List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                    foreach (State<T> s in succerssors)
                    {
                        if (!labeled.ContainsKey(s.StateRepresentation) && !openContains(s))
                            addToOpenList(s);
                    }
                }
            }
            return null;
        }

        private State<T> popOpenList()
        {
            evaluatedNodes++;
            return (openList as ICollectionStack<State<T>>).Pop();
        }

        private void addToOpenList(State<T> state)
        {
            (openList as ICollectionStack<State<T>>).Add(state);
        }
    }
}
