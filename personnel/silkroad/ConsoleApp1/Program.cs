using System.Data;

bool[,] silkyWay = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

for (int i = 0; i < 28; i++)
{
    Random rdm = new Random();
    int rdmX = rdm.Next(8);
    int rdmY = rdm.Next(8);
    if (!silkyWay[rdmX, rdmY])
        silkyWay[rdmX, rdmY] = true;
    else
        i--;
}
void DrawBoard(bool[,] board)
{
    Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= 8; col++)
        {
            if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
    Console.WriteLine(" └────────┘");
}

// TODO Put silk on 30 more squares
DrawBoard(silkyWay);

// TODO Create a data structure that allow us to remember which square has already been tested
bool[,] testCase = new bool[8, 8];
// TODO Create a data structure that allow us to remember the successful steps
bool[,] path = new bool[8, 8];
// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

// TODO Call the function and show the results
bool isThereAWayOut(int x, int y)
{
    if(x == 7 && y == 7) return true;
    if(x < 0 || y < 0 || x > 7 || y > 7) return false;
    if(testCase[x, y]) return false;
    if(!silkyWay[x, y]) return false;

    testCase[x, y] = true;

    if(isThereAWayOut(x - 1, y + 1) ||
       isThereAWayOut(x - 1, y) ||
       isThereAWayOut(x - 1, y - 1) ||
       isThereAWayOut(x, y + 1) ||
       isThereAWayOut(y, y - 1) ||
       isThereAWayOut(x + 1, y - 1) ||
       isThereAWayOut(x + 1, y) ||
       isThereAWayOut(x + 1, y + 1))
    {
        path[x, y] = true;
        return true;
    }
    return false;
}

bool result = isThereAWayOut(0,0);

Console.WriteLine(result);

Console.ReadLine();