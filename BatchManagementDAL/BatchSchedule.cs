//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BatchManagementDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BatchSchedule
    {
        public int ScheduleId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> HoursTaken { get; set; }
        public string TopicsTaken { get; set; }
    
        public virtual Batch Batch { get; set; }
    }
}
