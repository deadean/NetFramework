using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public sealed class OperationTimer:IDisposable
	{
		private System.Diagnostics.Stopwatch _start;
		private String _text;
		private Int32 _collectionCount;

		public OperationTimer(String text)
		{
			PrepareForOperation();

			_text = text;
			_collectionCount = GC.CollectionCount(0);

			_start = System.Diagnostics.Stopwatch.StartNew();
		}

		public void Dispose()
		{
			Console.WriteLine("{0} (GCs={1},{2}) {3}", _start.Elapsed, GC.CollectionCount(0), _collectionCount, _text);
		}

		private static void PrepareForOperation()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}
	}
}
