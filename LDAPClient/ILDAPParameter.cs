namespace System.DirectoryServices.LDAPClient
{
    public interface ILDAPParameter
    {
        string Name { get; set; }
        string Value { get; set; }
    }
}