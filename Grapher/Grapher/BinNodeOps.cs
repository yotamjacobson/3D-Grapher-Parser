using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher
{
    class BinNodeOps<t>
    {      

        public int CountLeaves(BinNode<t> node)
        {
            if (node == null)
                return 0;
            if (node.GetLeft() == null & node.GetRight() == null)
                return 1;
            return (CountLeaves(node.GetLeft()) + CountLeaves(node.GetRight())); ;
        }

        public int CountHalves(BinNode<t> node)
        {
            if (node == null)
                return 0;
            if (node.GetLeft() == null & node.GetRight() != null || node.GetLeft() != null & node.GetRight() == null)
                return 1 + CountHalves(node.GetLeft()) + CountHalves(node.GetRight());
            return CountHalves(node.GetLeft()) + CountHalves(node.GetRight());
        }

        public bool IsAllPos(BinNode<int> node)
        {
            if (node == null)
                return true;
            if (node.GetValue() <= 0)
                return false;
            return IsAllPos(node.GetLeft()) && IsAllPos(node.GetRight());
        }

        public bool IsRightLeft(BinNode<t> node)
        {
            if (node == null)
                return true;
            if (node.GetLeft() == null & node.GetRight() == null)
                return true;
            if (node.GetLeft() == null && node.GetRight() != null)
                return false;
            return IsRightLeft(node.GetLeft()) && IsRightLeft(node.GetRight());
        }

        public BinNode<int> BuildTreePre(string[] preOrder, string[] inOrder)
        {
            int i = 0;
            BinNode<int> newTree = new BinNode<int>(int.Parse(preOrder[0]));

            while (preOrder[0] != inOrder[i])
                i++;

            if (i > 0)
            {
                string[] preOrderL = new string[i];
                string[] inOrderL = new string[i];
                for (int j = 0; j < i; j++)
                {
                    preOrderL[j] = preOrder[j + 1];
                    inOrderL[j] = inOrder[j];
                }
                newTree.SetLeft(BuildTreePre(preOrderL, inOrderL));
            }

            if (i < inOrder.Length - 1)
            {
                string[] preOrderR = new string[preOrder.Length - i - 1];
                string[] inOrderR = new string[preOrder.Length - i - 1];
                for (int j = i + 1; j < inOrder.Length; j++)
                {
                    preOrderR[j - i - 1] = preOrder[j];
                    inOrderR[j - i - 1] = inOrder[j];
                }
                newTree.SetRight(BuildTreePre(preOrderR, inOrderR));
            }
            return newTree;
        }
        public BinNode<int> BuildTreePost(string[] postOrder, string[] inOrder)
        {
            int i = inOrder.Length - 1;
            BinNode<int> newTree = new BinNode<int>(int.Parse(postOrder[inOrder.Length - 1]));

            while (postOrder[inOrder.Length - 1] != inOrder[i])
                i--;

            if (i > 0)
            {
                string[] postOrderL = new string[i];
                string[] inOrderL = new string[i];
                for (int j = 0; j < i; j++)
                {
                    postOrderL[j] = postOrder[j];
                    inOrderL[j] = inOrder[j];
                }
                newTree.SetLeft(BuildTreePost(postOrderL, inOrderL));
            }

            if (i < inOrder.Length - 1)
            {
                string[] postOrderR = new string[postOrder.Length - i - 1];
                string[] inOrderR = new string[postOrder.Length - i - 1];
                for (int j = i + 1; j < inOrder.Length; j++)
                {
                    postOrderR[j - i - 1] = postOrder[j - 1];
                    inOrderR[j - i - 1] = inOrder[j];
                }
                newTree.SetRight(BuildTreePost(postOrderR, inOrderR));
            }
            return newTree;
        }

        public BinNode<string> ToTree(string[] input)
        {
            // closing if input is empty
            if (input.Length == 0)
                return null;

            // turning all letters to lower case
            for (int j = 0; j < input.Length - 1; j++)
            {
                input[j] = input[j].ToLower();
            }

            BinNode<string> newTree = new BinNode<string>();           
            int parenthesesDepth = 0;

            int i;

            #region searching operators in order
            for (int round = 0; round < 3; round++)
            {
                for (i = input.Length - 1; i >= 0; i--)
                {
                    // updating how many parentheses are open
                    if (input[i] == ")")
                        parenthesesDepth += 1;
                    if (input[i].Contains("("))
                        parenthesesDepth -= 1;

                    #region parentheses stuff
                    if (i == 0)
                    {
                        if (parenthesesDepth == 0 && input[input.Length - 1] == ")")
                        {
                            string[] newInput = new string[input.Length - 2];

                            if (input[0] == "(")
                            {
                                for (int j = 0; j < input.Length - 2; j++)
                                {
                                    newInput[j] = input[j + 1];
                                }
                                input = newInput;
                                round = -1;
                                break;
                            }

                            else if (input[0] == "sin(")
                            {
                                for (int j = 0; j < input.Length - 2; j++)
                                {
                                    newInput[j] = input[j + 1];
                                }
                                newTree.SetLeft(ToTree(newInput));
                                newTree.SetValue("sin");
                                return newTree;
                            }

                            else if (input[0] == "cos(")
                            {
                                for (int j = 0; j < input.Length - 2; j++)
                                {
                                    newInput[j] = input[j + 1];
                                }
                                newTree.SetLeft(ToTree(newInput));
                                newTree.SetValue("cos");
                                return newTree;
                            }

                            else if (input[0] == "tan(")
                            {
                                for (int j = 0; j < input.Length - 2; j++)
                                {
                                    newInput[j] = input[j + 1];
                                }
                                newTree.SetLeft(ToTree(newInput));
                                newTree.SetValue("tan");
                                return newTree;
                            }

                            else if (input[0] == "sqrt(")
                            {
                                for (int j = 0; j < input.Length - 2; j++)
                                {
                                    newInput[j] = input[j + 1];
                                }
                                newTree.SetLeft(ToTree(newInput));
                                newTree.SetValue("sqrt");
                                return newTree;
                            }
                        }
                    }
                    #endregion

                    #region add / sub
                    if ((round == 0 && (input[i] == "+" || input[i] == "-")) && parenthesesDepth == 0)
                    {
                        newTree.SetValue(input[i]);

                        string[] inputL = new string[i];
                        for (int j = 0; j < i; j++)
                        {
                            inputL[j] = input[j];
                        }
                        newTree.SetLeft(ToTree(inputL));

                        string[] inputR = new string[input.Length - i - 1];
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            inputR[j - i - 1] = input[j];
                        }
                        newTree.SetRight(ToTree(inputR));
                        return newTree;
                    }
                    #endregion

                    #region mult / div
                    if ((round == 1 && (input[i] == "*" || input[i] == "/")) && parenthesesDepth == 0)
                    {
                        newTree.SetValue(input[i]);

                        string[] inputL = new string[i];
                        for (int j = 0; j < i; j++)
                        {
                            inputL[j] = input[j];
                        }
                        newTree.SetLeft(ToTree(inputL));

                        string[] inputR = new string[input.Length - i - 1];
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            inputR[j - i - 1] = input[j];
                        }
                        newTree.SetRight(ToTree(inputR));
                        return newTree;
                    }
                    #endregion

                    #region power
                    if (round == 2 && input[i] == "^" && parenthesesDepth == 0)
                    {
                        newTree.SetValue("^");

                        string[] inputL = new string[i];
                        for (int j = 0; j < i; j++)
                        {
                            inputL[j] = input[j];
                        }
                        newTree.SetLeft(ToTree(inputL));

                        string[] inputR = new string[input.Length - i - 1];
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            inputR[j - i - 1] = input[j];
                        }
                        newTree.SetRight(ToTree(inputR));
                        return newTree;
                    }
                    #endregion
                }
            }
            #endregion

            // if no operators were found just return the value
            newTree.SetValue(input[0]);
            return newTree;
        }

        public double Result(BinNode<string> node, double x, double y)
        {
            if (node == null)
                return 0;
            if (node.GetValue() == "+")
                return Result(node.GetLeft(), x, y) + Result(node.GetRight(), x, y);
            if (node.GetValue() == "-")
                return Result(node.GetLeft(), x, y) - Result(node.GetRight(), x, y);
            if (node.GetValue() == "*")
                return Result(node.GetLeft(), x, y) * Result(node.GetRight(), x, y);
            if (node.GetValue() == "/")
                return Result(node.GetLeft(), x, y) / Result(node.GetRight(), x, y);
            if (node.GetValue() == "^")
                return Math.Pow(Result(node.GetLeft(), x, y), Result(node.GetRight(), x, y));
            if (node.GetValue() == "sin")
                return Math.Sin(Result(node.GetLeft(), x, y));
            if (node.GetValue() == "cos")
                return Math.Cos(Result(node.GetLeft(), x, y));
            if (node.GetValue() == "tan")
                return Math.Tan(Result(node.GetLeft(), x, y));
            if (node.GetValue() == "sqrt")
            {
                return Math.Sqrt(Result(node.GetLeft(), x, y));
            }
            if (node.GetValue() == "x")
                return x;
            if (node.GetValue() == "y")
                return y;
            return double.Parse(node.GetValue());
        }

        public void ShowPre(BinNode<t> node)
        {
            if (node != null)
            {
                MessageBox.Show(node.GetValue() + " ");
                ShowPre(node.GetLeft());
                ShowPre(node.GetRight());
            }
        }
        public void ShowIn(BinNode<t> node)
        {
            if (node != null)
            {
                ShowIn(node.GetLeft());
                MessageBox.Show(node.GetValue() + " ");
                ShowIn(node.GetRight());
            }
        }
        public void ShowPost(BinNode<t> node)
        {
            if (node != null)
            {
                ShowPost(node.GetLeft());
                ShowPost(node.GetRight());
                MessageBox.Show(node.GetValue() + " ");
            }
        }
    }
}
