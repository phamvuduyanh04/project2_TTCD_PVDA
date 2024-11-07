using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJECT2.Models;

namespace PROJECT2.Controllers
{
    public class DatVesController : Controller
    {
        private QLVEMAYBAYEntities db = new QLVEMAYBAYEntities();

        // GET: DatVes
        public ActionResult Index()
        {
            var datVes = db.DatVes.Include(d => d.ChuyenBay).Include(d => d.KhachHang);
            return View(datVes.ToList());
        }

        // GET: DatVes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // GET: DatVes/Create
        public ActionResult Create()
        {
            ViewBag.MaChuyenBay = new SelectList(db.ChuyenBays, "MaChuyenBay", "SoHieuChuyenBay");
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen");
            return View();
        }

        // POST: DatVes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatVe,MaKhachHang,MaChuyenBay,NgayDat,SoLuongVe,TongTien,TrangThai")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.DatVes.Add(datVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuyenBay = new SelectList(db.ChuyenBays, "MaChuyenBay", "SoHieuChuyenBay", datVe.MaChuyenBay);
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", datVe.MaKhachHang);
            return View(datVe);
        }

        // GET: DatVes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuyenBay = new SelectList(db.ChuyenBays, "MaChuyenBay", "SoHieuChuyenBay", datVe.MaChuyenBay);
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", datVe.MaKhachHang);
            return View(datVe);
        }

        // POST: DatVes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatVe,MaKhachHang,MaChuyenBay,NgayDat,SoLuongVe,TongTien,TrangThai")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuyenBay = new SelectList(db.ChuyenBays, "MaChuyenBay", "SoHieuChuyenBay", datVe.MaChuyenBay);
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "HoVaTen", datVe.MaKhachHang);
            return View(datVe);
        }

        // GET: DatVes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // POST: DatVes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatVe datVe = db.DatVes.Find(id);
            db.DatVes.Remove(datVe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
