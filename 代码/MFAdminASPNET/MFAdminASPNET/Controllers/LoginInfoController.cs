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
    public class LoginInfoController : Controller
    {
        private MFAdminASPNETDB db = new MFAdminASPNETDB();

        // GET: LoginInfo
        public ActionResult Index()
        {
            return View(db.LoginInfoes.ToList());
        }

        // GET: LoginInfo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // GET: LoginInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginInfo/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoginToken,LastAccessTime,UserID,LoginName,ClientIP,EnumLoginAccountType,BusinessPermissionString,CreateTime")] LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                db.LoginInfoes.Add(loginInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginInfo);
        }

        // GET: LoginInfo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // POST: LoginInfo/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoginToken,LastAccessTime,UserID,LoginName,ClientIP,EnumLoginAccountType,BusinessPermissionString,CreateTime")] LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginInfo);
        }

        // GET: LoginInfo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            if (loginInfo == null)
            {
                return HttpNotFound();
            }
            return View(loginInfo);
        }

        // POST: LoginInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            LoginInfo loginInfo = db.LoginInfoes.Find(id);
            db.LoginInfoes.Remove(loginInfo);
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
