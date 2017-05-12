using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class BFSSearcher<T> : Searcher<T>
    {

        public BFSSearcher()
        {

            openList = new PriorityQueue<State<T>>(new StateComparer<T>());
        }

        private State<T> popOpenList()
        {
            evaluatedNodes++;
            return (openList as PriorityQueue<State<T>>).Dequeue();
        }

        private void addToOpenList(State<T> state)
        {
            (openList as PriorityQueue<State<T>>).Enqueue(state);
        }

        public override Solution search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            Dictionary<T, State<T>> closed = new Dictionary<T, State<T>>();
            while (OpenListSize > 0)
            {

                State<T> n = popOpenList();  // inherited from Searcher, removes the best state
                closed.Add(n.StateRepresentation,n);
                if (n.Equals(searchable.getGoalState()))
                {
                    return backTrace(n); // private method, back traces through the parents

                }
                // calling the delegated method, returns a list of states with n as a parent
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    

                    if (!closed.ContainsKey(s.StateRepresentation) && !openContains(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        if (openContains(s))
                        {
                            State<T> oldS = getStateFromOpen(s);
                            if (oldS.Cost > s.Cost)
                            {
                                removeItem(oldS);
                                addToOpenList(s);
                            }
                        }
                    }
                }
            }
            return null;
        }

    }
}