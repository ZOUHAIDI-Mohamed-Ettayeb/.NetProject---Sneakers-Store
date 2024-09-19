using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	public class SneakerRepos
	{
		public void Create(Sneaker entity)
		{
			MyDbContext mydb = new MyDbContext();
			mydb.Sneakers.Add(entity);
			mydb.SaveChanges();
		}

		public Sneaker Read(int id)
		{
			MyDbContext mydb = new MyDbContext();
			return mydb.Sneakers.Find(id);
		}

		public void Update(Sneaker entity)
		{
			MyDbContext mydb = new MyDbContext();
			mydb.Entry(entity).State = EntityState.Modified;
			mydb.SaveChanges();
		}

		public void Delete(int id)
		{
			MyDbContext mydb = new MyDbContext();
			Sneaker entity = mydb.Sneakers.Find(id);
			mydb.Sneakers.Remove(entity);
			mydb.SaveChanges();
		}
		public List<Sneaker> All()
		{
			MyDbContext mydb = new MyDbContext();
			return mydb.Sneakers.ToList();
		}
	}
}
