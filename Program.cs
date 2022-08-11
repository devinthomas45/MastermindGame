using System;
using System.Collections.Generic;

namespace MastermindGame
{
    internal class Program
    {
    
        static void Main(string[] args)
        {
            //Generate Random 4 numbers 1-6
            //Get users input of 4 numbers 1-6
            //Payer has 10 attempts to get correct answer : "++++"
            //Add minus (-) if number is correct but in wrong position
            //Add plus (+) if number is correct and in correct position
            //Do not add anything if number does not exist
            var mastermindGame = new MastemindGame();
           
            mastermindGame.StartGame();


        }


    }
}
