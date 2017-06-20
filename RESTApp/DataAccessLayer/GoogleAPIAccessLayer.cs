using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTApp.BL;
using RESTApp.GoogleAPI;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;
using RESTApp;

namespace RESTApp.DataAccessLayerNameSpace
{
    public class GoogleAPIAccessLayer
    {
        private static string m_goooleApiKey = System.Configuration.ConfigurationManager.AppSettings["GOOGLE_API_KEY"];
        private MapsAPIClient m_googleClient = new MapsAPIClient(m_goooleApiKey);

        public int GetShortestDistance(string p_From, string p_To, List<string> p_wayPoints)
        {
            GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation wpn_loc = null;
            GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation from_loc = null;
            GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation to_loc = null;

            from_loc = new GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation(p_From);
            to_loc = new GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation(p_To);

            List<GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Location> wayPntsLocations = new List<GoogleMapsAPI.NET.API.Common.Components.Locations.Common.Location>(p_wayPoints.Count);
            foreach (string wayPnt in p_wayPoints)
            {
                wpn_loc = new GoogleMapsAPI.NET.API.Common.Components.Locations.PlaceLocation(wayPnt);
                wayPntsLocations.Add(wpn_loc);
            }

           

            GoogleMapsAPI.NET.API.Directions.Responses.GetDirectionsResponse directionsResult = null;

            if (wayPntsLocations.Count > 0)
                directionsResult = m_googleClient.Directions.GetDirections(from_loc, to_loc, mode: TransportationModeEnum.Driving, waypoints: wayPntsLocations);
            else
                directionsResult = m_googleClient.Directions.GetDirections(from_loc, to_loc, mode: TransportationModeEnum.Driving);

            int dist = GetShortestDistance(directionsResult.Routes);
            
            return dist;
        }
        
    

        private int GetShortestDistance(List <GoogleMapsAPI.NET.API.Directions.Results.GetDirectionsRouteResult> routsList)
        {
            List<int> routDistList = new List<int>(routsList.Count);
            foreach (GoogleMapsAPI.NET.API.Directions.Results.GetDirectionsRouteResult route in routsList)
            {
                routDistList.Add(route.Summary.Length);
            }


            return routDistList.Min();
        }
    }
}