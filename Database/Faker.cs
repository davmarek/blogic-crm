namespace BlogicCRM.Database;

public class Faker
{
    private static readonly List<Guid> Guids =
    [
        Guid.Parse("00000000-0000-0000-0000-000000000001"),
        Guid.Parse("00000000-0000-0000-0000-000000000002"),
        Guid.Parse("00000000-0000-0000-0000-000000000003"),
        Guid.Parse("00000000-0000-0000-0000-000000000004"),
        Guid.Parse("00000000-0000-0000-0000-000000000005"),
        Guid.Parse("00000000-0000-0000-0000-000000000006"),
        Guid.Parse("00000000-0000-0000-0000-000000000007"),
        Guid.Parse("00000000-0000-0000-0000-000000000008"),
        Guid.Parse("00000000-0000-0000-0000-000000000009"),
        Guid.Parse("00000000-0000-0000-0000-000000000010"),
        Guid.Parse("00000000-0000-0000-0000-000000000011"),
        Guid.Parse("00000000-0000-0000-0000-000000000012"),
        Guid.Parse("00000000-0000-0000-0000-000000000013"),
        Guid.Parse("00000000-0000-0000-0000-000000000014"),
        Guid.Parse("00000000-0000-0000-0000-000000000015"),
        Guid.Parse("00000000-0000-0000-0000-000000000016"),
        Guid.Parse("00000000-0000-0000-0000-000000000017"),
        Guid.Parse("00000000-0000-0000-0000-000000000018"),
        Guid.Parse("00000000-0000-0000-0000-000000000019"),
        Guid.Parse("00000000-0000-0000-0000-000000000020")
    ];

    private static readonly List<string> FirstNames =
    [
        "Jan", "David", "Petr", "Martin", "Tomáš", "Lukáš", "Michal", "Jakub", "Filip", "Vojtěch",
        "Ondřej", "Daniel", "Matěj", "Adam", "Josef", "Jaroslav", "Radek", "Karel", "Marek", "Václav",
        "Jana", "Eva", "Petra", "Martina", "Tereza", "Lucie", "Kateřina", "Anna", "Barbora", "Veronika",
    ];

    private static readonly List<string> LastNames =
    [
        "Novák", "Svoboda", "Novotný", "Dvořák", "Černý", "Procházka", "Kovář", "Veselý", "Horák",
        "Němec", "Pokorný", "Růžička", "Beneš", "Richter", "Král", "Fiala", "Urban", "Krejčí",
        "Polák", "Čech", "Jelínek", "Havel", "Kříž", "Šimek", "Zeman", "Bartoš", "Kučera", "Tichý", "Pavlíček", "Holub"
    ];


    private static readonly List<string> Emails =
    [
        "Barry_Moran561@jcf8v.mobi", "Ema_Mcleod5369@yahoo.directory", "Maxwell_Ebbs6093@1kmd3.press",
        "Louise_Khan3677@ds59r.host", "Aileen_Gaynor5441@hepmv.meet", "Sloane_Tanner4692@kyb7t.info",
        "Adalind_Lindsay1835@yfxpw.edu", "Maria_Potts856@v1wn5.zone", "Mason_Tutton6832@xtwt3.online",
        "Fiona_Saunders8101@karnv.software", "Rocco_Richards6731@bcfhs.business", "Courtney_Salt2851@y96lx.mobi",
        "Bryon_Windsor6229@iscmr.meet", "Roger_Bingham7598@dvqq2.meet", "Josh_Logan4466@uagvw.app",
        "Sebastian_Sanchez2407@yvu30.website", "Christine_Mann8445@yfxpw.ca", "Carl_Drummond2938@1kmd3.com",
        "Hayden_Stubbs8107@c2nyu.com", "Nathan_Walter6768@zynuu.design"
    ];

    private static readonly List<string> PhoneNumbers =
    [
        "123456789", "987654321", "555123456", "444987654", "333555123",
        "222444987", "111333555", "666777888", "999000111", "888999000",
        "777666555", "555444333", "444222111", "333111000", "222999888",
        "111888777", "000111222", "999888777", "888666555", "777444333",
        "666555444", "555333222", "444111000", "333999888", "222777666", "111555444"
    ];

    public static Guid GetGuid(int index)
    {
        if (index < 0 || index >= Guids.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the range of available GUIDs.");
        }

        return Guids[index];
    }

    public static string GetFirstName(int index)
    {
        if (index < 0 || index >= FirstNames.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "Index must be within the range of available first names.");
        }

        return FirstNames[index];
    }

    public static string GetLastName(int index)
    {
        if (index < 0 || index >= LastNames.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "Index must be within the range of available last names.");
        }

        return LastNames[index];
    }


    public static string GetEmail(int index)
    {
        if (index < 0 || index >= Emails.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the range of available emails.");
        }

        return Emails[index];
    }


    public static string GetPhoneNumber(int index)
    {
        if (index < 0 || index >= PhoneNumbers.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "Index must be within the range of available phone numbers.");
        }

        return PhoneNumbers[index];
    }

    public static string GetRandomBirthNumber()
    {
        var random = new Random();
        // Generate a random birth number in the format "123456/7890"
        var firstPart = random.Next(100000, 1000000).ToString("D6");
        var secondPart = random.Next(1000, 10000).ToString("D4");
        return $"{firstPart}/{secondPart}";
    }

    public static DateTime GetRandomBirthdate()
    {
        var random = new Random();
        // Generate a random date between 1950 and 2000
        var year = random.Next(1950, 2001);
        var month = random.Next(1, 13);
        var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateTime(2000, 1, 1);
    }
}