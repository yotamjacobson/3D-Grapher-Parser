using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    class BinNode<t>
    {
        BinNode<t> left = null, right = null;
        t value;

        public BinNode()
        { }
        public BinNode(t value, BinNode<t> left, BinNode<t> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public BinNode(t value)
        {
            this.value = value;
        }

        public void SetValue(t newVal)
        {
            value = newVal;
        }
        public t GetValue()
        {
            return value;
        }

        public void SetLeft(BinNode<t> newNode)
        {
            left = newNode;
        }
        public BinNode<t> GetLeft()
        {
            return left;
        }

        public void SetRight(BinNode<t> newNode)
        {
            right = newNode;
        }
        public BinNode<t> GetRight()
        {
            return right;
        }
    }
}
