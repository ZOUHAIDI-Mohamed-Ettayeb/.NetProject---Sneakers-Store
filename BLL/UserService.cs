using DAL.Repos;
using Models.Auth; 


namespace BLL
{
	public class UserService
	{
		public UserSession? VerifierCompte(UserAuthModel obj)
		{
			UserRepos utilisateurRepos = new UserRepos();
			var result = utilisateurRepos.All()
						.Where(a => a.MotPasse == obj.Password && a.Compte == obj.Account)
						.FirstOrDefault();
			if (result != null)
			{
				UserSession userSession = new UserSession();
				userSession.AdresseMail = result.Compte;
				userSession.Id = result.Id;
				userSession.Nom = result.Name;
				return userSession;
			}
			return null;
		}


	}

	
}
