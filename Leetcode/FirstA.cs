using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
 
    // Definition for singly-linked list.
      public class ListNode {
        public int val;
        public ListNode next;

        public ListNode Tail { get
            {
                ListNode tmp = this;
                while(tmp.next != null)
                {
                    tmp = tmp.next;
                }
                return tmp;
            } }

        public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
        }

        public void addNode(ListNode node)
        {
            Tail.next = node;
        }

        public static string Print(ListNode node)
        {
            string output = "[";
            while(node != null)
            {
                output += node.val + ",";
                node = node.next;
            }
            output += "]";
            return output;
        }

     }
 
    internal class FirstA
    {
        // #1
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return new int[2];
        }

        // #2
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode result = head;
            int carryFalg = 0;
            for (int i = 0; i < 0; i++)
            {

            }
            int tmp = 0;
            do
            {
                tmp = (l1 == null? 0: l1.val) + (l2 == null ? 0 : l2.val) + carryFalg;
                if (tmp >= 10)
                {
                    carryFalg = 1;
                    tmp -= 10;
                }
                else
                {
                    carryFalg = 0;
                }
                result.next = new ListNode(tmp);
                result = result.next;

                l1 = l1?.next;
                l2 = l2?.next;

                if (l1 == null && l2 == null && carryFalg == 0)
                    break;
            } while (true);

            return head.next;
        }

        public int LongestSubstringWithoutRepeatingCharacters(string s)
        {
            char[] chars = s.ToCharArray();
            Dictionary<char,int> dict = new Dictionary<char,int>();
            for (int i = 0; i <= chars.Length; i++)
            {
                if (dict.ContainsKey(chars[i]))
                {

                }
                else
                {
                    dict.Add(chars[i], i);
                }
            }
            foreach (char c in dict.Keys)
            {
                
            }
            return 0;
        }
    }

}
