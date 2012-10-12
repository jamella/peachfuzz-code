﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Peach.Core.Dom;

namespace Peach.Core.Publishers
{
	[Publisher("FilePerIteration", true)]
	[Parameter("FileName", typeof(string), "Name of file to open for reading/writing", true)]
	public class FilePerIterationPublisher : FilePublisher
	{
		protected string fileTemplate;

		public FilePerIterationPublisher(Dictionary<string, Variant> args)
			: base(args)
		{
			fileTemplate = FileName;

			try
			{
				setFileName(0);

				if (FileName == fileTemplate)
					throw new PeachException("Error, FileName \"" + fileTemplate + "\" missing iteration format identifier.");

				FileName = null;
			}
			catch (FormatException)
			{
				throw new PeachException("Error, FileName \"" + fileTemplate + "\" is not a valid format string.");
			}
		}

		protected void setFileName(uint iteration)
		{
			FileName = string.Format(fileTemplate, iteration);
		}

		protected override void OnOpen()
		{
			setFileName(this.Iteration);
			base.OnOpen();
		}
	}
}
