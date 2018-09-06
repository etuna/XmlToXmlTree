using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToXmlTree
{
    class Node
    {

        public string name { get; set; }
        public string value { get; set; }
        public Node parent { get; set; }
        public ArrayList children { get; set; }
        public Boolean IsLeaf { get; set; }

        public Node(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public Boolean isLeafCheck()
        {
            return children.Count == 0;
        }



    }
}
