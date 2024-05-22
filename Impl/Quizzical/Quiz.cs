namespace FunWithQuizzes;

public class Quiz
{
    // field(s)/prop(s)
    private Dictionary<int,Question> Questions = [];
    public int Score { get; private set;}
    // constructor(s)
    // - use default constructor
    // override(s)
    // method(s)
    public void AddQuestion(Question q) {
        if (!Questions.Keys.Contains(q._id))
        {
            Questions.Add(q._id, q);
        }
    }
    public void RemoveQuestion(Question q)
    {
        throw new NotImplementedException();
    }
    public void Run() {
        foreach (KeyValuePair<int, Question> kvp in Questions)
        {
            Question q = kvp.Value;
            string ans = q.AskNGetAnswer();
            Score += q.Score(ans);
        }
    }
}