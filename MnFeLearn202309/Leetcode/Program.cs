using Leetcode;


ListNode h1 = new ListNode(2, new ListNode(4, new ListNode(3)));
ListNode h2 = new ListNode(5);
h2.addNode(new ListNode(6));
h2.addNode(new ListNode(4));

FirstA firstA = new FirstA();

Console.WriteLine(ListNode.Print(firstA.AddTwoNumbers(h1, h2)));