class Solution(object):
    def decodeString(self, s):
        stack = []
        for c in range(len(s)):
            if s[c] != ']':
                stack.append(s[c])
            else:
                string = ''
                num = ''
                while stack[-1] != '[':
                    string = stack.pop() + string
                stack.pop()
                while stack and stack[-1].isdigit():
                    num = stack.pop() + num
                stack.append(int(num) * string)
        return "".join(stack)