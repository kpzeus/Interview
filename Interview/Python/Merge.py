class Solution(object):
    def findCircleNum(self, isConnected):
        i=0
        j=0
        d={}
        n=len(isConnected)
        m=0

        while i<n:
            j=0
            while j<n:
                if isConnected[i][j] == 1:
                    if not i in d.keys():
                        d[i] = set()
                    if not j in d.keys():
                        d[j] = set()
                    d[i].add(j)
                    for x in list(d[i]):
                        if not x in d.keys():
                            d[x] = set()
                        d[x].add(i)
                        d[x].add(j)
                        d[j].add(x)
                    l = len(d[i])
                    if l > m:
                        m=l
                j+=1
            i+=1

        
        if m == n:
            return 1

        i=0
        j=0
        while i < len(d) - 1:
            j=i+1
            while j < len(d):
                if len(d[d.keys()[i]].intersection(d[d.keys()[j]])) > 0:
                    d[d.keys()[i]] = d[d.keys()[i]].union(d[d.keys()[j]])
                    del d[d.keys()[j]]
                    i-=1
                    break
                j+=1
            i+=1

        return len(d)