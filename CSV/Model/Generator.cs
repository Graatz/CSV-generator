using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSV.Model
{
    class Generator
    {
        private Panel columnsPanel;
        private Panel buttonsPanel;
        private Button generateControl;
        private NumericUpDown columnsControl;
        private NumericUpDown recordsControl;
        private OpenFileDialog fileDialog;
        private BackgroundWorker backgroundWorker1;

        private int numberOfColumns;
        public int NumberOfColumns
        {
            get
            {
                return numberOfColumns;
            }
            set
            {
                if (numberOfColumns > value)
                    DeleteColumns(numberOfColumns - value);
                else if (numberOfColumns < value)
                    AddColumns(value - numberOfColumns);

                numberOfColumns = value;
            }
        }

        private int numberOfRecords;
        public int NumberOfRecords
        {
            get
            {
                return numberOfRecords;
            }
            set
            {
                numberOfRecords = value;
            }
        }

        public Generator(Panel columnsPanel, Panel buttonsPanel, NumericUpDown columnsControl, NumericUpDown recordsControl, Button generateControl)
        {
            this.columnsPanel = columnsPanel;
            this.buttonsPanel = buttonsPanel;
            this.columnsControl = columnsControl;
            this.recordsControl = recordsControl;
            this.generateControl = generateControl;

            InitializeWorker();
            InitializeControls();
        }

        public void InitializeWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
        }

        public void InitializeControls()
        {
            columnsControl.ValueChanged += new EventHandler(ColumnsChanged);
            recordsControl.ValueChanged += new EventHandler(RecordsChanged);
            generateControl.Click += new EventHandler(startAsyncButton_Click);

            fileDialog = new OpenFileDialog();
        }

        public void DeleteColumns(int number)
        {
            for (int i = numberOfColumns; i > numberOfColumns - number; i--)
            {
                columnsPanel.Controls.RemoveAt(i - 1);
                buttonsPanel.Controls.RemoveAt(i - 1);
            }
        }

        public void AddColumns(int number)
        {
            for (int i = numberOfColumns; i < numberOfColumns + number; i++)
            {
                TextBox columnText = new TextBox();
                columnText.Enabled = false;
                columnText.Text = "Click the button to set source directory";
                columnText.Width = columnsPanel.Width;
                columnText.Location = new Point(0, 25 * i);
                columnsPanel.Controls.Add(columnText);

                Button button = new Button();
                button.Click += new EventHandler(GetFilePath);
                button.Width = 30;
                button.Height = 20;
                button.Text = "...";
                button.Location = new Point(0, 25 * i);
                buttonsPanel.Controls.Add(button);
            }
        }

        public void RecordsChanged(object sender, EventArgs e)
        {
            if (NumberOfRecords != (int)recordsControl.Value)
                NumberOfRecords = (int)recordsControl.Value;
        }

        public void ColumnsChanged(object sencer, EventArgs e)
        {
            if (NumberOfColumns != (int)columnsControl.Value)
                NumberOfColumns = (int)columnsControl.Value;
        }

        public void GetFilePath(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = buttonsPanel.Controls.IndexOf(button);
            string filePath = null;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.InitialDirectory + fileDialog.FileName;
            }

            columnsPanel.Controls[index].Text = filePath;
        }

        public void SaveFile(string path, StringBuilder text)
        {
            try
            {
                System.IO.File.WriteAllText(path, text.ToString());
                MessageBox.Show("File generated succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<string[]> getData(string[] sourceFiles)
        {
            List<string[]> data = new List<string[]>();


            for (int i = 0; i < NumberOfColumns; i++)
            {
                sourceFiles[i] = @columnsPanel.Controls[i].Text;
                data.Add(System.IO.File.ReadAllLines(sourceFiles[i]));
            }

            return data;
        }

        public void GenerateCSV(object sender, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string path = e.Argument.ToString() + "/data.csv";
            string[] sourceFiles = new string[NumberOfColumns];
            List<string[]> data = getData(sourceFiles);

            Random random = new Random();
            StringBuilder csv = new StringBuilder();

            for (int i = 0; i < NumberOfRecords; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    string colValue = data[j][random.Next(data[j].Length)];

                    if (j == 0 && i > 0)
                        csv.AppendLine();

                    csv.Append(colValue);

                    if (j < NumberOfColumns - 1)
                        csv.Append(",");

                }
            }

            SaveFile(path, csv);
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (backgroundWorker1.IsBusy != true)
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync(folderBrowser.SelectedPath);
                }
            }
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            GenerateCSV(sender, worker, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
