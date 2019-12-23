
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace Calckit.GUIsHandle
{
    public class ButtonHandle
    {
     

        //public method for handling numbers button clicked event

        public void NumBtnHandle(Button button, TextBox textBox)
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

        //Functions button

        public void FuncBtnHandle(Button button,TextBox textBox)
        {
            if (textBox.CaretIndex != textBox.Text.Length)
            {
                int index = textBox.CaretIndex;
                string input = textBox.Text;
                input = input.Insert(index, button.Content.ToString() + "(" + ")");
                textBox.Text = input;
                textBox.CaretIndex = index + button.Content.ToString().Length + 1;
                textBox.Focus();
            }
            else
            {
                textBox.Text += button.Content + "(" + ")";
                textBox.CaretIndex = textBox.Text.Length -1;
                textBox.Focus();
            }
        }


        //public method for handling back and forth buttons

        public void BFBtnHandle(Button button, TextBox textBox)
        {
            if (textBox.Text.Length != 0)
            {
                if (textBox.CaretIndex != 0)
                {
                    if (button.Name == "Back")
                    {
                        textBox.CaretIndex = textBox.CaretIndex - 1;
                        textBox.Focus();
                    }
                    else if (button.Name == "Forth")
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

        public void MemHandle(Button button, TextBox value, ListBox textBlock)
        {


            if (button.Content.ToString() == "M˅" || button.Content.ToString()=="Mv")
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
            else if (button.Content.ToString() == "MC")
            {
                textBlock.Items.Clear();

            }
            else if (button.Content.ToString() == "MR"||button.Content.ToString()=="M-")
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
            else if (button.Content.ToString() == "MS")
            {
                if (textBlock.Items.CurrentPosition == 0)
                    textBlock.Items.Insert(0, value.Text);
                else
                {
                    textBlock.Items.MoveCurrentToNext();
                    textBlock.Items.Insert(0, value.Text);
                }
            }
            else if (button.Content.ToString() == "M+")
            {
                if (textBlock.Items.IsEmpty)
                    textBlock.Items.Add(value.Text);
                else
                    textBlock.Visibility = Visibility.Visible;
            }

        }

      
        public void Delete(TextBox textBox)
        {
            if (textBox.Text.Length != 0)
            {

                if (textBox.CaretIndex != textBox.Text.Length && textBox.CaretIndex != 0)
                {
                    int index = textBox.CaretIndex;
                    textBox.Text = textBox.Text.Remove(index - 1, 1);
                    textBox.CaretIndex = index - 1;
                    textBox.Focus();
                }
                else
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                    textBox.CaretIndex = textBox.Text.Length;
                    textBox.Focus();
                }

            }
            else
            {
                textBox.Focus();
            }
        }


    }
}
