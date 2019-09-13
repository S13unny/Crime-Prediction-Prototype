using System;
using System.Collections.Generic;
using formattingLocations;
using Newtonsoft.Json;
using System.Net;
using bleedOutEffect;

namespace analysingData
{
    class dateClass
    {
        public string date { get; set; }
    }
    class program
    {
        static public double findTimeLapse()
        {
            dateClass firstUpdate = new dateClass();
            firstUpdate.date = "2016-07-01";
            string json = new WebClient().DownloadString("https://data.police.uk/api/crime-last-updated");
            dateClass recentUpdate = JsonConvert.DeserializeObject<dateClass>(json);
            DateTime initialEntry = DateTime.Parse(firstUpdate.date);
            DateTime finalEntry = DateTime.Parse(recentUpdate.date);
            double timeLapse = (finalEntry - initialEntry).TotalDays;
            return timeLapse;
        }
        static public double findLambda(keyLocation location, double timeLapse)
        {
            double lambda = location.crimes.Count / timeLapse;
            return lambda;
        }
        static public double findProbabilityOfCrime(keyLocation location, int timeFrame)
        {
            double adjustedLambda = location.lambda * timeFrame;
            double probability = adjustedLambda * (Math.Pow(Math.E, (0 - adjustedLambda)));
            return probability;
        }


        static public List<keyLocation> analyse(List<keyLocation> fullGrid)
        {
            double timeLapse = findTimeLapse();
            foreach (keyLocation location in fullGrid)
            {
                double lambda = findLambda(location, timeLapse);
                location.lambda = lambda;
            }
            int timeFrameForCrimeOccur = 7;
            foreach (keyLocation location in fullGrid)
            {
                double probability = findProbabilityOfCrime(location, timeFrameForCrimeOccur);
                location.probability[0] = probability;
                location.probability[1] = timeFrameForCrimeOccur;
            }
            bleedOutEffect.program.activateBleedOut(ref fullGrid);
            return fullGrid;
        }
    }
}