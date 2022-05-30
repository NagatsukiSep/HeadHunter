using ExitGames.Client.Photon;
using Photon.Realtime;
public static class Score
{
    private const string ScoreKey = "Score";
    private static readonly Hashtable scoreTable = new Hashtable();

    public static int GetScore(this Player player)
    {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    public static void AddScore(this Player player, int value)
    {
        scoreTable[ScoreKey] = player.GetScore() + value;
        player.SetCustomProperties(scoreTable);
        scoreTable.Clear();
    }
}
