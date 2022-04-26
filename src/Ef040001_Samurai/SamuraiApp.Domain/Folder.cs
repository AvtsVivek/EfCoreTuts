using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Folder
    {
        private Folder()
        {
            // InverseParent = new HashSet<Folder>();
        }

        public Folder(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Folder? Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Folder> SubFolders { get; } = new List<Folder>();
    }
}
