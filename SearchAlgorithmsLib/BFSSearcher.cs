using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class BFSSearcher : Searcher
    {

        public BFSSearcher()
        {

            openList = new PriorityQueue<State<Position>>(new StateComparer<Position>());
        }

        private State<Position> popOpenList()
        {
            evaluatedNodes++;
            return (openList as PriorityQueue<State<Position>>).Dequeue();
        }

        private void addToOpenList(State<Position> state)
        {
            (openList as PriorityQueue<State<Position>>).Enqueue(state);
        }

        public override Solution search(ISearchable searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            Dictionary<Position, State<Position>> closed = new Dictionary<Position, State<Position>>();
            while (OpenListSize > 0)
            {

                State<Position> n = popOpenList();  // inherited from Searcher, removes the best state
                closed.Add(n.StateRepresentation,n);
                if (n.Equals(searchable.getGoalState()))
                {
                    return backTrace(n); // private method, back traces through the parents

                }
                // calling the delegated method, returns a list of states with n as a parent
                List<State<Position>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<Position> s in succerssors)
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
                            State<Position> oldS = getStateFromOpen(s);
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