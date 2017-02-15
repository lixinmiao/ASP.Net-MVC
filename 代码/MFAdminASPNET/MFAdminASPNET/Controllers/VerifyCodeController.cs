using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MFAdminASPNET.Models;

namespace MFAdminASPNET.Controllers
{
    public class VerifyCodeController : Controller
    {
        private MFAdminASPNETDB db = new MFAdminASPNETDB();

        // GET: VerifyCode
        public ActionResult Index()
        {
            return View(db.VerifyCodes.ToList());
        }

        // GET: VerifyCode/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerifyCode verifyCode = db.VerifyCodes.Find(id);
            if (verifyCode == null)
            {
                return HttpNotFound();
            }
            return View(verifyCode);
        }

        // GET: VerifyCode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VerifyCode/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Guid,VerifyText")] VerifyCode verifyCode)
        {
            if (ModelState.IsValid)
            {
                db.VerifyCodes.Add(verifyCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(verifyCode);
        }

        // GET: VerifyCode/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerifyCode verifyCode = db.VerifyCodes.Find(id);
            if (verifyCode == null)
            {
                return HttpNotFound();
            }
            return View(verifyCode);
        }

        // POST: VerifyCode/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Guid,VerifyText")] VerifyCode verifyCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verifyCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(verifyCode);
        }

        // GET: VerifyCode/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VerifyCode verifyCode = db.VerifyCodes.Find(id);
            if (verifyCode == null)
            {
                return HttpNotFound();
            }
            return View(verifyCode);
        }

        // POST: VerifyCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VerifyCode verifyCode = db.VerifyCodes.Find(id);
            db.VerifyCodes.Remove(verifyCode);
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
