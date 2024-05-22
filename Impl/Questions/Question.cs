namespace FunWithQuizzes;

public abstract class Question
{
    // field(s)/prop(s)
    private static int nextId = 1;
    public readonly int _id; // init in constructor
    public readonly string _questionStr;
    // constructor(s)
    public Question(string questionStr)
    {
        _id = nextId++;
        _questionStr = questionStr;
    }
    // override(s)
    // method(s)
    public abstract string AskNGetAnswer();
    public abstract int Score(string answer);
}