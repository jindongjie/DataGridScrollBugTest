using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridScrollBugTest.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Item> _items = GenerateItems(300,400);

    public static ObservableCollection<Item> GenerateItems(int minCount, int maxCount)
    {
        var items = new ObservableCollection<Item>();
        var random = new Random();
        var count = random.Next(minCount, maxCount + 1);

        for (var i = 0; i < count; i++)
        {
            items.Add(new Item());
        }
        return items;
    }
}

public class Item
{
    private static DateTime GenerateRandomBirthDay()
    {
        var random = new Random();
        var year = random.Next(1900, 2022);
        var month = random.Next(1, 13);
        var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateTime(year, month, day);
    }

    public string Name { get; } = GenerateRandomName();
    public int Value { get; } = GenerateRandomValue();

    public DateTime BirthDay { get; } = GenerateRandomBirthDay();

    private static string GenerateRandomName()
    {
        var names = new List<string>
        {
            "John",
            "Jane",
            "Michael",
            "Emily",
            "David",
            "Sarah"
        };

        var random = new Random();
        var index = random.Next(names.Count);
        return names[index];
    }

    private static int GenerateRandomValue()
    {
        var random = new Random();
        return random.Next();
    }
}