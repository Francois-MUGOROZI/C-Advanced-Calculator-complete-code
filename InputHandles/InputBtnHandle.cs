using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Calckit.InputHandles
{
   public class InputBtnHandle
    {


       //public method for handling numbers button clicked event

        public void NumBtnHandle(Button button,TextBox textBox)
        {
            if (textBox.CaretIndex != textBox.Text.Length)
            {
                int index = textBox.CaretIndex;
                string input = textBox.Text;
                input = input.Insert(index, button.Content.ToString());
                textBox.Text = input;
                textBox.CaretIndex = index + button.Content.ToString().Length;
                textBox.Focus();
            }
            else
            {
                textBox.Text += button.Content;
                textBox.CaretIndex = textBox.Text.Length;
                textBox.Focus();
            }

        }


        //public method for handling back and forth buttons

        public void BFBtnHandle(Button button,TextBox textBox)
        {
            if (textBox.Text.Length != 0)
            {
                if (textBox.CaretIndex != 0)
                {
                    if (button.Name == "BackBtn")
                    {
                        textBox.CaretIndex = textBox.CaretIndex - 1;
                        textBox.Focus();
                    }
                    else if (button.Name == "ForthBtn")
                    {
                        textBox.CaretIndex = textBox.CaretIndex + 1;
                        textBox.Focus();
                    }
                }
                else
                {
                    textBox.CaretIndex = textBox.Text.Length;
                    textBox.Focus();
                }
            }
            else
                textBox.Focus();
        }

        
        //method for handle memory control

        public void MemHandle(Button button,TextBox textBox,ListBox textBlock)
        {
            if (button.Name == "MemViewBtn")
            {
                if (textBlock.IsVisible == true)
                {
                    button.Background = Brushes.Transparent;
                    textBlock.Visibility = Visibility.Hidden;
                }
                else
                {
                    button.Background = Brushes.LightBlue;
                    textBlock.Visibility = Visibility.Visible;
                }
            }
            else if (button.Name == "MemClearBtn")
            {
                textBlock.Items.Clear();
                textBlock.Visibility = Visibility.Hidden;
                
            }
            else if (button.Name == "MemReadBtn")
            {
                if (textBlock.Items.IsEmpty)
                {
                    MessageBox.Show("Nothing in Memory to read!", "Null reference error");
                }
                else
                {
                    textBlock.Visibility = Visibility.Visible;
                }
            }
           else if (button.Name == "MemSaveBtn")
            {
                if (textBlock.Items.CurrentPosition == 0)
                    textBlock.Items.Insert(0, textBox.Text);
                else
                {
                    textBlock.Items.MoveCurrentToNext();
                    textBlock.Items.Insert(0, textBox.Text);
                }
            }
        }

        //method for history control buttons

        public void HistHandle(Button button,RichTextBox textBox)
        {
            if (button.Name == "HistViewBtn")
            {
                if (textBox.IsVisible == true)
                {
                    button.Background = Brushes.Transparent;
                    textBox.Visibility = Visibility.Hidden;
                }
                else
                {
                    button.Background = Brushes.LightBlue;
                    textBox.Visibility = Visibility.Visible;
                }
            }
            else if (button.Name == "HistClearBtn")
            {
                textBox.Document.Blocks.Clear();
                textBox.Visibility = Visibility.Hidden;
            }
        }

       
    }
}
