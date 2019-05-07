using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.Metadata;
using CapaDatos;

namespace CapaNegocio
{
    public class CNTerritories
    {
        public void Insertar(string idT, string descT, string descR)
        {
            try
            {
                using (NorthwindEntities obNE = new NorthwindEntities())
                {
                    Territory obT = new Territory
                    {
                        TerritoryID = idT,
                        TerritoryDescription = descT,
                        RegionID = obNE.Regions.First(r => r.RegionDescription == descR).RegionID
                    };
                    obNE.Territories.Add(obT);
                    obNE.SaveChanges();
                }
            }
            catch(Exception ex) { throw ex;  }
        }
        public void Modificar(string idT, string descT, string descR)
        {
            try
            {
                using (NorthwindEntities obNE = new NorthwindEntities())
                {
                    Territory obT = obNE.Territories.First(q => q.TerritoryID == idT);
                    obT.TerritoryID = idT;
                    obT.TerritoryDescription = descT;
                    obT.RegionID = obNE.Regions.First(r => r.RegionDescription == descR).RegionID;
                    obNE.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Eliminar(string idT)
        {
            try
            {
                using (NorthwindEntities obNE = new NorthwindEntities())
                {
                    Territory obT = obNE.Territories.Find(idT);
                    obNE.Territories.Remove(obT);
                    obNE.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
      
        public List<CETerritories> GetList()
        {
            try
            {
                using (NorthwindEntities obNE = new NorthwindEntities())
                {
                    List<CETerritories> obQuery = (from t in obNE.Territories
                                                   join r in obNE.Regions on t.RegionID equals r.RegionID
                                                   select new CETerritories {
                                                       TerritoryID = t.TerritoryID,
                                                       TerritoryDescription = t.TerritoryDescription,
                                                       RegionID = t.RegionID,
                                                       RegionDescription = r.RegionDescription
                                                   }).ToList();
                    return obQuery;
                }


            }catch(Exception ex) { throw ex;  }
        }
    }
}
