using System.Text;
namespace FunWithQuizzes;

public class Common
{
    public static string ElmtPerLine<T>(List<T> list)
    {
        StringBuilder sb = new();
        for (int i=0; i<list.Count; i++)
        {
            sb.AppendLine($"{i}) {list[i]}");
        }
        return sb.ToString();
    }
    public static string SingleLine(List<string> list)
    {
        return String.Join("|",
          list
          .Select((item, idx) => $"{idx}({list[idx]})"));
    }
}