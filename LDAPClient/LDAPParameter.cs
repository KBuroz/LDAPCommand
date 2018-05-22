namespace System.DirectoryServices
{
    public class LDAPParameter
	{
		public LDAPParameter() { }
		public LDAPParameter(string name, string value)
		{
			Name = name;
			Value = value;
		}

		private string m_Name { get; set; }
		public string Name
		{ 
			get
			{
				return m_Name;
			}
			set
			{
				// replace these values for security reasons
				m_Name = value
					.Replace(@",", @"\,")
					.Replace(@"\", @"\\")
					.Replace(@"#", @"\#")
					.Replace(@"+", @"\+")
					.Replace(@"<", @"\<")
					.Replace(@">", @"\>")
					.Replace(@";", @"\;")
					.Replace("\"", "\\\"")
					.Replace(@"=", @"\=")
					.Trim();
			}
		}

		private string m_Value;
		public string Value 
		{ 
			get
			{
				return m_Value;
			}
			set
			{
				// replace these values for security reasons
				m_Value = value
					.Replace(@",", @"\,")
					.Replace(@"\", @"\\")
					.Replace(@"#", @"\#")
					.Replace(@"+", @"\+")
					.Replace(@"<", @"\<")
					.Replace(@">", @"\>")
					.Replace(@";", @"\;")
					.Replace("\"", "\\\"")
					.Replace(@"=", @"\=")
					.Trim();
			}
		}

		public override string ToString()
		{
			return Name + "=" + Value;
		}
	}
}
