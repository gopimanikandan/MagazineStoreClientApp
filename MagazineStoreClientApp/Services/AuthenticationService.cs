#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives

using MagazineStoreClientApp.Helper;
using MagazineStoreClientApp.Model.Response;
using MagazineStoreClientApp.Services.Interfaces;
using System.Configuration;
using System.Threading.Tasks;

#endregion

namespace MagazineStoreClientApp.Services
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly WebApiClient client;

		/// <summary>
		/// Default constructor
		/// </summary>
		internal AuthenticationService()
		{
			var apiEndPoint = ConfigurationManager.AppSettings.Get("ApiEndPoint");

			client = new WebApiClient(apiEndPoint);
		}

		/// <summary>
		/// Get the token
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetToken()
		{
			var response = await client.GetAsync<MagazineStoreResponse>(ApiAction.Token);
			return response.Token;
		}
	}
}
