using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private static int gridSize; //number of cells in each row and column
        private int progress;




        private float size;

        private void newMakeCells()
        {

            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 1)
                {
                    gridSize = 50;
                    MessageBox.Show("Invalid input (" + gridSizeInput.Text + "). Grid size set to default(50).");
                }
                if (gridSize > 300)
                {
                    gridSize = 300;
                    MessageBox.Show("Input too large (" + gridSizeInput.Text + "). " + "Grid size set to max (300).");
                }
            }
            catch
            {
                gridSize = 50;
                MessageBox.Show("Invalid input (" + gridSizeInput.Text + ") . Grid size set to default (50).");
            }
            size = (mazeContainer.Width / gridSize);

            mazeContainer.Height = mazeContainer.Height + 1;
            mazeContainer.Width = mazeContainer.Width + 1;

            progressBar1.Maximum = gridSize * gridSize;
            progress = 0;

            Pen myPen = new Pen(Color.Black, 1);
            Graphics g = mazeContainer.CreateGraphics();

            g.DrawLine(myPen, 0, 0, size * gridSize, 0); //north wall
            g.DrawLine(myPen, 0, 0, 0, size * gridSize);

            for (int i = 0; i < gridSize; i++)
            {
                g.DrawLine(myPen, 0, i * size + size, gridSize * size, i * size + size);
            }
            for (int i = 0; i < gridSize; i++)
            {
                g.DrawLine(myPen, i * size + size, 0, i * size + size, gridSize * size);

            }
            myPen.Dispose();
        }



        private void drawMaze() //uses a randomised prim's algorithm to generate the maze
        {
            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 1)
                {
                    gridSize = 50;
                }
                if (gridSize > 300)
                {
                    gridSize = 300;
                }
            }
            catch
            {
                gridSize = 50;
            }

            Random rand = new Random();

            int i = rand.Next(0, gridSize);//randomly choosing a cell 
            int j = rand.Next(0, gridSize); //i = rows and j = columns
                                            //i = Y value of point, j = x value of point

            List<Point> chosenCells = new List<Point>();//adding starting cell to chosen cells list
            Point chosenPoint = new Point(j, i);
            chosenCells.Add(chosenPoint);

            List<Point> potentialNext = new List<Point>();//this will be the list of cells adjacent to chosen cells that may be chosen next iteration

            int[] neighbourRowOffsets = { -1, 0, 1, 0 };
            int[] neighbourColOffsets = { 0, 1, 0, -1 };

            for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
            {                                                   //allows me to add to potentialNext without creating runtime error
                int newRow = i + neighbourRowOffsets[direction];
                int newCol = j + neighbourColOffsets[direction];
                Point nextPoint = new Point(newCol, newRow);

                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid
                }
            }

            int count = 0;

            while (count < (gridSize * gridSize - 1))
            {
                progressBar1.Value = progress;
                int r = rand.Next(0, potentialNext.Count);//index to choose a random potential cell
                i = potentialNext[r].Y; //indexing a random potential cell's coordinates
                j = potentialNext[r].X;

                int index = 0;//index to choose a valid cell
                Point[] neighbours = new Point[4];//potential neighbouring chosen cells

                for (int direction = 0; direction < 4; direction++) //checking neighbouring cells for a chosen cell
                {
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];

                    Point nextPoint = new Point(newCol, newRow);//selected point from potentialNext

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (chosenCells.Contains(nextPoint))
                        {
                            neighbours[index] = nextPoint; //adds cell to potential targets if it has already been chosen
                            index++;
                        }
                    }
                }

                Graphics g = mazeContainer.CreateGraphics();
                Color color = mazeContainer.BackColor;
                Pen myPen = new Pen(color, 1);

                int targ = rand.Next(0, index);//choosing valid target cell
                //deleting connecting walls between the chosen cells

                //if neighbours[targ].X > potentialNext[r].X -> target cell is to the right
                if (neighbours[targ].X > potentialNext[r].X)
                {
                    g.DrawLine(myPen, potentialNext[r].X * size + size, potentialNext[r].Y * size + 1, potentialNext[r].X * size + size, potentialNext[r].Y * size + size - 1);
                }
                //if neighbours[targ].X < potentialNext[r].X -> target cell is to the left
                else if (neighbours[targ].X < potentialNext[r].X)
                {
                    g.DrawLine(myPen, potentialNext[r].X * size, potentialNext[r].Y * size + 1, potentialNext[r].X * size, potentialNext[r].Y * size + size - 1);
                }
                //if neighbours[targ].Y < potentialNext[r].Y -> target cell is above
                else if (neighbours[targ].Y < potentialNext[r].Y)
                {
                    //wallN[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    //g.DrawLine(myPen, size * j, size * i, size * j + size, size * i);
                    g.DrawLine(myPen, potentialNext[r].X * size + 1, potentialNext[r].Y * size, potentialNext[r].X * size + size - 1, potentialNext[r].Y * size);
                }
                //if neighbours[targ].Y > potentialNext[r].Y -> target cell is below
                else if (neighbours[targ].Y > potentialNext[r].Y)
                {
                    g.DrawLine(myPen, potentialNext[r].X * size + 1, potentialNext[r].Y * size + size, potentialNext[r].X * size + size - 1, potentialNext[r].Y * size + size);
                }


                //find neighbours of potentialNext[r] for next iteration
                //if neighbours arent already chosen or in potentialNext, add to potentialNext
                for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
                {                                                   //allows me to add to potentialNext without creating runtime error
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];
                    Point nextPoint = new Point(newCol, newRow);

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (!chosenCells.Contains(nextPoint) && !potentialNext.Contains(nextPoint))
                        {
                            potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid and not previously interacted with

                        }
                    }
                }

                chosenCells.Add(potentialNext[r]); //add chosen cell to chosen cells
                potentialNext.RemoveAt(r); //remove chosen cell from potential choices

                count++;
                progress++;

                this.Update(); //updates progress each iteration, makes maze pathing visual. very statisfying
            }        
        }


        private void generate()
        {

            time.Visible = false;
            progressBar1.Visible = true;

            var watch = new Stopwatch();
            watch.Start();
            Graphics g = mazeContainer.CreateGraphics();
            Color color = mazeContainer.BackColor;


            g.Clear(color);  //disposing of the maze to clear memory, allows for multiple generations without memory leak


            newMakeCells();
            drawMaze();

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            progressBar1.Visible = false;
            time.Visible = true;

            time.Text = "Generated in " + elapsedTime.ToString() + "ms";
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generate();
        }


        private void gridSizeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generate();
            }
        }
    }
}
