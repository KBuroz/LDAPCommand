using System.Collections.Generic;

namespace System.DirectoryServices.LDAPClient
{
    public interface ILDAPCommand
    {
        List<LDAPParameter> Parameters { get; set; }
    }
}