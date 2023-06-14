﻿using Microsoft.EntityFrameworkCore;
using TechRental.Domain.Core.Orders;
using TechRental.Domain.Core.Users;

namespace TechRental.DataAccess.Abstractions;

public interface IDatabaseContext
{
    DbSet<Order> Orders { get; }

    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}