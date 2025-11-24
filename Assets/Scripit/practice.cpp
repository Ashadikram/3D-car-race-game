#include<iostream>
using namespace std;
int main()
{
    int *arr,n;
    cout<<"Enter the size of array"<<endl;
    cin>>n;
    arr = new int[n];
    cout<<"Enter the all array element";
    for(int i=0;i<n;i++)
    {
        cin>>arr[i];
    }
}