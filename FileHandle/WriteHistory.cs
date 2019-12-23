
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Calckit.FileHandle
{
   public class WriteHistory
    {
        public WriteHistory(string Exp,string res, RichTextBox richText)
        {

            string write = "Entered value: " + Exp + "\n\t" + "Result: " + res+"\n";

            Paragraph paragraph = new Paragraph();
            paragraph.TextAlignment = System.Windows.TextAlignment.Right;
            paragraph.Inlines.Add(write);
            richText.Document.Blocks.InsertBefore(richText.Document.Blocks.FirstOrDefault(), paragraph);
        }
    }
}
