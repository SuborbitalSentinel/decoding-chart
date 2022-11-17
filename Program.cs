var rnd = new Random();
var all_characters = File.ReadAllLines("character_set.txt").SelectMany(l => l.Split(" "));

Func<IEnumerable<string>, int, IEnumerable<string>> RowValues = (choice, count) => choice.OrderBy(_ => rnd.Next()).Take(count);
Func<string, string> ToDiv = (input) => $"<div>{input}</div>";
Func<IEnumerable<string>, string> ToRow = (input) => string.Join(Environment.NewLine, input.Select(ToDiv));
Func<string> GenerateRow = () => ToRow(RowValues(all_characters, 6));


var output = File.ReadAllLines("index.html").Select(l => l.Replace("{{ROW}}", GenerateRow()));
File.WriteAllLines("output.html", output);
