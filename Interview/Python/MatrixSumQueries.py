class Solution:
    def matrixSumQueries(self, n, queries):
        rowSeenCount = 0
        colSeenCount = 0
        rowSeen = [False] * n
        colSeen = [False] * n
        totalSum = 0

        for qi in range(len(queries) - 1, -1, -1):
            type, index, val = queries[qi]
            if type == 0 and not rowSeen[index]:
                rowSeenCount += 1
                rowSeen[index] = True
                totalSum += (n - colSeenCount) * val

            if type == 1 and not colSeen[index]:
                colSeenCount += 1
                colSeen[index] = True
                totalSum += (n - rowSeenCount) * val

        return totalSum
