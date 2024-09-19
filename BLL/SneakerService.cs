using DAL.Entity;
using DAL.Repos;
using Models.Sneaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class SneakerService
	{
		

		public List<Models.Sneaker.AdminSneakerListVM> ListProduit()
		{
			var list = new List<Models.Sneaker.AdminSneakerListVM>();
			SneakerRepos repos = new SneakerRepos();


			foreach (var item in repos.All())
			{
				AdminSneakerListVM obj = new AdminSneakerListVM()
				{ Id = item.Id, Name = item.Name, Price = item.Price, Brand = item.Brand, Description=item.Description , EstDispo =item.EstDispo  };
				list.Add(obj);
			}

			return list;
		}



		public SneakerDetailVM Detail(int id)
		{
			var source = new SneakerRepos();
			var objSource = source.Read(id);


			SneakerDetailVM obj = new SneakerDetailVM();

			obj.Id = objSource.Id;
			obj.Description = objSource.Description;
			obj.Price = objSource.Price;
			obj.Brand = objSource.Brand;
			obj.Name = objSource.Name;
			obj.EstDispo = objSource.EstDispo;


			return obj;
		}

		public void Create(AdminSneakerAddVM obj)
		{
			var source = new SneakerRepos();
			Sneaker produit = new Sneaker();
			produit.Price = obj.Price;
			produit.Description = obj.Description;
			produit.Brand = obj.Brand;
			produit.Name = obj.Name;
			produit.EstDispo = obj.EstDisp;
			source.Create(produit);
		}
	}
}
