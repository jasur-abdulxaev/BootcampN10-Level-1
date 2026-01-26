var play = true;
Random random = new Random();

while (play)
{
    char player = ' ';
    char comp = ' ';

    char[,] board =
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };

    // Player belgi tanlash
    while (true)
    {
        Console.Write("Please select (x, 0): ");
        var input = Console.ReadLine();

        if (input == "x")
        {
            player = 'x';
            comp = '0';
            break;
        }
        else if (input == "0")
        {
            player = '0';
            comp = 'x';
            break;
        }
        Console.WriteLine("Noto‘g‘ri kiritildi!");
    }

    while (true)
    {
        Console.Clear();

        // Computer move (agar joy bo‘lsa)
        if (HasEmpty(board))
        {
            while (true)
            {
                int x = random.Next(0, 3);
                int y = random.Next(0, 3);

                if (board[x, y] == ' ')
                {
                    board[x, y] = comp;
                    break;
                }
            }
        }

        Draw(board);

        if (IsWinner(board, comp))
        {
            Console.WriteLine("Dastur yutdi!!!");
            if (!AskContinue()) play = false;
            break;
        }

        if (IsDraw(board))
        {
            Console.WriteLine("Durrang!!!");
            if (!AskContinue()) play = false;
            break;
        }

        // Player move
        while (true)
        {
            Console.Write("Qator (1-3): ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Katak (1-3): ");
            int y = Convert.ToInt32(Console.ReadLine());

            if (x < 1 || x > 3 || y < 1 || y > 3)
            {
                Console.WriteLine("Chegaradan tashqarida!");
            }
            else if (board[x - 1, y - 1] != ' ')
            {
                Console.WriteLine("Bu joy band!");
            }
            else
            {
                board[x - 1, y - 1] = player;
                break;
            }
        }

        Console.Clear();
        Draw(board);

        if (IsWinner(board, player))
        {
            Console.WriteLine("Siz yutdingiz!!!");
            if (!AskContinue()) play = false;
            break;
        }

        if (IsDraw(board))
        {
            Console.WriteLine("Durrang!!!");
            if (!AskContinue()) play = false;
            break;
        }
    }
}

// ======= yordamchi qismlar =======

static void Draw(char[,] board)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(board[i, j] == ' ' ? "[ ]" : $"[{board[i, j]}]");
        }
        Console.WriteLine();
    }
}

static bool IsWinner(char[,] b, char s)
{
    return
        (b[0, 0] == s && b[0, 1] == s && b[0, 2] == s) ||
        (b[1, 0] == s && b[1, 1] == s && b[1, 2] == s) ||
        (b[2, 0] == s && b[2, 1] == s && b[2, 2] == s) ||
        (b[0, 0] == s && b[1, 0] == s && b[2, 0] == s) ||
        (b[0, 1] == s && b[1, 1] == s && b[2, 1] == s) ||
        (b[0, 2] == s && b[1, 2] == s && b[2, 2] == s) ||
        (b[0, 0] == s && b[1, 1] == s && b[2, 2] == s) ||
        (b[0, 2] == s && b[1, 1] == s && b[2, 0] == s);
}

static bool IsDraw(char[,] board)
{
    foreach (var c in board)
        if (c == ' ')
            return false;
    return true;
}

static bool HasEmpty(char[,] board)
{
    foreach (var c in board)
        if (c == ' ')
            return true;
    return false;
}

static bool AskContinue()
{
    Console.Write("Yana o‘ynaymizmi? (y/n): ");
    return Console.ReadLine() == "y";
}
