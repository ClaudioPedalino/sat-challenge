﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sat.Recruitment.Application.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool should, Expression<Func<T, bool>> expression)
            => should
                ? query.Where(expression)
                : query;
    }
}
