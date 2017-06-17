using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Services;
using Google.Apis.Discovery;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;

namespace RESTApp.GoogleAPI
{
    public class GoogleApiClient
    {
        public void DisCoveryService()
        { // Create the service.
            //to do remove from here
            var client = new MapsAPIClient("AIzaSyC29znWjdwUcxAqvmlBQfa_0fGGwOQKfAo");
            // Geocoding an address
            var geocodeResult = client.Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");

            // Look up an address with reverse geocoding
            var reverseGeocodeResult = client.Geocoding.ReverseGeocode(40.714224, -73.961452);

            // Request directions via public transit
            var directionsResult = client.Directions.GetDirections("jerusalem",
                "tel aviv",
                mode: TransportationModeEnum.Transit,
                departureTime: DateTime.Now);
        }
    }
}