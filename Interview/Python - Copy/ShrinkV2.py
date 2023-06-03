class Solution(object):
    def shrink(self, a):
        i = 1
        n = len(a)
        r=[]
        if(len(a) < 2):
            return a
        #print('start') 
        #print(a) 
        while i < n+1:
            if i < n and a[i-1] > 0 and a[i] < 0:
                if a[i-1] > abs(a[i]):
                    r.append(a[i-1])
                    #print('left') 
                    #print(i)
                    #print(a[i-1])         
                    i=i+2     
                elif a[i-1] < abs(a[i]):
                    r.append(a[i])  
                    #print('right') 
                    #print(i)
                    #print(a[i]) 
                    if i == n-1:
                        return r
                    i=i+2
                else:
                    i=i+2        
            else:
                r.append(a[i-1])
                #print('pre')
                #print(i)
                #print(a[i-1])
                i=i+1       

        return r

    def asteroidCollision(self, asteroids):
        """
        :type asteroids: List[int]
        :rtype: List[int]
        """
        r=asteroids
        while True:
            old = len(r)
            r = self.shrink(r)
            #print(r)
            if old == len(r):
                break
        
        return r