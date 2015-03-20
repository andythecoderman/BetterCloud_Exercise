using System;

namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// Base class for all POCOs
    /// </summary>
    public abstract class DataObject
    {
        public virtual Guid? Id { get; set; }
    }
}
