using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class AreaRepo
    {
        public static List<AreaModel> Get()
        {
            var areas = new List<AreaModel>();
            var db = new ZeroHungerDbEntities();

            foreach (var area in db.Areas)
            {
                areas.Add(new AreaModel()
                {
                    Id = area.Id,
                    Name = area.Name
                });
            }
            return areas;
        }
    }
}