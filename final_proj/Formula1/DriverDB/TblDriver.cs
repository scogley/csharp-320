using System;
using System.Collections.Generic;

namespace DriverDB
{
    public partial class TblDriver
    {
        public int Id { get; set; }
        public string CircuitName { get; set; }
        public string DriverName { get; set; }
        public string TeamName { get; set; }
        public string Position { get; set; }
        public string Points { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
