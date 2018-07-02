using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.LDAPClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAPClient.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            string password;
            try
            {
                if (string.IsNullOrWhiteSpace(args[0]) == false || string.IsNullOrWhiteSpace(args[1]) == false)
                {
                    username = args[0];
                    password = args[1];
                }
                else
                    throw new Exception();

                using (var ldapConn = new LDAPConnection("LDAP://ldap.forumsys.com", username, password, AuthenticationTypes.Anonymous))
                using(var ldapCMD = new LDAPCommand(ldapConn))
                {
                    ldapCMD.Parameters.Add(new LDAPParameter("uid", "einstein"));
                    ldapCMD.Parameters.Add(new LDAPParameter("dc", "example"));
                    ldapCMD.Parameters.Add(new LDAPParameter("dc", "com"));

                    var sr = ldapCMD.FindOne();

                }
            }
            catch (Exception)
            {
                Help();
                return;
            }
        }

        static void Help()
        {
            Console.WriteLine("Please provide a username and password, example:");
            Console.WriteLine("LDAPClient <username> <password>");
        }
    }
}
