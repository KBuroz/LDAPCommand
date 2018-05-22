using System.Collections.Generic;

namespace System.DirectoryServices.LDAPClient
{
    public class LDAPCommand : ILDAPCommand
    {
		public List<LDAPParameter> Parameters { get; set; }
		
		public override string ToString()
		{
			List<string> strParameters = new List<string>();

			foreach(var param in Parameters)
				strParameters.Add(param.ToString());

			return string.Join(",", strParameters);
		}
	}
}
