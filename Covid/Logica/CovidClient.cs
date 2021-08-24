using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using unirest_net;
using unirest_net.http;
using Covid.Models;
using System.Threading.Tasks;

namespace Covid.Logica
{
    public class CovidClient : ICovidClient
    {

        public DataContainer<Region> GetRegion()
        {
            Uri uri = new Uri("https://covid-19-statistics.p.rapidapi.com/regions");

            HttpResponse<DataContainer<Region>> response = Unirest.get(uri.AbsoluteUri.ToString())
            .header("X-RapidAPI-Key", "2131537414msh5f4b3c0b5d210e8p13b800jsn16b70140b4d9")
            .header("X-RapidAPI-Host", "covid-19-statistics.p.rapidapi.com")
            .asJson<DataContainer<Region>>();

            return response.Body;

        }

        public DataContainer<CaseCovid> GetReportRegion()
        {
            Uri uri = new Uri("https://covid-19-statistics.p.rapidapi.com/reports");

            HttpResponse<DataContainer<CaseCovid>> response = Unirest.get(uri.AbsoluteUri.ToString())
            .header("X-RapidAPI-Key", "2131537414msh5f4b3c0b5d210e8p13b800jsn16b70140b4d9")
            .header("X-RapidAPI-Host", "covid-19-statistics.p.rapidapi.com")
            .asJson<DataContainer<CaseCovid>>();

            return response.Body;

        }


        public DataContainer<CaseCovid> GetReportByRegion(string StrIso)
        {
            Uri uri = new Uri("https://covid-19-statistics.p.rapidapi.com/reports");

            HttpResponse<DataContainer<CaseCovid>> response = Unirest.get(uri.AbsoluteUri.ToString()+"?iso="+ StrIso)
            .header("X-RapidAPI-Key", "2131537414msh5f4b3c0b5d210e8p13b800jsn16b70140b4d9")
            .header("X-RapidAPI-Host", "covid-19-statistics.p.rapidapi.com")
            .asJson<DataContainer<CaseCovid>>();

            return response.Body;

        }

        public DataContainer<ProvinceE> GetProvince(string StrIso)
        {
            Uri uri = new Uri("https://covid-19-statistics.p.rapidapi.com/provinces");

            HttpResponse<DataContainer<ProvinceE>> response = Unirest.get(uri.AbsoluteUri.ToString() + "?iso=" + StrIso)
            .header("X-RapidAPI-Key", "2131537414msh5f4b3c0b5d210e8p13b800jsn16b70140b4d9")
            .header("X-RapidAPI-Host", "covid-19-statistics.p.rapidapi.com")
            .asJson<DataContainer<ProvinceE>>();

            return response.Body;

        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public CovidClient() { }
    }
}