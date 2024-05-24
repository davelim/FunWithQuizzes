namespace FunWithQuizzes;

public class Quiz
{
    // field(s)/prop(s)
    // TODO: Dictionary is overkill? Use list?
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
    public void Run() {
        foreach (KeyValuePair<int, Question> kvp in Questions)
        {
            Question q = kvp.Value;
            q.Ask();
            Score += q.Grade();
        }
    }
}