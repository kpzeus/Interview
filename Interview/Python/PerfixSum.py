def solution(A, S):
    r = 0
    curr = 0
    n=len(A)
    d = dict()
     
    for i in range(0, n):
        curr += (A[i] - S)
        
        if (curr == 0):
            r += 1
             
        if curr in d:
            r += d[curr]
             
        if curr in d:
            d[curr] += 1
        else:
            d[curr] = 1
             
    return min(r, 1000000000)


print(solution([2, 1, 3], 2))     # Output: 3
print(solution([0, 4, 3, -1], 2)) # Output: 2
print(solution([2, 1, 4], 3))     # Output: 0
print(solution([3], 3))     # Output: 1
