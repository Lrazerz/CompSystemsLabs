/******************************************************************************

                              Online C++ Compiler.
               Code, Compile, Run and Debug C++ program online.
Write your code in this editor and press "Run" button to compile and execute it.

*******************************************************************************/

#include <iostream>

using namespace std;

int *fillArrayWithDepend()
{
    int *arr;
    arr = new int [1000];
    
    for(int i = 0; i < 1000; i++) {
        if(i != 0) {
            arr[i] = arr[i-1] + (rand() % 100);
        } else {
            arr[i] = rand() % 100;
        }
    }
    return arr;
}

int * fillArrayWithoutDepend()
{
    int *arr;
    arr = new int [1000];
    
    for(int i = 0; i < 1000; i++) {
        arr[i] = rand() % 100;
    }
    return arr;
}

int * addArrays(int arr1[], int arr2[])
{
    int *arr;
    arr = new int [1000];
    
    for(int i = 0; i < 1000; i++) {
        arr[i] = arr1[i] + arr2[i];
    }
    
    return arr;
}

int main()
{
    int *arr1 = fillArrayWithDepend();
    int *arr2 = fillArrayWithoutDepend();
    int *arr3 = addArrays(arr1, arr2);
    
    // cout << *arr1 << *(arr1+1);
    // cout << *arr2 << *(arr2+1);
    // cout << *arr3 << *(arr3 + 1);
}
