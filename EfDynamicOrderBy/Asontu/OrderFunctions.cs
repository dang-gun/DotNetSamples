using ModelsDB;


namespace Utility.AsontuDynamicOrderBy;

public static class OrderFunctions
{
    /// <summary>
    ///Code that needs mapping from string to ordering-expression. 
    /// </summary>
    public static readonly Dictionary<string, IOrderBy> OrderFunctionList =
        new Dictionary<string, IOrderBy>
        {
            { "Int", new OrderBy<TestOrderBy, int>(x => x.Int) },
            { "Str", new OrderBy<TestOrderBy, string>(x => x.Str) },
            { "Date", new OrderBy<TestOrderBy, DateTime>(x => x.Date) }
        };

    /// <summary>
    ///Code that needs mapping from string to ordering-expression. 
    /// </summary>
    public static readonly Dictionary<string, IOrderBy> OrderFunctionList_Big =
        new Dictionary<string, IOrderBy>
        {
            { "Int", new OrderBy<TestOrderBy_Big, int>(x => x.Int) },
            { "Str", new OrderBy<TestOrderBy_Big, string>(x => x.Str) },
            { "Date", new OrderBy<TestOrderBy_Big, DateTime>(x => x.Date) }
        };


}
