/*********************************
* Author: Zachery Brunner
* Class: Proj2.c
* Date Built: 2/23/18
* Date Due: 2/25/18
* Assignment - Project 2 - Sequence and Order validation
***********************************
* This program will build a binary tree constructed by the user and will be able to correctly
* find numbers within the tree and traverse the tree and print out the traversal order when prompted to
**********************************/
#pragma warning(disable : 4996)	//DISABLES THE ERROR 4996 WARNING ALLOWING THE PROGRAM TO COMPILE
#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>
#include<ctype.h>
#include"bst.h"
#include"io.h"

/********************************
* The main method runs the program
* Precondition - The udser starts the program and everything compiled
* Postcondition - All allocated memory will be freed and the program will exit without issues
* Return - An int telling the user what error code it exited with or if it exited correctly
***********************************/
int main()
{
	char traverse[255];
	char answer;
	int key;
	Node *MainTreeNode = NULL;
	do
	{
		answer = userMenu();
		switch (answer)
		{
			case 'i':
				key = insertNumber();
				MainTreeNode = insert(MainTreeNode, key);
				break;
			case 't':
				memset(&traverse, 0, sizeof(traverse));
				traversalOfTree(MainTreeNode, traverse);
				traversal(traverse);
				break;
			case 's':
				key = search();
				ifFound(searchNumber(MainTreeNode, key), key);
				break;
			default:
				freeTree(MainTreeNode);
				exit(0);
		}	//END OF SWITCH - CASE
	} while (true);
}	//END OF main FUNCTION