namespace lab1;
class GameAccount
{
    private int rating = 1;
    public string UserName { get; private set; }
    public int CurrentRating
    {
        get
        { return rating; }
        set
        {
            if (value < 1)
            {
                rating = 1;
            }
            else
            {
                rating = value;
            }
        }
    }
    public int GamesCount
    {
        get
        {
            return gamesHistory.Count;
        }
    }

    private List<Game> gamesHistory;

    public GameAccount(string userName)
    {
        UserName = userName;
        gamesHistory = new List<Game>();
    }

    public void WinGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating is less than 0.");
        }

        CurrentRating += rating;
        Game game = new Game(opponentName, "Won", rating);
        gamesHistory.Add(game);
    }

    public void LoseGame(string opponentName, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating is less than 0.");
        }

        CurrentRating -= rating;

        Game game = new Game(opponentName, "Lost", rating);
        gamesHistory.Add(game);
    }

    public void GetStats()
    {
        Console.WriteLine($"\nGames played in {UserName}:");
        foreach (var game in gamesHistory)
        {
            Console.WriteLine($"{game.Index} | {game.OpponentName} | {game.Result} | {game.Rating}");
        }
    }
    public void PlayerStats()
    {
        Console.WriteLine($"\nStats of {UserName}:");
        Console.WriteLine($"\nCurrentRating | GamesCount");
        Console.WriteLine($"{CurrentRating} | {GamesCount}");
    }
}