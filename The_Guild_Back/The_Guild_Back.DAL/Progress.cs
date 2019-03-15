using System;
using System.Collections.Generic;

namespace The_Guild_Back.DAL
{
    public partial class Progress
    {
        public Progress()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Nam { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
