using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment;

namespace CAB301_TradeTools.ViewModels
{
    public class BTNode
    {
        private Member aMember; // value
        private BTNode leftchild; // reference to its left child
        private BTNode rightchild; // reference to its right child

        public BTNode(Member AMemeber)
        {
            this.aMember = AMemeber;
            leftchild = null;
            rightchild = null;
        }

        public Member AMemeber
        {
            get { return AMemeber; }
            set { AMemeber = value; }
        }

        public BTNode LeftChild
        {
            get { return leftchild; }
            set { leftchild = value; }
        }

        public BTNode RightChild
        {
            get { return rightchild; }
            set { rightchild = value; }
        }
    }

    
    public class MemberCollection : iMemberCollection, IComparable<Member>
    {
        readonly Member memberCollection = new Member();

        private string LastName;
        private string FirstName;
        private BTNode r;

        public MemberCollection()
        {
            r = null;
        }

        public bool IsEmpty()
        {
            return r == null;
        }

        public int Number
        {
            get => memberCollection.CollectMembers.Count();
        }

        public void add(Member aMember)
        {
           if(r==null)
            {
                r = new BTNode(aMember);
            }
           else
            {
                add(aMember, r);
            }
        }

        // pre: ptr != null
        // post: item is inserted to the binary search tree rooted at ptr
        private void add(Member aMember, BTNode btNode)
        {
            if (aMember.CompareTo(btNode.AMemeber) < 0)
            {
                if (btNode.LeftChild == null)
                {
                    btNode.LeftChild = new BTNode(aMember);
                }
                else
                {
                    add(aMember, btNode.LeftChild);
                }
            }
            else
            {
                if (btNode.RightChild == null)
                {
                    btNode.RightChild = new BTNode(aMember);
                }
                else
                {
                    add(aMember, btNode.RightChild);
                }
            }
        }

        public int CompareTo(Member other)
        {
            if (other.GetType() != typeof(Member))
            {
                throw new Exception();
            }

            Member m = (Member)other;
            if (!LastName.Equals(m.LastName))
            {
                return LastName.CompareTo(m.LastName);
            }
            else
            {
                return FirstName.CompareTo(m.FirstName);
            }

        }

        public void delete(Member aMember)
        {
            // search for item and its parent
            BTNode btNode = r; // search reference
            BTNode Parent = null; // parent of ptr


            while ((btNode!=null)&&(aMember.CompareTo(btNode.AMemeber)!=0))
            {
                Parent = btNode;
                if (aMember.CompareTo(Parent.AMemeber)<0) // move to the left child
                {
                    btNode = btNode.LeftChild;
                }
                else
                {
                    btNode = btNode.RightChild;
                }

            }

            if (btNode != null) // if the search was successful
            {
                //item has two children
                if ((btNode.LeftChild != null)&&(btNode.RightChild != null))
                {
                    // find the right-most node in left subtree of ptr
                    if (btNode.LeftChild.RightChild == null)  //the right subtree of ptr.LChild is empty
                    {
                        btNode.AMemeber = btNode.LeftChild.AMemeber;
                        btNode.LeftChild = btNode.LeftChild.LeftChild;
                    }
                    else
                    {
                        BTNode p = btNode.LeftChild;
                        BTNode pp = btNode; // parent of p
                        while (p.RightChild != null)
                        {
                            pp = p;
                            p = p.RightChild;
                        }
                        // copy the item at p to ptr
                        btNode.AMemeber = p.AMemeber;
                        pp.RightChild = p.LeftChild;
                    }
                }
                else //item has no or only one child
                {
                    BTNode c;
                    if (btNode.LeftChild != null)
                    {
                        c = btNode.LeftChild;
                    }
                    else
                    {
                        c = btNode.RightChild;
                    }
                    // remove node ptr
                    if (btNode == r) //need to change root
                    {
                        r = c;
                    }
                    else
                    {
                        if (btNode == Parent.LeftChild)
                        {
                            Parent.LeftChild = c;
                        }
                        else
                        {
                            Parent.RightChild = c;
                        }
                    }
                }
            }

        }

        public bool search(Member aMember)
        {
            return search(aMember, r);
        }

        private bool search(Member aMember, BTNode r)
        {
            if (r != null)
            {
                if (aMember.CompareTo(r.AMemeber) == 0)
                {
                    return true;
                }
                else               
                    if (aMember.CompareTo(r.AMemeber) < 0)
                    {
                        return search(aMember, r.LeftChild);
                    }               
                else
                {
                    return search(aMember, r.RightChild);
                }
            }          
            else
            {
                return false;
            }          
        }


        private Member[] getMembers;
        public List<string> CollectMembers = new List<string>();

        public Member[] toArray()
        {
            getMembers.SetValue(CollectMembers, 0);
            return getMembers;
        }

        public List<Member> InTraverse()
        {
            List<Member> MemberList = new List<Member>();
            InOrderTraverse(MemberList, r);
            return MemberList;
        }

        public void InOrderTraverse(List<Member> List, BTNode r)
        {
            if (r != null)
            {
                InOrderTraverse(List , r.LeftChild);
                List.Add(r.AMemeber);
                InOrderTraverse(List, r.RightChild);
            }
        }   

        public void Clear()
        {
            r = null;
        }

        private Member[] ListMembers = new Member[0];

        //Checks members login, allowing them access if both username and password match 
        public Member LoginMember(string Username, string pin)
        {
            try
            {
                Member member = ListMembers.SingleOrDefault(Member => Member.UserName == Username);
                if (member == null)
                {
                    throw new ArgumentException("Incorrect Username Or Password. Try Again.");
                }

                if (!Int32.TryParse(pin, out int PINparse))
                {
                    throw new ArgumentException("Incorrect Username Or Password. Try Again.");
                }
                if (member.PIN == Convert.ToString(PINparse))
                {
                    return member;
                }
                else
                {
                    throw new ArgumentException("Incorrct Username or Password. Try Again.");
                }
                             
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //checks for members name and returns member if member exists  
        public Member SearchMember(string FirstName, string LastName)
        {
            string UserName = FirstName + LastName;
            try
            {
                Member Member = ListMembers.SingleOrDefault(member => member.UserName == UserName);
                if (Member == null)
                {
                    throw new ArgumentException("Doesn't Exist. Try Again.");
                }
                return Member;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal Member search(string amember)
        {
            throw new NotImplementedException();
        }
    }



}
