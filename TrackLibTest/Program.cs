using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;

using Zeptomoby.OrbitTools;

namespace TrackLibTest
{
    public class Program : Microsoft.SPOT.Application
    {
        public static void Main()
        {
            string str1 = "ISS (ZARYA)             ";
            string str2 = "1 25544U 98067A   13222.08683053  .00004563  00000-0  87202-4 0  3628";
            string str3 = "2 25544  51.6485 201.2720 0004128 298.2475 180.8024 15.50224716843064";
            Tle tle1 = new Tle(str1, str2, str3);
            Site siteEquator = new Site(52.1259155, -0.219355, 0);
            Orbit orbit = new Orbit(tle1);
            DateTime now = DateTime.Now;
            Track t = new Track();
            t.GetPasses(siteEquator, orbit, DateTime.Now);

            while (true)
            {
                EciTime eciSDP4 = orbit.GetPosition(DateTime.Now);
                Topo topoLook = siteEquator.GetLookAngle(eciSDP4);
                CoordGeo g = eciSDP4.ToGeo();
                Debug.Print(g.Latitude.ToString() + " " + g.Longitude.ToString() + " " + g.Altitude.ToString());
                Thread.Sleep(1000);
            }
        }

    }
}
