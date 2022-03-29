using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BUS;
using QuanLySachKT.Models;

namespace QuanLySachKT.Controllers
{
    public class SachesController : Controller
    {

        private SachBUS sachBUS = new SachBUS();

        // GET: Saches
        public ActionResult Index()
        {
            return View(sachBUS.GetSaches());
        }

        // GET: Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = sachBUS.GetSachByID(id.Value);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,LinhVu,CacTacGia,NhaXB,NamXB,LanTaiBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                int check = sachBUS.Add(sach);
                if (check == -1)
                {
                    ViewBag.ThongBao = "Sach da ton tai";
                }
                else if (check > 0)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.ThongBao = "Khong thanh cong";
                }

            }

            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = sachBUS.GetSachByID(id.Value);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,LinhVu,CacTacGia,NhaXB,NamXB,LanTaiBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                int check = sachBUS.Update(sach);
                if (check > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ThongBao = "Cap nhat khong thanh cong";
                }

            }
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = sachBUS.GetSachByID(id.Value);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = sachBUS.GetSachByID(id);
            sachBUS.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetSachByLinhVuc(string linhvuc)
        {
            return View(sachBUS.GetSachByLinhVu(linhvuc));
        }
        public ActionResult GetSachByTenSach(string tensach)
        {
            return View(sachBUS.GetSachByName(tensach));
        }
        public ActionResult SoLuongBYNXB(string nxb)
        {
            int count = sachBUS.GetSoLuongByNXB(nxb);
            ViewBag.SoLuong = count;
            return View();
        }
        public ActionResult SachTaiBanSau2020()
        {
            return View(sachBUS.GetSachAfter2020());
        }
        public ActionResult SachTaiBanLon2()
        {
            return View(sachBUS.GetSachesSoLanTaiBan());
        }

    }
}
