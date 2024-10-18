/*
 * Project that allows multiple users to play Snakes and Ladders. Has to state the number of players.
 * Create a char matrix of 10x10, with numbers running from 1-100. There will be snakes and ladders which takes one down and up, respectively.
 * The matrix will have G - green, and G - goal (matrix[9][9]), all other letters will either be for a snake or a ladder.
 * Each letter will be assigned a location in which the user should go to, using the switch function.
 * A die which will be represented by random number generating function.
 * Need a way to keep track of the position of each player.
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <stdbool.h>

#define G 'G'

int die()
{
srand(time(NULL));

return rand() % 6 + 1;
}

char* returnStr(int n)
{
char str[3];
char* str1 = (char*)malloc(sizeof(char)*3);

switch(n)
{
case 88: return "S1";
case 76: return "S2";
case 61: return "L1";
case 59: return "S3";
case 55: return "L2";
case 34: return "S4";
case 25: return "L3";
case 12: return "L4";
default: sprintf(str, "%d", n);
	strcpy(str1, str);
	return str1;
}

free(str1);
}

char* playerPosition(int position)
{
char temp[3];
char* temp1 = (char*)malloc(sizeof(char)*3);

temp1[0] = 'P';

sprintf(temp, "%d", position);
strcat(temp1, temp);

return temp1;
}

int returnPosition(int* players, int size, int value)
{
for(int i = 0; i < size; i++)
if(players[i] == value)
return i;

return -1;
}

void printBoard(int* players, int size)
{
int temp = 10;
char* temp2 = (char*)malloc(sizeof(char) * 3);
int temp3;

printf("\n");

for(int i = 10; i > 0; i--)
{
temp = 10 * i;

for(int j = 0; j < 10; j++)
{

if(i == 1)
{
temp2 = returnStr(j+1);
temp3 = j+1;
}//if i == 1

else if ((i-1) % 2 == 0)
{
temp3 = (temp - 10) + j + 1;
temp2 = returnStr(temp3);
}//if (i-1) % 2

else
{
temp3 = temp - j;
temp2 = returnStr(temp3);
}//else

if (returnPosition(players, size, temp3) != -1 && temp3 != 100)
temp2 = playerPosition(returnPosition(players, size, temp3));

//printing the value
if (temp3 < 10)
printf("  %s  ", temp2);
else if (temp3 == 100)
printf(" %s ", temp2);
else
printf("  %s ", temp2);

}//for j

printf("\n\n");

}//for i

free(temp2);
}

int newPosition(int argc)
{
switch(argc)
{
case 88 : return 68;
case 76 : return 31;
case 61 : return 98;
case 59 : return 16;
case 55 : return 73;
case 34 : return 28;
case 25 : return 63;
case 12 : return 53;
default : return argc;
}

}

		//Function to return the number of current players
int currentPlayers(bool* playersWon, int size)
{
int number = 0;

for (int i = 0; i < size; i++)
if (!playersWon[i]) number += 1;

return number;
}


		//Function to ensure that no more than one player can have the same position
int previousPlayer(int* players, int size, int currentPlayer)
{
for(int i = 0; i < size; i++)
if(i != currentPlayer)
if(players[currentPlayer] == players[i] && players[i] != 100)
return i;

return -1;
}


					//The main function

int main(int argc, char** argv[])
{

int *player;// = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

int numberOfUsers;

printf("Hey there. Wlecome to my game of Snakes and Ladders. You will need to be at least 2 users.\n");
printf("\nPlease enter the number of user who will be playing: ");
scanf("%d", &numberOfUsers);

//printBoard(101, 2);

//The core
int curPlayers = numberOfUsers;
char roll;
int dice, temp, temp1;
player = (int*)malloc(sizeof(int)*numberOfUsers);
bool* playerOn = (bool*)malloc(sizeof(bool) * numberOfUsers);
bool* playerWon = (bool*)malloc(sizeof(bool) * numberOfUsers);

for(int i = 0; i < numberOfUsers; i++)
{
player[i] = 0;
playerOn[i] = false;
playerWon[i] = false;
}

while(curPlayers > 1)
{
curPlayers = numberOfUsers;

for(int i = 0; i < numberOfUsers; i++)
{
//Making sure that the players who are done can not play

temp = player[i];


printf("\n\nPlayer %d:\nRoll a die? (y)", i);
scanf("%c", &roll);

dice = 0;
if(!playerWon[i])
dice = die();

printf("You rolled a %d\n", dice);

	//If for the dice = 6
if (dice == 6)
{
if(!playerOn[i])
{
temp = 1;
playerOn[i] = true;
}
else
{
temp = temp + dice;
}

	//If caught by a snake or climbs up a ladder
temp1 = newPosition(temp);
if(temp1 > temp)
{
printf("\nYou have climbed up a ladder.\n");
temp = temp1;
}
else if (temp1 < temp)
{
printf("\nYou were caught by a snake.\n");
temp = temp1;
}

	//Check the scores
printf("Positions: \n	Before:%d\n	After:%d\n	On/Off:%b\n", player[i], temp, playerOn[i]);


	//Ensuring that the numbers never exceed 100
if(temp <= 100)
player[i] = temp;

if(player[i] == 100)
{
playerWon[i] = true;
//curPlayers -= 1;
}

	//Ensuring that no more than one player have the same position
int temp4 = previousPlayer(player, numberOfUsers, i);
if(temp4 != -1)
{
player[temp4] = 0;
playerOn[temp4] = false;
}
	//Presentation of the score
printBoard(player, numberOfUsers);

i--;
}
	//End for if for the dice = 6

	//If for any value of the dice
else
{
if(playerOn[i])
{
temp = temp + dice;
}


	//If caught by a snake or climbs up a ladder
temp1 = newPosition(temp);
if(temp1 > temp)
{
printf("\nYou have climbed up a ladder.\n");
temp = temp1;
}
else if (temp1 < temp)
{
printf("\nYou were caught by a snake.\n");
temp = temp1;
}

	//Check the scores
printf("Positions: \n	Before:%d\n	After:%d\n	On/Off:%b\n", player[i], temp, playerOn[i]);


	//Ensuring that the numbers/sum does not exceed 100
if(temp <= 100)
player[i] = temp;

if(player[i] == 100)
{
playerWon[i] = true;
//curPlayers -= 1;
}//if temp == 100


	//Ensuring that no more than one player have the same position
int temp4 = previousPlayer(player, numberOfUsers, i);
if(temp4 != -1)
{
player[temp4] = 0;
playerOn[temp4] = false;
}

	//Presentation of the score
printBoard(player, numberOfUsers);

}
	//End for any value of dice

	//Current players
curPlayers = currentPlayers(playerWon, numberOfUsers);
printf("\nThe number of current players: %d", curPlayers);

}

}

free(player);
free(playerOn);
free(playerWon);

return 0;
}
