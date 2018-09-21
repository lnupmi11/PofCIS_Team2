using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PofCIS_Team2.Entities
{
	public class SkypeContact : Contact
	{
		public string SkypeName { get; set; }

		public SkypeContact(string name, string skypeName) : base(name)
		{
			SkypeName = skypeName;
		}

		public SkypeContact(string skypeName)
		{
			SkypeName = skypeName;
		}

		public SkypeContact()
		{
		}


		public void LoadJson(string filename)
		{
			using (var r = new StreamReader(filename))
			{
				var json = r.ReadToEnd();
				var items = JsonConvert.DeserializeObject<List<SkypeContact>>(json);
				foreach (var item in items)
				{
					Console.WriteLine("{0} {1}", item.Name, item.SkypeName);
				}
			}
		}
	}
}