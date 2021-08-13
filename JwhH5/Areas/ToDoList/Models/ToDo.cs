using System;
using System.Collections.Generic;

#nullable disable

namespace JwhH5.Areas.ToDoList.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
    }
}
