using System.Collections.Generic;

namespace TaskManagement.Models
{

    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoItem> TodoItem { get; set; }


        public Project()
        {

        }

        public Project(string name)
        {
            this.Name = name;
        }
    }
}