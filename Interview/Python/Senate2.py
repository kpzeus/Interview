class Solution(object):
    def predictPartyVictory(self, senate):
        i=0
        s=list(senate)
        print(senate)
        while True:
            if s[i] == 'R':
                j=i+1
                if j == len(s):
                    j=0
                while j < len(s):
                    if s[j] == "D":
                        s.pop(j)
                        break
                    j+=1
            else:
                j=i+1
                if j == len(s):
                    j=0
                while j < len(s):
                    if s[j] == "R":
                        s.pop(j)
                        break
                    j+=1            
            r=sum(x == "R" for x in s)
            d=sum(x == "D" for x in s)
            print(''.join(s), r, d, i)   
            if d == 0:
                return "Radiant"
            if r == 0:
                return "Dire"   
            i+=1            
            if i >= len(s):
                i=0