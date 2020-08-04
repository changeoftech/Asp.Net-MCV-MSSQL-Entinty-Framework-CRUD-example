using RegisterTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterTestApp.Business
{
    public class NWBusinessLogic
    {
        public int Save(Bilgi bilgi)
        {
            using (var ctx = new TestDatabaseEntities())
            {
                ctx.Bilgi.Add(bilgi);
                return ctx.SaveChanges();
            }
        }

        public List<Bilgi> List()
        {
            using (var ctx = new TestDatabaseEntities())
            {
                return ctx.Bilgi.ToList();
            }
        }

        public Bilgi Update(Bilgi bilgi)
        {
            using (var ctx = new TestDatabaseEntities())
            {
                var c = ctx.Bilgi.FirstOrDefault(i => i.SICIL_NO == bilgi.SICIL_NO);
                if(c != null)
                {
                    c.AD = bilgi.AD;
                    c.SOYAD = bilgi.SOYAD;
                    c.GOREVI = bilgi.GOREVI;
                    c.IS_BASLANGIC_TARIH = bilgi.IS_BASLANGIC_TARIH;
                    ctx.SaveChanges();
                }
                return c;
            }
        }

        public int Delete(Bilgi bilgi)
        {
            using (var ctx = new TestDatabaseEntities())
            {
                Bilgi c = ctx.Bilgi.Where(i => i.SICIL_NO == bilgi.SICIL_NO).SingleOrDefault();
                ctx.Bilgi.Remove(c);
                return ctx.SaveChanges();
            }
        }

    }
}