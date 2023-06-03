class RecentCounter(object):

    def __init__(self):
        self.a = []
        self.l=0

    def ping(self, t):
        self.a.append(t)
        self.l = self.l+1
        c = 0
        limit=t-3000
        for x in self.a:
            if x < limit:
                c=c+1
            else:
                break
        
        while c > 0:
            self.a.pop(0)
            self.l = self.l-1
            c=c-1
        return self.l