
class Solution(object):   
    def shortestPathBinaryMatrix(self, grid):
        """
        :type grid: List[List[int]]
        :rtype: int
        """
        l=len(grid)-1

        if grid[0][0] == 1 or grid[l][l] == 1:
			return -1
        
        q = collections.deque([(0,0,1)])

        v = set()

        while q:
            i,j,c = q.popleft()

            if i < 0 or j < 0 or i > l or j > l:
                continue

            if (i,j) in v:
                continue 

            v.add((i,j))       

            if grid[i][j] == 1:
                continue

            if i == l and j == l:
                return c 

            q.append((i+1, j, c+1))
            q.append((i+1, j+1, c+1))
            q.append((i+1, j-1, c+1))
            q.append((i, j+1, c+1))
            q.append((i, j-1, c+1))
            q.append((i-1, j, c+1))
            q.append((i-1, j+1, c+1))
            q.append((i-1, j-1, c+1))           

        return -1