using System.Text;
namespace FunWithQuizzes;

public class MultipleChoice : Question
{
    // field(s)/prop(s)
    public readonly List<string> _choices;
    private readonly string _choiceIndices;
    private readonly string _correctAnswer;
    // constructor(s)
    public MultipleChoice(string questionStr, List<string> choices, string correctAnswer)
    : base(questionStr)
    {
        _choices = choices;
        _choiceIndices = String.Join(", ", Enumerable.Range(0, _choices.Count));
        _correctAnswer = correctAnswer;
    }
    // override(s)
    // methods(s)
    public override string AskNGetAnswer()
    {
        int userChoice = -1;
        bool correctFormat = false;
        Console.WriteLine(BuildQuestion());
        while (true)
        {
            // TODO(s):
            // - handle case when Console.ReadLine() returns 'null'
            // - allow user go to next question
            string? answer = Console.ReadLine();
            correctFormat = int.TryParse(answer, out userChoice);
            if (correctFormat && userChoice >= 0 && userChoice < _choices.Count)
            {
                break;
            }
            Console.WriteLine($"'{answer}' is not one of the options. Please choose one of [{_choiceIndices}]");
        }
        return _choices[userChoice];
    }

    private StringBuilder BuildQuestion()
    {
        StringBuilder sb = new();
        sb.AppendLine(Constants.DASHED_LINE);
        sb.AppendLine(_questionStr);
        sb.AppendLine($"Please choose one of [{_choiceIndices}]:");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"> {i} - {_choices[i]}");
        }
        return sb;
    }
    public override int Score(string answer)
    {
        return answer.Equals(_correctAnswer) ? 1 : 0;
    }
}