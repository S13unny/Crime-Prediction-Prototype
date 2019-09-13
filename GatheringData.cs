using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Crime_Preditction_Prototype__With_Form_;
namespace gatheringData
{

    class streetObject
    {
        public int id { get; set; }
        public string name { get; set; }

    }
    class locationObject
    {
        public float latitude { get; set; }
        public streetObject street { get; set; }
        public float longitude { get; set; }


    }
    class reportedCrime
    {
        public string category { get; set; }
        public string location_type { get; set; }
        public locationObject location { get; set; }
        public string context { get; set; }
        public string persistant_id { get; set; }
        public string id { get; set; }
        public string month { get; set; }


    }
    class Program
    {
        static public List<List<reportedCrime>> getCrimeObjects(string latitude1,string longitude1,string latitude2,string longitude2,string latitude3, string longitude3)
        {
            List<List<reportedCrime>> allOfTheCrimes = new List<List<reportedCrime>>();
            for (int year = 2016; year < 2020; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                    try
                    {
                        string url = "https://data.police.uk/api/crimes-street/all-crime?poly="+latitude1+",%20"+longitude1+":"+latitude2+",%20"+longitude2+":"+latitude3+",%20"+longitude3+"&date=" + year.ToString() + "-" + month.ToString();
                        string json = new WebClient().DownloadString(url);

                        List<reportedCrime> allCrimes = JsonConvert.DeserializeObject<List<reportedCrime>>(json);
                        allOfTheCrimes.Add(allCrimes);
                    }
                    catch
                    {

                    }
                    // Must increment progress bar with each of these ticks //
                    // Function in form namespace incrementProgressBar() increments the bar //                    
                    
                    
                    Console.WriteLine("Month: {0} Year: {1}", month, year);
                }

            }
            Console.WriteLine("Data Gathered");
            return allOfTheCrimes;
        }




    }
}
