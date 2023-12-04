using AdventOfCode.Classes;
using AdventOfCode.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 4 of 2023.
/// Instructions: https://adventofcode.com/2023/day/4.
/// </summary>
public class Day4 : IDay
{
    record Card(int Id, List<int> WinningNumbers, List<int> ResultNumbers, List<int> MatchingNumbers);

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day4Input.txt");
        var firstAnswer = GetFirstAnswer(input);
        var secondAnswer = GetSecondAnswer(input);

        return new DayResult($"{firstAnswer}", $"{secondAnswer}");
    }

    public static double GetFirstAnswer(string[] inputLines)
    {
        double totalPoints = 0.0;

        foreach (var input in inputLines)
        {
            var card = CreateCard(input);

            totalPoints += card.MatchingNumbers.Any()
                ? Math.Pow(2, card.MatchingNumbers.Count - 1)
                : 0;
        }

        return totalPoints;
    }

    public static double GetSecondAnswer(string[] inputLines)
    {
        double scratchCards = 0.0;

        List<Card> initialCards = new();

        foreach (var input in inputLines)
            initialCards.Add(CreateCard(input));

        scratchCards += initialCards.Count;

        Console.WriteLine(string.Join(", ", initialCards.Select(x => x.Id).ToList()));

        initialCards.ForEach(card =>
        {
            var isMatchFound = card.MatchingNumbers.Any();
            if (isMatchFound)
            {
                var nextCards = GetNextCards(card, initialCards);
            }
        });

        return scratchCards;
    }

    private static List<Card> GetNextCards(Card card, List<Card> initialCards) 
    {
        List<Card> nextCards = new();

        foreach (var (match, i) in card.MatchingNumbers.Select((value, i) => (value, i))
        {
            var nextCard = initialCards.ElementAt(card.Id + i);
            nextCards.Add(nextCard);
        }

        var ids = nextCards.Where(c => c.Id != card.Id).Select(c => c.Id).ToList();
        var idsString = string.Join(',', ids);
        if (!string.IsNullOrEmpty(idsString))
            Console.WriteLine(idsString);
        


        nextCards.ForEach(x => GetNextCards(x, initialCards));

        return nextCards;
    }

    private static Card CreateCard(string input)
    {
        var cardParts = input.Split('|');
        var match = Regex.Match(input, @"\d+");
        var id = int.Parse(match.Value);

        var winningNumbers = ParseNumbers(cardParts[0].Split(':')[1]);
        var resultNumbers = ParseNumbers(cardParts[1]);
        var matchingNumbers = winningNumbers.Intersect(resultNumbers).ToList();

        return new Card(id, winningNumbers, resultNumbers, matchingNumbers);
    }

    private static List<int> ParseNumbers(string input)
        => input.Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToList();
}
