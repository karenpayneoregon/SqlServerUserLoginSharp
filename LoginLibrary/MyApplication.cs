namespace LoginLibrary.My
{
	internal sealed class MyApplication : Microsoft.VisualBasic.ApplicationServices.ApplicationBase
	{
		private static readonly MyApplication instance = new MyApplication();

		static MyApplication()
		{
		}

		[System.Diagnostics.DebuggerStepThroughAttribute()]
		private MyApplication() : base()
		{
		}

		public static MyApplication Application => instance;
	}
}