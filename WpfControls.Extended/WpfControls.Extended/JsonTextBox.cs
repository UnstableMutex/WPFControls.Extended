using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfControls_Extended
{
    public class JsonTextBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            Regex re = new Regex(@"\W", RegexOptions.IgnoreCase);
            bool b = re.IsMatch(e.Text);
            if (b)
            {
                TextInputController.Override(this, e);
                return;
            }
        }
        static class TextInputController
        {
            public static void Override(TextBox tb, TextCompositionEventArgs e)
            {
                if (tb.SelectionLength == 0)
                {
                    NoSelTextInputController.Override(tb, e);
                    return;
                }
                else
                {
                }
            }
        }
        static class SelTextInputController
        {
            public static void Override(TextBox tb, TextCompositionEventArgs e)
            {

            }
        }
        static class NoSelTextInputController
        {
            public static void Override(TextBox tb, TextCompositionEventArgs e)
            {
                string[] doubled = { "[", "{", "'", "(" };
                string[] doubledpair = { "]", "}", "'", ")" };
                var start = tb.Text.Substring(0, tb.SelectionStart);
                var end = tb.Text.Substring(tb.SelectionStart);
                if (doubled.Contains(e.Text))
                {
                    var ind = doubled.ToList().IndexOf(e.Text);
                    var newselstart = tb.SelectionStart + 1;
                    tb.Text = start + doubled[ind] + doubledpair[ind] + end;
                    tb.SelectionStart = newselstart;
                    e.Handled = true;
                }
            }
        }
    }
}
