using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace CardBuilderApp
{
    public class CardBuilder
    {
        public List<Card> cards = new();

        public static void MakeTestJson(string inputFilePath)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 10; i++)
            {
                Card card = new Card();
                card.title = $"Card {i + 1}";
                card.text = $"This is the text for card {i + 1}.";
                cards.Add(card);
            }
            string json = JsonConvert.SerializeObject(cards, Formatting.Indented);
            System.IO.File.WriteAllText(inputFilePath, json);
        }
        public static void BuildCards(string inputFilePath, string outputFilePath = "output_cards.png")
        {
            List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText(inputFilePath));
            if(cards.Count<4 || cards.Count> 70)
            {
                throw new Exception("The number of cards must be between 4 and 70.");
            }
            //width = 2-10
            //height = 2-7
            int use_width = 2;
            int use_height = 2;
            bool breaking = false;
            for (int height = 2; height <= 7; height++)
            {
                for (int width = 2; width <= 10; width++)
                {
                    if(width*height >= cards.Count)
                    {
                        use_width = width;
                        use_height = height;
                        breaking = true;
                        break;
                    }
                    //we will create a grid of cards with the specified width and height, and we will draw the cards on a single bitmap. We will then save the bitmap as a PNG file.
                }
                if (breaking) break;
            }
            using(Bitmap bm = new Bitmap(use_width * 750, use_height * 1050))
            {
               
                int x_index = 0;
                int y_index = 0;
                Graphics g = Graphics.FromImage(bm);
                g.FillRectangle(Brushes.White, new RectangleF(0, 0, bm.Width, bm.Height));

                StringFormat title_format = new StringFormat();
                title_format.LineAlignment = StringAlignment.Center;
                title_format.Alignment = StringAlignment.Center;

                StringFormat text_format = new StringFormat();
                text_format.LineAlignment = StringAlignment.Near;

                
                Pen outline_pen = new Pen(Color.Black, 5);

                foreach (Card card in cards)
                {
                    RectangleF title_bounding_box = new RectangleF(x_index * 750 + 10, y_index * 1050 + 10, 730, 200);
                    RectangleF text_bounding_box = new RectangleF(x_index * 750 + 10, y_index * 1050 + 210, 730, 830);
                    


                    g.DrawString(card.title, new Font("Arial", 64), Brushes.Black, title_bounding_box, title_format);
                    g.DrawRectangle(outline_pen, title_bounding_box);

                    g.DrawString(card.text, new Font("Arial", 48), Brushes.Black, text_bounding_box, text_format);
                    g.DrawRectangle(outline_pen, text_bounding_box);

                    x_index++;
                    if(x_index >= use_width)
                    {
                        x_index = 0;
                        y_index++;
                    }
                }
                bm.Save(outputFilePath, ImageFormat.Png);
            }
            
            //750x1050 pixels is the standard size for a card, so we will create a bitmap of that size for each card and draw the title and text on it. We will then save each card as a PNG file.
        }
    }
}
