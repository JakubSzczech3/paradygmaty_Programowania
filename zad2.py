from _collections import deque


def zadanie(graph, start, end):
    visited = set()
    queue = deque([start])

    while queue:
        path = queue.popleft()
        node = path[-1]

        if node == end:
            return path

        if node not in visited:
            for neighbor in graph.get(node, []):
                new_path = list(path)
                new_path.append(neighbor)
                queue.append(new_path)
            visited.add(node)

        return None



graph= {
    'A': ['B'],
    'B': ['A','C','D'],
    'C': ['B'],
    'D': ['B','E','F'],
    'E': ['D'],
    'F': ['D','G'],
    'G': ['F']
}

print(zadanie(graph,'A','F'))