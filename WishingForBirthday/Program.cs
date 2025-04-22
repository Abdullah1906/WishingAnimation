using System;
using System.Data;
using System.Threading;
using System.Media;
using NAudio.Wave;

class Program
{
    static void Main()
    {
        // Play the song synchronously
        string filePath = @"E:\Wavfile\happy-bithday-in-dining-room-53763.mp3";
        string filePath2 = @"E:\Wavfile\voice5-30459.mp3";



        string name = " Happy Happy Birthday  ";
        string name_wish = "Wishing you a day filled with love,";
        string name_wish2 = "laughter, and all your favorite things!";

        string[] fireworks = {
            "       *",
            "     *   *",
            "   *       *",
            " *    BOOM!  *",
            "   *       *",
            "     *   *",
            "       *"
        };


        string[][] walkingManFrames = new string[][]
               {
            new string[]
            {
                "   _____  ",
                "  /     \\ ",
                " |  o o  |",
                " |   ^   |",
                " |  '-'  |",
                "  \\_____/ ",
                "    | |   ",
                "   /| |\\ ",
                "  / | | \\",
                "    / \\   ",
                "   /   \\  "
            },
            new string[]
            {
                "   _____  ",
                "  /     \\ ",
                " |  o o  |",
                " |   ^   |",
                " |  '-'  |",
                "  \\_____/ ",
                "    | |   ",
                "   /|_|\\ ",
                "    | |   ",
                "   /   \\  ",
                "  /     \\ "
            }
          };
        string[] wavingMan = new string[]
        {
            "   _____  ",
            "  /     \\ ",
            " |  o o  |",
            " |   ^   |",
            " |  \\_/  |",
            "  \\_____/ ",
            "    \\ |   ",
            "   \\|_|\\ ",
            "     |    ",
            "    / \\   ",
            "   /   \\  "
        };

        int width = Console.WindowWidth;
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        int frame = 0;
        int colorIndex = 0;




        // Walking Man Animation
        for (int x = 0; x < width - 50; x++)
        {
            Console.Clear();
            Console.ForegroundColor = colors[colorIndex % colors.Length];

            var man = walkingManFrames[frame % walkingManFrames.Length];
            for (int i = 0; i < man.Length; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(man[i]);
            }

            Thread.Sleep(150);
            frame++;
            colorIndex++;
        }
        // Stop, wave, and wish
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;


        for (int i = 0; i < wavingMan.Length; i++)
        {
            Console.SetCursorPosition(width / 2, i);
            Console.Write(wavingMan[i]);
        }

        Thread.Sleep(500);
        // After walking man, display Happy Birthday above the man
        string[] happy = new string[]
        {
            " H   H  AAAAA  PPPP   PPPP   Y   Y   ",
            " H   H  A   A  P   P  P   P   Y Y    ",
            " HHHHH  AAAAA  PPPP   PPPP     Y     ",
            " H   H  A   A  P      P        Y     ",
            " H   H  A   A  P      P        Y     "
        };
        string[] birthday = new string[]
       {
            " BBBBB   III  RRRRR  TTTTT  H   H   DDDD   AAAAA  Y   Y   ",
            " B   B    I   R   R    T    H   H   D   D  A   A   Y Y    ",
            " BBBBB    I   RRRR     T    HHHHH   D   D  AAAAA    Y     ",
            " B   B    I   R  R     T    H   H   D   D  A   A    Y     ",
            " BBBBB   III  R   R    T    H   H   DDDD   A   A    Y     "
       };

        string[] miss = new string[]
        {
            " M   M III SSSS  SSSS  ",
            " MM MM  I  S     S     ",
            " M M M  I   SSS   SSS  ",
            " M   M  I     S     S  ",
            " M   M III SSSS  SSSS  "
        };

        string[] arefin = new string[]
        {
            " AAAAA  RRRR  EEEEE FFFFF III N   N ",
            " A   A  R   R E     F      I  NN  N ",
            " AAAAA  RRRR  EEEE  FFF    I  N N N ",
            " A   A  R  R  E     F      I  N  NN ",
            " A   A  R   R EEEEE F     III N   N "
        };


        string[][] wordsToShow = new string[][] { happy, birthday, miss, arefin };

        foreach (var word in wordsToShow)
        {
            Console.Clear();
            
            for (int i = 0; i < word.Length; i++)
            {
                Console.SetCursorPosition(width / 2 - word[i].Length / 2, i + 2); // +2 to move down a little
                Console.ForegroundColor = colors[colorIndex % colors.Length];
                Console.WriteLine(word[i]);
            }
            colorIndex++;
            Thread.Sleep(1500); // Pause between words
        }

        

        Console.SetCursorPosition(width / 2 - 10, wavingMan.Length + 2);
        Random rand = new Random();
        int xx = Console.CursorLeft;
        int y = Console.CursorTop;

        // wishing part
        foreach (var c in name)
        {
            // Skip black to keep text visible on most terminals
            ConsoleColor color;
            do
            {
                color = (ConsoleColor)rand.Next(1, 16); // 1 to 15 (skip black)
            } while (color == ConsoleColor.Black);

            Console.ForegroundColor = color;
            Console.Write(c);
            Thread.Sleep(500);
        }

        Console.SetCursorPosition(xx, y + 2);
        foreach (var c in name_wish)
        {
            // Skip black to keep text visible on most terminals
            ConsoleColor color;
            do
            {
                color = (ConsoleColor)rand.Next(1, 16); // 1 to 15 (skip black)
            } while (color == ConsoleColor.Black);

            Console.ForegroundColor = color;
            Console.Write(c);
            Thread.Sleep(500);
        }

        Console.SetCursorPosition(xx, y + 3);
        foreach (var c in name_wish2)
        {
            // Skip black to keep text visible on most terminals
            ConsoleColor color;
            do
            {
                color = (ConsoleColor)rand.Next(1, 16); // 1 to 15 (skip black)
            } while (color == ConsoleColor.Black);

            Console.ForegroundColor = color;
            Console.Write(c);
            Thread.Sleep(500);
        }
        // play music 
        try
        {
            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing the sound: " + ex.Message);
        }


        // Simulate fireworks
        int fireworksTop = Console.WindowHeight - fireworks.Length - 2;
        int left = (Console.WindowWidth - fireworks[0].Length) / 2;

        for (int i = 0; i < 9; i++)
        {
            ConsoleColor color = (ConsoleColor)(new Random().Next(1, 16));
            Console.ForegroundColor = color;

            for (int j = 0; j < fireworks.Length; j++)
            {
                Console.SetCursorPosition(left, fireworksTop + j);
                Console.WriteLine(fireworks[j]);
            }

            Thread.Sleep(500);
        }
        Console.ResetColor();

        // for plaing music
        try
        {
            using (var audioFile = new AudioFileReader(filePath2))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing the sound: " + ex.Message);
        }
    }
}

