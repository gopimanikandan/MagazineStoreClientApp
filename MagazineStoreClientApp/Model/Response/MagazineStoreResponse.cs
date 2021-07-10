#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives

using System.Collections.Generic;

#endregion



namespace MagazineStoreClientApp.Model.Response
{
	public class MagazineStoreResponse
	{
		public bool Success { get; set; }
		public string Token { get; set; }
		public string Message { get; set; }
	}

	public class CategoriesResponse : MagazineStoreResponse
	{
		public List<string> Data { get; set; }
	}

	public class SubscriberResponse : MagazineStoreResponse
	{
		public List<Subscriber> Data { get; set; }
	}

	public class MagazinesResponse : MagazineStoreResponse
	{
		public List<Magazine> Data { get; set; }
	}

	public class AnswerResponse : MagazineStoreResponse
	{
		public Answer Data { get; set; }
	}



	public class Subscriber
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<int> MagazineIds { get; set; }
	}

	public class Magazine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
	}

	public class Answer
	{
		public string TotalTime { get; set; }
		public string AnswerCorrect { get; set; }
		public List<string> ShouldBe { get; set; }
	}
}
