using Covid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Logica
{
    public interface ICovidClient
    {
            DataContainer<Region> GetRegion();

            DataContainer<CaseCovid> GetReportRegion();
          
            DataContainer<CaseCovid> GetReportByRegion(string StrIso);

            DataContainer<ProvinceE> GetProvince(string StrIso);
    }
}
