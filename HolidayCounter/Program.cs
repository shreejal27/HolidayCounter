using HolidayCounter;
using System;

Console.WriteLine("Holiday Counter");

bool flag = true;

DateTime cDate = DateTime.Today;

//DateTime[] startDate = new DateTime[5];
//startDate[0] = new DateTime(11, 11, 10);
//startDate[1] = new DateTime(11, 11, 10);

DateTime[] holidayDates =
[
    new DateTime(2029, 01, 01),
    new DateTime(2024, 01, 01),
    new DateTime(2024, 03, 08),
    new DateTime(2024, 03, 25),
    new DateTime(2020, 04, 01),
    new DateTime(2024, 03, 25),
    new DateTime(2021, 10, 11),
];

DateTime[] newholidayDates = new DateTime[holidayDates.Length];
Array.Copy(holidayDates, newholidayDates, holidayDates.Length);
Array.Sort(newholidayDates);

//Array.Sort(holidayDates);

string[] holidayNames =
    [
        "New Year Future",
        "New Year",
        "Maha ShivaRatri",
        "Holi",
        "April Fools Day",
        "Nepali New Year",
        "Saturday",
    ];

Console.WriteLine();
Console.WriteLine("Choose an option:");
Console.WriteLine("1 => View past holidays");
Console.WriteLine("2 => View upcoming holidays");
Console.WriteLine("3 => View holidays today");
Console.WriteLine("4 => View days remaining for nearest holiday");
Console.WriteLine();

var optionInput = Console.ReadLine();

if (int.TryParse(optionInput, out int option))
    Console.WriteLine();
else
    Console.WriteLine("Error");

int counter = 0;

switch (option)
{
    case 1:
        Console.WriteLine("All Past Holidays");
        Console.WriteLine();
        Console.WriteLine("Date \t\t Holiday Name");

    for (int i = 0; i < holidayDates.Length; i++)
    {
        int result = DateTime.Compare(holidayDates[i], cDate);
        if (result < 0)
        {
            counter++;
            Console.WriteLine(holidayDates[i].ToShortDateString() + "\t " + holidayNames[i]);
            flag = false;
        }
    }
        Console.WriteLine();
        Console.WriteLine("Past Holidays Counter:" + counter);

    if (flag)
    {
        Console.WriteLine("No Past Holidays Available");
    }
    break;
case 2:
    for (int i = 0; i < holidayDates.Length; i++)
    {
        int result = DateTime.Compare(holidayDates[i], cDate);
        if (result > 0)
        {
            counter++;
            Console.WriteLine("Upcoming Holiday: " + holidayDates[i].ToShortDateString() + " " + holidayNames[i]);
            flag = false;
        }
    }
        Console.WriteLine();
        Console.WriteLine("Future Holidays Counter: " + counter);
    if (flag)
    {
        Console.WriteLine("No Future Holidays Available");
    }
    break;
case 3:
    for (int i = 0; i < holidayDates.Length; i++)
    {
        int result = DateTime.Compare(holidayDates[i], cDate);
        if (result == 0)
        {
            Console.WriteLine("Holiday today: " + holidayDates[i].ToShortDateString() + " " + holidayNames[i]);
            flag = false;
        }
    }
    if (flag)
    {
        Console.WriteLine("No Holiday Today");
    }
    break;

case 4:
    for (int i = 0; i < newholidayDates.Length; i++)
    {
        int result = DateTime.Compare(newholidayDates[i], cDate);
        if (result > 0)
        {
            DateTime nearestHoliday = newholidayDates[i];
            TimeSpan daysLeft = nearestHoliday - cDate;

            int indexOfHolidayName = Utilities.searchHoliday(newholidayDates, i, holidayDates);

            Console.WriteLine(daysLeft.Days + " day left for " + holidayNames[indexOfHolidayName]);
            flag = false;
            break;
        }
    }
    if (flag)
    {
        Console.WriteLine("There are no holidays in the future.");
    }
    break;

default:
    Console.WriteLine("Please choose from above options only.");
    break;
}