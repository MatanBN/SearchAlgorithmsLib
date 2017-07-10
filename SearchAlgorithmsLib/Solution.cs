using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution
    {
        private string solution;
        private int nodesEvauluated;
        private string name;
        public Solution(string solution, int numberOfNodesEvauluated)
        {
            this.solution = solution;
            this.nodesEvauluated = numberOfNodesEvauluated;

        }

        public string Name
        {
            set { this.name = value; }
        }

        public override string ToString()
        {
            return solution;
        }

        private string GetSolutionWay()
        {
            StringBuilder sob = new StringBuilder();
            string[] path = solution.Split(' ');
            int[] currentCoordinates = ParseCoordinates(path[0]);
            for (int i = 1; i < path.Length - 1; ++i)
            {
                int[] nextCoordinates = ParseCoordinates(path[i]);
                if (currentCoordinates[0] > nextCoordinates[0])
                {
                    sob.Append('0');
                }
                else if (currentCoordinates[0] < nextCoordinates[0])
                {
                    sob.Append('1');
                }
                else if (currentCoordinates[1] > nextCoordinates[1])
                {
                    sob.Append('2');
                }
                else
                {
                    sob.Append('3');
                }
                currentCoordinates = nextCoordinates;
            }
            return sob.ToString();
        }

        private int[] ParseCoordinates(string node)
        {
            int[] coordinates = new int[2];
            string[] xy = node.Split(',');
            coordinates[1] = int.Parse(xy[0][1].ToString());
            coordinates[0] = int.Parse(xy[1][0].ToString());
            return coordinates;
        }

        public string toJSON()
        {
            JObject jSolution = new JObject();
            jSolution.Add("Name", name);
            jSolution.Add("Solution", GetSolutionWay());
            jSolution.Add("NodesEvaluated", nodesEvauluated.ToString()); ;
            return jSolution.ToString();
        }
    }
}
