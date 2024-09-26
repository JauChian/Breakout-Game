using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// Bricks class includes attributes bricks, rows, cols, brickWidth, brickHeight, and _numberOfBricks.
    /// It also has createBricks and CreateBricksForLevel methods to create bricks for different levels.
    /// </summary>
    class Bricks
    {
        private PictureBox[,] bricks;
        private int rows;
        private int cols;
        private int brickWidth, brickHeight;
        private int _numberOfBricks;
        private int[,] bricksFirmless;
        private int gameLevel;

        Random rnd = new Random();

        /// Gets or sets the array of PictureBoxes representing the bricks.
        public PictureBox[,] BricksArray
        {
            get { return bricks; }
            private set { bricks = value; }
        }

        /// Gets or sets the number of bricks.
        public int numberOfBricks
        {
            get { return _numberOfBricks; }
            set { _numberOfBricks = value; }
        }

        /// Initializes a new instance of the Bricks class with the specified number of rows and columns.
        public Bricks(int rows, int cols, int windowWidth, int windowHeight, int gameLevel)
        {
            // Set default brick size
            this.brickHeight = 40; // Default height of the brick
            this.brickWidth = 100; // Default width of the brick

            // Set rows and columns
            this.rows = rows;
            this.cols = cols;

            // Set game Level
            this.gameLevel = gameLevel;

            // Create the array of PictureBoxes
            this.bricks = new PictureBox[rows, cols];
            this.bricksFirmless = new int[rows, cols];
            createBricks(windowWidth);
        }

        /// The method that creates bricks and sets up basic information for bricks.
        public void createBricks(int windowWidth)
        {
            // Set initial position and gap between bricks
            int top = 50;
            int gapHeight = 10;
            this._numberOfBricks = 0;
            // Calculate the total brick width and the remaining space for gaps
            int totalBrickWidth = cols * brickWidth;
            int remainingSpace = windowWidth - totalBrickWidth;
            int gapWidth = remainingSpace / (cols + 1);

            try
            {
                // Loop through each row and column to create PictureBoxes for bricks
                for (int x = 0; x < rows; x++)
                {
                    for (int y = 0; y < cols; y++)
                    {
                        // Create a new PictureBox for the brick
                        bricks[x, y] = new PictureBox();
                        bricks[x, y].Size = new Size(brickWidth, brickHeight);

                        // Set the position of the brick
                        bricks[x, y].Left = gapWidth + brickWidth * y + gapWidth * y;
                        bricks[x, y].Top = top + brickHeight * x + gapHeight * x;

                        // Set a random image from resources
                        SetImage(x, y);

                        // Generate a random number for the brick and use it for PowerUp
                        try
                        {
                            int randomNumber = rnd.Next(1, 6);
                            bricks[x, y].Text = randomNumber.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while generating a random number for the brick: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Set a tag for the brick
                        bricks[x, y].Tag = new Tuple<int, int>(x, y);

                        // Set firmless dependce on gameLevel 
                        setBrickFirmless(x, y, gameLevel);

                        // Increment the total number of bricks
                        _numberOfBricks+= gameLevel;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during Bricks initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Gets the durability of a brick.
        public int GetBrickFirmless(int row, int col)
        {
            return bricksFirmless[row, col];
        }

        /// Reduces the durability of a brick.
        public void SetBrickFirmless(int row, int col)
        {
            bricksFirmless[row, col]--;
        }

        /// Sets a random image for a brick.
        /// <param name="row">The row of the brick.</param>
        /// <param name="col">The column of the brick.</param>
        public void SetImage(int row, int col)
        {
            try
            {
                string imageName = "brick" + rnd.Next(1, 22).ToString();
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
                if (img != null)
                {
                    bricks[row, col].Image = img;
                    bricks[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting the brick image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // The method set bricks frimless basic on the diffenrt level of game  
        public void setBrickFirmless (int row, int col ,int gameLevel)
        {
            bricksFirmless[row, col] = gameLevel;
        }
    }
}
