#region Copyright © 2021 Vert Magazine Store.
// Proprietary and Confidential
// 
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of Vert Magazine Store.
#endregion

#region Using Directives


#endregion

using System.Threading.Tasks;

namespace MagazineStoreClientApp.Services.Interfaces
{
	internal interface IAuthenticationService
	{
		Task<string> GetToken();
	}
}
