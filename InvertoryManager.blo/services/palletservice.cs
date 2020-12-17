using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using inventoryManager.client;
using InventoryManagerDatabase;
using InventoryManagerDatabase.model;
using Microsoft.EntityFrameworkCore;

namespace InvertoryManager.blo.services
{
    public class palletservice
    {
        private InventoryManagerContext managercontext;
        public palletservice(InventoryManagerContext context)
        {
            managercontext = context;
        }
        public GetPalletResponse getpalletResponse(int palletID)
        {
            var pallet = managercontext.pallets.Include(x => x.size).SingleOrDefault(x => x.Id == palletID); ;
            takedownpallet(pallet);
            return new GetPalletResponse
            {
                weight = pallet.Weight,
                size = new sizeResponse
                {
                    Length = pallet.size.Length,
                    Height = pallet.size.Height,
                    Width = pallet.size.Width
                }
            };
           
        }
        private void takedownpallet(pallet pal)
        {
            pal.Isplacede = false;
            managercontext.Update(pal);
            managercontext.SaveChanges();
        }
    }
}
