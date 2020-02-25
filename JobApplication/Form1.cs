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
		private string filesPath = @"../../TEMP_CSV_1";
		private short UpdateCycle = 10;
		private int NoT;

		bool finish = false;

		private string path = Directory.GetCurrentDirectory();
		private string[] files;
		private List<CsvFile> fileList = new List<CsvFile>();
		private List<LineValue> Values = new List<LineValue>();

		private List<FileMenager> fileMenager = new List<FileMenager>();

		private long summaryQty = 0;
		private Dictionary<int, int> yearsDict = new Dictionary<int, int>();
		private Dictionary<string, int> categoryDict = new Dictionary<string, int>();

		private List<List<LineValue>> ValuesList = new List<List<LineValue>>();
		private List<Dictionary<int, int>> yearsList = new List<Dictionary<int, int>>();
		private List<Dictionary<string, int>> categoriesList = new List<Dictionary<string, int>>();

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
			this.UpdateCycle = Convert.ToInt16(timerUD.Value);
			Thread thread = new Thread(() => Timer(this.UpdateCycle)); //60
			thread.Start();
			this.path = Path.GetFullPath(Path.Combine(path, filesPath));
			this.files = Directory.GetFiles(this.path);
			setFileList(this.files);
			DevideFilesByTHreads();

			Thread checkFinish = new Thread(() => CheckEnd());
			checkFinish.Start();
		}

		private void CheckEnd()
		{
			Thread.Sleep(this.UpdateCycle * 1000);
			bool end = false;
			while (true)
			{
				foreach (FileMenager thread in this.fileMenager)
				{
					if (!thread.Thread.IsAlive)
					{
						end = true;
						break;
					}
				}
				if (end)
				{
					break;
				}
			}
			this.Invoke(new Action(() => this.finish = true));
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
				int index = i;
				this.fileMenager.Add(new FileMenager(new Thread(() => ParseFile(smallFileList, index)), smallFileList));
				this.fileMenager.ElementAt(i).Start();
			}
		}

		private void ParseFile(List<CsvFile> fileList, int index)
		{
			ValuesList.Add(new List<LineValue>());
			yearsList.Add(new Dictionary<int, int>());
			categoriesList.Add(new Dictionary<string, int>());
			CsvFile currentFile = fileList.Find(x=>x.Managed == false);
			while (null != currentFile)
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
							ValuesList.ElementAt(index).Add(new LineValue(year, category, quality));
						}
						catch(Exception e)
						{
							Console.WriteLine(e.Message);
						}
					}
				}
				GetAllYears(index);
				GetAllCategories(index);

				currentFile = fileList.Find(x => x.Managed == false);
			}
		}

		private void GetAllYears(int index)
		{
			List<LineValue> list =  ValuesList.ElementAt(index);
			foreach (LineValue val in list)
			{
				if (val.Year == 0)
				{
					continue;
				}
				if (!yearsList.ElementAt(index).ContainsKey(val.Year))
				{
					yearsList.ElementAt(index).Add(val.Year, 0);
				}
			}
			foreach(LineValue val in list)
			{
				int size = yearsList.ElementAt(index).Count;
				for (int i = 0; i < size; i++)
				{
					int currKey = yearsList.ElementAt(index).ElementAt(i).Key;
					int currValue;
					yearsList.ElementAt(index).TryGetValue(currKey, out currValue);
					if (val.Year == currKey)
					{
						yearsList.ElementAt(index).Remove(currKey);
						yearsList.ElementAt(index).Add(currKey, val.Qty + currValue);
						break;
					}
				}
			}
		}

		private void GetAllCategories(int index)
		{
			List<LineValue> list = ValuesList.ElementAt(index);
			foreach (LineValue val in list)
			{
				if (val.Category == null)
				{
					continue;
				}
				if (!categoriesList.ElementAt(index).ContainsKey(val.Category))
				{
					categoriesList.ElementAt(index).Add(val.Category, 0);
				}
			}
			foreach (LineValue val in list)
			{
				int size = categoriesList.ElementAt(index).Count;
				for (int i = 0; i < size; i++)
				{
					string currKey = categoriesList.ElementAt(index).ElementAt(i).Key;
					int currValue;
					categoriesList.ElementAt(index).TryGetValue(currKey, out currValue);
					if (val.Category == currKey)
					{
						categoriesList.ElementAt(index).Remove(currKey);
						categoriesList.ElementAt(index).Add(currKey, val.Qty + currValue);
						break;
					}
				}
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
				this.Invoke(new Action(() => this.timeLabel.Text = "Cycle: " + count));
				this.Invoke(new Action(() => summQty()));
				

				if (this.finish)
				{
					this.Invoke(new Action(() => this.timeLabel.Text = $"Finished in {count} cycles"));
					return;
				}
			}
		}

		private void summQty()
		{
			foreach(FileMenager thread in this.fileMenager)
			{
				try
				{
					thread.Thread.Suspend();
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			long sum = 0;
			foreach (List<LineValue> list in ValuesList)
			{
				foreach (LineValue value in list)
				{

					sum += value.Qty;
				}
			}
			this.summaryQty = sum;
			this.Invoke(new Action(() => this.QtyLabel.Text = "Summary Qty: " + this.summaryQty));

			Dictionary<int, int> dctYear = new Dictionary<int, int>();
			foreach (Dictionary<int, int> dict in yearsList)
			{
				foreach(var item in dict)
				{
					var key = item.Key;
					var val = item.Value;
					if (!dctYear.ContainsKey(key))
					{
						dctYear.Add(key, val);
					}
					else
					{
						int currValue;
						dctYear.TryGetValue(key, out currValue);
						dctYear.Remove(key);
						dctYear.Add(key, currValue + val);
					}
				}
			}
			yearsDict = dctYear;

			string output = "Qty by year: \n";
			foreach (var item in yearsDict)
			{
				output += $"{item.Key}: {item.Value} \n";
			}
			this.Invoke(new Action(() => this.QtyYearLabel.Text = output));

			Dictionary<string, int> dctCat = new Dictionary<string, int>();
			foreach (Dictionary<string, int> dict in categoriesList)
			{
				foreach (var item in dict)
				{
					var key = item.Key;
					var val = item.Value;
					if (!dctCat.ContainsKey(key))
					{
						dctCat.Add(key, val);
					}
					else
					{
						int currValue;
						dctCat.TryGetValue(key, out currValue);
						dctCat.Remove(key);
						dctCat.Add(key, currValue + val);
					}
				}
			}
			categoryDict = dctCat;

			output = "Qty by year: \n";
			foreach (var item in categoryDict)
			{
				output += $"{item.Key}: {item.Value} \n";
			}
			this.Invoke(new Action(() => this.QtyCatLabel.Text = output));

			foreach (FileMenager thread in this.fileMenager)
			{
				try
				{
					thread.Thread.Resume();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
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

		private void pathSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.filesPath = "../../" + pathSelector.Text;
		}
	}
}
