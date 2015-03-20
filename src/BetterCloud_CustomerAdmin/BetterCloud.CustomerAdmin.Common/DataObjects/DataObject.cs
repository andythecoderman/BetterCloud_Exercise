using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// Base class for all POCOs
    /// </summary>
    public abstract class DataObject
    {
        public virtual Guid Id { get; set; }
    }
}
