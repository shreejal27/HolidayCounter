using HolidayCounter;

Console.WriteLine("Holiday Counter");


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
    new DateTime(2024, 02, 18),
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
        "Test Holiday",
    ];

Console.WriteLine();

do
{
    bool flag = true;

    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 => View past holidays");
    Console.WriteLine("2 => View upcoming holidays");
    Console.WriteLine("3 => View holidays today");
    Console.WriteLine("4 => View days remaining for nearest holiday");
    Console.WriteLine("9 => To exit the application");
    Console.WriteLine();

    var optionInput = Console.ReadLine();

    if (int.TryParse(optionInput, out int option))
        Console.WriteLine();
    else
        Console.WriteLine("\tError !!! Please Input Integers Only");

    int counter = 0;

    switch (option)
    {
        case 1:
            Console.WriteLine("\t\t Past Holidays");
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine("\tDate \t\t Holiday Name");
            Console.WriteLine("\t-----------------------------------");

            for (int i = 0; i < holidayDates.Length; i++)
            {
                int result = DateTime.Compare(holidayDates[i], cDate);
                if (result < 0)
                {
                    counter++;
                    Console.WriteLine("\t" + holidayDates[i].ToShortDateString() + "\t " + holidayNames[i]);
                    flag = false;
                }
            }
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("\tPast Holidays Counter: " + counter);
            Console.WriteLine();

            if (flag)
            {
                Console.WriteLine("\tNo Past Holidays Available");
                Console.WriteLine();
            }
            break;
        case 2:
            Console.WriteLine("\t\t Upcomming Holidays");
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine("\tDate \t\t Holiday Name");
            Console.WriteLine("\t-----------------------------------");
            for (int i = 0; i < holidayDates.Length; i++)
            {
                int result = DateTime.Compare(holidayDates[i], cDate);
                if (result > 0)
                {
                    counter++;
                    Console.WriteLine("\t" + holidayDates[i].ToShortDateString() + "\t " + holidayNames[i]);
                    flag = false;
                }
            }
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tFuture Holidays Counter: " + counter);
            Console.WriteLine();
            if (flag)
            {
                Console.WriteLine("\tNo Future Holidays Available");
                Console.WriteLine();
            }
            break;
        case 3:
            Console.WriteLine("\t\t Holidays Today");
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine("\tDate \t\t Holiday Name");
            Console.WriteLine("\t-----------------------------------");
            for (int i = 0; i < holidayDates.Length; i++)
            {
                int result = DateTime.Compare(holidayDates[i], cDate);
                if (result == 0)
                {
                    counter++;
                    Console.WriteLine("\t" + holidayDates[i].ToShortDateString() + "\t" + holidayNames[i]);
                    flag = false;
                }
            }
            Console.WriteLine("\t-----------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t Today Holidays Counter: " + counter);
            Console.WriteLine();
            if (flag)
            {
                Console.WriteLine("\tNo Holiday Today");
                Console.WriteLine();
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

                    Console.WriteLine("\t" + daysLeft.Days + " day left for " + holidayNames[indexOfHolidayName]);
                    Console.WriteLine();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("\tThere are no holidays in the future.");
                Console.WriteLine();
            }
            break;

        case 9:
            Console.WriteLine("\tExiting the application ...");
            Console.WriteLine();
            return;

        default:
            Console.WriteLine("\tPlease choose from above options only.");
            Console.WriteLine();
            break;
    }
} while (true);