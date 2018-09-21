using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PofCIS_Team2.Entities
{
	public class MailContact : Contact
	{
		public string Mail { get; set; }

		public MailContact(string name, string mail) : base(name)
		{
			Mail = mail;
		}

		public MailContact(string mail)
		{
			Mail = mail;
		}

		public MailContact()
		{
		}

		public void LoadJson(string filename)
		{
			using (var r = new StreamReader(filename))
			{
				var json = r.ReadToEnd();
				var items = JsonConvert.DeserializeObject<List<MailContact>>(json);
				foreach (var item in items)
				{
					Console.WriteLine("{0} {1}", item.Name, item.Mail);
				}
			}
		}
	}
}