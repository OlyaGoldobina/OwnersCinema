﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public class TariffRepositiory : IRepository<Tariff>
    {

        OurCinema Cinema = Factory.Instance.GetOurCinema();

        public TariffRepositiory()
        {

        }

        public bool AddItem(Tariff item)
        {
            try
            {
                int tempID = 0;
                foreach (Tariff tariff in Cinema.Tariffs)
                {
                    if (tariff.TariffID > tempID)
                    {
                        tempID = tariff.TariffID;
                    }
                }
                item.TariffID = tempID + 1;
                Cinema.Tariffs.Add(item);
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveItem(Tariff item)
        {
            try
            {
                foreach (Tariff tariff in Cinema.Tariffs)
                {
                    if (tariff.TariffID == item.TariffID)
                    {
                        Cinema.Tariffs.Remove(tariff);
                        
                    }
                }
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateItem(Tariff previous, Tariff updated)
        {
            try
            {
                int id = previous.TariffID;
                updated.TariffID = id;
                foreach (Tariff tariff in Cinema.Tariffs)
                {
                    if (tariff.TariffID == previous.TariffID)
                    {
                        //Cinema.Tariffs.Remove(tariff);
                        //Cinema.Tariffs.Add(updated);
                        //Cinema.SaveChanges();
                        tariff.D = updated.D;
                        tariff.Morning = updated.Morning;
                        tariff.Name = updated.Name;
                        tariff.Price = updated.Price;
                        tariff.Weekend = updated.Weekend;

                    }
                }
                Cinema.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Tariff> SelectItem()
        {
            List<Tariff> tariffs = new List<Tariff>();
            DbSet<Tariff> dbSet = Cinema.Tariffs;
            foreach (Tariff item in dbSet)
                tariffs.Add(item);
            return tariffs;
        }
    }
}
