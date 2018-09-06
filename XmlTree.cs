using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToXmlTree
{
    class XmlTree
    {
        private Node root;
        private ArrayList nodes;


        public Node Insert(Node parentNode, Node n)

        {
            if (parentNode == null) // If tree is empty
            {
               
                n.IsLeaf = true;
                root = n;
            }
            else // If tree is not empty
            {
                parentNode.children.Add(n); // Add to parent node's children
                n.parent = parentNode;      

                if (parentNode.IsLeaf)
                {
                    parentNode.IsLeaf = false;
                }

                n.IsLeaf = true;
            }


            nodes.Add(n);
            return n;
        }


        public Node Delete(Node n)
        {
            Node parent = n.parent;
            
            if(parent == null)
            {
                //deletion of root
                return null;
            }

            foreach(Node child in n.children)
            {
                parent.children.Add(child);
                child.parent = parent;
            }

            if(parent.children.Count == 0)
            {
                parent.IsLeaf = true;
            }


            return n;
        }


        public Node Update(Node n,string newName, string newVal)
        {
            n.name = newName;
            n.value = newVal;

            return n;
        }
    }
}
