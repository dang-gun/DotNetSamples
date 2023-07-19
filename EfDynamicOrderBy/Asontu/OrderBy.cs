using ModelsDB;
using System;
using System.Linq.Expressions;

namespace EfDynamicOrderBy.Asontu;

public class OrderBy<TToOrder, TBy> : IOrderBy
{
    private readonly Expression<Func<TToOrder, TBy>> expression;

    public OrderBy(Expression<Func<TToOrder, TBy>> expression)
    {
        this.expression = expression;
    }

    public dynamic Expression => this.expression;
}



