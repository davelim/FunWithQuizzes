using System.Text;
namespace FunWithQuizzes;

public class TrueFalse : Question
{
    // field(s)/prop(s)
    private readonly bool _correctAnswer;
    // constructor(s)
    public TrueFalse(string questionStr, bool correctAnswer)
    : base(questionStr)
    {
        _correctAnswer = correctAnswer;
    }
    // override(s)
    // methods(s)
    public override string AskNGetAnswer()
    {
        string userChoice;
        Console.WriteLine(BuildQuestion());
        while (true)
        {
            string? answer = Console.ReadLine();
            if (answer != null
                && (answer.Contains("t") 
                    || answer.Contains("T")
                    || answer.Contains("f")
                    || answer.Contains("F")))
            {
                userChoice = ParseChoice(answer);
                break;
            }
            Console.WriteLine($"'{answer}' is not an option. Please choose [T/F]");
        }
        return userChoice;
    }
    private string ParseChoice(string str)
    {
        if (str.Contains("t") || str.Contains("T"))
        {
            return "T";
        }
        else
        {
            return "F";
        }
    }
    private bool ParseBool(string str)
    {
        if (str.Contains("t") || str.Contains("T"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override int Score(string answer)
    {
        return _correctAnswer == ParseBool(answer) ? 1 : 0;
    }
    private StringBuilder BuildQuestion()
    {
        return new StringBuilder($"{_questionStr}. Please choose [T/F]");
    }

}