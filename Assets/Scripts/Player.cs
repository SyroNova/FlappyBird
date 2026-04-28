
[System.Serializable]
public class Player
{
    private int Score { get; set; }

    private string Name { get; set; }


    public Player(int score, string name)
    {
        this.Score = score;
        this.Name = name;
    }
}
