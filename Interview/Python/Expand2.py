class Solution(object):
    def decodeString(self, s):
        """
        :type s: str
        :rtype: str
        """
        st=[]
        c=""
        r=""
        for a in s:
            if a == '[':
                st.append(c)
                c=""
            elif a == ']':
                pre = list(st.pop())
                print(pre)
                i=0
                n=0
                d=0
                l1=len(pre)
                while i < l1:
                    if pre[i].isdigit():
                        n=n*10
                        n=n + int(pre[i])
                    else:
                        d=d+1
                    i=i+1
                print(n,'n')
                print(d,'d')
                e= ""
                if d > 0:
                    e = e.join(pre[0:d])
                if c == "":
                    c = r
                    r = c * n
                    print(r, ' r')
                    c=""
                    continue
                else:
                    curr = c * n               
                    print(curr)
                    print(e)
                    r = r + e + curr
                    print(r, ' r')            
                    c=""
            else:
                c=c+a

        r = r + c

        return r