using System;
using System.Collections.Generic;

namespace TaskManagerBackend.Models;

public partial class Task
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsComplete { get; set; }

    public virtual User User { get; set; } = null!;
}
