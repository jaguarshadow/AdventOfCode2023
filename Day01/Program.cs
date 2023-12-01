using System.Text.RegularExpressions;

var input = File.ReadAllLines(@"input.txt");

int part1sum = 0;
foreach (var line in input) {
    var first = line.First(x => char.IsNumber(x));
    var last = line.Last(x => char.IsNumber(x));
    var number = int.Parse(new string(new[] { first, last }));
    part1sum += number;
}
Console.WriteLine($"Part 1: Sum of all calibration values: {part1sum}");


int part2sum = 0;
var spelled_numbers = new Dictionary<string, string>() { { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" }, { "seven", "7" }, { "eight", "8" }, { "nine", "9" } };
var pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";
foreach (var line in input) {
    var first_match = Regex.Match(line, pattern).Value;
    var last_match = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
    var first_digit = first_match.Length > 1 ? spelled_numbers[first_match] : first_match;
    var last_digit  = last_match.Length > 1  ? spelled_numbers[last_match]  : last_match;
    part2sum += int.Parse(first_digit + last_digit);
}
Console.WriteLine($"Part 2: Sum of all calibration values: {part2sum}");