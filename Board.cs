using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace ChessBoardModel
{
    public class Board
    {
        // size of board
        public int Size { get; set; }
        // 2D array of type cell
        public Cell[,] theGrid { get; set; }


        // constructor
        public Board(int s)
        {
            //size of board
            Size = s;

            //luo uuden   2D array of type cell 
            theGrid = new Cell[Size, Size];

            // fill 2D array with new cells , each with unique x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // step 1 clear all previous legal moves 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;  
                }
            }

            // step 2 find all legal moves and the cells as "legal"

            switch (chessPiece)
            {
                case "Knight":

                    // draw possible moves
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;


                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;


                    break;

                case "King":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    }

                    break;

                case "Rook":

                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }
                        
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                       
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }
                       
                    }

                    break;

                case "Bishop":

                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }    
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }  
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber +i, currentCell.ColumnNumber -i))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }
                    }

                    break;

                case "Queen":

                    //check movements of queen
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }
                    }

   
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                        }

                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                        }

                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                        }

                    }
                    break;

                case "Pawn":
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    }                    
                   
                    break;
            }
        }

        private bool isSafe(int x, int y)
        {
            // jos x ja y suurempi tai yhtsuuri kuin 0 sekä  x ja y pienempi kuin laudan koko
            // check if movements is out of bounds
                if (x >= 0 && y >= 0 && x < Size && y < Size)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }  
    }
}
