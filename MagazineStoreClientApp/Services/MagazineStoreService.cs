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
using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;

#endregion

namespace MagazineStoreClientApp.Services
{
	internal class MagazineStoreService : IMagazineStoreService
	{
		private readonly WebApiClient client;

		/// <summary>
		/// Default constructor
		/// </summary>
		public MagazineStoreService()
		{
			var apiEndPoint = ConfigurationManager.AppSettings.Get("ApiEndPoint");

			client = new WebApiClient(apiEndPoint);
		}

		/// <summary>
		/// Get the categories
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<CategoriesResponse> GetCategories(string token)
		{
			var resource = $"{ApiAction.Categories}/{token}";

			var response = await client.GetAsync<CategoriesResponse>(resource);

			return response;
		}

		/// <summary>
		/// Get Magazines for the category
		/// </summary>
		/// <param name="category"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<MagazinesResponse> GetMagazinesByCategory(string category, string token)
		{
			var resource = $"{ApiAction.Magazines}/{token}/{category}";

			var response = await client.GetAsync<MagazinesResponse>(resource);

			return response;
		}

		/// <summary>
		/// Get the subscribers
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<SubscriberResponse> GetSubscribers(string token)
		{
			var resource = $"{ApiAction.Subscribers}/{token}";

			var response = await client.GetAsync<SubscriberResponse>(resource);

			return response;
		}


		/// <summary>
		/// Submit the answer
		/// </summary>
		/// <param name="answer"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<AnswerResponse> SubmitAnswer(MagazineStoreAnswerModel answer, string token)
		{
			var resource = $"{ApiAction.Answer}/{token}";

			var response = await client.PostAsync<AnswerResponse>(JsonConvert.SerializeObject(answer), resource);

			return response;
		}
	}

}
