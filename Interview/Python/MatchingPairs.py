import math
def numberOfPairs(N, S):
    i=0
    result = 0
    s={}
    s[0] = 0
    s[1] = 0
    while i < N:
        c=S[i]
        j=0
        l=len(c)
        zFound=False
        oFound=False
        while j < l:
            if c[j] == '0':
                zFound = True
            elif c[j] == '1':
                oFound = True
            else:
                if zFound and oFound:
                    break
            j+=1
        if zFound:
            s[0] += 1
        if oFound:
            s[1] += 1
        i+=1
    zeroPairs = 0
    onePairs = 0
    print()
    print(s[0])
    print(s[1])
    if s[0] > 1:
        zeroPairs = math.factorial(s[0])/(2 * (math.factorial(s[0]-2)))
    if s[1] > 1:
        onePairs = math.factorial(s[1])/(2 * (math.factorial(s[1]-2)))
    result = zeroPairs
    if onePairs > result:
        result = onePairs
    return int(result)

s=[
    "01",
"1111",
"0001",
"11",
"01"
    ]

x=numberOfPairs(len(s),s)
print(x)

s=[
   "01",
"11011",
"00001",
"111",
"011",
"10101"
    ]

x=numberOfPairs(len(s),s)
print(x)