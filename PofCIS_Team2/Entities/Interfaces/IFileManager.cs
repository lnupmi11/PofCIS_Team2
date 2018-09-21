namespace PofCIS_Team2.Entities.Interfaces
{
	public interface IFileManager
	{
		string ReadData(string filename);
		void OutputDataToFile();
	}
}