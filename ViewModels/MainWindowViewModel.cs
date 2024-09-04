using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridScrollBugTest.ViewModels;

/// <summary>
/// ViewModel for the main window.
/// </summary>
public partial class MainWindowViewModel : ObservableObject
{
    /// <summary>
    /// Collection of items.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<Item> _items = GenerateItems(50, 50);

    /// <summary>
    /// Generates a collection of items with a random count between the specified minimum and maximum.
    /// </summary>
    /// <param name="minCount">The minimum number of items to generate.</param>
    /// <param name="maxCount">The maximum number of items to generate.</param>
    /// <returns>A collection of randomly generated items.</returns>
    public static ObservableCollection<Item> GenerateItems(int minCount, int maxCount)
    {
        var items = new ObservableCollection<Item>();
        var random = new Random();
        var count = random.Next(minCount, maxCount + 1);
        for (var i = 0; i < count; i++)
        {
            items.Add(new Item(i));
        }
        return items;
    }
}

/// <summary>
/// Represents an item with various properties.
/// </summary>
public partial class Item : ObservableObject
{
    [ObservableProperty]
    private int _index;

    /// <summary>
    /// The name of the item.
    /// </summary>
    [ObservableProperty]
    private string _name = GenerateRandomName();

    /// <summary>
    /// The value of the item.
    /// </summary>
    [ObservableProperty]
    private int _value = GenerateRandomValue();

    /// <summary>
    /// The birthdate of the item.
    /// </summary>
    [ObservableProperty]
    private DateTime _birthDay = GenerateRandomBirthDay();

    /// <summary>
    /// Indicates whether the item is male.
    /// </summary>
    [ObservableProperty]
    private bool _isMale = new Random().Next(0, 2) == 0;

    /// <summary>
    /// The hair color of the item.
    /// </summary>
    [ObservableProperty]
    private string _hairColor = "White";

    partial void OnHairColorChanged(string value)
    {
        HairColorContent = value;
        Debug.WriteLine($"Grid row  Index {Index} <hair color changed to: {value}>");
    }

    /// <summary>
    /// Generates a random name from a predefined list.
    /// </summary>
    /// <returns>A randomly selected name.</returns>
    private static string GenerateRandomName()
    {
        var names = new List<string>
                    {
                        "John",
                        "Jane",
                        "Michael",
                        "Emily",
                        "David",
                        "Sarah",
                        "Riven",
                        "Sarah",
                        "RealMax",
                        "Jinx",
                        "Zed",
                        "Yasuo"
                    };

        var random = new Random();
        var index = random.Next(names.Count);
        return names[index];
    }

    /// <summary>
    /// Generates a random integer value.
    /// </summary>
    /// <returns>A randomly generated integer.</returns>
    private static int GenerateRandomValue()
    {
        var random = new Random();
        return random.Next();
    }

    /// <summary>
    /// Generates a random birthdate.
    /// </summary>
    /// <returns>A randomly generated birthdate.</returns>
    private static DateTime GenerateRandomBirthDay()
    {
        var random = new Random();
        var year = random.Next(1900, 2022);
        var month = random.Next(1, 13);
        var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateTime(year, month, day);
    }
    public Item()
    {

    }
    public Item(int index)
    {
        _index = index;
    }

    /// <summary>
    /// Gets the content of the hair color.
    /// </summary>
    [ObservableProperty] private string _hairColorContent;

    /// <summary>
    /// Collection of hair colors.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<string> _hairColors =
    [
        "Brown",
        "Red",
        "AliceBlue",
        "AntiqueWhite",
        "Aqua",
        "Aquamarine",
        "Azure",
        "Beige",
        "Bisque",
        "Black",
        "BlanchedAlmond",
        "Blue",
        "BlueViolet",
        "Brown",
        "BurlyWood",
        "CadetBlue",
        "Chartreuse",
        "Chocolate",
        "Coral",
        "CornflowerBlue"
    ];
}
