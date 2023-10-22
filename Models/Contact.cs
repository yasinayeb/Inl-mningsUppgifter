﻿
using System.Diagnostics.CodeAnalysis;

namespace InlämningsUppgiften.Models;

public class Contact
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Address Address { get; set; } = null!;
}
