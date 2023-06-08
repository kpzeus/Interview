#include<iostream>
#include <map>
#include <vector>
#include <algorithm>
using namespace std;

void healthyDuplicate(int N,int A[])
{
    map<int,int> m;
    vector<int> c;
    int i=0;
    while(i<N){
        if(m.count(A[i]) == 0){
            m[A[i]]=0;
            c.push_back(A[i]);
        }
        m[A[i]]+=1;
        //cout<<A[i]<<'z'<<'\n';
        //cout<<m[A[i]]<<'b'<<'\n';
        i++;
    }
    i=0;
    int count=0;
    vector<int> v;
    sort(c.begin(),c.end());
    for (auto e : c)
    {
        //cout<<e.first<<'e'<<e.second<<'\n';
        //cout<<e<<'q'<<'\n';
        //cout<<(e==4)<<'t'<<'\n';
        if(m[e] > 1)
        {
            //cout<<e<<'y'<<'\n';
            int j=0;
            for (auto e1 : c)
            {
                //cout<<e1<<'x';
                j=e1;
                if(e1 <= e){
                    if(m[e1] >= m[e])
                        break;
                }
                else
                    break;
                
                //cout<<j<<'z';
            }
            //cout<<'\n';
            if(e == j){
                
                count++;
                v.push_back(e);
            }
        }
        i++;
    }
    cout<<'\n'<<count<<'\n';
    for (const auto e : v)
    {
        cout<<e<<' ';
    }
}

int main(){
    int arr[] = {2,4, 2,4, 6, 1,5, 7, 8, 8, 8};
    healthyDuplicate(11, arr);
    int arr1[] = {2,4,4,6,1,1,5,7,8,8,8};
    healthyDuplicate(11, arr1);
    return 0;
}