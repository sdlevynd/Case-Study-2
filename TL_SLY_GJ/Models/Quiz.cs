using System;
using System.Collections.Generic;

namespace TL_SLY_GJ.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int? UserId { get; set; }

    public int? SubjectId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
