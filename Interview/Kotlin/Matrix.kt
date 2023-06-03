var r = 0

fun solution(A: Array<IntArray>): Int {
    r = 0

    val v = hashSetOf<Pair<Int,Int>>()
    var i = 0
    var j = 0
    while(i < A.size){
        while(j < A[0].size){
            Visit(A, i, j, i, j, 1, v)
            j++
        }
        i++
    }
    
    return r
}

fun Visit(A: Array<IntArray>, i:Int, j:Int, a:Int, b:Int, c:Int, v:HashSet<Pair<Int,Int>>){
    if(i < 0 || j < 0 || i > A.size - 1 || j > A[0].size - 1)
        return
    
    if(v.contains(Pair(i,j)))
        return

    val diff = A[a][b] - A[i][j]
    if(diff > 1 || diff < -1)
        return

    v.add(Pair(i,j))

    if(c > r)
        r = c;
    
    Visit(A, i+1, j, i, j, c+1, v)
    Visit(A, i+1, j+1, i, j, c+1, v)
    Visit(A, i+1, j-1, i, j, c+1, v)
    Visit(A, i, j-1, i, j, c+1, v)
    Visit(A, i, j+1, i, j, c+1, v)
    Visit(A, i-1, j, i, j, c+1, v)
    Visit(A, i-1, j+1, i, j, c+1, v)
    Visit(A, i-1, j-1, i, j, c+1, v)
}
