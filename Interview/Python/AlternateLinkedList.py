# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def oddEvenList(self, head):
        if not head:
            return head
        s=[]
        c=head
        i=1
        r=head
        end=head
        while c:
            if i % 2 == 0:
                s.append(c)
            c=c.next
            i=i+1
        r=head
        while r:
            if r:
                end=r
            if r and r.next:
                r.next = r.next.next
                r=r.next
            else:
                break
        for x in s:
            x.next=None
            end.next = x
            end=end.next
        
        end.next=None

        return head