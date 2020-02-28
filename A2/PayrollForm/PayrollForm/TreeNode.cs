using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollForm
{
    class TreeNode<T>
    {
        public T Element { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T element)
        {
            this.Element = element;
        }

        // display method which indicates on which side the node is and whether it is a leaf
        public override string ToString()
        {
            string nodeString = "[" + this.Element + " ";

            if (this.Left == null && this.Right == null)
            {
                nodeString += " (Leaf)";
            }

            if (this.Left != null)
            {
                nodeString += "Left: " + this.Left.ToString() + "\n"; 
            }

            if (this.Right != null)
            {
                nodeString += "Right: " + this.Right.ToString();
            }

            nodeString += "] ";

            return nodeString;
        }

    }
}
