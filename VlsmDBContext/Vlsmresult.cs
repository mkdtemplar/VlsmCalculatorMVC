using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VlsmDBContext
{
    [Table("vlsmresults")]
    public partial class Vlsmresult
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("NetworkID", TypeName = "VARCHAR (45)")]
        public string NetworkId { get; set; }
        [Column("CIDR", TypeName = "VARCHAR (45)")]
        public string Cidr { get; set; }
        [Column(TypeName = "VARCHAR (45)")]
        public string SubnetMask { get; set; }
        [Column(TypeName = "VARCHAR (45)")]
        public string NumberOfHostsPerSubnet { get; set; }
        [Column(TypeName = "VARCHAR (45)")]
        public string NumberOfSubnets { get; set; }
        [Column("RangeOfUsableIPaddresses", TypeName = "VARCHAR (45)")]
        public string RangeOfUsableIpaddresses { get; set; }
        [Column("broadcastID", TypeName = "VARCHAR (45)")]
        public string BroadcastId { get; set; }
    }
}
