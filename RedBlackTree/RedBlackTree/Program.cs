using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    
    public class TreeNode
    {
        public int val;
        public string color;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;

        public TreeNode(int val)
        {
            this.left = null;
            this.right = null;
            this.parent = null;
            this.val = val;
            this.color = "BLACK";
        }
        
    }

    public class RBTree
    {
        public TreeNode root;
        public TreeNode Nil;

        public RBTree()
        {
            root = null;
            Nil = new TreeNode(int.MinValue);
            Nil.left = null;
            Nil.right = null;
            Nil.parent = null;
            Nil.color = "BLACK";
        }

        public  TreeNode searchNode(ref TreeNode tempNode, int val)
        { 

            if(tempNode == Nil) // Nil이면 null 리턴
            {
                return null;
            }

            if(tempNode.val > val)  // 작으면 왼쪽
            {
                return searchNode(ref tempNode.left, val);
            }
            else if(tempNode.val < val) // 크면 오른쪽
            {
                return searchNode(ref tempNode.right, val);
            }
            else
            {
                return tempNode;    // 같으면 노드를 리턴
            }
        }

        public TreeNode searchMinNode(ref TreeNode tempNode)
        {
            if(tempNode == Nil)     // 노드가 Nil이면 Nil 리턴
            {
                return Nil;
            }

            if(tempNode.left == Nil)    // 노드의 왼쪽이 Nil이면 tempNode가 제일 작은 수 
            {
                return tempNode;
            }
            else
            {
                return searchMinNode(ref tempNode.left);    // 왼쪽으로 파고 든다.
            }
        }

        public void insertNode(ref TreeNode tempNode, int val)      // insert
        {
            TreeNode newNode = new TreeNode(val);                   // Make new node

            newNode.parent = null;
            newNode.left = null;
            newNode.right = null;
            newNode.val = val;
            newNode.color = "BLACK";                                // new node setting

            insertNodeHelper(ref tempNode,ref newNode);             // binary tree insert

            newNode.color = "RED";
            newNode.left = Nil;
            newNode.right = Nil;                                    // new node "RED" color, left, right Nil setting
            

            rebuildAfterInsert(ref tempNode, ref newNode);          // balancing


        }

        public void insertNodeHelper(ref TreeNode tempNode, ref TreeNode newNode)       // tempNode == 상위노드
        {
            if(root == null)                                                            // 일반적인 Binay Tree insert 과정을 recurcive하게 만듦.
            {
                root = newNode;
            }

            if(tempNode.val < newNode.val)  // 크면 오른쪽 작으면 왼쪽
            {
                if(tempNode.right == Nil)   // right가 Nil이면 오른쪽에 붙여준다.
                {
                    tempNode.right = newNode;
                    newNode.parent = tempNode;
                }
                else
                {
                    insertNodeHelper(ref tempNode.right, ref newNode);  // right가 Nil이 아니면 오른쪽으로 접근
                }
            }
            else if(tempNode.val > newNode.val)
            {
                if (tempNode.left == Nil)   // left가 Nil이면 왼쪽에 붙여준다.
                {
                    tempNode.left = newNode;
                    newNode.parent = tempNode;
                }
                else
                {
                    insertNodeHelper(ref tempNode.left, ref newNode);   // left가 Nil이 아니면 왼쪽으로 접근
                }
            }
        }

        public void rotateRight(TreeNode tempNode, TreeNode parent)
        {
            TreeNode leftChild = parent.left;           // 

            parent.left = leftChild.right;              // 왼쪽 자식의 오른쪽 자식을 기준 노드의 left에 붙여준다.

            if(leftChild.right != Nil)                  // 왼쪽 자식의 오른쪽 자신이 Nil이 아니면 부모를 기준 노드로 설정
            {
                leftChild.right.parent = parent;
            }


            leftChild.parent = parent.parent;           // 왼쪽 자식의 부모는 기준 노드의 부모로

            if (parent.parent == null)                  // 기준 노드의 부모가 null이면 루트 노드
            {
                root = leftChild;
            }
            else
            {                                           // root 노드가 아니고
                if(parent == parent.parent.left)        // 부모 노드의 왼쪽이 기준 노드이면
                {
                    parent.parent.left = leftChild;     // 왼쪽에 왼쪽 자식을 붙인다.
                }
                else
                {
                    parent.parent.right = leftChild;    // 오른쪽이 기준 노드이면 오른쪽에 붙인다.
                }
            }

            leftChild.right = parent;                   // 왼쪽 자식의 오른쪽에 기준 노드를 붙이고
            parent.parent = leftChild;                  // 기준 노드의 부모를 왼쪽 자식으로 해준다.
        }

        public void rotateLeft(TreeNode tempNode, TreeNode parent)
        {
            TreeNode rightChild = parent.right;

            parent.right = rightChild.left;             // 기준 노드의 오른쪽에 오른쪽 자식의 왼쪽 노드를 붙인다.

            if (rightChild.left != Nil)                 // 오른쪽 자식의 왼쪽 노드가 Nil이 아니면
            {
                rightChild.left.parent = parent;        // 오른쪽 자식의 왼쪽 노드의 부모를 기준 노드로 해준다.
            }


            rightChild.parent = parent.parent;          // 오른쪽 자식의 부모 노드를 기준 노드의 부모로 설정

            if (parent.parent == null)                  // 기준 노드가 root 이면 오른쪽 자식을 root로 설정
            {
                root = rightChild;
            }
            else
            {                                           // root가 아니면
                if (parent == parent.parent.left)       // 기준 노드가 부모의 왼쪽 자식이면
                {
                    parent.parent.left = rightChild;    // 기준 노드의 부모 노드의 왼쪽에 오른쪽 자식을 붙여준다.
                }
                else
                {                                       // 부모 노드의 오른쪽 자식이면
                    parent.parent.right = rightChild;   // 오른쪽에 오른쪽 자식을 붙여준다.
                }
            }

            rightChild.left = parent;                   // 오른쪽 자식의 왼쪽에 기준 노드를 붙이고
            parent.parent = rightChild;                 // 기준 노드의 부모 노드를 오른쪽 자식으로 설정
        }

        public void rebuildAfterInsert(ref TreeNode tempNode,ref TreeNode X)        // balancing
        {
            while(X != root && string.Equals(X.parent.color,"RED")) // 새로 들어온 인스턴스가 root라면 건너 뜀. 부모의 color가 "RED"라면
            {
                if(X.parent == X.parent.parent.left)        // X의 부모가 Grand Parent의 왼쪽 자식이라면
                {
                    TreeNode uncle = X.parent.parent.right; // 오른쪽은 삼촌이 된다.

                    if(string.Equals(uncle.color,"RED"))    // 삼촌이 "RED"라면
                    {
                        X.parent.color = "BLACK";           // 부모는 "BLACK"
                        uncle.color = "BLACK";              // 삼촌은 "BLACK"
                        X.parent.parent.color = "RED";      // Grand Parent는 "RED"

                        X = X.parent.parent;                // X는 Grand Parent
                    }
                    else
                    {                                       // 삼촌이 "BLACK" 이면
                        if(X == X.parent.right)             // X가 오른쪽 자식이면
                        {
                            X = X.parent;                   // X는 부모
                            rotateLeft(tempNode,X);         // 왼쪽회전
                        }

                        X.parent.color = "BLACK";    // 부모는 "BLACK"
                        X.parent.parent.color = "RED"; // Grand Parent는 "RED"

                        rotateRight(tempNode,X.parent.parent);  // X Grand Parent 기준으로 오른쪽 회전
                    }
                }
                else
                {   // 부모 노드가 right
                    TreeNode uncle = X.parent.parent.left;      // 삼촌 노드가 Left

                    if(string.Equals(uncle.color,"RED"))        // 삼촌 노드가 "RED"
                    {
                        X.parent.color = "BLACK";               // 부모 노드를 "BLACK"
                        uncle.color = "BLACK";                  // 삼촌 노드를 "BLACK"
                        X.parent.parent.color = "RED";          // Grand Parent의 노드를 "RED"

                        X = X.parent.parent;                    // X는 Grand Parent
                    }
                    else
                    {                                           // 삼촌 노드가 "BLACK"
                        if(X == X.parent.left)                  // X가 왼쪽 자식이면
                        {
                            X = X.parent;                       // X를 X의 부모로
                            rotateRight(tempNode, X);           // 오른쪽 회전
                        }

                        X.parent.color = "BLACK";               // X 부모의 색깔을 "BLACK"
                        X.parent.parent.color = "RED";          // X Grand Parent 색깔을 "RED"

                        rotateLeft(tempNode, X.parent.parent);  // X Grand Parent 기준으로 왼쪽 회전
                    }
                }
            }

            root.color = "BLACK";                                   // root는 무조건 "BLACK"
        }

        public TreeNode removeNode(ref TreeNode tempNode, int data) // tempNode == 해당 노드
        {
            TreeNode removed = null;
            TreeNode successor = null;
            TreeNode target = searchNode(ref tempNode, data);       // 타겟 노드를 찾음

            if(target == null)                                      // 없으면 null값 리턴
            {
                return null;
            }

            if(target.left==Nil || target.right == Nil)             // target의 Left나 right가 Nil이면 단말노드 이므로 지울 노드를 target으로 설정
            {
                removed = target;
            }
            else
            {                                                       // 아니면 오른쪽에서 가장 작은 수를 찾는다.
                removed = searchMinNode(ref target.right);
                target.val = removed.val;                           // target 값을 지울 값으로 설정
            }

            if(removed.left != Nil)                                 // 지울 노드의 left가 Nil이 아니면 successor를 지울 노드의 왼쪽으로 설정.
            {
                successor = removed.left;
            }
            else
            {                                                       // 오른쪽이 Nil이 아니면 오른쪽으로 설정
                successor = removed.right;
            }

            successor.parent = removed.parent;                      // successor의 부모를 지울 노드의 부모로 설정

            if(removed.parent == null)                              // 지울 노드의 부모가 null이면 successor를 루트로 지정
            {
                root = successor;
            }
            else
            {
                if(removed == removed.parent.left)                  // 지울 노드가 부모의 왼쪽 자식이면
                {
                    removed.parent.left = successor;                // 지울 노드의 부모의 왼쪽에 successor를 붙인다.
                }
                else
                {                                                   // 오른쪽 자식이면
                    removed.parent.right = successor;               // 지울 노드의 부모의 오른쪽에 successor를 붙인다.
                }
            }

            if(string.Equals(removed.color,"BLACK"))                // 지울 노드가 "BLACK"이면
            {
                rebuildAfterRemove(ref tempNode, ref successor);    // successor를 기준으로 rebuild
            }

            return removed;                                         // 지울 자식을 return
        }

        public void rebuildAfterRemove(ref TreeNode tempNode, ref TreeNode successor)   // successor는 이중 흑색 노드
        {
            TreeNode sibling = null;

            while(successor.parent != null && string.Equals(successor.color,"BLACK"))   // 기준 노드의 부모가 null이 아니고 기준 노드가 "BLACK"이면
            {
                if (successor == successor.parent.left)                                 // successor가 부모의 왼쪽 자식이면
                {
                    sibling = successor.parent.right;                                   // sibling에 기준 노드의 형제 노드를 대입

                    if(string.Equals(sibling.color,"RED"))                              // 형제 노드가 "RED"이면
                    {
                        sibling.color = "BLACK";                                        // 형제 노드를 "BLACK"으로 변경
                        successor.parent.color = "RED";                                 // 기준 노드의 부모의 색을 "RED"로 변경
                        rotateLeft(tempNode,successor.parent);                          // 기준 노드의 부모를 기준으로 왼쪽 회전
                    }
                    else
                    {
                        if(string.Equals(sibling.left.color,"BLACK")&&string.Equals(sibling.right.color,"BLACK"))   // 형제 노드의 왼쪽 자식의 색이 "BLACK"이고
                        {                                                                                           // 형제 노드의 오른쪽 자식의 색이 "BLACK"이면
                            sibling.color = "RED";                                                                  // 형제 노드의 색을 "RED"로
                            successor = successor.parent;                                                           // 기준 노드를 기준 노드의 부모로
                        }
                        else
                        {
                            if(string.Equals(sibling.left.color,"RED"))                                             // 형제 노드의 왼쪽 자식이 "RED"이면
                            {
                                sibling.left.color = "BLACK";                                                       // 형제 노드의 왼쪽 자식의 색을 "BLACK"으로
                                sibling.color = "RED";                                                              // 형제 노드를 "RED"로

                                rotateRight(tempNode, sibling);                                                     // 형제 노드를 기준으로 오른쪽 회전
                                sibling = successor.parent.right;                                                   // 형제 노드를 다시 대입
                            }

                            sibling.color = successor.parent.color;                                                 // 형제 노드의 색을 기준 노드의 부모의 색으로 변경
                            successor.parent.color = "BLACK";                                                       // 기준 노드의 부모의 색을 "BLACK"
                            sibling.right.color = "BLACK";                                                          // 형제 노드의 오른쪽 자식의 색을 "BLACK"
                            rotateLeft(tempNode, successor.parent);                                                 // 기준 노드의 부모를 기준으로 왼쪽 회전
                            successor = tempNode;                                                                   // 기준 노드를 상위 노드로
                        }
                    }
                }
                else
                {                                                                                                    // 기준 노드가 오른쪽 자식이면
                    sibling = successor.parent.left;                                                                 // 형제 노드가 왼쪽 자식

                    if (string.Equals(sibling.color,"RED"))                                                           // 형제 노드가 "RED"이면
                    {
                        sibling.color = "BLACK";                                                                     // "BLACK"으로 변경
                        successor.parent.color = "RED";                                                              // 기준 노드의 부모를 "RED"로
                        rotateRight(tempNode, successor.parent);                                                     // 기준 노드의 부모를 기준으로 오른쪽 회전
                    }
                    else
                    {                                                                                               // 형제 노드가 "BLACK"이면
                        if (string.Equals(sibling.right.color,"BLACK")&&string.Equals(sibling.left.color,"BLACK"))   // 형제의 자식들이 모두 "BLACK"이면
                        {
                            sibling.color = "RED";                                                                  // 형제의 색을 "RED"로
                            successor = successor.parent;                                                           // 기준 노드를 기준 노드의 부모로
                        }
                        else
                        {                                                                                           // 
                            if(string.Equals(sibling.right.color,"RED"))                                            // 형제 노드의 오른쪽 자식이 "RED"이면
                            {
                                sibling.right.color = "BLACK";                                                      // 형제 노드의 오른쪽자식의 색을 "BLACK"으로
                                sibling.color = "RED";                                                              // 형제 노드의 색을 "RED"로

                                rotateLeft(tempNode, sibling);                                                      // 형제 노드를 기준으로 왼쪽 회전
                                sibling = successor.parent.left;                                                    // 형제 노드를 재설정
                            }

                            sibling.color = successor.parent.color;                                                 // 형제 노드의 색을 기준 노드의 부모의 색과 같게 하고
                            successor.parent.color = "BLACK";                                                       // 기준 노드의 부모의 색을 "BLACK"으로
                            sibling.left.color = "BLACK";                                                           // 형제 노드의 왼쪽 자식의 색을 "BLACK"으로
                            rotateRight(tempNode, successor.parent);                                                // 기준 노드의 부모를 기준으로 오른쪽 회전
                            successor = tempNode;                                                                   // 기준 노드를 상위 노드로
                        }
                    }
                }
            }
            successor.color = "BLACK";                                                                              // 루트 노드는 "BLACK"
        }

        public void printTree(TreeNode tempNode, int depth, int blackCount)
        {
            char c = 'X';
            int v = -1;
            string cnt = "";

            if(tempNode == null || tempNode == Nil)
            {
                return;
            }

            if(string.Equals(tempNode.color, "BLACK"))
            {
                blackCount++;
            }

            if(tempNode.parent != null)
            {
                v = tempNode.parent.val;

                if(tempNode.parent.left == tempNode)
                {
                    c = 'L';
                }
                else
                {
                    c = 'R';
                }
            }

            if(tempNode.left == Nil && tempNode.right == Nil)
            {
                cnt += "------- " + blackCount;
            }
            else
            {
                cnt += "";
            }

            for(int i=0;i<depth;i++)
            {
                Console.Write("  ");
            }

            Console.WriteLine("{0} {1} [{2},{3}] {4}", tempNode.val, (string.Equals(tempNode.color, "RED") ? "RED" : "BLACK"), c, v, cnt);

            printTree(tempNode.left, depth + 1, blackCount);
            printTree(tempNode.right, depth + 1, blackCount);
        }
    }


    class Program
    {
        class MyClass
        {
            public int MyField1;
            public int MyField2;
        }

        class Base
        {
            public void BaseMethod()
            {
                Console.WriteLine("BaseMethod");
            }
        }

        class Derived : Base
        {

        }

        static void Main(string[] args)
        {

            RBTree rbt = new RBTree();

            for (int i = 0; i < 10; i++)
            {
                rbt.insertNode(ref rbt.root, i + 1);
            }

            rbt.printTree(rbt.root,0,0);

            for (int i = 0; i < 10; i++)
            {
                rbt.removeNode(ref rbt.root, i + 1);
            }
            Console.WriteLine();

            //rbt.printTree(rbt.root,0,0);
            //Console.WriteLine();
            /*
            MyClass source = new MyClass();

            source.MyField1 = 10;
            source.MyField2 = 20;

            MyClass target = source;

            target.MyField2 = 30;

            Console.WriteLine("{0} {1}", source.MyField1, source.MyField2);
            Console.WriteLine("{0} {1}", target.MyField1, target.MyField2);*/
            /*
            Derived dv = new Derived();
            dv.BaseMethod();
            */
        }
    }
}
