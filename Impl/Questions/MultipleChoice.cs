using System.Text;
namespace FunWithQuizzes;

public class MultipleChoice : Question
{
    // field(s)/prop(s)
    public List<string> Choices {get;} // readonly, assigned in constructor
    public string CorrectAnswer {get;} // readonly, assigned in constructor
    public string? Answer {get; set;} // assigned in Ask()
    // constructor(s)
    public MultipleChoice(string questionStr, List<string> choices, string correctAnswer)
    : base(questionStr)
    {
        Choices = choices;
        CorrectAnswer = correctAnswer;
    }
    // override(s)
    public override void Ask()
    {
        Console.WriteLine(_questionStr);
        Console.WriteLine("Please choose one:");
        Console.WriteLine(Common.ElmtPerLine(Choices));
        while (true)
        {
            // TODO: 
            // - Let user confirm/start over?
            string? input = Console.ReadLine();
            int choiceInt;
            if (int.TryParse(input, out choiceInt))
            {
                if (choiceInt >= 0 && choiceInt < Choices.Count)
                {
                    Answer = Choices[choiceInt];
                    break;
                }
            }
            Console.WriteLine($"Sorry, '{input}' is not one of the choices.");
            Console.WriteLine("Please choose one:");
            Console.WriteLine(Common.ElmtPerLine(Choices));
        }
    }
    public override int Grade()
    {
        return Answer != null && Answer.Equals(CorrectAnswer) ? 1 : 0;
    }
    // methods(s)
}