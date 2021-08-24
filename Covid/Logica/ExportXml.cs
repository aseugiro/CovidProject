using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covid.Models;
using Newtonsoft.Json;

namespace Covid.Logica
{
    public class ExportXml : ExportData
    {
        public override string DataToExport(List<CaseCovid> Data,string TypeSearch)
        {
            string DataExport = "<xml>";

            foreach (var item in Data)
            {
                DataExport += "<"+TypeSearch.ToLower()+"><name>" + (TypeSearch == "REGION" ? item.Region.Name : item.Region.Province) + "</name><cases>" + item.Confirmed + "</cases><death>" + item.Deaths + "</death></region>\n";

            }
            DataExport += "</xml>";

            return DataExport;

        }
    }
}