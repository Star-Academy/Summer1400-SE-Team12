using System.Collections.Generic;
using Phase11_ASP.Implementations;

namespace Phase11_ASP.Interfaces
{
    internal interface IFilterHandler
    {
        ISet<string> Filter(QueryKeeper queryKeeper);
    }
}