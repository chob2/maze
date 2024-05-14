using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void makeCells(int gridSize, int size, Color wallColor)
        {


            Pen myPen = new Pen(wallColor, 1);
            Graphics g = mazeContainer.CreateGraphics();

            mazeContainer.Size = new Size(size * gridSize+1, size * gridSize+1);


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
            g.Dispose();
        }



        private void drawMaze(int gridSize, int size) //uses a randomised prim's algorithm to generate the maze
        {
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


            progressBar1.Maximum = gridSize * gridSize;
            int progress = 0;

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
            watch.Reset();
            watch.Start();

            Graphics g = mazeContainer.CreateGraphics();
            Color color = mazeContainer.BackColor;


            g.Clear(color);  //disposing of the maze to clear memory, allows for multiple generations without memory leak
            g.Dispose();


            Color wallColor = wallPreview.BackColor;
            Color backColor = backPreview.BackColor;
            mazeContainer.BackColor = backColor;
            int gridSize;
            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 2)
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

            mazeContainer.Size = new Size(900, 900);
            int size = (mazeContainer.Width / gridSize);
            mazeContainer.Size = new Size(901, 901);


            makeCells(gridSize, size, wallColor);
            drawMaze(gridSize, size);

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            progressBar1.Visible = false;
            time.Visible = true;
            btnSolve.Visible = true;
            btnExport.Visible = true;

            time.Text = "Generated in " + elapsedTime.ToString() + "ms";
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generate();
        }




        private void btnSolve_Click(object sender, EventArgs e)
        {
            var watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            int gridSize;
            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 2)
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
                MessageBox.Show("Invalid input (" + gridSizeInput.Text + ") . Grid size set to default (50).");
            }

            int size = (mazeContainer.Width / gridSize);


            solve(gridSize, size);

            watch.Stop();
            solveTime.Text = "Solved in ~" + (watch.ElapsedMilliseconds / 1000).ToString() + "s.";
            solveTime.Visible = true;
            MessageBox.Show("Solver complete");

        }

        public Color getPixelColor(Control control, Point location)//function that checks the pixel color of a given point
        {
            Point screenPoint = control.PointToScreen(location); //converts point in the mazeContainer to a point on the screen
            Bitmap bitmap = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, new Size(1, 1)); //captures pixel at desired point
            }
            Color pixelColor = bitmap.GetPixel(0, 0);
            bitmap.Dispose();
            return pixelColor;
        }



        private void solve(int gridSize, int size)//maze solver using DFS algorithm
        {
            Random rand = new Random();

            int[] cellOffsetY = { 0, size / 2, size, size / 2 };
            int[] cellOffsetX = { size / 2, size, size / 2, 0 };


            int[] gridOffsetX = { 0, 1, 0, -1 }; //n, e, s, w
            int[] gridOffsetY = { -1, 0, 1, 0 };

            List<Point> moves = new List<Point>(); //list of moves, e.g. up one or left one
            List<Point> visited = new List<Point>(); //visited cells
            List<Point> intersections = new List<Point>(); //list of cells with unexplored intersections


            Point[] next = new Point[4]; //potential cell that can be moved to
            int index = 0; //index for next

            Point current = new Point(0, 0); //current point, starting at 0,0
            Color color2 = Color.White; //color of background

            Pen myPen = new Pen(Color.Red, 2); //solver line
            Pen myEraser = new Pen(Color.White, 2); //to remove solver line during backtracking
            Graphics g = mazeContainer.CreateGraphics();
            Point p = new Point(size / 2, size / 2); //solver line starting point


            for (int direction = 0; direction < 4; direction++) //checks cells around starting cell for paths
            {
                int newY = cellOffsetY[direction]; //new coords within current cell that are on each of the four walls
                int newX = cellOffsetX[direction];

                int dirY = gridOffsetY[direction]; //direction the loop is checking, e.g. upwards (0, -1)
                int dirX = gridOffsetX[direction];

                Point point = new Point(newX, newY); //point where wall could be
                Point nextMove = new Point(dirX, dirY);//next point to be moved to on this index

                Color color1 = getPixelColor(mazeContainer, point);
                //checks n,e,s,w
                if (color1.A == color2.A && color1.R == color2.R && color1.G == color2.G && color1.B == color2.B) //if the inspected pixel is the same as background, there is no wall
                { //really annoyinng to compare all argb values, required though because names will not match even if argb does
                    next[index] = nextMove; //if no wall, add connecting cell to potential next moves
                    index++;
                }
            }
            if (index > 1 && !intersections.Contains(current)) //if there is more than one choice and node isnt already marked as intersection, mark as intersection
            {
                intersections.Add(current);
            }


            int targ = rand.Next(0, index); //choose random number to select next cell
            moves.Add(next[targ]); //add move to the list of moves made
            visited.Add(current); //add current cell to list of visited cells
            current = new Point(moves[moves.Count - 1].X, moves[moves.Count - 1].Y); //update current cell to the next cell

            g.DrawLine(myPen, p.X, p.Y, p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
            p = new Point(p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);

            while (current != new Point(gridSize - 1, gridSize - 1)) //while the current cell is not the end cell
            {
                index = 0;
                bool path = false; //boolean to store if a node has a continuing path from it, if false algorithm starts backtracking


                for (int direction = 0; direction < 4; direction++) //checks cells around starting cell for paths
                {
                    int newY = cellOffsetY[direction];
                    int newX = cellOffsetX[direction];

                    int dirY = gridOffsetY[direction];
                    int dirX = gridOffsetX[direction];

                    Point point = new Point(current.X * size + newX, current.Y * size + newY);
                    Point nextMove = new Point(dirX, dirY);
                    Point checkPoint = new Point(current.X + dirX, current.Y + dirY);

                    Color color1 = getPixelColor(mazeContainer, point);
                    //checks in the order of w, n, e, s

                    if (color1.A == color2.A && color1.R == color2.R && color1.G == color2.G && color1.B == color2.B)
                    {
                        if (!visited.Contains(checkPoint))
                        {
                            next[index] = nextMove; //if no wall and not already visited, add to next moves
                            index++;
                            path = true;
                        }
                    }
                }


                if (index > 1 && !intersections.Contains(current)) //records intersection if multiple paths and its not already marked
                {
                    intersections.Add(current);
                }
                else if (index <= 1 && intersections.Contains(current)) //removes intersection if it is recorded but there are no longer multiple paths
                {
                    intersections.Remove(current);
                }


                if (path) //if there is an unexplored path
                {
                    targ = rand.Next(0, index);
                    moves.Add(next[targ]);
                    visited.Add(current);
                    current = new Point(current.X + moves[moves.Count - 1].X, current.Y + moves[moves.Count - 1].Y);

                    g.DrawLine(myPen, p.X, p.Y, p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
                    p = new Point(p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
                }
                else //if there is no unexplored path (dead end)
                {
                    while (!intersections.Contains(current)) //backtrack until a new path can be found
                    {
                        visited.Add(current);
                        current = new Point(current.X - moves[moves.Count - 1].X, current.Y - moves[moves.Count - 1].Y);

                        g.DrawLine(myEraser, p.X, p.Y, p.X - moves[moves.Count - 1].X * size, p.Y - moves[moves.Count - 1].Y * size); //erase solver line on incorrect path
                        p = new Point(p.X - moves[moves.Count - 1].X * size, p.Y - moves[moves.Count - 1].Y * size);

                        moves.RemoveAt(moves.Count - 1);
                    }
                }
            }
        }

        private void collectSolverDiagnostics()
        {
            var watch = new Stopwatch();
            string[] times = new string[25];
            int index = 0;
            for(int i = 1; i < 6; i++)
            {
                mazeContainer.Size = new Size(900, 900);
                int gridSize = 10 * i;
                int size = (mazeContainer.Width / gridSize);
                mazeContainer.Size = new Size(901, 901);

                for (int j=0; j < 5; j++)
                {
                    Graphics g = mazeContainer.CreateGraphics();
                    g.Clear(mazeContainer.BackColor);
                    g.Dispose();

                    watch.Reset();
                    watch.Start();
                    
                    //makeCells(gridSize, size);
                    drawMaze(gridSize, size);
                    solve(gridSize, size);

                    watch.Stop();

                    times[index] = watch.ElapsedMilliseconds.ToString();
                    index++;
                }
            }

            string filePath = "R:\\out\\out.txt";
            File.WriteAllLines(filePath, times);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            collectSolverDiagnostics();
        }



        private int colorChanged(int value)
        {
            int n;
            if(value < 0)
            {
                n = 0;

            }
            else if(value > 255)
            {
                n = 255;
            }
            else
            {
                n = value;
            }
            return n;

            
        }

        private void wallR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(wallR.Text));
                wallR.Text = n.ToString();
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));

            }
            catch
            {
                if(wallR.Text != "")
                {
                    wallR.Text = "0";
                }
            }
        }

        private void wallG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(wallG.Text));
                wallG.Text = n.ToString();
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));

            }
            catch
            {
                if (wallG.Text != "")
                {
                    wallG.Text = "0";
                }
            }
        }

        private void wallB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(wallB.Text));
                wallB.Text = n.ToString();
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));

            }
            catch
            {
                if (wallB.Text != "")
                {
                    wallB.Text = "0";
                }
            }
        }

        private void backR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(backR.Text));
                backR.Text = n.ToString();
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));

            }
            catch
            {
                if (backR.Text != "")
                {
                    backR.Text = "0";
                }
            }
        }

        private void backG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(backG.Text));
                backG.Text = n.ToString();
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));

            }
            catch
            {
                if (backG.Text != "")
                {
                    backG.Text = "0";
                }
            }
        }

        private void backB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int n = colorChanged(Convert.ToInt32(backB.Text));
                backB.Text = n.ToString();
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));

            }
            catch
            {
                if (backB.Text != "")
                {
                    backB.Text = "0";
                }
            }
        }
    }
}
