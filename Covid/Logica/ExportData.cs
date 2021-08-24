using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covid.Models;
namespace Covid.Logica
{
    public abstract class ExportData
    {
        public abstract string DataToExport(List<CaseCovid> Data,string TypeSearch);
    }
}