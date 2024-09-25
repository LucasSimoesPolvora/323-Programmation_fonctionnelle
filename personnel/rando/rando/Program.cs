using Aspose.Gis;
using Aspose.Gis.Geometries;
using GPXReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace rando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\running.gpx";
            int index = 0;

            List<Trackpoint> trackpoints = new List<Trackpoint>();

            var layer = Drivers.Gpx.OpenLayer(filePath);
            

            foreach (var feature in layer)
            {
                // Check for Point geometry
                if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
                {
                    MultiLineString mls = (MultiLineString)feature.Geometry;

                    foreach (LineString line in mls)
                    {
                        foreach(var coords in line)
                        {
                            index++;
                            trackpoints.Add(new Trackpoint { index = index, latitude = coords.X, longitude = coords.Y, elevation = coords.Z});
                        }
                    }

                    //double distance = 0;

                    double distance = trackpoints.Zip(trackpoints.Skip(1), (current, next) => distanceBetween2points(current, next)).Sum();

                    double distanceBetween2points(Trackpoint current, Trackpoint next)
                    {
                        return Math.Sqrt(Math.Pow(next.latitude - current.latitude, 2) + Math.Pow(next.longitude - current.longitude, 2) + Math.Pow(next.elevation - current.elevation, 2));
                    }

                    

                    double verticalheight = trackpoints.Zip(trackpoints.Skip(1), (current, next) => current.elevation + next.elevation).Sum();

                    Console.WriteLine($"Distance du parcours: {distance}");
                    Console.WriteLine($"Dénivelé: {trackpoints[0].elevation - trackpoints[trackpoints.ToArray().Length - 1].elevation}");
                    Console.Read();
                }
                Console.Write(feature);
            }
        }
       

        internal class Trackpoint
        {
            private double _latitude;
            private double _longitude;
            private double _elevation;

            public int index { get; set; }
            public double latitude { get { return _latitude; } set { _latitude = value; } }
            public double longitude { get { return _longitude; } set { _longitude = value; } }
            public double elevation { get { return _elevation; } set { _elevation = value; } }
        }
    }
}
