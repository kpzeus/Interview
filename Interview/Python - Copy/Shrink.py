class Solution(object):    

    def asteroidCollision(self, asteroids):
        ans = []
        for next in asteroids: 
            while ans and next < 0 and ans[-1] > 0:
                if ans[-1] < -next:
                    ans.pop()
                    continue
                elif ans[-1] == -next:
                    ans.pop()
                break
            else:
                ans.append(next)
        return ans