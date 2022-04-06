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

            // string array containing the words from the text file
            var words = File.ReadAllLines(fileName);
            Random rand = new Random();
            String word = words[rand.Next(words.Length)];
            //Console.WriteLine(word);

            // PROCESS USER INPUT GUESS
            Console.Write("How many guesses?: ");
            int numGuesses;
            while (!int.TryParse(Console.ReadLine(), out numGuesses)) {
                Console.Write("Please enter the number of guesses: ");
            }

            bool solved = false;
            int attempt = 1;

            Console.WriteLine();

            do {
                Console.WriteLine("Attempt #{0} ",attempt);
                Console.Write("Enter Guess: ");
                string? guess = Convert.ToString(Console.ReadLine());

                var result = Enumerable.Range(0, guess.Length).Select(i=>new
                {
                    index = i,
	                letter = guess[i],
	                wrongPosition = word.ToList().Contains(guess[i]),
                    correct = guess[i] == word[i]
                });

                // prints result string of guess and word comparison
                // If letter is in correct position, character is capitalized
                // If letter is in wrong position, character is lowercase
                // If letter is not in word, '_' 
                var resultstring = string.Concat(result.Select(i => 
                i.correct ? i.letter.ToString().ToUpper()[0] : 
                i.wrongPosition ? i.letter.ToString().ToLower()[0] : '_'));

                Console.WriteLine(resultstring);
                if(word == guess) {
                    solved = true;
                }
                attempt++;
            }
            while(!solved && attempt <= numGuesses);

            Console.WriteLine("The word was: "+word);

        }
    }
}