using Xamarin.Auth;

namespace Xamarin.Auth
{
	public static class Auth
	{
		public static void Init()
		{
			OAuthLoginPresenter.PlatformLogin = (authenticator) => {
				var oauthLogin = new PlatformOAuthLoginPresenter ();
				oauthLogin.Login (authenticator);
			};
		}
	}
}