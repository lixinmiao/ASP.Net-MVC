using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MFAdminASPNET.Models;
using Framework.Contracts;
using Web;

namespace MFAdminASPNET.Controllers
{
    [Permission(EnumBusinessPermission.Media_Manage)]
    public class MediaController : BaseController
    {

        private MFAdminASPNETDB db = new MFAdminASPNETDB();

        // GET: Media
        public ActionResult Index(MediaRequest request = null)
        {
            request = request ?? new MediaRequest();
            IQueryable<Media> medias = db.Medias;
            if (!string.IsNullOrEmpty(request.MediaName))
                medias = medias.Where(u => u.MediaName.Contains(request.MediaName));
            return View(medias.OrderBy(u => u.Id).ToPagedList(request.PageIndex, request.PageSize));
        }

        // GET: Media/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = db.Medias.Find(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            var model = new Media();
            return View("Edit", model);
        }

        // POST: Media/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create([Bind(Include = "MediaId,MediaName,IsActive")] Media media)
        {
            if (ModelState.IsValid)
            {
                db.Medias.Add(media);
                db.SaveChanges();

                var script = string.Format("<script>{0}; parent.location.reload(1)</script>", string.Empty);
                return this.Content(script);
            }

            return View(media);
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = db.Medias.Find(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View("Edit", media);
        }

        // POST: Media/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var media = this.db.Medias.Find(id);
            if (ModelState.IsValid)
            {

                this.TryUpdateModel<Media>(media);
                db.Entry(media).State = EntityState.Modified;
                this.db.SaveChanges();
                var script = string.Format("<script>{0}; parent.location.reload(1)</script>", string.Empty);
                return this.Content(script);
            }
            return View(media);
        }




        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            foreach (int id in ids)
            {
                Media media = db.Medias.Find(id);
                db.Medias.Remove(media);
                db.SaveChanges();
            }
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
