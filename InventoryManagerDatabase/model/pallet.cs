using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagerDatabase.model
{
    public class pallet
    {
        public Size size { get; set; }
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public bool Isplacede { get; set; }
    }
}
