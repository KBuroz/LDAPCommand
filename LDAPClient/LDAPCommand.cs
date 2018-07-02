using System.Collections.Generic;

namespace System.DirectoryServices.LDAPClient
{
    public class LDAPCommand : ILDAPCommand, IDisposable
    {
        DirectorySearcher ds;

        public LDAPCommand(LDAPConnection connection)
        {
            Connection = connection;
        }
        public LDAPCommand()
        {
        }

        LDAPConnection Connection { get; set; }
        public List<LDAPParameter> Parameters { get; set; }

        public override string ToString()
		{
			List<string> strParameters = new List<string>();

			foreach(var param in Parameters)
				strParameters.Add(param.ToString());

			return string.Join(",", strParameters);
		}

        public SearchResultCollection FindAll()
        {
            return ds.FindAll();
        }
        public SearchResult FindOne()
        {
            return ds.FindOne();
        }

        /// <summary>
        /// Get the underlying DirectorySearcher object
        /// </summary>
        /// <returns></returns>
        public DirectorySearcher GetDirectorySearcher()
        {
            return ds;
        }
        public void Dispose()
        {
             ds.Dispose();
        }
	}
}
