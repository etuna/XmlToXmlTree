using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlToXmlTree
{
    class Program
    {
        static XmlDocument doc;
        static string path = "C:/Users/etuna/source/repos/XmlToSql/newtest.xml";

        static void Main(string[] args)
        {
            Init(path);
        }


        /// <summary>
        /// It initiates the process, loads document given a path
        /// </summary>
        /// <param name="mpath"></param>
        public static void Init(string mpath)
        {
            doc = new XmlDocument();
            if (File.Exists(mpath))
            {
                doc.Load(mpath);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }


        static ArrayList generateTrees()
        {
            ArrayList xmlTrees = new ArrayList();
            int numChild = doc.ChildNodes.Count;

            if (numChild == 0)
            {
                return xmlTrees;
            }
            else
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    XmlTree aTree = new XmlTree();
                    generateXmlTree(aTree, node);
                    xmlTrees.Add(aTree);
                }
            }
            return xmlTrees;
        }

        static void generateXmlTree(XmlTree tree, XmlNode node)
        {

            if (node.HasChildNodes)
            {
                string name = node.Name;
                string value = node.InnerText.ToString();
                Node mNode = new Node(name, value);
                tree.Insert(mNode.parent, mNode);

                foreach (XmlNode mnode in node.ChildNodes)
                {
                    generateXmlTree(tree, mnode);
                }

            }
            else
            {
                if (node.Attributes.Count != 0)
                {
                    foreach(XmlAttribute a in node.Attributes)
                    {
                        string name = a.Name;
                        string value = node.Attributes[name].Value.ToString();
                        Node mNode = new Node(name, value);
                        tree.Insert(mNode.parent, mNode);
                    }
                }
                else
                {
                    string name = node.Name;
                    string value = node.InnerText.ToString();
                    Node mNode = new Node(name, value);
                    tree.Insert(mNode.parent, mNode);
                }

            }

        }
    }
}
