# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution(object):
    def reverseList(self, head):
        if not head:
            return head
        if not head.next:
            return head
        c = self.reverseList(head.next)
        end = c
        while end.next:
            end=end.next 
        #print(c.val, head.val)
        end.next = head
        head.next = None
        return c