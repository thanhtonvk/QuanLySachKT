using QuanLySachKT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLSach.Controllers
{
    public class SachController : ApiController
    {
        DBContext db = new DBContext();
        [Route("api/sach/getall")]
        public IEnumerable<Sach> GetSaches()
        {
            return db.Saches;
        }
        [Route("api/sach/getsachbyid/{id}")]
        public Sach GetSachById(int id)
        {
            return db.Saches.Find(id);
        }
        [Route("Thuvien/Sachs/{tensach}")]
        public IEnumerable<Sach> GetSachByName(string tensach)
        {
            return db.Saches.Where(x => x.TenSach.ToLower().Contains(tensach.ToLower()));
        }
        [Route("Thuvien_Sachs/public/{linhvuc}")]
        public IEnumerable<Sach> GetSachByLinhVu(string linhvuc)
        {
            return db.Saches.Where(x => x.LinhVu.ToLower().Contains(linhvuc.ToLower()));
        }
        [Route("Sachs/{XuatBan}")]
        public int GetSoLuongByNXB(string XuatBan)
        {
            if (string.IsNullOrEmpty(XuatBan)) return 0;
            return db.Saches.Where(x => x.NhaXB.ToLower().Contains(XuatBan.ToLower())).ToList().Count;
        }
        [Route("Sachs/getafter2020")]
        public IEnumerable<Sach> GetSachAfter2020()
        {
            return db.Saches.Where(x => x.NamXB > 2020);
        }
        [Route("Sachs/sotaibans")]
        public IEnumerable<Sach> GetSoLanTaiBan()
        {
            return db.Saches.Where(x => x.LanTaiBan > 2);
        }

        [Route("api/Sachs/post")]
        public int Post([FromBody] Sach sach)
        {
            var check = db.Saches.FirstOrDefault(x => x.TenSach.ToLower().Equals(sach.TenSach));
            if (check == null)
            {
                db.Saches.Add(sach);
                return db.SaveChanges();
            }
            return -1;
        }
        [Route("api/Sachs/put")]
        public int Put([FromBody] Sach sach)
        {
            var check = db.Saches.FirstOrDefault(x => x.TenSach.ToLower().Equals(sach.TenSach));
            if (check == null)
            {
                return -1;
               
            }
            db.Saches.Add(sach);
            db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        [Route("api/Sachs/delete")]
        public int Delete(int id)
        {
            var check = db.Saches.Find(id);
            if (check == null) return -1;
            else
            {
                db.Saches.Remove(check);
                return db.SaveChanges();
            }
        }

    }
}
