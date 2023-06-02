#include <iostream>
#include <vector>
#include <bits/stdc++.h>
using namespace std;


void Visit(int& r, int c, int x, int y, int n, vector <tuple <int,int>>& visited){
    if(x < 1 || y < 1 || x > n || y > n)
    {
        return;
    }
    
    tuple <int,int> curr = make_tuple (x, y);
    if(std::count(visited.begin(), visited.end(), curr))
        return;
    cout<<x<<","<<y<<"\r\n";
    if(c > r)
        r = c;
    visited.push_back(curr);
    Visit(r, c+1, x + 1, y, n, visited);
    Visit(r, c+1, x - 1, y, n, visited);
    Visit(r, c+1, x, y + 1, n, visited);
    Visit(r, c+1, x, y - 1, n, visited);
}

int gridMovement(int N,int X,int Y){ 
    
    //this is default OUTPUT. You can change it.
    int result =-404;

    if(N == 1)
        return 0;

    result = 0;

    vector <tuple <int,int>> visited = {};
   
    int& r = result;
    vector <tuple <int,int>>& v = visited;
    Visit(r, 0, X, Y, N, v);

    return result;
}


int main(void){
    //INPUT [uncomment & modify if required]
    int N, X, Y;
    N=2;
    X=1;
    Y=1;

    //OUTPUT [uncomment & modify if required]
    cout<<gridMovement(N,X,Y);    
}