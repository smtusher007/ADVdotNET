//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zero_Hunger.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DisReq
    {
        public DisReq()
        {
            this.ReqDetails = new HashSet<ReqDetail>();
        }
    
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int EmpId { get; set; }
        public int Status { get; set; }
        public int AreaId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<ReqDetail> ReqDetails { get; set; }
    }
}
