using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class RequestingGroup
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int CustomerId { get; set; }

        public virtual Users Customer { get; set; }
        public virtual Request Request { get; set; }
    }
}
