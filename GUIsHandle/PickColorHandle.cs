using System;
using System.Collections.Generic;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorPickerWPF;
using ColorPickerWPF.Code;
using System.Windows.Media;
using System.Windows.Controls;

namespace Calckit.GUIsHandle
{
   public class PickColorHandle
    {
        public event EventHandler OnPick;

        public Color Color { get; set; }

        public ColorPickerDialogOptions Options { get; set; }

        public void PickColorButton_OnClick(TextBox textBox)
        {
            Color color;
            if (ColorPickerWindow.ShowDialog(out color, Options))
            {
                SetColor(color,textBox);
                OnPick?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SetColor(Color color, TextBox textBox)
        {
            Color = color;
            textBox.Text = color.ToHexString();

        }
    }
}
