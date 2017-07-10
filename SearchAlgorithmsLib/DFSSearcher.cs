using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class DFSSearcher : Searcher
    {

        public DFSSearcher()
        {
            openList = new ICollectionStack<State<Position>>(new Stack<State<Position>>());

        }
        public override Solution search(ISearchable searchable)
        {
            addToOpenList(searchable.getInitialState());
            Dictionary<Position, State<Position>> labeled = new Dictionary<Position, State<Position>>();
            while (OpenListSize > 0 )
            {
                State<Position> n = popOpenList();
                if (!labeled.ContainsKey(n.StateRepresentation) && !openContains(n))
                {

                    labeled.Add(n.StateRepresentation,n);
                    if (n.Equals(searchable.getGoalState()))
                        return backTrace(n); // private method, back traces through the parents
                                             // calling the delegated method, returns a list of states with n as a parent
                    List<State<Position>> succerssors = searchable.getAllPossibleStates(n);
                    foreach (State<Position> s in succerssors)
                    {
                        if (!labeled.ContainsKey(s.StateRepresentation) && !openContains(s))
                            addToOpenList(s);
                    }
                }
            }
            return null;
        }

        private State<Position> popOpenList()
        {
            evaluatedNodes++;
            return (openList as ICollectionStack<State<Position>>).Pop();
        }

        private void addToOpenList(State<Position> state)
        {
            (openList as ICollectionStack<State<Position>>).Add(state);
        }
    }
}
