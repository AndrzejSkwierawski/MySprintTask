using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace JobApplication
{
	class CsvFile
	{
		private int qty;

		public string Path { get; set; }
		public bool Managed { get; set; }

		public List<LineValue> Values = new List<LineValue>();
		public List<int> yearsList = new List<int>();
		public List<string> categoriesList = new List<string>();

		public CsvFile(string path)
		{
			this.Path = path;
			this.Managed = false;
			this.qty = 0;
		}

	}

	class LineValue
	{
		public int Year { get; set; }
		public string Category { get; set; }
		public int Qty { get; set; }

		public LineValue(int year, string cat, int qty)
		{
			this.Year = year;
			this.Category = cat;
			this.Qty = qty;
		}
	}

	class FileMenager
	{
		public Thread Thread { get; set; }
		public List<CsvFile> FileList = new List<CsvFile>();

		public long Qty { get; set; }
		public Dictionary<int, int> yearsList = new Dictionary<int, int>();
		public Dictionary<string, int> categoriesList = new Dictionary<string, int>();
		public List<LineValue> Values = new List<LineValue>();

		public FileMenager(Thread thread, List<CsvFile> list)
		{
			this.Thread = thread;
			this.FileList = list;
		}

		public void Start()
		{
			this.Thread.Start();
		}

		public List<LineValue> TValues { get { return Values; } }
		public Dictionary<string, int> TcategoriesList { get { return categoriesList; } }
		public Dictionary<int, int> TyearsList { get { return yearsList; } }

	}
}
