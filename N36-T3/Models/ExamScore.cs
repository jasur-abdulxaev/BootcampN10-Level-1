namespace N36_T3.Models;

public class ExamScore
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; set; }

    public ExamScore(Guid userId, int score)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Score = score;
    }
}
