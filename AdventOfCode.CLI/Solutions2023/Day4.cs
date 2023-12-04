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
    private record Card(int Id, IReadOnlyList<int> WinningNumbers, IReadOnlyList<int> MatchingNumbers);

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("4");
        var firstAnswer = GetFirstAnswer(input);
        var secondAnswer = GetSecondAnswer(input);

        return new DayResult($"{firstAnswer}", $"{secondAnswer}");
    }

    public static double GetFirstAnswer(string[] inputLines)
    {
        var cards = inputLines.Select(CreateCard).ToList();

        return cards.Sum(card =>
            card.MatchingNumbers.Any()
                ? Math.Pow(2, card.MatchingNumbers.Count - 1)
                : 0
            );
    }

    public static double GetSecondAnswer(string[] inputLines)
    {
        var cards = inputLines.Select(CreateCard).ToList();
        var result = cards.Count;

        foreach (var card in cards)
        {
            var isMatchFound = card.MatchingNumbers.Any();
            if (!isMatchFound) continue;

            var nextIds = GetNextCardMatchingIdsRecursively(card, cards);
            result += nextIds.Count;
        }

        return result;
    }

    private static IReadOnlyList<int> GetNextCardMatchingIdsRecursively(Card card, List<Card> initialCards) 
    {
        List<int> idList = new();
        List<Card> nextCards = new();

        var matchingNumbersWithIndex = card.MatchingNumbers
            .Select((value, i) => (value, i));

        foreach (var (match, i) in matchingNumbersWithIndex)
        {
            var nextCard = initialCards.ElementAt(card.Id + i);
            nextCards.Add(nextCard);
        }

        var nextCardIds = nextCards
            .Where(c => c.Id != card.Id)
            .Select(c => c.Id);

        if (nextCardIds.Any())
            idList.AddRange(nextCardIds);
        
        foreach (var nextCard in nextCards)
        {
            var nestedIds = GetNextCardMatchingIdsRecursively(nextCard, initialCards);
            idList.AddRange(nestedIds);
        }

        return idList;
    }

    private static Card CreateCard(string input)
    {
        var idMatch = Regex.Match(input, @"\d+");
        _ = int.TryParse(idMatch.Value, out int id);

        var parts = input.Split('|');
        var winningNumbers = ParseNumbers(parts[0].Split(':')[1]);
        var resultNumbers = ParseNumbers(parts[1]);

        var matchingNumbers = winningNumbers
            .Intersect(resultNumbers)
            .ToList();

        return new Card(id, winningNumbers, matchingNumbers);
    }

    private static IReadOnlyList<int> ParseNumbers(string input)
        => input.Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToList();
}
