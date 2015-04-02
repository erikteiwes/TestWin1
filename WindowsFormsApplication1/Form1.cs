using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //static List<FileInfo> files = new List<FileInfo>();  // List that will hold the files and subfiles in path
        //static List<DirectoryInfo> folders = new List<DirectoryInfo>(); // List that hold direcotries that cannot be accessed
        public Form1()
        {
            InitializeComponent();
            //textBox1.Text="C:\tmp\testdata\";
        }


        private bool CopyFolderContents(string SourcePath, string DestinationPath)
        {
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }

                    foreach (string files in Directory.GetFiles(SourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);
                        fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {



            //}
            string currentDir = textBox1.Text;
            string string1 = null;
            string uitvoerName = textBox2.Text;
            string arcInfoName = null;
            try
            {
                //int one = 1;
                //int zero = 0;
                //int test = one / zero;

                DirectoryInfo di = new DirectoryInfo(textBox1.Text);
                //FullDirList(di, "*");
                if (Directory.Exists(textBox1.Text))
                {

                    foreach (DirectoryInfo d in di.GetDirectories())
                    {
                        foreach (FileInfo f in di.GetFiles("*.e00"))
                        {
                            arcInfoName = f.Name;
                            // strip extension
                            string arcInfoNamed = arcInfoName.Substring(0, arcInfoName.Length - 4);
                            //Console.WriteLine("File {0}", f.FullName);
                            int uitvoerNameLen = uitvoerName.Length;
                            if (uitvoerNameLen > 13)
                            {
                                uitvoerNameLen = 13;
                            }
                            if (arcInfoNamed != uitvoerName.Substring(0, uitvoerNameLen))
                            {
                                // rename file toe uitvoerName
                                f.MoveTo(currentDir + "\\" + uitvoerName + ".e00");
                            }
                            //if (arcInfoNamed != uitvoerName.Substring(0, 13))
                            //{
                            //    // rename file toe uitvoerName
                            //    f.MoveTo(currentDir + "\\" + uitvoerName + ".e00");
                            //}


                            //if (uitvoerName.Length >= 13)
                            //{

                            //}
                            //else
                            //{
                            //    // rename file toe uitvoerName
                            //    f.MoveTo(currentDir + "\\" + uitvoerName + ".e00");
                            //}

                            break;
                        }
                        //if (d.Name!="info")
                        //{
                        //    //textBox2.Text = d.Parent + " - " + d.Name;
                        //    string1 = d.Parent.ToString();
                        //    string2 = d.Name;


                        //}
                    }
                }

                // create backup dir
                //string oldDir=currentDir + "\\wegvakken";
                //string backupDir = currentDir + "\\" +"backup";
                //Directory.CreateDirectory(backupDir);
                ////bool ok = CopyFolderContents(oldDir , backupDir);

                //if (ok )
                //{
                //   // MessageBox.Show("Test ok");
                //    textBox2.Text = "OK";
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("foutje bedankt", ex.Message);
                //return;
                //rethrow ex;
                throw new Exception("waar moet dit heen");
            }
            finally
            {
                MessageBox.Show("ha finally");

            }

        }

    }
}
