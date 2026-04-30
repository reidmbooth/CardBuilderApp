using System;
using System.Collections.Generic;
using System.Text;

namespace CardBuilderApp
{
    public class Card
    {
        public string title { get; set; }
        public string text { get; set; }

        public Card()
        {
            title = "null";
            text = "";
        }
    }
}
