using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDynamicOrderBy.Asontu;

public interface IOrderBy
{
    dynamic Expression { get; }
}
