using System;

namespace Domain.Entities;

public class User
{
    public string Id { get; }

    public User()
    {
        Id = Guid.NewGuid().ToString("D");
    }
}
