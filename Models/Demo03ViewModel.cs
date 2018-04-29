using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Is3106Lecture12DotNet.Models
{
    public class Demo03ViewModel
    {
        public book[] Books { get; set; }
        public book SelectedBookToView { get; set; }



        public Demo03ViewModel()
        {
        }
    }
}
