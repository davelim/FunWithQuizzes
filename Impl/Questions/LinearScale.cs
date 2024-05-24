namespace FunWithQuizzes;
// TODO: allow user to confirm choice?
public class LinearScale : Question
{
    // field(s)/prop(s)
    public int ScaleStart {get;} // readonly, assigned in constructor
    public int ScaleEnd {get;} // readonly, assigned in constructor
    public int CorrectAnswer {get;} // readonly, assigned in constructor
    public int Answer {get; set;} // assigned in Ask()
    // constructor(s)
    public LinearScale(string questionStr, int correctAnswer, int scaleEnd, int scaleStart = 1)
    : base(questionStr)
    {
        CorrectAnswer = correctAnswer;
        ScaleStart = scaleStart;
        ScaleEnd = scaleEnd;
    }
    // override(s)
    public override void Ask()
    {
        Console.WriteLine(_questionStr);
        Console.WriteLine($"Please from scale [{ScaleStart}-{ScaleEnd}]");
        while (true)
        {
            // TODO:
            // - Let user confirm/start over?
            string? input = Console.ReadLine();
            int choiceInt;
            if (int.TryParse(input, out choiceInt))
            {
                if (choiceInt >= ScaleStart && choiceInt <= ScaleEnd)
                {
                    Answer = choiceInt;
                    break;
                }
            }
            Console.WriteLine($"Sorry, '{input}' is not one of the choices.");
            Console.WriteLine($"Please from scale [{ScaleStart}-{ScaleEnd}]");
        }
    }
    public override int Grade()
    {
        return CorrectAnswer == Answer ? 1 : 0;
    }
    // methods(s)
}