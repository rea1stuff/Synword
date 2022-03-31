﻿using Ardalis.Specification.EntityFrameworkCore;
using Synword.Domain.Interfaces;

namespace Synword.Infrastructure.Data;

public class UserDataRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public UserDataRepository(UserDataContext dbContext) : base(dbContext)
    {
    }
}
