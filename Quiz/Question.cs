using System.Collections.Generic;

namespace Quiz
{
    public class Question
    {
        public int Number { get; set; }
        public string QuestionText { get; set; }
        public int CorrectAnswer { get; set; }
        public Dictionary<int, string> Options { get; set; }
    }
}
