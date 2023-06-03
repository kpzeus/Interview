import math

def solution(A, K, L):
    n = len(A)
    max1 = -math.inf
    max2 = -math.inf
    r1 = K
    r2 = L
    if L > r1:
        r1 = L
        r2 = K
    idx = 0
    for i in range(n - r1 + 1):
        curr = sum(A[i:i + r1])
        if curr > max1:
            max1 = curr
            idx = i
            
    if max1 == -math.inf:
        return -1
    
    for i in range(n - r2 + 1):
        curr = sum(A[i:i + r2])
        if curr > max2:
            if i > idx + r1 or i < idx - r2:
                max2 = curr
    
    return max1 + max2
    
print(solution([5, 1, 5, 1, 2, 1, 6], 1, 3))