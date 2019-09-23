namespace LoginLibrary.SupportClasses
{
	namespace SupportClasses
	{
		public class SqlServerLoginResult
		{
			public bool Success {get; set;}
			public bool Failed => Success == false;
		    public bool GenericException {get; set;}
			public string Message {get; set;}

			public override string ToString()
			{
				return Message;
			}
		}
	}
}