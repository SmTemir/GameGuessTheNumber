using System;

namespace GameGuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру \"Угадай число\"!");
            Random rnd = new Random();
            Console.WriteLine("############## Один игрок #############");
            Console.WriteLine("#######################################");
            Console.WriteLine("\n");

            Console.Write("Пожалуйста, назовите ваше имя: ");
            string playerName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"-- {playerName}, для вас будет загадано случайное число больше нуля.");
            Console.WriteLine("");

            int maxGuessNumber = 999;
            int quantityOfAttempts = int.MaxValue;
            bool enableAdditionalHints = false;
            Console.WriteLine("Вы можете настроить следующие параметры для вашей игры: ");
            Console.WriteLine("1 - верхняя граница диапазона, из которого будет выбираться число (по умолчанию 999)");
            Console.WriteLine("2 - количество попыток на отгадывание(по умолчанию - без ограничения)");
            Console.WriteLine("3 - включение дополнительных подсказок \"горячо\", \"холодно\" (по умолчанию выключено)");

            //Console.WriteLine("Для настройки параметров нажмите \"Enter\", для пропуска нажмите \"Пробел\"");
            //while (Console.ReadKey().Key != ConsoleKey.Spacebar || Console.ReadKey().Key != ConsoleKey.Enter) 
            //{
            //    if (Console.ReadKey().Key == ConsoleKey.Enter)
            //    {

            //    }
            //}

            maxGuessNumber = GetNumberToUseAsUpperBorder();
            Console.WriteLine($"Верхняя граница : {maxGuessNumber}");

            quantityOfAttempts = GetNumberOfAttempts();
            Console.WriteLine($"Количество попыток: {quantityOfAttempts}");

            enableAdditionalHints = GetHintsEnableSwitch();

            Console.Clear();

            int currentAttempt = 0;
            int guessNumber;
            bool isWin = false;
            int theNumber = rnd.Next(0, maxGuessNumber);
            int diffTheNumberAndGuessNumber1;
            int diffTheNumberAndGuessNumber2 = 0;

            Console.WriteLine($"{playerName}, игра началась!");
            Console.WriteLine("Число загадано, попробуйте его угадать.");
            do
            {
                Console.WriteLine("");
                Console.WriteLine($"Ваша попытка №{++currentAttempt}.");

                guessNumber = GetNumberFromUser();
                if (guessNumber > theNumber)
                {
                    Console.WriteLine("Ваше число больше загаданного");
                }
                else if (guessNumber < theNumber)
                {
                    Console.WriteLine("Ваше число меньше загаданного");
                }
                else
                {
                    isWin = true;
                }

                diffTheNumberAndGuessNumber1 = Math.Abs(theNumber - guessNumber);

                if (isWin) { }
                else if (enableAdditionalHints && currentAttempt != 1)
                {
                    Console.WriteLine(diffTheNumberAndGuessNumber1 < diffTheNumberAndGuessNumber2 ? "\"Тепло\"" : "\"Холодно\"");
                }
                //else if (enableAdditionalHints && currentAttempt != 1 && diffTheNumberAndGuessNumber1 > diffTheNumberAndGuessNumber2)
                //{

                //}

                diffTheNumberAndGuessNumber2 = diffTheNumberAndGuessNumber1;

            } while (guessNumber != theNumber && currentAttempt < quantityOfAttempts);

            Console.WriteLine(isWin ? "Вы угадали!" : "Вы проиграли!");
        }

        /// <summary>
        /// Request number from user to use it for Max number which can be choose for guess.
        /// </summary>
        /// <returns>int value which >= 2</returns>
        private static int GetNumberToUseAsUpperBorder()
        {
            string getMaxBorder;
            int gotBorder;
        M: do
            {
                Console.WriteLine("");
                Console.WriteLine("Для значения по умолчанию жмите \"Enter\".");
                Console.Write("1 - Верхняя граница(целое число, больше единицы): ");
                getMaxBorder = Console.ReadLine();
            } while (!(int.TryParse(getMaxBorder, out gotBorder) || getMaxBorder == ""));

            if (getMaxBorder == "")
            {
                return 999;
            }
            else if (gotBorder >= 2)
            {
                return gotBorder;
            }
            else
            {
                goto M;
            }
        }

        /// <summary>
        /// Request number from user to set quantityOfAttempts.
        /// </summary>
        /// <returns>int value which >= 1</returns>
        private static int GetNumberOfAttempts()
        {
            string numberOfAttemptsLine;
            int numberOfAttempts;
        M:  do
            {
                Console.WriteLine("");
                Console.WriteLine("Для значения по умолчанию жмите \"Enter\".");
                Console.Write("2 - Количество попыток(целое число, больше нуля):");
                numberOfAttemptsLine = Console.ReadLine();
            } while (!(int.TryParse(numberOfAttemptsLine, out numberOfAttempts) || numberOfAttemptsLine == ""));

            if (numberOfAttemptsLine == "")
            {
                return int.MaxValue;
            }
            else if (numberOfAttempts >= 1)
            {
                return numberOfAttempts;
            }
            else
            {
                goto M;
            }
        }

        /// <summary>
        /// Requset data from user for Enable or Disable Additional Hints.
        /// </summary>
        /// <returns>bool true to enable, false to disable</returns>
        private static bool GetHintsEnableSwitch()
        {
            string hintsLine;
            //bool enableHints;
        M:  do
            {
                Console.WriteLine("");
                Console.WriteLine("Для значения по умолчанию жмите \"Enter\".");
                Console.Write("3 - Дополнительные подсказки(для включения ввести \"1\": ");
                hintsLine = Console.ReadLine();
            } while (!(hintsLine == "1" || hintsLine == ""));

            if (hintsLine == "")
            {
                Console.WriteLine("Дополнительные подсказки выключены.");
                return false;
            }
            else if (hintsLine == "1")
            {
                Console.WriteLine("Дополнительные подсказки включены.");
                return true;
            }
            else
            {
                goto M;
            }
        }

        /// <summary>
        /// Request number from user which more than 0.
        /// </summary>
        /// <returns>int value more than 0</returns>
        private static int GetNumberFromUser()
        {
            string userNumberLine;
            int userNumber;
        do
            {
                Console.Write("Введите число:");
                userNumberLine = Console.ReadLine();
            } while (!(int.TryParse(userNumberLine, out userNumber) && userNumber > 0));

            return userNumber;
        }

    }
}
