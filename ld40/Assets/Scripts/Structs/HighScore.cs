[System.Serializable]
public struct HighScore
{
    public string username;
    public string score;

    public HighScore(string _username, string _score)
    {
        username = _username;
        score = _score;
    }
}