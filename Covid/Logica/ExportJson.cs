using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covid.Models;
using Newtonsoft.Json;

namespace Covid.Logica
{
    public class ExportJson : ExportData
    {
        public override string DataToExport(List<CaseCovid> Data, string TypeSearch)
        {
            string DataExport = "[";

            foreach (var item in Data) {
                DataExport += "{" + "\""+TypeSearch+"\":\"" + (TypeSearch == "REGION" ? item.Region.Name : item.Region.Province) + "\"," + "\"CASES\":" + item.Confirmed + "," + "\"DEATHS\":" + item.Deaths + "},";

            }
            if (!DataExport.Equals("[")) {
                DataExport = DataExport.Remove(DataExport.Length - 1, 1);

            }

            DataExport += "]";

            return DataExport;

        }

    }
}