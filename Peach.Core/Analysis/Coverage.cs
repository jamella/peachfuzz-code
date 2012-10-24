﻿
//
// Copyright (c) Michael Eddington
//
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in	
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

// Authors:
//   Michael Eddington (mike@dejavusecurity.com)

// $Id$

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Peach.Core;

namespace Peach.Core.Analysis
{
	/// <summary>
	/// Abstract base class for performing code coverage via basic blocks
	/// for native binaries.  Each architecture implements this class.
	/// </summary>
	/// <remarks>
	/// So far only Windows has an implementation.
	/// </remarks>
	public abstract class Coverage : IDisposable
	{
		/// <summary>
		/// Create an instance of this abstract class
		/// </summary>
		/// <returns></returns>
		public static Coverage CreateInstance()
		{
            return new CoverageImpl();
			//return ClassLoader.FindAndCreateByTypeAndName<Coverage>("Peach.Core.Analysis.CoverageImpl");
		}

		/// <summary>
		/// Collect all basic blocks in binary
		/// </summary>
		/// <param name="executable"></param>
		/// <returns></returns>
		public abstract List<ulong> BasicBlocksForExecutable(string executable);

		/// <summary>
		/// Perform code coverage based on collection of basic blocks.  If
		/// not provided they will be generated by calling BasicBlocksForExecutable.
		/// </summary>
		/// <param name="executable"></param>
		/// <param name="arguments"></param>
		/// <param name="basicBlocks"></param>
		/// <returns></returns>
		public abstract List<ulong> CodeCoverageForExecutable(string executable, string arguments, List<ulong> basicBlocks = null);

		public abstract void Dispose();
	}
}
