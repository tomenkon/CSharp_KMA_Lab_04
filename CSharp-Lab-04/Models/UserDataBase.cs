using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_04.Models
{
    class UserDataBase
    {
        public static List<Person> users = new()
        {
            new Person("Samantha", "Johnson", "samantha.johnson@example.com", new DateTime(1985, 9, 20)),
            new Person("Isaac", "Gomez", "isaac.gomez@example.com", new DateTime(1993, 11, 9)),
            new Person("Elizabeth", "Lopez", "elizabeth.lopez@example.com", new DateTime(1977, 1, 31)),
            new Person("Gabriel", "Baker", "gabriel.baker@example.com", new DateTime(2005, 7, 8)),
            new Person("Mila", "Graham", "mila.graham@example.com", new DateTime(2009, 4, 16)),
            new Person("David", "Harris", "david.harris@example.com", new DateTime(1954, 2, 17)),
            new Person("Chloe", "Allen", "chloe.allen@example.com", new DateTime(1997, 12, 30)),
            new Person("Andrew", "Nguyen", "andrew.nguyen@example.com", new DateTime(1965, 8, 5)),
            new Person("Lily", "Rivera", "lily.rivera@example.com", new DateTime(1988, 6, 7)),
            new Person("Joseph", "Green", "joseph.green@example.com", new DateTime(2002, 3, 22)),
            new Person("Emma", "Carter", "emma.carter@example.com", new DateTime(1990, 5, 12)),
            new Person("James", "Turner", "james.turner@example.com", new DateTime(1951, 10, 27)),
            new Person("Aaliyah", "Parker", "aaliyah.parker@example.com", new DateTime(2011, 2, 4)),
            new Person("Daniel", "Collins", "daniel.collins@example.com", new DateTime(1976, 9, 18)),
            new Person("Natalie", "Morris", "natalie.morris@example.com", new DateTime(1983, 4, 17)),
            new Person("Christopher", "Reyes", "christopher.reyes@example.com", new DateTime(1960, 12, 9)),
            new Person("Addison", "Hill", "addison.hill@example.com", new DateTime(2007, 6, 15)),
            new Person("Ava", "Gutierrez", "ava.gutierrez@example.com", new DateTime(1996, 3, 1)),
            new Person("Elijah", "Mitchell", "elijah.mitchell@example.com", new DateTime(1986, 10, 26)),
            new Person("Grace", "Edwards", "grace.edwards@example.com", new DateTime(2004, 8, 13)),
            new Person("William", "Ramirez", "william.ramirez@example.com", new DateTime(1959, 4, 5)),
            new Person("Hazel", "Campbell", "hazel.campbell@example.com", new DateTime(1969, 7, 28)),
            new Person("Anthony", "Foster", "anthony.foster@example.com", new DateTime(1972, 2, 16)),
            new Person("Ella", "Powell", "ella.powell@example.com", new DateTime(2013, 1, 10)),
            new Person("Mason", "Long", "mason.long@example.com", new DateTime(1995, 3, 29)),
            new Person("Sophie", "Flores", "sophie.flores@example.com", new DateTime(1981, 7, 17)),
            new Person("Caleb", "Washington", "caleb.washington@example.com", new DateTime(2001, 12, 7)),
            new Person("Olivia", "Butler", "olivia.butler@example.com", new DateTime(1978, 6, 28)),
            new Person("Michael", "Sanders", "michael.sanders@example.com", new DateTime(1992, 4, 14)),
            new Person("Abigail", "Barnes", "abigail.barnes@example.com", new DateTime(2003, 8, 25)),
            new Person("Lucas", "Gonzales", "lucas.gonzales@example.com", new DateTime(1968, 10, 31)),
            new Person("Madison", "Price", "madison.price@example.com", new DateTime(2008, 11, 11)),
            new Person("Ryan", "Peterson", "ryan.peterson@example.com", new DateTime(1984, 12, 1)),
            new Person("Sofia", "Cooper", "sofia.cooper@example.com", new DateTime(2000, 5, 18)),
            new Person("Alexander", "Bailey", "alexander.bailey@example.com", new DateTime(1991, 9, 22)),
            new Person("Evelyn", "Ross", "evelyn.ross@example.com", new DateTime(1955, 3, 5)),
            new Person("Daniel", "Bell", "daniel.bell@example.com", new DateTime(1963, 7, 16)),
            new Person("Aria", "Garcia", "aria.garcia@example.com", new DateTime(2006, 2, 13)),
            new Person("Nicholas", "Lee", "nicholas.lee@example.com", new DateTime(1979, 4, 18)),
            new Person("Avery", "Reed", "avery.reed@example.com", new DateTime(2015, 9, 3)),
            new Person("Hannah", "Collins", "hannah.collins@example.com", new DateTime(1989, 2, 8)),
            new Person("Joshua", "Edwards", "joshua.edwards@example.com", new DateTime(2009, 7, 21)),
            new Person("Makayla", "Parker", "makayla.parker@example.com", new DateTime(1998, 11, 19)),
            new Person("Benjamin", "Cruz", "benjamin.cruz@example.com", new DateTime(1953, 1, 30)),
            new Person("Victoria", "Mitchell", "victoria.mitchell@example.com", new DateTime(1966, 8, 27)),
            new Person("Samuel", "Wood", "samuel.wood@example.com", new DateTime(2000, 2, 20)),
            new Person("Eleanor", "Adams", "eleanor.adams@example.com", new DateTime(1971, 5, 9)),
            new Person("Jackson", "Wright", "jackson.wright@example.com", new DateTime(2016, 4, 7)),
            new Person("Sophia", "Ramirez", "sophia.ramirez@example.com", new DateTime(1982, 6, 2)),
            new Person("William", "Scott", "william.scott@example.com", new DateTime(1994, 10, 12))
        };
    }
}
