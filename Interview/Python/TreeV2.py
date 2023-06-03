class Solution(object):
    def numOfMinutes(self, n, headID, manager, informTime):
        d = {}
        i=0
        while i < n:
            if informTime[i] > 0:
                if manager[i] not in d:
                    d[manager[i]] = informTime[i]
                else:
                    d[manager[i]] = max([d[manager[i]], informTime[i]])
                print(d)
            i=i+1
        t=0
        i=0
        print('x')
        while i < n:
            if manager[i] in d:
                t=t+d[manager[i]]  
                print(d[manager[i]], 'add')
                curr = manager[i]
                print(curr, 'curr')
                if curr != -1:
                    dl = []
                    curr = manager[curr]
                    print(curr, 'curr2')                        
                    for l in d:
                        if manager[l] == curr and l != -1:
                             dl.append(l)
                    print(dl, 'dl')
                    for a in dl:
                        del d[a]
                else:
                    del d[-1]                
                print(i, 'i')
               
                print(t, 't')
                print(d)
                print('')
            i=i+1

        return t