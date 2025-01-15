using System;
using System.Collections.Generic;

namespace TL_SLY_GJ.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int QuizId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string Answer1 { get; set; } = null!;

    public string Answer2 { get; set; } = null!;

    public string Answer3 { get; set; } = null!;

    public string Answer4 { get; set; } = null!;

    public int Correct { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;
}
