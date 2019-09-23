//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace LoginLibrary
{
	namespace SupportClasses
	{
		public class SqlServerLoginResult
		{
			public bool Success {get; set;}
			public bool Failed
			{
				get
				{
					return Success == false;
				}
			}
			public bool GenericException {get; set;}
			public string Message {get; set;}

			public override string ToString()
			{
				return Message;
			}
		}
	}
}