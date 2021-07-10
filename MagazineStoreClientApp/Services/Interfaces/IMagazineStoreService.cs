#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives


#endregion

using MagazineStoreClientApp.Model.Response;
using System.Threading.Tasks;

namespace MagazineStoreClientApp.Services.Interfaces
{
	internal interface IMagazineStoreService
	{
		Task<CategoriesResponse> GetCategories(string token);
		Task<MagazinesResponse> GetMagazinesByCategory(string category, string token);
		Task<SubscriberResponse> GetSubscribers(string token);
		Task<AnswerResponse> SubmitAnswer(MagazineStoreAnswerModel answer, string token);
	}
}
