#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives

using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace MagazineStoreClientApp.Helper
{
	public class WebApiClient
	{
		private readonly string _endpoint;

		/// <summary>
		/// Initializes a new instance of the <see cref="WebApiClient"/> class.
		/// </summary>
		/// <param name="endpoint">The endpoint.</param>
		/// <returns></returns>
		public WebApiClient(string endpoint)
		{
			_endpoint = endpoint;
		}

		/// <summary>
		/// Get the data from the API
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="resource"></param>
		/// <returns></returns>
		public async Task<T> GetAsync<T>(string resource)
		{
			using (var httpClient = new HttpClient())
			{
				var endpoint = $"{_endpoint}/{resource}";

				var response = await httpClient.GetAsync(endpoint);

				var apiResponse = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

				return apiResponse;
			}
		}

		/// <summary>
		/// Posts the specified resource.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public async Task<T> PostAsync<T>(string data, string resource)
		{
			using (var httpClient = new HttpClient())
			{
				var content = GetHttpContent(data);

				var endpoint = $"{_endpoint}/{resource}";

				var response = await httpClient.PostAsync(endpoint, content);

				var apiResponse = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

				return apiResponse;
			}
		}

		/// <summary>
		/// Get the Http content
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <param name="dateFormatHandling"></param>
		/// <param name="dateTimeZoneHandling"></param>
		/// <returns></returns>
		protected HttpContent GetHttpContent<T>(T data, DateFormatHandling dateFormatHandling = DateFormatHandling.IsoDateFormat, DateTimeZoneHandling dateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind)
		{
			if (data is string)
				return new StringContent(data.ToString(), Encoding.UTF8, "application/json");
			// Else serialize
			return new StringContent(JsonConvert.SerializeObject(data, new JsonSerializerSettings { DateFormatHandling = dateFormatHandling, DateTimeZoneHandling = dateTimeZoneHandling }), Encoding.UTF8, "application/json");
		}
	}
}
