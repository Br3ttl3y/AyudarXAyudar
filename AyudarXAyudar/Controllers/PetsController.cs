using AyudarXAyudar.App_Code;
using AyudarXAyudar.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AyudarXAyudar.Controllers
{
    [Localization]
    public class PetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pets
        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PictureUrl,Description")]
            Pet pet,
            HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid && uploadFile != null)
            {
                // imagefile name needs id before pet has Id
                pet.Id = GetNewPetId();

                // only one image, needs to be unique.
                PetImageManager managePetImages =
                    new PetImageManager(ControllerContext, pet);
                managePetImages.DeleteExistingPetImages();

                string fileName = uploadFile.FileName;

                // unique image named after Id
                string petIdImagePath =
                    managePetImages.GetServerImageFilePath(fileName);
                uploadFile.SaveAs(petIdImagePath);

                // UrlContent uses relative path of model.
                pet.PictureUrl =
                    managePetImages.GetUrlContentFilePath(fileName);

                db.Pets.Add(pet);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }

            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PictureUrl,Description")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private int GetNewPetId()
        {
            int? maxPetId = db.Pets.Max(p => (int?)p.Id);
            return maxPetId ?? 0;
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
