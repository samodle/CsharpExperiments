using Xamarin.Auth;
using System.Linq;

namespace Diary.Shared
{
	public class AccountManager
	{
		const string serviceID 	= "Diary";
		const string pwKey = "password";
		const string kmKey = "keymaterial";
		const string saltKey = "salt";

 		public bool CreateAndSaveAccount (string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				return false;

            AccountStore store = AccountStore.Create();
            if (GetAccountFromStore(store, username) != null)
                return false;

            Account account = new Account(username);
            account.Properties.Add(pwKey, password);

            store.Save(account, serviceID);

			return true;
		}




        public bool LoginToAccount (string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				return false;

            Account account = GetAccount(username);
              return account != null && account.Properties[pwKey] == password;
		}



        public Account GetAccount (string username)
		{
			return GetAccountFromStore (AccountStore.Create (), username);
		}

		Account GetAccountFromStore (AccountStore store, string username)
		{
            if (store == null || username == null)
                return null;

            var accounts = store.FindAccountsForService(serviceID);
            return accounts.FirstOrDefault(a => a.Username == username);
        }
	}
}