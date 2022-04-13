using System.Text;

namespace Wordle {

    class Word {
        public String getWord (String fileName) {
            var words = File.ReadAllLines(fileName);
            Random rand = new Random();
            return words[rand.Next(words.Length)].ToLower();
        }

    }

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

            // PICK RANDOM WORD TO SOLVE
            Word mysteryWord = new Word();
            String word = mysteryWord.getWord(fileName);

            Console.Write("How many guesses?: ");
            int numGuesses;
            while (!int.TryParse(Console.ReadLine(), out numGuesses)) {
                Console.Write("Please enter the number of guesses: ");
            }

            bool solved = false;
            int attempt = 1;

            // PROCESS USER INPUT GUESS
            do {

                Console.Write("Attempt #{0}: ",attempt);
                string? guess = Console.ReadLine();

                if (guess is null) {
                    throw new ArgumentNullException(nameof(guess));
                }
                else if (int.TryParse(guess, out _)) {
                    Console.WriteLine("Guess is not valid!");
                }
                else if (guess.Length < word.Length) {
                    guess = guess.Substring(0,guess.Length).ToLower();
                }
                else {
                    guess = guess.Substring(0,word.Length).ToLower();
                }

                // prints result string of guess and word comparison
                string result = new String('_', word.Length);
                StringBuilder resultString = new StringBuilder(result);

                // If letter is in correct position, character is capitalized
                // If letter is in wrong position, character is lowercase
                // If letter is not in word, leave blank or '_' 
                for (int i=0; i<guess.Length; i++) {
                    if (word[i] == guess[i]) {
                        resultString[i] = guess[i].ToString().ToUpper()[0];
                    }
                    else if (word.Contains(guess[i])) {
                        resultString[i] = guess[i].ToString().ToLower()[0];
                    }
                }
                
                if (word == guess) {
                    solved = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(resultString);
                    Console.ResetColor();
                }
                else {
                    Console.WriteLine(resultString);
                }

                attempt++;

            }
            while(!solved && attempt <= numGuesses);

            Console.WriteLine("The word was: "+ word);
        }
    }
}