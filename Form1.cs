using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using formattingLocations;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using gatheringData;

namespace Crime_Preditction_Prototype__With_Form_
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
        }
        private bool boxesFilled()
        {
            if(latitude1.Text != "" && longitude1.Text != "" && latitude2.Text != "" && longitude2.Text != "" && latitude3.Text != "" && longitude3.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetProgress(int progress)
        {
            progressBar1.PerformStep();
        }
        private bool boxesValid()
        {
            Regex pattern = new Regex("^-?[0-9]+(.[0-9]+)?$");
            if(pattern.IsMatch(latitude1.Text) && pattern.IsMatch(longitude1.Text) && pattern.IsMatch(latitude2.Text) && pattern.IsMatch(longitude2.Text) && pattern.IsMatch(latitude3.Text) && pattern.IsMatch(longitude3.Text))
            {
                Console.WriteLine("Regex Pass");
                return true;
            }
            else
            {
                Console.WriteLine("Regex Fail");
                return false;
            }
            
        }



        private void Analyse_Button_Click(object sender, EventArgs e)
        {
            if (boxesValid())
            {
                output_Box.Text = "";
                progressBar1.Visible = true;
                List<List<reportedCrime>> allCrime = gatheringData.Program.getCrimeObjects(latitude1.Text, longitude1.Text, latitude2.Text, longitude2.Text, latitude3.Text, longitude3.Text);
                Dictionary<int, List<reportedCrime>> splitData = splittingData.program.splittingDataFunction(allCrime);
                List<keyLocation> locations = formattingLocations.program.formatData(splitData);
                List<keyLocation> grid = analysingData.program.analyse(locations);
                GMapOverlay markers = new GMapOverlay("markers");
                foreach (keyLocation point in grid)
                {
                    if (point.smallDataSize)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                        new PointLatLng(point.coordinates["Latitude"], point.coordinates["Longitude"]),
                        GMarkerGoogleType.red_small);
                        string outputText = ("ID: " + point.id.ToString() +"\nName: " + point.name + "\nProbability: " + point.probability[0].ToString());
                        marker.ToolTipText = outputText;
                        markers.Markers.Add(marker);
                        gmap.UpdateMarkerLocalPosition(marker);

                    }
                    else
                    {
                        GMapMarker marker = new GMarkerGoogle(
                        new PointLatLng(point.coordinates["Latitude"], point.coordinates["Longitude"]),
                        GMarkerGoogleType.blue_small);
                        string outputText = ("ID: " + point.id.ToString() +"\nName: " + point.name + "\nProbability: " + point.probability[0].ToString());
                        marker.ToolTipText = outputText;
                        markers.Markers.Add(marker);
                        gmap.UpdateMarkerLocalPosition(marker);

                    }
                    GMapOverlay connectionsOverlay = new GMapOverlay("polygons");
                    foreach (keyLocation otherPoint in grid)
                    {
                        foreach (keyLocation neighbour in otherPoint.nearLocations)
                        {
                            List<PointLatLng> coordinates = new List<PointLatLng>();
                            coordinates.Add(new PointLatLng(otherPoint.coordinates["Latitude"], otherPoint.coordinates["Longitude"]));
                            coordinates.Add(new PointLatLng(neighbour.coordinates["Latitude"], neighbour.coordinates["Longitude"]));
                            GMapPolygon linePolygon = new GMapPolygon(coordinates, "mypolygon");
                            linePolygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                            linePolygon.Stroke = new Pen(Color.Red, 1);
                            connectionsOverlay.Polygons.Add(linePolygon);
                            Console.WriteLine("Point: {0} Neighbour: {1}", otherPoint.id, neighbour.id);
                        }
                    }
                    List<PointLatLng> temp = new List<PointLatLng>();
                    temp.Add(new PointLatLng(53.1984235851904, -2.90));
                    temp.Add(new PointLatLng(53.1984235851904, -2.91));
                    GMapPolygon tempPolygon = new GMapPolygon(temp, "newPolygon");
                    tempPolygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    tempPolygon.Stroke = new Pen(Color.Red, 1);
                    connectionsOverlay.Polygons.Add(tempPolygon);
                    gmap.Overlays.Add(connectionsOverlay);



                }
                progressBar1.Visible = false;
                gmap.Overlays.Clear();
                gmap.Overlays.Add(markers);
            }
            else if(!boxesFilled())
            {
                output_Box.Text = "Not all required boxes have been filled please fill all boxes";
            }
            else
            {
                output_Box.Text = "Coordinates in the required boxes are not in the correct format\nPlease ensure all coordinates are formatted such as 3.456 or -123.456";
            }

        }

        private void gm1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(radioButton1.Checked)
                {
                    latitude1.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
                    longitude1.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
                    radioButton2.Checked = true;
                }
                else if (radioButton2.Checked)
                {
                    latitude2.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
                    longitude2.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
                    radioButton3.Checked = true;
                }
                else
                {
                    latitude3.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
                    longitude3.Text = gmap.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
                    radioButton1.Checked = true;
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(54.5, -5);
            gmap.ShowCenter = false;
            gmap.DragButton = MouseButtons.Left;

            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(53.123, -2.585789));
            points.Add(new PointLatLng(53.5678, -2.588171));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);

        }

        private void textBox_Changed(object sender, EventArgs e)
        {
            if (boxesValid())
            {
                gmap.Overlays.Clear();
                GMapOverlay polygons = new GMapOverlay("polygons");
                List<PointLatLng> points = new List<PointLatLng>();
                points.Clear();
                points.Add(new PointLatLng(Double.Parse(latitude1.Text), Double.Parse(longitude1.Text)));
                points.Add(new PointLatLng(Double.Parse(latitude2.Text), Double.Parse(longitude2.Text)));
                points.Add(new PointLatLng(Double.Parse(latitude3.Text), Double.Parse(longitude3.Text)));
                GMapPolygon polygon = new GMapPolygon(points, "Search Area");
                polygons.Polygons.Add(polygon);
                gmap.Overlays.Add(polygons);
                gmap.UpdatePolygonLocalPosition(polygon);
            }
        }
    }
    public class program
    {
        static public void incrementProgressBar()
        { 
            // Progress Bar code calls this function after each gather //
        }
    }
}
