using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class DisReqRepo
    {
        public static List<DisReqModel> Get()
        {
            var db = new ZeroHungerDbEntities();
            var requests = new List<DisReqModel>();

            foreach (var item in db.DisReqs.ToList())
            {
                var request = new DisReqModel();
                request.Id = item.Id;
                request.Status = item.Status;
                request.RestaurantId = item.RestaurantId;
                request.EmpId = item.EmpId;
                request.AreaId = item.AreaId;
                requests.Add(request);
            }

            return requests;
        }
        public static List<DisReqModel> Get(int RestaurantId)
        {
            var db = new ZeroHungerDbEntities();
            var requests = new List<DisReqModel>();

            foreach (var item in db.DisReqs.ToList())
            {
                if (item.RestaurantId == RestaurantId)
                {
                    var request = new DisReqModel();
                    request.Id = item.Id;
                    request.Status = item.Status;
                    request.RestaurantId = item.RestaurantId;
                    request.EmpId = item.EmpId;
                    requests.Add(request);
                }
            }

            return requests;

        }
        public static List<DisReqModel> EmpGet(int EmpId)
        {
            var db = new ZeroHungerDbEntities();
            var requests = new List<DisReqModel>();

            foreach (var item in db.DisReqs.ToList())
            {
                if (item.EmpId == EmpId)
                {
                    var request = new DisReqModel();
                    request.Id = item.Id;
                    request.Status = item.Status;
                    request.RestaurantId = item.RestaurantId;
                    request.EmpId = item.EmpId;
                    requests.Add(request);
                }
            }

            return requests;

        }
        public static DisReq Create(DisReqModel data)
        {
            var db = new ZeroHungerDbEntities();
            var request = new DisReq()
            {
                RestaurantId = data.RestaurantId,
                AreaId = data.AreaId,
                Status = data.Status,
            };
            db.DisReqs.Add(request);
            db.SaveChanges();

            return request;

        }
        public static void Update(DisReqModel data)
        {
            var db = new ZeroHungerDbEntities();
            var request = (from rq in db.DisReqs
                           where rq.Id == data.Id
                           select rq).SingleOrDefault();
            request.EmpId = data.EmpId;
            request.Status = 2;

            db.SaveChanges();
        }
        public static void UpdateStatus(DisReqModel data)
        {
            var db = new ZeroHungerDbEntities();
            var request = (from rq in db.DisReqs
                           where rq.Id == data.Id && rq.EmpId == data.EmpId
                           select rq).SingleOrDefault();

            db.SaveChanges();
        }
    }
}