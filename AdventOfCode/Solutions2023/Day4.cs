using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 4 of 2023.
/// Instructions: https://adventofcode.com/2023/day/4.
/// </summary>
public class Day4 : IDay
{
    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day4Input.txt");
        var firstAnswer = GetFirstAnswer(input);
        var secondAnswer = GetSecondAnswer(input);

        return new DayResult(firstAnswer.ToString(), "");
    }

    public static double GetFirstAnswer(string[] cards)
    {
        var totalPoints = 0.0;

        foreach (var card in cards)
        {
            var cardParts = card.Split('|');
            var winningNumbers = ParseNumbers(cardParts[0].Split(':')[1]);
            var resultNumbers = ParseNumbers(cardParts[1]);

            var matchingNumbers = winningNumbers.Intersect(resultNumbers).ToList();

            var matchingNumbersWithIndex = matchingNumbers
                .Select((value, i) => (value, i));

            var points = matchingNumbers.Count == 0
                ? 0
                : Math.Pow(2, matchingNumbers.Count - 1);

            totalPoints += points;
        }

        return totalPoints;
    }

    public static double GetSecondAnswer(string[] input)
    {
        var result = 0;

        var cards = input
            .Select((value, i) => (value, i));

        foreach (var (card, cardIndex) in cards)
        {
            var cardParts = card.Split('|');
            var winningNumbers = ParseNumbers(cardParts[0].Split(':')[1]);
            var resultNumbers = ParseNumbers(cardParts[1]);

            var matchingNumbers = winningNumbers.Intersect(resultNumbers).ToList();

            var cardCopies = string.Empty;

            foreach (var match in matchingNumbers)
            {
                var nextCardIndex = cardIndex + 1;
                if (nextCardIndex > cards.Count())
                    break;

                var nextCard = cards.ElementAt(cardIndex + 1).value;
                Console.WriteLine("current" + card);
                Console.WriteLine("nextcard"+nextCard);

            }

        }


        return 0;
    }

    private static List<int> ParseNumbers(string input)
        => input.Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToList();
}
