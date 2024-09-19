using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Sneaker;
using DAL;
using Microsoft.AspNetCore.DataProtection.Repositories;
using DAL.Repos;
using DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace Admin.Controllers
{
   
    [Authorize]
    public class SneakerController : Controller
	{
        private readonly SneakerRepos _sneakerRepos;
        public SneakerController()
        {
            _sneakerRepos = new SneakerRepos();
        }


        public ActionResult Dashboard()
        {
            SneakerService service = new SneakerService();

            return View(service.ListProduit());
        }




        // GET: ProduitController
        public ActionResult Index()
		{
			SneakerService service = new SneakerService();

			return View(service.ListProduit());
		}



		// GET: ProduitController/Details/5
		public ActionResult Details(int id)
		{
            Sneaker sneaker = _sneakerRepos.Read(id);

            if (sneaker == null)
            {
                return NotFound(); // Or handle the case when the sneaker is not found
            }

            return View(sneaker);
        }




		// GET: ProduitController/Create
		public ActionResult Create()
		{
			ViewData["Title"] = "Création Produit";
			return View();
		}

		// POST: ProduitController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AdminSneakerAddVM model)
		{

			if (ModelState.IsValid)
			{

				try
				{
					SneakerService service = new SneakerService();
					service.Create(model);
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View();
				}


			}
			return RedirectToAction(nameof(Create));

		}




        // GET: SneakerController/Edit/5
        public ActionResult Edit(int id)
        {
            Sneaker sneaker = _sneakerRepos.Read(id);

            if (sneaker == null)
            {
                return NotFound(); // Ou gérer le cas où le sneaker n'est pas trouvé
            }

            var editViewModel = new AdminSneakerEditVM
            {
               
                Name = sneaker.Name,
                Description = sneaker.Description,
                Brand = sneaker.Brand,
                Price = sneaker.Price,
                EstDispo = sneaker.EstDispo
            };

            return View(editViewModel);
        }

        // POST: SneakerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminSneakerEditVM model)
        {
            if (id != model.Id)
            {
                return BadRequest(); // Ou gérer le cas où l'ID ne correspond pas
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSneaker = _sneakerRepos.Read(id);

                    if (existingSneaker == null)
                    {
                        return NotFound(); // Ou gérer le cas où le sneaker n'est pas trouvé
                    }

                    // Mettre à jour les valeurs du sneaker avec celles du modèle édité
                    existingSneaker.Name = model.Name;
                    existingSneaker.Description = model.Description;
                    existingSneaker.Brand = model.Brand;
                    existingSneaker.Price = model.Price;
                    existingSneaker.EstDispo = model.EstDispo;

                    _sneakerRepos.Update(existingSneaker);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }





        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
		{
			Sneaker sneaker = _sneakerRepos.Read(id);

			if (sneaker == null)
			{
				return NotFound(); // Or handle the case when the sneaker is not found
			}

			// Si vous ne souhaitez pas afficher une vue de confirmation de suppression,
			// vous pouvez effectuer la suppression directement ici et rediriger ensuite vers la vue Index.
			_sneakerRepos.Delete(id);

			return RedirectToAction(nameof(Index));
		}
	}
}

