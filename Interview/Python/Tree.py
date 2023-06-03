class Solution(object):
    def find(self, i):
        if self.manager[i]!=-1:
            self.informTime[i]+=self.find(self.manager[i])
            self.manager[i]=-1

        return self.informTime[i]
    
    def numOfMinutes(self, n, headID, manager, informTime):
        i=0
        t=0
        self.informTime = informTime
        self.manager = manager
        while i < n:
            x = self.find(i)
            if x > t:
                t=x
            i=i+1
    
        return t