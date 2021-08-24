using Covid.Models;
using System.Collections.Generic;

namespace Covid.Logica
{
    public class ExportCSV : ExportData
    {
        public override string DataToExport(List<CaseCovid> Data, string TypeSearch)
        {
            string DataExport = TypeSearch+",CASES,DEATHS\n";

            foreach (var item in Data)
            {
                DataExport +=  (TypeSearch== "REGION" ? item.Region.Name:item.Region.Province) + "," + item.Confirmed + "," + item.Deaths + "\n";

            }
            return DataExport;

        }
    }
}