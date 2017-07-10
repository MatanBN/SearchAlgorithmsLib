using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public interface ISearchable
    {
        State<Position> getInitialState();
        State<Position> getGoalState();
        List<State<Position>> getAllPossibleStates(State<Position> s);

    }
}
