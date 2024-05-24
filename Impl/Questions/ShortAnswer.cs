namespace FunWithQuizzes;

// TODO:
// - when running in git bash terminal, Console.ReadKey() causes an exception:
//   "System.InvalidOperationException: Cannot read keys when either
//    application does not have a console or when console input has been
//    redirected.
//    - see: https://stackoverflow.com/questions/46901071/readkey-invalidoperationexception-application-does-not-have-a-console
// - make 'done' character (ConsoleKey.Enter) configurable?
// - handle arrow keys
// - handle situation where use types too quickly

public class ShortAnswer: Question
{
    // field(s)/prop(s)
    public int Limit {get;} // readonly, assigned in constructor
    System.Text.StringBuilder Answer {get;} // set capacity in constructor, appended in Ask()
    // constructor(s)
    public ShortAnswer(string questionStr, int limit=80)
    : base(questionStr) {
        Limit = limit;
        Answer = new(limit, limit);
    }
    // override(s)
    public override void Ask()
    {
        Console.WriteLine(_questionStr);
        Console.WriteLine($"Please limit answer to {Limit} characters or less ([ENTER] to submit).");
        Console.Write("> ");
        while (true) {
            int length = ListenForKey();
            Console.WriteLine(Constants.DASHED_LINE);
            Console.WriteLine($"Your answer was {length} characters. Please confirm answer [ENTER].");
            Console.WriteLine($"{Answer}");
            Console.WriteLine(Constants.DASHED_LINE);
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter) {
                break;
            }
            Console.WriteLine($"Ok. Please limit answer to {Limit}.");
            Console.Write("> ");
        }
    }
    public override int Grade()
    {
        return Answer.Length != 0 ? 1 : 0;
    }
    // method(s)
    private int ListenForKey() {
        Answer.Clear();
        ConsoleKeyInfo cki;
        do {
            cki = Console.ReadKey();
            try {
                Answer.Append(cki.KeyChar);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine($"{Environment.NewLine}Reached {Limit} character limit.");
                break;
            }
        } while (cki.Key != ConsoleKey.Enter);
        return Answer.Length;
    }
}