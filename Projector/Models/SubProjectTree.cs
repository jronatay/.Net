using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projector.Models
{
    public class SubProjectTree
    {
        public SubProjectTree()
        {
            this.tree = new List<SubProjectTree>();
        }
        public int id { get; set; }
        public string name {get;set;}
        public List<SubProjectTree> tree {get;set;}
    }
}