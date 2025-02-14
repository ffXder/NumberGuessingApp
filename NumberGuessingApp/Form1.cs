using System.Text.RegularExpressions;

namespace NumberGuessingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Guess Button
        private void play_button_Click(object sender, EventArgs e)
        {
            Random random = new Random(); //using random
            int guessNumber = random.Next(1, 10); //guess the number up to 1 to 10
            String showNumber = Convert.ToString(guessNumber);
            Match matchNumber = Regex.Match(textBox1.Text, @"\d+"); //checks if the user input are all the digits using regex
            if (matchNumber.Success)
            {
                if (textBox1.Text == showNumber)
                {
                    MessageBox.Show(" You guessed it right!" + "\n The correct answer is " + showNumber);
                }
                else
                {
                    MessageBox.Show(" Wrong! try again!" + "\n The correct answer is " + showNumber);
                }
            } else {
                DialogResult dr = MessageBox.Show("Please input a number", "Wrong Input", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            textBox1.Clear(); //clears the textbox after pressing the button
        }
        //Exit Button
        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for using our game :>");
                this.Close();
            }
        }
    }
}
