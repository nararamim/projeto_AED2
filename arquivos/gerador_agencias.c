#include <stdio.h>
#include <stdlib.h>

int main(){
    srand(100);
    for(int i= 0; i<100; i++){
        printf("%d \n",rand() % 500);
    }
}