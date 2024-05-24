using FunWithQuizzes;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Quiz quiz = new ();
Question q1 = new MultipleChoice(
    "What is the correct modifier to declare a member belongs to the class/type (not object)?",
    ["class", "static", "type", "delegate", "this"],
    "static");
quiz.AddQuestion(q1);
Question q2 = new CheckBox(
    "What are C# access modifiers?",
    ["public", "protected internal", "protected", "internal", "private protected", "private", "file", "assembly"],
    ["public", "protected internal", "protected", "internal", "private protected", "private", "file"]);
quiz.AddQuestion(q2);
Question q3 = new TrueFalse(
    "We have to declare a private field when we declare a public property.",
    false
);
quiz.AddQuestion(q3);

// more questions
quiz.AddQuestion(new ShortAnswer("<Short answer question>?", 80));
quiz.AddQuestion(new LinearScale("<Linear scale question>?", 42, 50));

quiz.Run();
Console.WriteLine($"score: {quiz.Score}");