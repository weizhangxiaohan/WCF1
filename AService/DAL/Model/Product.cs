using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AService.DAL.Model
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Inventory { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
    }
}
