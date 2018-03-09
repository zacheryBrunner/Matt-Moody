/*******************************
* Author: Zachery Brunner
* Class: bst.c
* Date: 2/23/18
* Date Due: 2/25/18
* Assignment - Project 2 - Sequence and Order validation
***********************************
* This program will build a binary tree constructed by the user and will be able to correctly
* find numbers within the tree and traverse the tree and print out the traversal order when prompted to
**********************************/
#pragma warning(disable : 4996)	//DISABLES THE ERROR 4996 WARNING ALLOWING THE PROGRAM TO COMPILE
#include "bst.h"
#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>
#include<string.h>

/**********************
* This structure creates an "obejct" with the attributes
* Key - An int to hold the value of the node
* *leftChild - A pointer to the left child of the node if there is one
* *rightChild - A pointer to the right child of the node if there is one
************************/
typedef struct node {
	int key;
	struct node *leftChild;
	struct node *rightChild;
}Node;

/*************************
* The method will create a new Node "object" using the integer named "key" inputted by the user
* Precondition - The user will enter and integer and that integer will be used to initialize the key field
* PostCondition - A node will be created with the left and right child being NULL
* Return - A Node "object" that was created during the method
*************************/
Node *CreateNode(int key)
{
	Node *newNode = (Node*)malloc(sizeof(Node));
	newNode->key = key;
	newNode->leftChild = NULL;
	newNode->rightChild = NULL;
	return newNode;
}	//END OF CreateNode FUNCTION

/************************
* The freeTree function frees all the allocated memory used to create nodes before the program exits
* Precondition - *node has to be a valid node
* Postcondition - All allocated memory used will be freed
* Return - There is nothing to return
***************************/
void freeTree(Node *node)
{
	if (node != NULL)
	{
		freeTree(node->leftChild);
		freeTree(node->rightChild);
		free(node);
	}	//END OF IF STATEMENT
}	//END OF FUNCTION freeTree

/*****************************
* This method inserts a node into the binary tree (Excludes repeating keys due to the definition of a 
* binary tree)
* Precondition - The user had to of selected the insert button and entered a valid number 
* Postcondition - After this method executes it will have created a new node and placed it in the correct
* position within the tree
* Return - The head node used for traversing and inserting the nodes correctly
********************************/
Node *insert(Node *node, int key)
{
	if (node == NULL)
	{		
		return CreateNode(key);
	}	//END OF IF STATEMENT
	if (node->key == key)
	{
		return node;
	}	//END OF IF STATEMENT
	else
	{
		Node *newNode = CreateNode(key);
		if (newNode->key < node->key && node->leftChild != NULL)
		{
			insert(node->leftChild, key);
		}	//END OF IF STATEMENT
		else if (newNode->key > node->key && node->rightChild != NULL)
		{
			insert(node->rightChild, key);
		}	//END OF ELSE-IF CONDITIONAL
		else if (newNode->key < node->key)
		{
			node->leftChild = newNode;
		}	//END OF ELSE-IF CONDITIONAL
		else
		{
			node->rightChild = newNode;
		}	//END OF ELSE STATEMENT
		return node;
	}	//END OF ELSE STATEMENT
}	//END OF insert FUNCTION

/*******************************
* This method traverses the tree using the key as a way to either find the node or inform the user
* that the node does not exist yet
* Precondition - The program will pass in the main tree node and a user inputted int
* Postcondition - The program will either find the node or not
* Return - The program will return a bool informing Proj2.c if the node was found or not
*********************************/
bool searchNumber(Node *node, int key)
{
	if (node == NULL)
	{
		return false;
	}	//END OF IF STATEMENT
	if (node->key == key)
	{
		return true;
	}	//END OF IF STATEMENT
	else
	{
		if (node->key > key)
		{
			return searchNumber(node->leftChild, key);
		}	//END OF IF STATEMENT
		else 
		{
			return searchNumber(node->rightChild, key);
		}	//END OF ELSE STATEMENT
	}	//END OF ELSE STATEMENT
}	//END OF search FUNCTION

/***************************************
* This function will traverse the tree and put all the value within the key field into a char
* array the will print to the console during runtime
* Precondition - The program passes in the main tree node and a char array that will be used to 
* store the values
* Postcondition - All values will be printed to the console in increasing order
* Return - This method returns nothing
*****************************************/
void traversalOfTree(Node *node, char inTree[])
{
	if (node != NULL)
	{
		traversalOfTree(node->leftChild, inTree);
		sprintf(inTree + strlen(inTree), "%d ", node->key);
		traversalOfTree(node->rightChild, inTree);
	}	//END OF IF STATEMENT
}	//END OF traversalOfTree FUNCTION