using System.Text;
namespace FunWithQuizzes;

public class MultipleChoice : Question
{
    // field(s)/prop(s)
    public readonly List<string> _choices;
    private readonly string _correctAnswer;
    // constructor(s)
    public MultipleChoice(string questionStr, List<string> choices, string correctAnswer)
    : base(questionStr)
    {
        _choices = choices;
        _correctAnswer = correctAnswer;
    }
    // override(s)
    // methods(s)
    public override string AskNGetAnswer()
    {
        int userChoice;
        bool correctFormat;
        Console.WriteLine(BuildQuestion());
        do {
            // TODO(s):
            // - handle case where Console.ReadLine() returns 'null'
            // - add prompt to remind user of available choices
            string? answer = Console.ReadLine();
            correctFormat = int.TryParse(answer, out userChoice);
        } while (!correctFormat || userChoice < 0 || userChoice > _choices.Count - 1);
        return _choices[userChoice];
    }

    private StringBuilder BuildQuestion()
    {
        string choiceIndices =
          String.Join(", ", Enumerable.Range(0, _choices.Count));
        StringBuilder sb = new();
        sb.AppendLine(_questionStr);
        sb.AppendLine($"Please choose one of [{choiceIndices}]:");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"{i} - {_choices[i]}");
        }
        return sb;
    }
    public override int Score(string answer)
    {
        return answer.Equals(_correctAnswer) ? 1 : 0;
    }
}