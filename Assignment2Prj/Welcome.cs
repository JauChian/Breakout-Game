using System;
using System.Windows.Forms;

namespace Assignment2Prj
{
    /// <summary>
    /// Welocme form is displayed once the program starts, it has two buttons: "Play" and "Exit"  
    /// The Play button allows user to enter the game form, with default gameLvel = 1
    /// The Exit button allows user to exit the game
    /// </summary>
    public partial class Welcome : Form
    {
        // Constructor for the Welcome form
        public Welcome()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during Welcome form initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for button1 click event
        // This method starts the game and hides the Welcome form
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new instance of the Game form, with level 1
                Game game = new Game(1);
                // Show the Game form
                game.Show();
                // Hide the Welcome form
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while starting the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for button2 click event
        // This method closes the game
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while closing the application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
