/*****************************************
8 Author: Zachery Brunner
* Class: io.c
* Date: 2/23/18
* Date Due: 2/25/18
* Assignment - Project 2 - Sequence and Order validation
***********************************
* This program will build a binary tree constructed by the user and will be able to correctly
* find numbers within the tree and traverse the tree and print out the traversal order when prompted to
**********************************/
#pragma warning(disable : 4996)	//DISABLES THE ERROR 4996 WARNING ALLOWING THE PROGRAM TO COMPILE
#include"io.h"
#include<stdbool.h>
#include<string.h>
#include<stdio.h>
#include<ctype.h>

/**************
* This function asks the user what they want the program to do
* Precondition - The user can type
* Postcondition - The program will return either "i", "s", "t", or "q"
* Return - A char for what the user wants to do
*****************/
char userMenu()
{
	char answer;
	char input[255];
	do
	{
		printf("Enter (i)nsert, (s)earch, inorder (t)raversal, (q)uit: ");
		scanf("%s", &input);
		answer = input[0];
	} while (answer != 'i' && answer != 's' && answer != 't' && answer != 'q');
	return answer;
}	//END OF userMenu FUNCTION

/*****************
* This function asks the user to enter a number to insert into the tree
* Precondition - The user enter i into the menu and then this method was called
* Postcondition - Nothing has changed within the tree yet just passing a number back to the main
* Return - A number that the user entered to be inserted within the tree
******************/
int insertNumber()
{
	int key;
	printf("Enter a number to insert: ");
	scanf("%d", &key);
	return key;
}	//END OF insertNumber FUNCTION

/***********
* This function asks the user what number they would like to search for in the binary tree
* Precondition - The user entered "s" within the menu option
* Postcondition - Nothing within the tree is changed
* Return - A number for the program to search for
***********/
int search()
{
	double key;
	printf("Enter a number to search for: ");
	scanf("%lf", &key);
	return (int)key;
}	//END OF search FUNCTION

/********************************
* This function prints out to the user if the number they entered previously was found within the tree
* Precondition - The search function was run and returned a bool
* Postcondition- Nothing is altered in this executes
* Return - There is nothing to return after this function executes
*********************************/
void ifFound(bool answer, int key)
{
	if (answer)
	{
		printf("%d is in the tree\n", key);
	}	//END OF IF STATEMENT
	else
	{
		printf("%d is not in the tree\n", key);
	}	//END OF ELSE STATEMENT
}	//END OF ifFound FUNCTION

/*******************************
* This function prints the traversal out if there is anything to print out
* Precondition - The traversal function has ran and accumulated every key within the tree
* Postcondition - Nothing will change within the tree after this function has ran
* Return - Nothing to return after this method has ran
*******************************/
void traversal(char traverse[])
{
	if (strlen(traverse) == 0)
	{
		printf("There are no traversals to print\n");
	}	//END OF IF STATEMENT
	else
	{
		printf("%s\n", traverse);
	}	//END OF ELSE STATEMENT
}	//END OF traversal METHOD