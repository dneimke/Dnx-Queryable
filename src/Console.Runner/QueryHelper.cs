// <copyright file="QueryHelper.cs" company="Oconics Pty Ltd">
// Copyright (c) 2015 Oconics Pty Ltd. All rights reserved.
// </copyright>
// <author>Jonathan Ruckert</author>
// <date>13/07/2015</date>
// <summary>Implements the query helper class</summary>
namespace Parliament.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public static class QueryHelper
    {
        public static bool PropertyExists<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        public static Expression<Func<T, string>> GetPropertyExpression<T>(string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }

            var paramterExpression = Expression.Parameter(typeof(T));

            return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName), paramterExpression);
        }

        public static Expression<Func<T, int>> GetPropertyExpressionInt<T>(string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }

            var paramterExpression = Expression.Parameter(typeof(T));

            return (Expression<Func<T, int>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName), paramterExpression);
        }
    }
}
