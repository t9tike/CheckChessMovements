﻿using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUIApp
{
    
    public partial class Form1 : Form
    {
        // viittaus board luokkaan . sisältää arvot boardiin
        static Board myBoard = new Board(8);
        // 2D array of buttons whose values are determined by myBoard
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public string peliNappula;
        public string viimeisinNappula;
        public Form1()
        {
            InitializeComponent();
            populateGrid();
            
        }

        private void populateGrid()
        {
            // luo buttonit ja aseta ne panel1
            int buttonSize = panel1.Width / myBoard.Size;
            // tee paneli1 täydelliseksi neliöksi
            panel1.Height = panel1.Width;

            // tee nested looppi ja luo buttonit ja aseta ne näytölle
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    // lisää click event jokaiselle buttonille 

                    btnGrid[i, j].Click += Grid_Button_Click;

                    // lisää button paneeliin
                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i, j);


                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("PAinoit nappia"); 

            // get the row and column of the button clicked 
            Button clickedButton = (Button)sender;

            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];
            // determine next legal moves

            myBoard.MarkNextLegalMoves(currentCell, peliNappula);
            // update the text for each button

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    if (myBoard.theGrid[i, j].LegalNextMove == true)
                    {
                        btnGrid[i, j].Text = "Sallittu";
                    }
                    else if (myBoard.theGrid[i,j].CurrentlyOccupied == true)
                    {
                        btnGrid[i, j].Text = peliNappula;
                    }
                    
                }

            }
            viimeisinNappula = peliNappula;
            btnGrid[currentCell.RowNumber, currentCell.ColumnNumber].Text = viimeisinNappula;
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            peliNappula = comboBox1.Text;
        }
    }
}
