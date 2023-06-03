import math

class Solution(object):
    def maximumDetonation(self, bombs):
        """
        :type bombs: List[List[int]]
        :rtype: int
        """
        n = len(bombs)
        c = 0
        i = 0
        while i < n:
            s = []
            s.append(i)
            detonate(s, i, bombs)
            l = len(s)
            if l > c:
                c = l
                if c == n:
                    return c
            i=i+1
            
        return c

def detonate(s, i, bombs):
    j = 0
    old = len(s)
    #print("x" + str(old))
    n=len(bombs)
    b=bombs[i]
    while j < n:
        a = bombs[j]
        
        if j != i:
            if in_range(a[0], a[1], b[0], b[1], b[2]):
                if j not in s:
                    s.append(j)
        
        j=j+1
    
    l=len(s)
    if l > old:
        k=0        
        #print(l)
        while k < l:
            detonate(s, s[k], bombs)
            k=k+1

def in_range(x, y, a, b, r):
    distance = math.sqrt((x - a) ** 2 + (y - b) ** 2)
    #print(distance)
    #print(r)
    return distance <= r
