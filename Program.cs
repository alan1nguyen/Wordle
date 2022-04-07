using System.Text;

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

            // PROCESS USER INPUT GUESS
            Console.Write("How many guesses?: ");
            int numGuesses;
            while (!int.TryParse(Console.ReadLine(), out numGuesses)) {
                Console.Write("Please enter the number of guesses: ");
            }

            bool solved = false;
            int attempt = 1;

            // this line reveals the length of the picked word 
            //Console.WriteLine(new String('_', word.Length));

            do {

                Console.WriteLine("Attempt #{0} ",attempt);
                Console.Write("Enter Guess: ");
                string? guess = Console.ReadLine();

                if (guess is null) {
                    throw new ArgumentNullException(nameof(guess));
                }
                else if (int.TryParse(guess, out _)) {
                    Console.WriteLine("Guess is not valid!");
                }
                else if (guess.Length < word.Length) {
                    //Console.WriteLine("Guess is too short!");
                }
                else {
                    guess = guess.Substring(0,word.Length).ToLower();
                }

                // prints result string of guess and word comparison
                // If letter is in correct position, character is capitalized
                // If letter is in wrong position, character is lowercase
                // If letter is not in word, leave blank or '_' 

                string result = new String('_', word.Length);
                StringBuilder resultString = new StringBuilder(result);

                for (int i=0; i<guess.Length; i++) {
                    if (word[i] == guess[i]) {
                        resultString[i] = guess[i].ToString().ToUpper()[0];
                    }
                    else if (word.Contains(guess[i])) {
                        resultString[i] = guess[i].ToString().ToLower()[0];
                    }
                    else {
                        resultString[i] = '_';
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