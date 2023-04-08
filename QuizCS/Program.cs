using System;
namespace QuizProjectCS
{
    internal class Program
    {
        static public bool newGame = false;
        static public bool exit = false;
        static public bool checkTrue = false;
        static public int point = 0;
        static public string[] questions =
           {
                    "Azerbaycanin paytaxti haradir?","Chevrenin uzunlug dusturu hansidir?","Ashagdakilardan hansi girish qurgusudur?",
                    "Ashagdakilardan hansi C# diline uygun sintaksisdir?","Hansi dil .Net-e daxildir?","Pifaqor teoreminin dusturu hansidir?",
                    "Yumurta ilk yaranib yoxsa toyuq?","CPU nedir?","Abstrac classda ne etmek olmur?","C# char tipinin olchusu nechedir?"
            };
        static public string[,] answers = new string[10, 3]
        {
                        { "Baki","Gence","Sumqayit" },
                        { "2πd","πr","2πr" },
                        { "Klaviatura","Monitor","Printer" },
                        { "cout<<'a'","print('b')","Console.Clear()"},
                        { "C++","Python","F#"},
                        { "a**2 + b**2 = c**2","(a+b)*2 = c","a + b = c"},
                        { "Yumurta","Allah bilir","Toyuq"},
                        { "RAM","Prossesor","SSD"},
                        { "Inheritance olmur","Obyektini yaratmaq olmur","Her ikisi"},
                        { "1","4","2" }
        };

        static public string[] rightAnswer =
        {
                       "Baki","2πr","Klaviatura","Console.Clear()","F#","a**2 + b**2 = c**2","Allah bilir","Prossesor","Obyektini yaratmaq olmur","2"
            };


        public static void Shuffle(string[,] array)
        {
            Random random = new Random();

            for (int i = array.GetLength(1) - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                for (int row = 0; row < array.GetLength(0); row++)
                {
                    string temp = array[row, i];
                    array[row, i] = array[row, j];
                    array[row, j] = temp;
                }
            }
        }
        static public void arrow(int realPosition, int arrowPosition)
        {
            if (realPosition == arrowPosition)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" --->  ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("       ");
            }
        }

        static public void Menu()
        {
            int positionMenu = 1;
            dynamic key = 0;
            while (true)
            {

                Console.Clear();
                Console.Write("\n\n");
                arrow(1, positionMenu);
                Console.Write("Start Quiz\n");
                arrow(2, positionMenu);
                Console.Write("Exit\n");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {

                    break;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu != 2)
                {
                    positionMenu++;
                }
                else if (key.Key == ConsoleKey.DownArrow && positionMenu <= 2)
                {
                    positionMenu--;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu <= 1)
                {
                    positionMenu++;

                }
                else if (key.Key == ConsoleKey.UpArrow && positionMenu != 1)
                {
                    positionMenu--;
                }
                else
                {
                    positionMenu = positionMenu;
                }
            }
            switch (positionMenu)
            {
                case 1:
                    newGame = true;
                    break;
                case 2:
                    exit = true;
                    break;

            }
        }
        static public void quizz()
        {
            Console.Clear();
            int position = 1;
            dynamic key = 0;
            int temp = 0;
            int positionCpy = 0;
            int nextQuestion = 0;
            Shuffle(answers);

            while (true)
            {
                if (nextQuestion == answers.GetLength(0))
                {
                    break;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(questions[nextQuestion]);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\n");
                arrow(1, position);
                Console.Write($"A) {answers[nextQuestion, 0]}\n");
                arrow(2, position);
                Console.Write($"B) {answers[nextQuestion, 1]}\n");
                arrow(3, position);
                Console.Write($"C) {answers[nextQuestion, 2]}\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Point: {point}");
                Console.ForegroundColor = ConsoleColor.White;


                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();
                    Thread.Sleep(1000);
                    positionCpy = position;
                    position = 1;

                    temp = positionCpy - 1;
                    if (answers[nextQuestion, temp] == rightAnswer[nextQuestion])
                    {


                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(questions[nextQuestion]);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("\n\n");
                        if (answers[nextQuestion, temp] == answers[nextQuestion, 0])
                        {

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("       ");
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");

                            Console.Write("       ");
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");

                        }
                        else if (answers[nextQuestion, temp] == answers[nextQuestion, 1])
                        {
                            Console.Write("       ");
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("       ");
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");

                        }
                        else if (answers[nextQuestion, temp] == answers[nextQuestion, 2])
                        {
                            Console.Write("       ");
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");

                            Console.Write("       ");
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        Thread.Sleep(1000);


                        nextQuestion++;
                        temp = 0;
                        point += 10;

                    }
                    else
                    {

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(questions[nextQuestion]);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("\n\n");
                        if (answers[nextQuestion, temp] == answers[nextQuestion, 0])
                        {

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("       ");
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");

                            Console.Write("       ");
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");

                        }
                        else if (answers[nextQuestion, temp] == answers[nextQuestion, 1])
                        {
                            Console.Write("       ");
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("       ");
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");

                        }
                        else if (answers[nextQuestion, temp] == answers[nextQuestion, 2])
                        {
                            Console.Write("       ");
                            Console.Write($"A) {answers[nextQuestion, 0]}\n");

                            Console.Write("       ");
                            Console.Write($"B) {answers[nextQuestion, 1]}\n");

                            Console.Write("       ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"C) {answers[nextQuestion, 2]}\n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        Thread.Sleep(1000);



                        nextQuestion++;
                        temp = 0;
                        if (point - 10 < 0)
                        {
                            point = 0;

                        }
                        else
                        {
                            point -= 10;

                        }
                    }



                }
                else if (key.Key == ConsoleKey.DownArrow && position != 3)
                {
                    position++;
                }
                else if (key.Key == ConsoleKey.DownArrow && position == 3)
                {
                    position = 1;

                }
                else if (key.Key == ConsoleKey.UpArrow && position == 1)
                {
                    position = 3;

                }
                else if (key.Key == ConsoleKey.UpArrow && position != 1)
                {
                    position--;
                }
                else
                {
                    position = position;
                }



            }


        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
                if (newGame)
                {
                    quizz();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("QUIZ FINISHED.YOUR SCORE");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" --->{point}<---");
                    if (point >= 80)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" GOOD JOB :)");
                    }
                    else if (point >= 50 && point < 80)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" NOT BAD");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" MAYBE TRY AGAIN");
                    }

                    Thread.Sleep(4000);
                    newGame = false;

                }
                if (exit)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GOOD BYE:)");
                    Console.ForegroundColor = ConsoleColor.White;
                    exit = false;
                    break;

                }

            }
        }
    }
}
