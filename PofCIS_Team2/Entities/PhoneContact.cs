using PofCIS_Team2.Entities.Interfaces;

namespace PofCIS_Team2.Entities
{
	public class PhoneContact : Contact, IFileManager
	{
		private string phoneNumber;

		
		public string ReadData(string filename)
		{
			return System.IO.File.ReadAllText(filename);
		}

		public void OutputDataToFile()
		{
			throw new System.NotImplementedException();
		}
	}
}