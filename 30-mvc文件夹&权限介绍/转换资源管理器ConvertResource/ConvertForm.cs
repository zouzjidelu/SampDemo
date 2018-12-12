using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace ConvertResource
{
    public partial class ConvertForm : Form
    {
        private string[] files = null;

        public ConvertForm()
        {
            InitializeComponent();
        }

        private void btnResources_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "resources文件(*.resources)|*.resources";
            DialogResult dr = this.openFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            //string strResources = this.openFileDialog.FileName;
            //this.txtResources.Text = strResources;

            files = openFileDialog.FileNames;
            string temp = string.Empty;
            StringBuilder sb = new StringBuilder();

            foreach (string file in files)
            {
                sb.Append(file);
                sb.Append("|");
            }
            temp = sb.ToString();
            if (temp.IndexOf("|") > 0)
            {
                txtResources.Text = temp.TrimEnd('|');
            }
            this.openFileDialog.FileName = string.Empty;
        }

        //private void btnResx_Click(object sender, EventArgs e)
        //{
        //    this.saveFileDialog.Filter = "resx文件(*.resx)|*.resx";
        //    DialogResult dr = this.saveFileDialog.ShowDialog();
        //    if (dr != DialogResult.OK)
        //    {
        //        return;
        //    }
        //    string strResx = this.saveFileDialog.FileName;
        //    this.txtResx.Text = strResx;
        //    this.saveFileDialog.FileName = string.Empty;
        //}
        private void btnOK_Click(object sender, EventArgs e)
        {
            string basePath = string.Empty;
            string sFile = string.Empty; //不带路径的文件名
            string newFold = "resx";//新文件夹名称
            string savePath = string.Empty;
            int len = 0;
            int index = -1;
            string strResx = string.Empty;
            if (files != null && files.Length > 0)
            {
                sFile = files[0];
                index = sFile.LastIndexOf("\\");
                basePath = sFile.Substring(0, index);//基路径
                savePath = string.Format("{0}\\{1}", basePath, newFold);
                if (!System.IO.Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                ResourceReader reader = null;
                ResXResourceWriter writer = null;
                foreach (string strResources in files)
                {
                    //strResx = sFile.Replace(".resources", ".resx");
                    sFile = strResources;
                    index = sFile.LastIndexOf("\\");
                    len = sFile.Length;
                    if (index > -1 && len > index)
                    {
                        strResx = sFile.Substring(index + 1, len - index - 1).Replace(".resources", ".resx");
                    }
                    strResx = string.Format("{0}\\{1}", savePath, strResx);
                    reader = new ResourceReader(strResources);
                    writer = new ResXResourceWriter(strResx);
                    foreach (DictionaryEntry en in reader)
                    {
                        writer.AddMetadata(en.Key.ToString(), en.Value);
                    }
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
                MessageBox.Show("转换资源文件转换成功", "系统提示");
                txtResources.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("待转换资源文件不能为空", "系统提示");
            }

            // string strResources = this.txtResources.Text;
            // string strResx = this.txtResx.Text;
            //if (string.IsNullOrEmpty(strResources) || string.IsNullOrEmpty(strResx))
            //{
            //    return;
            //}
            //ResourceReader reader = new ResourceReader(strResources);
            //ResXResourceWriter writer = new ResXResourceWriter(strResx);

            //foreach (DictionaryEntry en in reader)
            //{
            //    writer.AddMetadata(en.Key.ToString(), en.Value);
            //}
            //reader.Close();
            //writer.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Dispose();
            Application.Exit();
            //base.OnClosing(e);
        }
    }
}