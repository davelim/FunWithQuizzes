namespace FunWithQuizzes;

public class TrueFalse : Question
{
    // field(s)/prop(s)
    public List<bool> Choices {get;} = [false, true];
    public bool CorrectAnswer {get;} // readonly, assigned in constructor
    public bool Answer {get; set;} // assigned in Ask()
    // constructor(s)
    public TrueFalse(string questionStr, bool correctAnswer)
    : base(questionStr)
    {
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
                if (choiceInt == 0 || choiceInt == 1)
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
        return CorrectAnswer == Answer ? 1 : 0;
    }
    // methods(s)
}