﻿

using Shared.Interfaces;

namespace Shared.Models;

public class Customer : ICustomer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

}
