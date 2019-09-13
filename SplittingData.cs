using System;
using System.Collections.Generic;
using gatheringData;


namespace splittingData
{

    class program
    {
        static public Dictionary<int, List<reportedCrime>> splittingDataFunction(List<List<reportedCrime>> gatheredCrime)
        {
            Dictionary<int, List<reportedCrime>> dict = new Dictionary<int, List<reportedCrime>>();
            foreach (List<reportedCrime> month in gatheredCrime)
            {
                foreach (reportedCrime Crime in month)
                {
                    if (!dict.ContainsKey(Crime.location.street.id))
                    {
                        List<reportedCrime> temp = new List<reportedCrime>();
                        temp.Add(Crime);
                        dict.Add(Crime.location.street.id, temp);
                    }
                    else
                    {
                        List<reportedCrime> crimesForId = dict[Crime.location.street.id];
                        crimesForId.Add(Crime);
                        dict[Crime.location.street.id] = crimesForId;
                    }
                }
            }
            Console.WriteLine(dict.Count);
            return dict;
        }

    }
}