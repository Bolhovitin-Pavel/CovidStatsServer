using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;


namespace CovidStatsServer.Controllers
{
    public class CovidStatsController : ApiController
    {
        public class Records
        {
            public CovidStat[] records;
        }

        public class CovidStat
        {
            public string dateRep;
            public string day;
            public string month;
            public string year;
            public int cases;
            public int deaths;
            public string countriesAndTerritories;
            public string geoId;
            public string countryterritoryCode;  // can be null
            public string popData2019;  // int, but in json but can null
            public string continentExp;  // can be empty string
            [JsonProperty("Cumulative_number_for_14_days_of_COVID-19_cases_per_100000")]
            public string Cumulative_number_for_14_days_of_COVID19_cases_per_100000;
        }


        // GET api/covidstats
        public Records Get()
        {
            string url = "https://opendata.ecdc.europa.eu/covid19/casedistribution/json/";
            Records items = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            try
            {
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string response = streamReader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<Records>(response);
                }
            }
            catch (Exception e)
            {
                // TODO: Handle the exception
            }

            return items;
        }
    }
}