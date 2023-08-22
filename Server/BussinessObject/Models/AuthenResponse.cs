using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Models
{
	public class AuthenResponse
	{
		private User user;

		public string Token { get; set; }
		

		public AuthenResponse(User user, string token)
		{
			this.user = user;
			Token = token;
		}
	}
	
}
