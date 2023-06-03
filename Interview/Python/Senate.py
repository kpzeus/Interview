class Solution(object):
    def predictPartyVictory(self, senate):
        n = len(senate)
        s = set()
        b = [False] * n
        d = 0
        r = 0
        while len(s) != 1:
            s = set()
            for i, p in enumerate(senate):
                if b[i]: continue
                if p == 'R':
                    if r > 0:
                        r -= 1
                        b[i] = True
                    else:
                        d += 1
                        s.add('R')
                else:        
                    if d > 0:
                        d -= 1
                        b[i] = True
                    else:
                        r += 1
                        s.add('D')
        return 'Radiant' if list(s)[0] == 'R' else 'Dire'