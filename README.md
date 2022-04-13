# Wordle

This Wordle game is based on the original [Wordle](https://www.nytimes.com/games/wordle/index.html) with features that include inputting a text file with 4+ letter words or custom words with varying lengths and an variable number of attempts to guess the word.

## Explanation 

The program will:

1. Choose a random word from the inserted text file

2. Prompt the user for the number of desired attempts

3. Prompt the user to input guesses

4. Process the guessed word and output a result string until the puzzle is solved or the number of desired attempts has been reached

## Logic for Processing Guess Word

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

- If letter is in correct position, character is capitalized
- If letter is in wrong position, character is lowercase
- If letter is not in word, leave blank or '_'

## Technologies used

Written using latest .NET SDK (6.0.201) in C# syntax.

## How to setup and run

Latest [.NET SDK](https://dotnet.microsoft.com/en-us/download) must be installed

Test .txt files must be located in `\Resources`. I have added 5 files in addition to `"custom.txt"`.

Test file names are:

- `"wordle4.txt"`
- `"wordle5.txt"`
- `"wordle6.txt"`
- `"wordle7.txt"`
- `"random.txt"`

To run application in Command Prompt:

1. Download Wordle-master.zip

2. Extract .zip file in your desired location with 'Extract Here'

3. Navigate to folder in Command Prompt

    - `cd .. \Wordle-master`

    - Run command `dotnet run "FileName.txt"`

To run application in Visual Studio Code:

1. Open Wordle folder in Visual Studio Code

2. In terminal run command `dotnet run "FileName.txt"`

## Conclusion

1. If given more time, I would have added a dictionary implementation to compare guessed words to existing dictionary-language words

2. I would also like to display the game in a browser
