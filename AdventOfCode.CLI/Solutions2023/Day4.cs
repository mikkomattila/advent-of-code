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
    private record Card(
        int Id, 
        IReadOnlyList<int> WinningNumbers, 
        IReadOnlyList<int> MatchingNumbers
    );

    public DayResult GetResultForDay()
    {
        var input = Common.ReadInputLines("4");
        var firstPart = GetFirstPart(input);
        var secondPart = GetSecondPart(input);

        return new DayResult(firstPart, secondPart);
    }

    public static double GetFirstPart(string[] input)
    {
        var cards = input
            .Select(CreateCard)
            .ToList();

        return cards.Sum(card =>
            card.MatchingNumbers.Any()
                ? Math.Pow(2, card.MatchingNumbers.Count - 1)
                : 0
            );
    }

    public static double GetSecondPart(string[] input)
    {
        var result = 0;

        var initialCards = input
            .Select(CreateCard)
            .ToList();

        result += initialCards.Count;

        foreach (var card in initialCards)
        {
            var isMatchFound = card.MatchingNumbers.Any();
            if (!isMatchFound) continue;

            result += GetMatchingCardIdsRecursive(card, initialCards).Count;
        }

        return result;
    }

    private static IReadOnlyList<int> GetMatchingCardIdsRecursive(Card card, List<Card> initialCards) 
    {
        List<int> matchingCardIds = new();

        foreach (var (match, i) in card.MatchingNumbers.Select((value, i) => (value, i)))
        {
            var nextCardIndex = card.Id + i;
            if (nextCardIndex >= initialCards.Count) continue;
            
            var nextCard = initialCards[nextCardIndex];
            matchingCardIds.Add(nextCard.Id);
            matchingCardIds.AddRange(GetMatchingCardIdsRecursive(nextCard, initialCards));
        }

        return matchingCardIds;
    }

    private static Card CreateCard(string input)
    {
        var id = int.TryParse(Regex.Match(input, @"\d+").Value, out int parsedId) 
            ? parsedId 
            : 0;

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
