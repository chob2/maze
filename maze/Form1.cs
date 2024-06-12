using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private Bitmap bmp = new Bitmap(901, 901);
        private int getGridSize(string input)
        {
            int x = Convert.ToInt32(input);
            return x;
        }
        private int gridSize;
        private int size;


        private void bmpUpdate(Pen pen, int x1, int y1, int x2, int y2)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(pen, x1, y1, x2, y2);
            g.Dispose();
        }


        private void makeCells(Color wallColor, Color backColor)
        {
            Pen myPen = new Pen(wallColor, 1);
            SolidBrush myBrush = new SolidBrush(backColor);
            Rectangle rect = new Rectangle(0, 0, size * gridSize, size * gridSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(myBrush, rect);
            }


            bmpUpdate(myPen, 0, 0, gridSize * size, 0); //top border
            bmpUpdate(myPen, 0, 0, 0, gridSize * size); //left border


            for (int i = 0; i < gridSize; i++)
            {
                bmpUpdate(myPen, 0, i * size + size, gridSize * size, i * size + size);//horizontal lines

            }
            for (int i = 0; i < gridSize; i++)
            {
                bmpUpdate(myPen, i * size + size, 0, i * size + size, gridSize * size);//vert lines

            }
            myPen.Dispose();
        }



        private void drawMaze(Color wallColor) //uses a randomised prim's algorithm to generate the maze
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

                Color color = mazeDisplay.BackColor;
                Pen myPen = new Pen(color, 1);

                int targ = rand.Next(0, index);//choosing valid target cell
                //deleting connecting walls between the chosen cells

                //if neighbours[targ].X > potentialNext[r].X -> target cell is to the right
                if (neighbours[targ].X > potentialNext[r].X)
                {
                    bmpUpdate(myPen, potentialNext[r].X * size + size, potentialNext[r].Y * size + 1, potentialNext[r].X * size + size, potentialNext[r].Y * size + size - 1);
                }
                //if neighbours[targ].X < potentialNext[r].X -> target cell is to the left
                else if (neighbours[targ].X < potentialNext[r].X)
                {
                    bmpUpdate(myPen, potentialNext[r].X * size, potentialNext[r].Y * size + 1, potentialNext[r].X * size, potentialNext[r].Y * size + size - 1);

                }
                //if neighbours[targ].Y < potentialNext[r].Y -> target cell is above
                else if (neighbours[targ].Y < potentialNext[r].Y)
                {
                    //wallN[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    //g.DrawLine(myPen, size * j, size * i, size * j + size, size * i);
                    //g.DrawLine(myPen, potentialNext[r].X * size + 1, potentialNext[r].Y * size, potentialNext[r].X * size + size - 1, potentialNext[r].Y * size);
                    bmpUpdate(myPen, potentialNext[r].X * size + 1, potentialNext[r].Y * size, potentialNext[r].X * size + size - 1, potentialNext[r].Y * size);

                }
                //if neighbours[targ].Y > potentialNext[r].Y -> target cell is below
                else if (neighbours[targ].Y > potentialNext[r].Y)
                {
                    bmpUpdate(myPen, potentialNext[r].X * size + 1, potentialNext[r].Y * size + size, potentialNext[r].X * size + size - 1, potentialNext[r].Y * size + size);

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

                // this.Update(); //updates progress each iteration, makes maze pathing visual. very statisfying
            }
            mazeDisplay.Image = bmp;

        }


        private void generate()
        {


            var watch = new Stopwatch();
            watch.Reset();
            watch.Start();






            Color wallColor = wallPreview.BackColor;
            Color backColor = backPreview.BackColor;

            if (wallColor.A == backColor.A && wallColor.G == backColor.G && wallColor.B == backColor.B) //getting colors and validating them
            {
                wallColor = Color.Black;
                backColor = Color.White;

                wallR.Text = wallColor.R.ToString();
                wallG.Text = wallColor.G.ToString();
                wallB.Text = wallColor.B.ToString();

                backR.Text = backColor.R.ToString();
                backG.Text = backColor.G.ToString();
                backB.Text = backColor.B.ToString();
            }

            mazeDisplay.Image = null;//do this one instead probs will be fine idk about memory though i am making a lot of imagaes and not disposing of them
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            mazeDisplay.BackColor = backColor;

            gridSize = getGridSize(gridSizeInput.Text);
            size = (900 / gridSize);


            makeCells(wallColor, backColor);
            drawMaze(wallColor);

            labelStart.Visible = true;
            labelEnd.Location = new Point(55 + gridSize * size, 26 + gridSize * size);
            labelEnd.Visible = true;

            watch.Stop();
            long elapsedTime = watch.ElapsedMilliseconds / 1000;

            progressBar1.Visible = false;
            time.Visible = true;
            btnSolve.Visible = true;
            btnExport.Visible = true;
            buttonGenerate.Visible = true;

            time.Text = "Generated in " + elapsedTime.ToString() + "s";
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(gridSizeInput.Text);
            if (i < 2)
            {
                gridSizeInput.Text = "2";
            }
            generate();
        }


        private void btnSolve_Click(object sender, EventArgs e)
        {
            var watch = new Stopwatch();
            btnSolve.Visible = false;
            buttonGenerate.Visible = false;
            btnExport.Visible=false;
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Visible = true;
            watch.Reset();
            watch.Start();


            solve(gridSize, size);

            watch.Stop();
            progressBar1.Visible=false;
            solveTime.Text = "Solved in " + (watch.ElapsedMilliseconds).ToString() + "ms.";
            solveTime.Visible = true;

            btnExport.Visible = true;
            buttonGenerate.Visible=true;
            
        }


        private Color getColor(Point location) //references bitmap for pixel color at desired point
        { //idk why but this made solving nearly instant
            Color pixelColor = bmp.GetPixel(location.X, location.Y);
            return pixelColor;
        }

        private int getSolverProgress(int x, int y, int ticks)
        {
            double dMax = Math.Sqrt(2 * Math.Pow(gridSize * size, 2));
            double dCurrent = Math.Sqrt(Math.Pow(gridSize * size - x, 2) + Math.Pow(gridSize * size - y, 2));
            int progress = Convert.ToInt32((dCurrent / dMax) * 100);
            if (ticks > gridSize*gridSize/100)
            {
                return progress;
            }
            else
            {
                return progress = progressBar1.Value;
            }
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
            Color color2 = mazeDisplay.BackColor; //color of background
            Color color3 = wallPreview.BackColor;

            Color solverColor = Color.FromArgb(((255 - color2.R) + (255 - color3.R)) / 2, ((255 - color2.G) + (255 - color3.G)) / 2, ((255 - color2.B) + (255 - color3.B)) / 2); //solver line color is opposite to background for most clarity



            Pen myPen = new Pen(solverColor, 1); //solver line
            Pen myEraser = new Pen(color2, 1); //to remove solver line during backtracking
            Point p = new Point(size / 2, size / 2); //solver line starting point


            for (int direction = 0; direction < 4; direction++) //checks cells around starting cell for paths
            {
                int newY = cellOffsetY[direction]; //new coords within current cell that are on each of the four walls
                int newX = cellOffsetX[direction];

                int dirY = gridOffsetY[direction]; //direction the loop is checking, e.g. upwards (0, -1)
                int dirX = gridOffsetX[direction];

                Point point = new Point(newX, newY); //point where wall could be
                Point nextMove = new Point(dirX, dirY);//next point to be moved to on this index

                //Color color1 = getPixelColor(mazeDisplay, point);
                Color color1 = getColor(point);
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

            bmpUpdate(myPen, p.X, p.Y, p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
            p = new Point(p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);

            int ticks = 1;
            progressBar1.Value = getSolverProgress(p.X,p.Y,ticks);
            
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

                    //Color color1 = getPixelColor(mazeDisplay, point);
                    Color color1 = getColor(point);
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

                    bmpUpdate(myPen, p.X, p.Y, p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
                    p = new Point(p.X + moves[moves.Count - 1].X * size, p.Y + moves[moves.Count - 1].Y * size);
                }
                else //if there is no unexplored path (dead end)
                {
                    while (!intersections.Contains(current)) //backtrack until a new path can be found
                    {
                        visited.Add(current);
                        current = new Point(current.X - moves[moves.Count - 1].X, current.Y - moves[moves.Count - 1].Y);

                        bmpUpdate(myEraser, p.X, p.Y, p.X - moves[moves.Count - 1].X * size, p.Y - moves[moves.Count - 1].Y * size);
                        p = new Point(p.X - moves[moves.Count - 1].X * size, p.Y - moves[moves.Count - 1].Y * size);

                        moves.RemoveAt(moves.Count - 1);
                    }
                }
                ticks++;
                progressBar1.Value = getSolverProgress(p.X, p.Y,ticks);
                if(ticks > gridSize * gridSize / 100)
                {
                    ticks = 0;
                }
                progressBar1.Update();

            }
            mazeDisplay.Image = bmp;

        }

        /* private void collectSolverDiagnostics()
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

         }*/





        private string colorChanged(string input)
        {
            try
            {
                int n = Convert.ToInt32(input);
                if (n < 0)
                {
                    input = "0";
                }
                else if (n > 255)
                {
                    input = "255";
                }
            }
            catch
            {
                if (input != "")
                {
                    input = "0";
                }
            }



            return input;

        }

        private void wallR_TextChanged(object sender, EventArgs e)
        {
            wallR.Text = colorChanged(wallR.Text);
            string input = wallR.Text;
            if (input != "")
            {
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));
            }
        }

        private void wallG_TextChanged(object sender, EventArgs e)
        {
            wallG.Text = colorChanged(wallG.Text);
            string input = wallG.Text;
            if (input != "")
            {
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));
            }
        }

        private void wallB_TextChanged(object sender, EventArgs e)
        {
            wallB.Text = colorChanged(wallB.Text);
            string input = wallB.Text;
            if (input != "")
            {
                wallPreview.BackColor = Color.FromArgb(Convert.ToInt32(wallR.Text), Convert.ToInt32(wallG.Text), Convert.ToInt32(wallB.Text));
            }
        }

        private void backR_TextChanged(object sender, EventArgs e)
        {
            backR.Text = colorChanged(backR.Text);
            string input = backR.Text;
            if (input != "")
            {
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));
            }
        }

        private void backG_TextChanged(object sender, EventArgs e)
        {
            backG.Text = colorChanged(backG.Text);
            string input = backG.Text;
            if (input != "")
            {
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));
            }
        }

        private void backB_TextChanged(object sender, EventArgs e)
        {
            backB.Text = colorChanged(backB.Text);
            string input = backB.Text;
            if (input != "")
            {
                backPreview.BackColor = Color.FromArgb(Convert.ToInt32(backR.Text), Convert.ToInt32(backG.Text), Convert.ToInt32(backB.Text));
            }
        }

        private void gridSizeInput_TextChanged(object sender, EventArgs e)
        {
            int input;
            try
            {
                input = Convert.ToInt32(gridSizeInput.Text);
                if (input < 1)
                {
                    gridSizeInput.Text = "1";
                }
                else if (input > 200)
                {
                    gridSizeInput.Text = "200";
                }
            }
            catch
            {
                if (gridSizeInput.Text != "")
                {
                    gridSizeInput.Text = "50";
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); //creating save file dialogue
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg"; //filters and stuff
            saveFileDialog.Title = "Save As";
            saveFileDialog.DefaultExt = "png";


            int gridSize = Convert.ToInt32(gridSizeInput.Text);
            int size = 900 / gridSize; //true length of maze

            Rectangle crop = new Rectangle(0, 0, gridSize * size, gridSize * size); //cropped maze (displayed size varies)

            Bitmap image = new Bitmap(crop.Width, crop.Height);


            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, crop.Width, crop.Height), crop, GraphicsUnit.Pixel); //applying crop
            }


            if (saveFileDialog.ShowDialog() == DialogResult.OK) //when user clicks save
            {
                string filePath = saveFileDialog.FileName;
                ImageFormat format = saveFileDialog.FilterIndex == 1 ? ImageFormat.Png : ImageFormat.Jpeg;
                image.Save(filePath, format);
            }
        }
    }
}
