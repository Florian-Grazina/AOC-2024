using _18;

var input = File.ReadAllLines("../../../input.txt");

MapHolder map = new MapHolder(input);
Console.WriteLine(map.FindBlockCoord());

// 228