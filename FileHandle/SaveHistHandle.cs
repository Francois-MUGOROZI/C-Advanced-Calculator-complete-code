using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Calckit.Properties;


namespace Calckit.FileHandle
{
   public class SaveHistHandle
    {
        private string path { get; set; }
        public void Save(string path, RichTextBox richText)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    SaveAs(richText);
                }
                else
                {

                    var f = File.OpenWrite(path);
                    TextRange range = new TextRange(richText.Document.ContentStart, richText.Document.ContentEnd);
                    range.Save(f, "Text");
                    f.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Save failed:" + ex.Message, "Save Dialog error");
            }
        }
        
        public void SaveAs(RichTextBox box)
        {

            TextRange range = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
            Settings settings = new Settings();
            try
            {
                System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();

                dialog.Filter = "Text files(*.txt)|*.txt";
                dialog.Title = "Save History";
                dialog.DefaultExt = ".txt";
                dialog.FilterIndex = 1;
                dialog.InitialDirectory = settings.DefaultPath;
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                
 
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   var f = File.OpenWrite(dialog.FileName);
                    path = dialog.FileName;
                    range.Save(f, "Text");

                    f.Close();

                    MessageBox.Show("File saved succefully", "Message");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed:" + ex.Message, "Save Dialog error");
            }
        }

        public string GetPath()
        {
            return path;
        }

    }
}
