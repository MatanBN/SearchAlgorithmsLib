using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State <T>
    {
        private T stateRepresentation;    // the state representation.
        private double cost;     // cost to reach this state (set by a setter)
        private State<T> statePapa; // The papa of this state.
        public double Cost
        {
            get
            {
                return cost;
            }
        }

        public T StateRepresentation
        {
            get
            {
                return stateRepresentation;
            }
        }

        public State<T> StatePapa
        {
            get
            {
                return statePapa;
            }
        }
        public State(T state, State<T> statePapa, double cost)    // CTOR
        {
            this.stateRepresentation = state;
            this.statePapa = statePapa;
            this.cost = cost;
        }

        public override string ToString()
        {
            return stateRepresentation.ToString();
        }

        public override bool Equals(object obj) // we override Object's Equals method
        {
            return stateRepresentation.Equals((obj as State<T>).stateRepresentation);
        }
    }
}
