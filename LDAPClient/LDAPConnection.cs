using System;
using System.Collections.Generic;
using System.Text;

namespace System.DirectoryServices.LDAPClient
{
    public class LDAPConnection : IDisposable
    {
        private void _LDAPConnection(Uri uri, string username = null, string password = null, AuthenticationTypes? authenticationType = null)
        {
            Username = username;
            Password = password;
            if(authenticationType != null)
                AuthenticationType = (AuthenticationTypes)authenticationType;
        }
        public LDAPConnection(Uri uri, string username = null, string password = null, AuthenticationTypes? authenticationType = null)
        {
            _LDAPConnection(uri, username, password, authenticationType);
        }
        public LDAPConnection(string url, string username = null, string password = null, AuthenticationTypes? authenticationType = null)
        {
            var uri = new Uri(url);
            _LDAPConnection(uri, username, password, authenticationType);
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public Uri Uri { get; set; }

        public AuthenticationTypes AuthenticationType { get; set; }

        DirectoryEntry de;

        private void Init()
        {
            de = new DirectoryEntry();
            
            de.Username = Username;
            de.Password = Password;
            de.Path = Uri.AbsoluteUri.Replace("ldap://", "LDAP://");
            de.AuthenticationType = AuthenticationType;
        }
        public void Dispose()
        {
            de.Dispose();
        }

        /// <summary>
        /// Get the underlying DirectoryEntry object
        /// </summary>
        /// <returns></returns>
        public DirectoryEntry GetDirectoryEntry()
        {
            return de;
        }
    }
}
