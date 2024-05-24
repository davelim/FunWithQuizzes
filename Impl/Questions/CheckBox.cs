using System.Text;
namespace FunWithQuizzes;

public class CheckBox : Question
{
    // field(s)/prop(s)
    public List<string> Choices {get;} // readonly, assigned in constructor
    public List<string> CorrectAnswer {get;} // readonly, assigned in constructor
    public List<string> Answer {get;} = []; // elements assigned in Ask()
    // constructor(s)
    public CheckBox(string questionStr, List<string> choices, List<string> correctAnswer)
    : base(questionStr)
    {
        Choices = choices;
        CorrectAnswer = correctAnswer;
    }
    // override(s)
    public override void Ask()
    {
        Console.WriteLine(_questionStr);
        Console.WriteLine("Please choose all that apply:");
        Console.WriteLine(Common.ElmtPerLine(Choices));
        while (true)
        {
            // TODO:
            // - Lot's nested 'if', is there a cleaner way to do this?
            // - Let user choose to clear choices and start over?
            string? input = Console.ReadLine();
            if (input != null && input =="") 
            {
                break;
            }
            int choiceInt;
            if (int.TryParse(input, out choiceInt))
            {
                if (choiceInt >= 0 && choiceInt < Choices.Count)
                {
                    if (!Answer.Contains(Choices[choiceInt]))
                    {
                        Answer.Add(Choices[choiceInt]);
                    }
                    Console.WriteLine("Your choice(s) so far:");
                    Console.WriteLine($"> {Common.SingleLine(Answer)}");
                    Console.WriteLine("Choose another, or [ENTER] to be done.");
                }
            }
        }
    }
    public override int Grade()
    {
        // TODO: more sophisticate algo for 'partial' credit?
        List<string> correctNotAnswer = CorrectAnswer.Except(Answer).ToList();
        List<string> answerNotCorrect = Answer.Except(CorrectAnswer).ToList();
        return !correctNotAnswer.Any() && !answerNotCorrect.Any() ? 1 : 0;
    }
    // methods(s)
}