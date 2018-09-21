namespace PofCIS_Team2.Entities
{
	public abstract class Contact
	{
		protected Contact(string name)
		{
			Name = name;
		}

		protected Contact()
		{
		}

		public string Name { get; set; }
	}
}