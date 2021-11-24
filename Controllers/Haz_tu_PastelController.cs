using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using pasteleria_dd.Models;

namespace pasteleria_dd.Controllers
{
    public class Haz_tu_PastelController : Controller
    {
        private STNBEntities db = new STNBEntities();
        // GET: Haz_tu_Pastel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Tamanio,Sabor,Relleno,Foto,nombre,telefono,Datos_extra,correo_electronico")] Pedido pedido, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string imageName = System.IO.Path.GetFileName(file.FileName);
                    string PhysicalPath = Server.MapPath("~/Content/img/Pictograma/" + imageName);
                    file.SaveAs(PhysicalPath);
                    pedido.Foto = imageName;
                }

                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }
    }
}