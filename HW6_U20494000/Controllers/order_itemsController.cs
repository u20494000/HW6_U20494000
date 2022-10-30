using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW6_U20494000.Models;
using PagedList;

namespace HW6_U20494000.Controllers
{
    public class order_itemsController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        // GET: order_items
        public ActionResult Index()
        {
            var order_items = db.order_items.Include(o => o.product).Include(o => o.order).OrderBy(o => o.order_id);
            var orderGroup = db.order_items.Include(o => o.product).Include(o => o.order).GroupBy(o => o.order_id);
           // return View(await order_items.ToListAsync());
            List<order_items> Details = (from x in db.orders.ToList()
                                         join z in db.order_items.ToList() on x.order_id equals z.order_id
                                         join y in db.products.ToList() on z.product_id equals y.product_id
                                         select new order_items
                                         {
                                             order_id = x.order_id,
                                             product_name = y.product_name,
                                             date = x.order_date,
                                             list_price = z.list_price,
                                             quantity = z.quantity,
                                             Total = z.list_price * z.quantity,
                                             grandTotal = db.order_items.GroupBy(x => x.order_id).FirstOrDefault().Sum(x => x.quantity * x.list_price)

                                         }).OrderBy(x => x.order_id).ToList();
            Console.WriteLine(Details);
            return View(Details);
        }

        // GET: order_items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = await db.order_items.FindAsync(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        
        // GET: order_items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_items order_items = await db.order_items.FindAsync(id);
            if (order_items == null)
            {
                return HttpNotFound();
            }
            return View(order_items);
        }

        // POST: order_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            order_items order_items = await db.order_items.FindAsync(id);
            db.order_items.Remove(order_items);
            await db.SaveChangesAsync();
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
