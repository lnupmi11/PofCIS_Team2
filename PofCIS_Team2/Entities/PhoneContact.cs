using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.Entities
{
	public class PhoneContact : Contact, IFileManager
	{
		public string PhoneNumber { get; set; }


		public PhoneContact(string name, string phoneNumber) : base(name)
		{
			PhoneNumber = phoneNumber;
		}

		public PhoneContact(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}

		public PhoneContact()
		{
		}

		public void LoadJson(string filename)
		{
			using (var r = new StreamReader(filename))
			{
				var json = r.ReadToEnd();
				var items = JsonConvert.DeserializeObject<List<PhoneContact>>(json);
				foreach (var item in items)
				{
					Console.WriteLine("{0} {1}", item.Name, item.PhoneNumber);
				}
			}
		}
	}
}