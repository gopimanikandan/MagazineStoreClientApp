#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives

using MagazineStoreClientApp.Model.Response;
using MagazineStoreClientApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace MagazineStoreClientApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var task = GetAnswers();
			task.Wait();
		}

		private static async Task GetAnswers()
		{
			try
			{
				var magazineStoreService = new MagazineStoreService();
				var authenticationService = new AuthenticationService();
				var token = await authenticationService.GetToken();

				var categories = await magazineStoreService.GetCategories(token);
				var subscribers = await magazineStoreService.GetSubscribers(token);

				var magazines = new List<Magazine>();
				var tasks = categories.Data.Select(async category =>
				{
					var magazinesResponse = await magazineStoreService.GetMagazinesByCategory(category, token);

					if (magazinesResponse.Success)
						magazines.AddRange(magazinesResponse.Data);
					else
						Console.WriteLine("Error: {0}", magazinesResponse.Message);
				});
				await Task.WhenAll(tasks);

				var response = subscribers.Data.Where(x => magazines.Where(y => x.MagazineIds.Any(z => z.Equals(y.Id)))
				.GroupBy(g => g.Category)
				.Select(g => g.Key)
				.Intersect(categories.Data, StringComparer.OrdinalIgnoreCase).Count() == categories.Data.Count()).Select(x => x.Id).ToList();

				var magazineStoreAnswerModel = new MagazineStoreAnswerModel { Subscribers = response };

				var answerResponse = await magazineStoreService.SubmitAnswer(magazineStoreAnswerModel, token);

				Console.WriteLine("Answer Correct: {0}", answerResponse.Data.AnswerCorrect);
				Console.WriteLine("TotalTime: {0}", answerResponse.Data.TotalTime);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: {0}", ex.Message);
			}
		}
	}
}
