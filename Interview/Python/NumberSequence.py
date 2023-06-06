def specialNumbers(N,K,S):
	i=0
	s=list(S)
	while i<(N-1):
		if s[i] == '5' and s[i+1] == '9' and K > 0:
		#print(i)
		if (i+1) % 2 == 0:
			s[i+1] = '5'
		else:
			s[i] = '9'
		#print(''.join(s))
		if i > 0:
			i-=1
		K-=1
		continue
		i+=1
return ''.join(s)