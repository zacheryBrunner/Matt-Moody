/**********************************
* Author: Zachery Brunner
* Class: io.h
* Date: 2/23/18
* Date Due: 2/25/18
* Assignment - Project 2 - Sequence and Order validation
***********************************/

/*******************************
* This file holds all the prototypes for the io.c class
* Precondition - This file is the precodition for the program to execute properly
* Postcodition - If this file and compiles then the program has a higher chance of compiling all together
***********************************/
#include<stdbool.h>

//Checks whether the given token has been defined earlier in the file or in an included file
//Often used to make header files
#ifndef IO_H

//Preprocessor direcive inherited from C
#define IO_H

char userMenu();
int insertNumber();
int search();
void ifFound(bool answer, int key);
void traversal(char traverse[]);

//Because no #else is defined we use an #endif to close the header file
#endif


/***********************************
* ALL COMMENTS IN THIS CLASS ARE FROM THE WEBSITE:
* https://www.cprogramming.com/reference/preprocessor/ifndef.html
* I WAS UNSURE WHAT THE #ifndef, #define, and #endif DID SO I LOOKED THEM UP
*************************************/