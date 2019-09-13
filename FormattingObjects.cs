using System;
using System.Collections.Generic;
using gatheringData;

namespace formattingLocations
{
    class keyLocation
    {
        private double thresholdDistance = 100;
        public int id;
        public string name;
        public double[] probability = new double[2];
        public double lambda;
        public List<reportedCrime> crimes;
        public bool smallDataSize;
        public Dictionary<string, float> coordinates = new Dictionary<string, float>();
        public List<keyLocation> nearLocations = new List<keyLocation>();
        public void createNewObject()
        {
            setCoordinates(crimes);
            setSmallDataSize(crimes);
        }
        public void setSmallDataSize(List<reportedCrime> crimeData)
        {
            if (crimeData.Count <= 7)
            {
                smallDataSize = true;
            }
            else
            {
                smallDataSize = false;
            }
        }

        private double DegreeToRadian (double angle)
        {
            return Math.PI * angle / 180.0;
        }
        public double distanceBetweenLocations(keyLocation otherLocation)
        {
            double longitude1 = this.coordinates["Longitude"];
            double longitude2 = otherLocation.coordinates["Longitude"];
            double latitude1 = this.coordinates["Latitude"];
            double latitude2 = otherLocation.coordinates["Latitude"];
            int radiusOfEarth = 6371000;
            double phi_1 = DegreeToRadian(latitude1);
            double phi_2 = DegreeToRadian(latitude2);
            double delta_phi = DegreeToRadian(latitude2 - latitude1);
            double delta_lambda = DegreeToRadian(longitude2 - longitude1);
            double a = (Math.Sin(delta_phi / 2.0) * Math.Sin(delta_phi / 2.0)) + Math.Cos(phi_1) * Math.Cos(phi_2) * (Math.Sin(delta_lambda/2.0) * Math.Sin(delta_lambda/2.0));
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double meterdistance = radiusOfEarth * c;
            return meterdistance;
        }
        public void setCoordinates(List<reportedCrime> crimeData)
        {
            float sumTotallatitudes = 0;
            float sumTotalLongitudes = 0;
            foreach (reportedCrime record in crimeData)
            {
                sumTotallatitudes = sumTotallatitudes + record.location.latitude;
                sumTotalLongitudes = sumTotalLongitudes + record.location.longitude;
            }
            float avglatitude = sumTotallatitudes / crimeData.Count;
            float avgLongitude = sumTotalLongitudes / crimeData.Count;
            this.coordinates.Add("Latitude", avglatitude);
            this.coordinates.Add("Longitude", avgLongitude);
        }
        public void findNearLocations(ref List<keyLocation> allLocations)
        {
            foreach (keyLocation locationObject in allLocations)
            {
                if (locationObject.id != this.id)
                {
                    double displacement = this.distanceBetweenLocations(locationObject);
                    if (displacement < thresholdDistance)
                    {
                        this.nearLocations.Add(locationObject);
                    }
                }
            }
        }
    }
    class program
    {
        static public List<keyLocation> formatData(Dictionary<int, List<reportedCrime>> splitData)
        {
            List<keyLocation> locations = new List<keyLocation>();
            foreach (KeyValuePair<int, List<reportedCrime>> splitLocation in splitData)
            {
                keyLocation temp = new keyLocation();
                temp.id = splitLocation.Key;
                temp.crimes = splitLocation.Value;
                temp.name = splitLocation.Value[0].location.street.name;
                temp.createNewObject();
                locations.Add(temp);
            }
            foreach (keyLocation record in locations)
            {
                record.findNearLocations(ref locations);
            }
            return locations;
        }

    }
}