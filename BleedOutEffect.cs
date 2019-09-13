using System;
using System.Collections.Generic;
using formattingLocations;
using System.Linq;

namespace bleedOutEffect
{
    class program
    {
        static private void bleedOut(int id, ref List<keyLocation> data)
        {
            foreach (keyLocation vertex in data)
            {
                if (vertex.id == id)
                {
                    foreach (keyLocation neighbour in vertex.nearLocations)
                    {
                        neighbour.probability[0] = (neighbour.probability[0] + vertex.probability[0]) / 2;
                    }
                }
                break;
            }
        }
        static private double standardDeviationCalc(List<double> data, double average)
        {
            List<double> tempList = new List<double>();
            foreach (double probability in data)
            {
                tempList.Add(Math.Pow((probability - average), 2));
            }
            double standardDeviation = Math.Sqrt(tempList.Average());
            return standardDeviation;

        }
        static public void activateBleedOut(ref List<keyLocation> data)
        {
            List<double> allProb = new List<double>();
            foreach (keyLocation location in data)
            {
                allProb.Add(location.probability[0]);
            }
            double average = allProb.Average();

            double standardDeviation = standardDeviationCalc(allProb, average);
            foreach (keyLocation location in data)
            {
                if (location.probability[0] > (average + (2 * standardDeviation)) || location.probability[0] < (average - (2 * standardDeviation)))
                {
                    bleedOut(location.id, ref data);
                }
            }
        }
    }
}