import math

class Solution(object):
    def is_on_range(self, source, dest):
		dist = ((source[0] - dest[0])**2 + (source[1] - dest[1])**2)**0.5
		return dist <= source[2]

    def bombs_to_graph(self, bombs):
		graph = Graph()
		for i_s, source in enumerate(bombs):
			for i_d, dest in enumerate(bombs):
				if i_s == i_d: continue

				if self.is_on_range(source, dest):
					graph.add_edge(i_s, i_d)

		return graph

    def DFS(self, v, visited):
		visited.add(v)
		for n in self.graph.graph[v]:
			if n not in visited:
				self.DFS(n, visited)

    def maximumDetonation(self, bombs):
        self.graph = self.bombs_to_graph(bombs)
        print(self.graph.graph)
        ans = 1
        self.dp = [0]*len(bombs)
        for i in range(len(bombs)):
            visited = set()
            self.DFS(i, visited)
            ans = max(ans, len(visited))
        return ans 
    
class Graph:
	def __init__(self):
		self.graph = defaultdict(list)

	def add_edge(self, s, d):
		self.graph[s].append(d)
