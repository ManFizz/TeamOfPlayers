using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TeamOfPlayers
{
    internal class FileReader
    {
        public static string Path;

        public static void Read(string fileName, ref RbTree<Player, DateTime> rbTree)
        {
            var fileReader = new StreamReader(Path + fileName);
            while (!fileReader.EndOfStream)
            {
                var parse = fileReader.ReadLine();
                if (string.IsNullOrEmpty(parse))
                    continue;
                var p = ParsePlayer(parse);
                rbTree.Insert(p, p.Birthday);
            }
            fileReader.Close();
        }

        public static void Save(string fileName, RbTree<Player, DateTime> rbTree)
        {
            var fileWriter = new StreamWriter(Path + fileName);
            var list = rbTree.GetList();
            foreach (var p in list)
            {
                fileWriter.WriteLine(p.Name + ";" + p.Birthday.ToString("dd.MM.yyyy") + ";"
                          + p.SportTypes.Aggregate("", (current, s) => current + ("," + s)).Remove(0,1));
            }
            fileWriter.Flush();
            fileWriter.Close();
        }

        public static void Save(string fileName, RbTree<TeamPlayer, string> rbTree)
        {
            var fileWriter = new StreamWriter(Path + fileName);
            var list = rbTree.GetList();
            foreach (var p in list)
                fileWriter.WriteLine(p.PlayerName + ";" + p.TeamName + ";" + p.Role + ";" + p.SportType);

            fileWriter.Flush();
            fileWriter.Close();
        }

        public static void Read(string fileName, ref RbTree<TeamPlayer, string> rbTree)
        {
            var fileReader = new StreamReader(Path + fileName);
            while (!fileReader.EndOfStream)
            {
                var parse = fileReader.ReadLine();
                if (string.IsNullOrEmpty(parse))
                    continue;
                var p = ParseTeamPlayer(parse);
                rbTree.Insert(p, p.Role);
            }
            fileReader.Close();
        }

        public static Player ParsePlayer(string parse)
        {
            //Exmp: Alexey Nitko Ivanovich; 12.02.17; Legkaya otletika, Swim, Destruct
            var parseStrings = parse.Split(';');
            if (parseStrings.Length != 3)
                throw new ArgumentException("Count missmatch");
            
            for (var i = 0; i < parseStrings.Length; i++)
                parseStrings[i] = parseStrings[i].Trim(' ');

            if (parseStrings[0] == "")
                throw new ArgumentException("Empty FIO");
            var parseName = parseStrings[0].Split(' ');
            if (parseName.Length != 3)
                throw new ArgumentException("ФИО состоит не из трех слов");
            foreach (var str in parseName)
            {
                if (!ValidWord(str))
                    throw new ArgumentException("Неправильное слово \"" + str + "\"");
            }

            if (parseStrings[1] == "")
                throw new ArgumentException("Empty date");

            if (parseStrings[2] == "")
                throw new ArgumentException("Empty sports list");

            DateTime date;
            try
            {
                date = DateTime.ParseExact(parseStrings[1], "dd.MM.yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(FormatException exception)
            {
                throw new ArgumentException("Fromat date broken: " + exception);
            }

            var parseSports = parseStrings[2].Split(',').ToList();
            foreach (var str in parseSports)
                if (!ValidWord(str))
                    throw new ArgumentException("Неправильное слово \"" + str + "\"");

            return new Player(parseStrings[0], date, parseSports);
        }

        public static bool ValidWord(string word)
        {
            char[] arrUpperChars = {
                'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X',
                'C', 'V', 'B', 'N', 'M' };
            char[] arrChars = {
                'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z', 'x',
                'c','v','b','n','m' };
            if (!arrUpperChars.Contains(word[0]))
                return false;

            for (var i = 1; i < word.Length; i++)
                if (!arrChars.Contains(word[i]))
                    return false;

            return true;

        }

        public static TeamPlayer ParseTeamPlayer(string parse)
        {
            //Exmp: Alexey Nitko Ivanovich;MegaZzubki;Vratar;Legkaya otletika
            var parseStrings = parse.Split(';');
            if (parseStrings.Length != 4)
                throw new ArgumentException("Count missmatch");

            for (var i = 0; i < parseStrings.Length; i++)
                parseStrings[i] = parseStrings[i].Trim(' ');

            if (parseStrings[0] == "")
                throw new ArgumentException("Empty FIO");
            var parseName = parseStrings[0].Split(' ');
            if (parseName.Length != 3)
                throw new ArgumentException("ФИО состоит не из трех слов");
            foreach (var str in parseName)
            {
                if (!ValidWord(str))
                    throw new ArgumentException("Неправильное слово \"" + str + "\"");
            }

            if (parseStrings[1] == "")
                throw new ArgumentException("Empty team name");
            if (!ValidWord(parseStrings[1]))
                throw new ArgumentException("Неправильное слово \"" + parseStrings[1] + "\"");

            if (parseStrings[2] == "")
                throw new ArgumentException("Empty role");
            if (!ValidWord(parseStrings[2]))
                throw new ArgumentException("Неправильное слово \"" + parseStrings[2] + "\"");

            if (parseStrings[3] == "")
                throw new ArgumentException("Empty sport");
            if (!ValidWord(parseStrings[3]))
                throw new ArgumentException("Неправильное слово \"" + parseStrings[3] + "\"");

            return new TeamPlayer(parseStrings[0], parseStrings[1], parseStrings[2], parseStrings[3]);
        }

    }
}