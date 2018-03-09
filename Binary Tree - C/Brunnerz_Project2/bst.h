/***********************
* Author: Zachery Brunner
* Class: bst.h
* Date: 2/24/18
* Date Due: 2/25/18
* Assignment - Project 2 - Sequence and Order validation
***********************/

/*******************************
* This file holds all the prototypes for the bst.c class
* Precondition - This file is the precodition for the program to execute properly
* Postcodition - If this file and compiles then the program has a higher chance of compiling all together
***********************************/
#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>

//Checks whether the given token has been defined earlier in the file or in an included file
//Often used to make header files
#ifndef BST_H

//Preprocessor direcive inherited from C
#define BST_H

typedef struct node Node;
Node *CreateNode(int key);
void freeTree(Node *node);
Node *insert(Node *node, int key);
bool searchNumber(Node *node, int key);
void traversalOfTree(Node *node, char inTree[]);

//Because no #else is defined we use an #endif to close the header file
#endif


/***********************************
* ALL COMMENTS IN THIS CLASS ARE FROM THE WEBSITE: 
* https://www.cprogramming.com/reference/preprocessor/ifndef.html
* I WAS UNSURE WHAT THE #ifndef, #define, and #endif DID SO I LOOKED THEM UP
*************************************/