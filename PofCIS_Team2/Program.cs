using System;
using PofCIS_Team2.Entities;

namespace PofCIS_Team2
{
	public static class Program
	{
		private static void Main(string[] args)
		{
			var ph = new PhoneContact();
            ph.LoadJson("/Users/roman/RiderProjects/PofCIS_Team2/PofCIS_Team2/Data/phoneData.json");
			var sk = new SkypeContact();
			sk.LoadJson("/Users/roman/RiderProjects/PofCIS_Team2/PofCIS_Team2/Data/skypeData.json");
			var ml = new MailContact();
			ml.LoadJson("/Users/roman/RiderProjects/PofCIS_Team2/PofCIS_Team2/Data/mailData.json");
		}
	}
}