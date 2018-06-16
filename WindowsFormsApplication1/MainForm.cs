using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {


        //initialize the space for our dictionary data
        DictionaryData DictData = new DictionaryData();



        //this is what runs at initialization
        public Form1()
        {

            InitializeComponent();

            foreach(var encoding in Encoding.GetEncodings())
            {
                EncodingDropdown.Items.Add(encoding.Name);
            }

            try
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact("utf-8");
            }
            catch
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(Encoding.Default.BodyName);
            }
            


        }







        private void StartButton_Click(object sender, EventArgs e)
        {


                    //make sure that our dictionary is loaded before anything else
                    if (DictData.RegExListLoaded != true)
                    {
                        MessageBox.Show("You must first load a RegEx list before you can process your texts.", "RegEx list not loaded!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            

                    FolderBrowser.Description = "Please choose the location of your .txt files to analyze";
                    if (FolderBrowser.ShowDialog() != DialogResult.Cancel) {

                        DictData.TextFileFolder = FolderBrowser.SelectedPath.ToString();
                
                        if (DictData.TextFileFolder != "")
                        {

                            saveOutputDialog.Description = "Please choose a folder for your output files";
                            saveOutputDialog.SelectedPath = DictData.TextFileFolder;
                            if (saveOutputDialog.ShowDialog() != DialogResult.Cancel) {


                                if (FolderBrowser.SelectedPath == saveOutputDialog.SelectedPath)
                                {
                                    MessageBox.Show("You can not use the same folder for text input and text output. If you do this, your original data would be overwritten. Please use a different folder for your output location.", "Folder selection error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                DictData.OutputFileLocation = saveOutputDialog.SelectedPath;
                                DictData.CompactWhitespace = CompactWhitespaceCheckbox.Checked;

                                if (DictData.OutputFileLocation != "") {



                                    StartButton.Enabled = false;
                                    CaseSensitiveCheckbox.Enabled = false;
                                    ScanSubfolderCheckbox.Enabled = false;
                                    EncodingDropdown.Enabled = false;
                                    LoadDictionaryButton.Enabled = false;
                                    CompactWhitespaceCheckbox.Enabled = false;
                            
                                    BgWorker.RunWorkerAsync(DictData);
                                }
                            }
                        }

                    }

                

        }

        




        private void BgWorkerClean_DoWork(object sender, DoWorkEventArgs e)
        {


            DictionaryData DictData = (DictionaryData)e.Argument;
            DictData.NumberOfMatches = new uint[DictData.RegexArray.Length];
            DictData.TotalFilesMatched = new uint[DictData.RegexArray.Length];

            for(int i = 0; i < DictData.NumberOfMatches.Length; i++)
            {
                DictData.NumberOfMatches[i] = 0;
                DictData.TotalFilesMatched[i] = 0;
            }


            //selects the text encoding based on user selection
            Encoding SelectedEncoding = null;
            this.Invoke((MethodInvoker)delegate ()
            {
                SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());
            });

            

            //get the list of files
            var SearchDepth = SearchOption.TopDirectoryOnly;
            if (ScanSubfolderCheckbox.Checked)
            {
                SearchDepth = SearchOption.AllDirectories;
            }
            var files = Directory.EnumerateFiles(DictData.TextFileFolder, "*.txt", SearchDepth);



            try {

               
                    foreach (string fileName in files)
                    {

                        //set up our variables to report
                        string Filename_Clean = Path.GetFileName(fileName);

                        string SubDirStructure = Path.GetDirectoryName(fileName).Replace(DictData.TextFileFolder, "").TrimStart('\\');


                        //creates subdirs if they don't exist
                        


                        string Output_Location = DictData.OutputFileLocation + '\\' + SubDirStructure;

                        if (!Directory.Exists(Output_Location))
                        {
                            Directory.CreateDirectory(Output_Location);
                        }

                        Output_Location = Path.Combine(Output_Location, Path.GetFileName(fileName));

                    //report what we're working on
                    FilenameLabel.Invoke((MethodInvoker)delegate
                        {
                            FilenameLabel.Text = "Processing: " + Filename_Clean;
                        });




                        //read in the text file, convert everything to lowercase
                        string readText = File.ReadAllText(fileName, SelectedEncoding);

                        if (DictData.CompactWhitespace) readText = Regex.Replace(readText, @"\s+", " ");


                        //     _                _                 _____         _   
                        //    / \   _ __   __ _| |_   _ _______  |_   _|____  _| |_ 
                        //   / _ \ | '_ \ / _` | | | | |_  / _ \   | |/ _ \ \/ / __|
                        //  / ___ \| | | | (_| | | |_| |/ /  __/   | |  __/>  <| |_ 
                        // /_/   \_\_| |_|\__,_|_|\__, /___\___|   |_|\___/_/\_\\__|
                        //                        |___/                             

                        for (int i = 0; i < DictData.RegexArray.Length; i++)
                        {

                            int NumMatches = DictData.RegexArray[i].Matches(readText).Count;

                            if (NumMatches == 0) continue;

                            DictData.NumberOfMatches[i] += (uint)NumMatches;
                            DictData.TotalFilesMatched[i] += 1;

                            readText = DictData.RegexArray[i].Replace(readText, DictData.ReplacementArray[i]);

                        }





                    // __        __    _ _          ___        _               _   
                    // \ \      / / __(_) |_ ___   / _ \ _   _| |_ _ __  _   _| |_ 
                    //  \ \ /\ / / '__| | __/ _ \ | | | | | | | __| '_ \| | | | __|
                    //   \ V  V /| |  | | ||  __/ | |_| | |_| | |_| |_) | |_| | |_ 
                    //    \_/\_/ |_|  |_|\__\___|  \___/ \__,_|\__| .__/ \__,_|\__|
                    //                                            |_|              

                    //open up the output file
                    using (StreamWriter outputFile = new StreamWriter(new FileStream(Output_Location, FileMode.Create), SelectedEncoding))
                    {
                        outputFile.Write(readText);
                    }


                }


                using (StreamWriter outputFile = new StreamWriter(new FileStream(Path.Combine(DictData.OutputFileLocation, "__TextEmend-Report.csv"), FileMode.Create), SelectedEncoding))
                {
                    outputFile.WriteLine("\"RegEx\",\"Replacement\",\"NumberOfMatches\",\"FilesWithPattern\"");

                    for (int i = 0; i < DictData.RegexArray.Length; i++)
                    {
                        outputFile.WriteLine("\"" + DictData.RegexArray[i].ToString() + "\"," +
                                             "\"" + DictData.ReplacementArray[i] + "\"," + 
                                             DictData.NumberOfMatches[i].ToString() + "," + 
                                             DictData.TotalFilesMatched[i].ToString());
                    }

                    

                }



            }
            catch
            {
                MessageBox.Show("TextEmend encountered an issue somewhere while trying to analyze your texts. The most common cause of this is trying to open your output file(s) while the program is still running. Did any of your input files move, or is your output file being opened/modified by another application? Are you sure that your regular expressions are properly formed?", "Error while analyzing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }


        //when the bgworker is done running, we want to re-enable user controls and let them know that it's finished
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartButton.Enabled = true;
            ScanSubfolderCheckbox.Enabled = true;
            EncodingDropdown.Enabled = true;
            LoadDictionaryButton.Enabled = true;
            CaseSensitiveCheckbox.Enabled = true;
            CompactWhitespaceCheckbox.Enabled = true;
            FilenameLabel.Text = "Finished!";
            MessageBox.Show("TextEmend has finished processing your texts.", "Analysis Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }







        public class DictionaryData
        {

            public string TextFileFolder { get; set; }
            public string OutputFileLocation { get; set; }


            public Regex[] RegexArray { get; set; }
            public string[] ReplacementArray { get; set; }

            public uint[] NumberOfMatches { get; set; }
            public uint[] TotalFilesMatched { get; set; }

            public bool RegExListLoaded { get; set; } = false;
            public bool CompactWhitespace { get; set; }


        }













        private void LoadDictionaryButton_Click(object sender, EventArgs e)
        {


            
            DictData = new DictionaryData();


           //   ____                _   _____         _     _____                        ____ ___ ____   _____ _ _      
           //  |  _ \ ___  __ _  __| | |_   _|____  _| |_  |  ___| __ ___  _ __ ___     |  _ \_ _/ ___| |  ___(_) | ___ 
           //  | |_) / _ \/ _` |/ _` |   | |/ _ \ \/ / __| | |_ | '__/ _ \| '_ ` _ \    | | | | | |     | |_  | | |/ _ \
           //  |  _ <  __/ (_| | (_| |   | |  __/>  <| |_  |  _|| | | (_) | | | | | |  _| |_| | | |___  |  _| | | |  __/
           //  |_| \_\___|\__,_|\__,_|   |_|\___/_/\_\\__| |_|  |_|  \___/|_| |_| |_| (_)____/___\____| |_|   |_|_|\___|
                                                                                                          



            string RegexListFileRawText = "";

            openFileDialog.Title = "Please choose your TextEmend RegEx List file";

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {

                FolderBrowser.SelectedPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

                //Load dictionary file now
                try
                {


                    Encoding SelectedEncoding = null;
                    SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());

                    RegexListFileRawText = File.ReadAllText(openFileDialog.FileName, SelectedEncoding);
                }
                catch
                {
                    MessageBox.Show("TextEmend is having trouble reading data from your RegEx list file. Is it open in another application?");
                    return;
                }

            }
            else
            {
                return;
            }



            //  ____                   _       _         ____  _      _   ____        _           ___  _     _           _   
            // |  _ \ ___  _ __  _   _| | __ _| |_ ___  |  _ \(_) ___| |_|  _ \  __ _| |_ __ _   / _ \| |__ (_) ___  ___| |_ 
            // | |_) / _ \| '_ \| | | | |/ _` | __/ _ \ | | | | |/ __| __| | | |/ _` | __/ _` | | | | | '_ \| |/ _ \/ __| __|
            // |  __/ (_) | |_) | |_| | | (_| | ||  __/ | |_| | | (__| |_| |_| | (_| | || (_| | | |_| | |_) | |  __/ (__| |_ 
            // |_|   \___/| .__/ \__,_|_|\__,_|\__\___| |____/|_|\___|\__|____/ \__,_|\__\__,_|  \___/|_.__// |\___|\___|\__|
            //            |_|                                                                             |__/               




            //parse out the the dictionary file

            List<Regex> RegexList = new List<Regex>();
            List<string> ReplacementList = new List<string>();


            try
            {
                string[] EntryLines = RegexListFileRawText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                //Map out the input entries
                for (int i = 0; i < EntryLines.Length; i++)
                {

                    string[] EntryRow = EntryLines[i].Split(new char[] { '\t' });


                    if (CaseSensitiveCheckbox.Checked) { 
                        RegexList.Add(new Regex(@EntryRow[0], RegexOptions.Compiled));
                    }
                    else
                    {
                        RegexList.Add(new Regex(@EntryRow[0], RegexOptions.Compiled | RegexOptions.IgnoreCase));
                    }
                    ReplacementList.Add(EntryRow[1]);

                }


                DictData.RegexArray = RegexList.ToArray();
                DictData.ReplacementArray = ReplacementList.ToArray();

                DictData.RegExListLoaded = true;

                MessageBox.Show("Your regular expression list has been successfully loaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("TextEmend encountered an error while trying to parse out your RegEx list. Please check to make sure that it is correctly formatted, that your regular expressions are valid, and that your list file is not currently open in another application.", "Error parsing RegEx list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DictData = new DictionaryData();
                return;
            }


    }



    }
    


}
