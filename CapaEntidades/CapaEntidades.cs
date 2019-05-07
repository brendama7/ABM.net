using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CETerritories
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public Int16 RegionID { get; set; }
        public string RegionDescription { get; set; }
        public CETerritories() { }
        public CETerritories(string idT, string descT, Int16 idR, string descR)
        {
            this.TerritoryID = idT;
            this.TerritoryDescription = descT;
            this.RegionID = idR;
            this.RegionDescription = descR;
        }

    }

}
