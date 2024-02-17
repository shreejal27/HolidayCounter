using System;

Console.WriteLine("This is from Holiday Counter");

bool flag = true;

DateTime cDate = DateTime.Today;

//DateTime[] startDate = new DateTime[5];
//startDate[0] = new DateTime(11, 11, 10);
//startDate[1] = new DateTime(11, 11, 10);

DateTime[] holidayDates =
[
    new DateTime(2024, 02, 18),
    new DateTime(2024, 01, 01),
    new DateTime(2024, 04, 01),
    new DateTime(2020, 04, 01),
    new DateTime(2020, 05, 01),
];

DateTime[] newholidayDates = new DateTime[holidayDates.Length];
Array.Copy(holidayDates, newholidayDates, holidayDates.Length);
Array.Sort(newholidayDates);

//Array.Sort(holidayDates);

string[] holidayNames =
    [
        "just holiday",
        "new year",
        "april fools day",
        "a",
        "n"
    ];

Console.WriteLine("Choose an option:");
Console.WriteLine("1 => View past holidays");
Console.WriteLine("2 => View upcoming holidays");
Console.WriteLine("3 => View holidays today");
Console.WriteLine("4 => View days remaining for nearest holiday");

int option = int.Parse(Console.ReadLine());

switch (option)
{
    case 1:
        for (int i = 0; i < holidayDates.Length; i++)
        {
            int result = DateTime.Compare(holidayDates[i], cDate);
            if (result < 0)
            {
                Console.WriteLine("Past Holiday: " + holidayDates[i].ToShortDateString() + " " + holidayNames[i]);
                flag = false;
            }
        }
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
                Console.WriteLine("Upcoming Holiday: " + holidayDates[i].ToShortDateString() + " " + holidayNames[i]);
                flag = false;
            }
        }
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
                Console.WriteLine(newholidayDates[i].ToShortDateString());
            }
        }
        break;

    default:
        Console.WriteLine("Invalid option");
        break;
}