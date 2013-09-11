using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MurmurHash.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var type = Type.GetType(string.Join(" ", args));
				var obj = (HashAlgorithm)Activator.CreateInstance(type);
				
				Console.WriteLine(type.Name);
				Console.WriteLine();

				var random = new Random();
				var val = new byte[1024];
				var count = 10000000;

				random.NextBytes(val);

				var sw = Stopwatch.StartNew();
				for (int i = 0; i < count; i++)
				{
					obj.ComputeHash(val);
				}
				sw.Stop();

				Console.WriteLine("Time: {0:0.00}secs", sw.Elapsed.TotalSeconds);
				Console.WriteLine("Memory: {0}KB", Process.GetCurrentProcess().PrivateMemorySize64 / 1024);

				Console.WriteLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.WriteLine();
			}

			Console.WriteLine("Press any key to continue ....");
			Console.Read();
		}
	}
}
