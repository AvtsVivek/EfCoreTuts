using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class Folder
    {
        public Folder()
        {
            InverseParent = new HashSet<Folder>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Folder? Parent { get; set; }
        public virtual ICollection<Folder> InverseParent { get; set; }
    }
}
