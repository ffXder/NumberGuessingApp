﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace NumberGuessingApp
{
    public partial class Form1 : Form
    {
        private int guessNumber;
        private int guessTries = 3;
        private bool hintUsed = false;
        private Random random = new Random();
        private int score = 0;


        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }


        private void StartNewGame()
        {
            guessNumber = random.Next(1, 10);
            guessTries = 3;
            hintUsed = false;
            scoreLabel.Text = $"Score: {score}"; // Update score label
            MessageBox.Show("New game started! You have 3 tries and 1 hint.");
        }

        // Event handler for the Guess button (play_button)
        

        private void play_button_Click(object sender, EventArgs e)
        {
            if (guessTries <= 0)
            {
                MessageBox.Show("Game Over! No more guesses left.\nStarting a new game...");
                StartNewGame();
                return;
            }

            Match matchNumber = Regex.Match(textBox1.Text, @"^\d+$"); // Check if input is a number
            if (!matchNumber.Success)
            {
                MessageBox.Show("Please enter a valid number!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userGuess = Convert.ToInt32(textBox1.Text); // Convert input to integer

            //Scoring System
            if (userGuess == guessNumber)
            { score += 100; // Increase score for correct guess
                MessageBox.Show($"You guessed it right!\nThe correct number was {guessNumber}.");
                if(score < 50) 
                { 
                MessageBox.Show($"Your score: {score}. better luck next time!!!");
                }
                else
                {
                    scoreLabel.Text = $"Score: {score}";
                    MessageBox.Show($"Your score: {score}. Good job!!!");
                }
                  
                    StartNewGame();
            }
            else
            {
                guessTries--; // Reduces yung tries
                score -= 25; // Decrease score for incorrect guess
                if (guessTries > 0)
                {
                    MessageBox.Show($"❌ Wrong! Try again.\nYou have {guessTries} guesses left.");
                }
                else
                {
                    {
                        MessageBox.Show($"❌ Game Over! The correct number was {guessNumber}.\nYour score: {score}\nStarting a new game...");
                        StartNewGame();
                    }
                }
            }

            scoreLabel.Text = $"Score: {score}"; // Update score label
            textBox1.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (hintUsed)
            {
                MessageBox.Show("You have already used your hint!");
                return;
            }

            Match matchNumber = Regex.Match(textBox1.Text, @"^\d+$");
            if (!matchNumber.Success)
            {
                MessageBox.Show("Enter a number first to get a hint!", "Hint Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userGuess = Convert.ToInt32(textBox1.Text);
            int difference = Math.Abs(guessNumber - userGuess);

            string hint;
            if (difference == 0)
                hint = "You already guessed the correct number!";
            else if (difference <= 2)
                hint = "Very close!";
            else if (difference <= 4)
                hint = "Close!";
            else
                hint = "Far away.,.,";

            MessageBox.Show($" Hint: {hint}");
            hintUsed = true;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for playing! uWu");
                this.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}