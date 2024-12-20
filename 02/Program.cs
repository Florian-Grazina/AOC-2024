using _02;
using Spectre.Console;

// 431
// 434
// 435

// 424
// 436

var input = File.ReadAllLines("../../../input.txt");

List<Report> reports = [];
foreach (string line in input)
{
    reports.Add(new Report(line));
}

var result = reports.Where(r => r.IsSafe).Count();

var grid = new Grid();

grid.AddColumn();
grid.AddColumn();

grid.AddRow(new string[] { "Levels", "Report" });

foreach (var report in reports)
{
    grid.AddRow([
        new Text(string.Join(" ", report.Levels)),
        new Text(report.IsSafe ? "Safe" : "Unsafe", new Style(report.IsSafe? Color.Green : Color.Red))
    ]);
};

AnsiConsole.Write(grid);

Console.WriteLine(result);
