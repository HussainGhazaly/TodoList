


using DiceRollGame.Game;

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

GameResult gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);


Console.ReadKey();






/*
 * 
 * 
 *   // Enum type is a type that defines a set if names constants ,
 *   (we will use it to create a better name for bool)
 * 
 * */


//Season firstSeason = Season.Spring;
//Season lastSeason = Season.Winter;
//int firstSeasonAsNumber = (int)firstSeason;
//int LastSeasonAsNumber = (int)lastSeason;

//Console.WriteLine(firstSeason);
//Console.WriteLine("As a number: " + firstSeasonAsNumber);

//Console.WriteLine(lastSeason);
//Console.WriteLine("As a number: " + LastSeasonAsNumber);

//Console.ReadKey();

//public enum Season
//{
//    Spring = 1, //0
//    Summer, //1
//    Autumn, //2
//    Winter //3
//}

//public enum HttpCode
//{
//    ok =200,
//    NotFound = 404,
//    InternalServerError = 500
//}



