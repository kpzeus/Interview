# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def pairSum(self, head):
        if not head:
            return head
        if not head.next:
            return head.val
        
        s=[]
        c=head
        while c:
            s.append(c.val)
            c=c.next
        l=len(s)
        i=0
        j=l-1
        max=0
        c=head
        while i < j:
            currentSum = c.val + s[j]
            #print(c.val, s[j], currentSum, i, j)
            if currentSum > max:
                max = currentSum
            c=c.next
            i+=1
            j-=1
        
        return max