namespace Wordle {
    class Program {
        static void Main(string[] args) {
            
            // READ TEXT FILE FROM COMMAND LINE AND RANDOMLY PICK WORD TO GUESS
            if (args.Length < 1) {
                Console.WriteLine("No file provided");
                Environment.Exit(0);
            }
            string fileName = @"Resources\" + args[0];

            try {
                using (StreamReader reader = new StreamReader(fileName)) {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine(ex);
            }
            
            if (new FileInfo(fileName).Length == 0) {
                Console.WriteLine("File is empty");
                Environment.Exit(0);
            }

            // words is a string array containing the words from the text file
            var words = File.ReadAllLines(fileName);
            Random rand = new Random();
            String word = words[rand.Next(words.Length)];
            Console.WriteLine(word);

            // PROCESS USER INPUT GUESS

            // OUTPUT

        }
    }
}