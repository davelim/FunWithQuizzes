using System.Text;
namespace FunWithQuizzes;

public class CheckBox : Question
{
    // field(s)/prop(s)
    public readonly List<string> _choices;
    private readonly string _choicesIndices;
    private readonly List<string> _correctAnswers;
    // constructor(s)
    public CheckBox(string questionStr, List<string> choices, List<string> correctAnswers)
    : base(questionStr)
    {
        _choices = choices;
        _choicesIndices = String.Join(", ", Enumerable.Range(0, _choices.Count));
        _correctAnswers = correctAnswers;
    }
    // override(s)
    // TODO: AskNGetAnswer() and Score(string) are abstract methods that
    //   return a string and accept a string as a parameter. This is
    //  inefficient for CheckBox question. Fix.
    public override string AskNGetAnswer()
    {
        List<int> userChoices;
        Console.WriteLine(BuildQuestion());
        while (true)
        {
            string? input = Console.ReadLine();
            userChoices = ParseInts(input);
            Console.WriteLine($"Please confirm you chose: {String.Join(", ", userChoices)} [y]");
            input = Console.ReadLine();
            if (input == null || input.Equals("")
                || input.Contains("y") || input.Contains("Y"))
            {
                break;
            }
        }
        return String.Join(" ", userChoices);
    }
    public override int Score(string answer)
    {
        int score = 0;
        foreach (string s in answer.Split(" "))
        {
            int choice;
            if (int.TryParse(s, out choice) &&
                _correctAnswers.Contains(_choices[choice]))
            {
                score += 1;
            }
        }
        return score;
    }
    // methods(s)
    private List<int> ParseInts(string? str)
    {
        List<int> ints = new();
        if (str == null || str.Equals(""))
        {
            return ints;
        }
        for (int i=0; i<str.Length; i++)
        {
            int parsedInt;
            if (int.TryParse(str[i].ToString(), out parsedInt))
            {
                if (!ints.Contains(parsedInt))
                {
                    ints.Add(parsedInt);
                }
            }
        }
        return ints;
    }
    private StringBuilder BuildQuestion()
    {
        StringBuilder sb = new();
        sb.AppendLine(Constants.DASHED_LINE);
        sb.AppendLine(_questionStr);
        sb.AppendLine($"Please choose all that apply [{_choicesIndices}]");
        for (int i = 0; i < _choices.Count; i++)
        {
            sb.AppendLine($"> {i} - {_choices[i]}");
        }
        return sb;
    }
}