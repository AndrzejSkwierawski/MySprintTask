using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplication
{
	public partial class Form1 : Form
	{
		private int NoT;
		private string samplePath1 = @"../../TEMP_CSV_1";
		private string samplePath2 = @"../../TEMP_CSV_2";

		private string path = Directory.GetCurrentDirectory();
		private string[] files;
		private List<CsvFile> fileList = new List<CsvFile>();
		private List<LineValue> Values = new List<LineValue>();


		private List<FileMenager> fileMenager = new List<FileMenager>();
		private Dictionary<int, int> yearsList = new Dictionary<int, int>();
		private Dictionary<string, int> categoriesList = new Dictionary<string, int>();

		private long summaryQty = 0;

		public Form1()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			this.StartButton.Enabled = false;
			Start();
		}

		private void Start()
		{
			Thread thread = new Thread(() => Timer(3)); //60
			thread.Start();
			this.path = Path.GetFullPath(Path.Combine(path, samplePath1));
			this.files = Directory.GetFiles(this.path);
			setFileList(this.files);
			DevideFilesByTHreads();

		}

		private void DevideFilesByTHreads()
		{
			this.NoT = Convert.ToInt16(numberOfThreadsUD.Value);
			int numberOfFiles = fileList.Count;
			int forEveryThread = numberOfFiles / this.NoT;
			int modulo = numberOfFiles % this.NoT;
			for (int i = 0; i < this.NoT; i++)
			{
				List<CsvFile> smallFileList;
				if (i == 0)
				{
					smallFileList = fileList.GetRange(i * forEveryThread + modulo, forEveryThread + modulo);
				}
				else
				{
					smallFileList = fileList.GetRange(i * forEveryThread + modulo, forEveryThread);
				}
				List<LineValue> tmpValues = new List<LineValue>();
				fileMenager.Add(new FileMenager(new Thread(() => ParseFile(smallFileList, ref tmpValues)), smallFileList));
				fileMenager.ElementAt(i).Start();

			}
		}

		private void ParseFile(List<CsvFile> fileList, ref List<LineValue> Tvalues)
		{
			CsvFile currentFile = fileList.Find(x=>x.Managed == false); 
			while(null != currentFile)
			{
				if (!currentFile.Managed)
				{
					currentFile.Managed = true;
					string path = currentFile.Path;
					string[] lines = File.ReadAllLines(path);
					foreach(string line in lines)
					{
						if (line == null)
						{
							break;
						}
						try
						{
							char[] separator = { ';', '\n' };
							string[] values = line.Split(separator);
							string time = values[0];
							string category = values[1];
							string qty = values[3];
							int year = GetTime(time);
							int quality = GetQty(qty);
							category = GetCategory(category);
							Tvalues.Add(new LineValue(year, category, quality));
						}
						catch(Exception e)
						{
							Console.WriteLine(e.Message);
						}
					}
				}
				currentFile = fileList.Find(x => x.Managed == false);
			}
		}

		private int GetTime(string time)
		{
			if (time != "TM")
			{
				try
				{
					DateTime timeTmp = DateTime.Parse(time);
					return timeTmp.Year;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message + time);
					try
					{
						DateTime timeTmp = DateTime.ParseExact(time, "MM-dd-yyyy hh:mm tt", null);
						return timeTmp.Year;
					}
					catch
					{
						Console.WriteLine(e.Message + time + "Unable to parse");
					}
				}

			}
			return 0;
		}

		private string GetCategory(string category)
		{
			if (category != "Category")
			{
				return category;
			}
			return null;
		}

		private int GetQty(string qty)
		{
			int qtyTmp;
			if (int.TryParse(qty, out qtyTmp))
			{
				return qtyTmp;
			}
			return 0;
		}

		private void Timer(int seconds)
		{
			int count = 0;
			while (true)
			{
				count++;
				System.Threading.Thread.Sleep(seconds * 1000);
				this.Invoke(new Action(() => this.timeLabel.Text = count.ToString()));
				//this.Invoke(new Action(() => this.summaryQtyLabel.Text = "summaryQty: " + this.summaryQty.ToString()));
				//this.Invoke(new Action(() => WriteQtyByYear()));
				//this.Invoke(new Action(() => WriteQtyByCategory()));
			}
		}

		private void setFileList(string[] list)
		{
			this.fileList.Clear();
			foreach (string file in list)
			{
				this.fileList.Add(new CsvFile(file));
			}
		}
	}
}
