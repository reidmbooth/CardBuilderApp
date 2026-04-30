using CardBuilderApp;

if (args.Length == 0)
{
    Console.WriteLine("Please provide the path to the card definition file.");
    return;
}

for(int i  = 0; i < args.Length; i++)
{
    if (args[i] == "-i" && args[i+1] is not null)
    {
        if (!File.Exists(args[i + 1]))
        {
            Console.WriteLine($"The file '{args[i + 1]}' does not exist.");
            return;
        }
        else
        {

            if (args[i+2] is not null && args[i+2] == "-o" && args[i+3] is not null)
            {
                CardBuilder.BuildCards(args[i + 1], args[i + 3]); //run with specified input and output filenames
            }
            else
            {
                CardBuilder.BuildCards(args[i + 1]); //run with specified input filename and default output filename
            }
            //run on default filename
        }
    }
}
//CardBuilder.BuildCards("cards.json", "cards.png"); //run with specified input and output filenames
//CardBuilder.MakeTestJson("cards.json");
