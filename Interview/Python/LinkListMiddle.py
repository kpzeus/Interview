# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def deleteMiddle(self, head):
        if not head:
            return head
        if not head.next:
            return head.next
        c1=head
        c2=head
        i=0
        pre=head
        pre2=head
        while c1 and c2:
            pre2= pre
            pre = c1
            c1=c1.next
            i+=1            
            if c2.next:
                c2=c2.next.next
            else:
                break
                      
        #print(pre2.val, pre.val, c1.val, c2, i)
        if i % 2 == 0:
            if c2:
                pre2.next=pre2.next.next
            else:
                pre.next=pre.next.next
        else:
            if c2:
                pre2.next=pre2.next.next
            else:
                pre.next=pre.next.next

        return head

        