using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeamOfPlayers.Structures;

namespace TeamOfPlayers.Utilities
{
    internal static class FileManager
    {
        public static void ReadPlayers(string fileName)
        {
            var fileReader = new StreamReader(fileName);
            while (!fileReader.EndOfStream)
            {
                var parse = fileReader.ReadLine();
                if (!string.IsNullOrEmpty(parse))
                    Program.AddData(ParsePlayer(parse));
            }
            fileReader.Close();
        }

        public static void ReadTeams(string fileName)
        {
            var fileReader = new StreamReader(fileName);
            while (!fileReader.EndOfStream)
            {
                var parse = fileReader.ReadLine();
                if (!string.IsNullOrEmpty(parse))
                    Program.AddData(ParseTeamPlayer(parse));
            }
            fileReader.Close();
        }

        public static void SavePlayers(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception("Файл не существует \"" + fileName + "\"");

            var fileWriter = new StreamWriter(fileName);
            foreach (var p in Program.ListPlayers)
                fileWriter.WriteLine(p.Name + ";" + p.Birthday.ToString("dd.MM.yyyy") + ";"
                                     + p.SportTypes.Aggregate("", (current, s) => current + ("," + s)).Remove(0,1));
            
            fileWriter.Flush();
            fileWriter.Close();
        }

        public static void SaveTeams(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception("Файл не существует \"" + fileName + "\"");

            var fileWriter = new StreamWriter(fileName);
            foreach (var p in Program.ListTeams)
                fileWriter.WriteLine(p.PlayerName + ";" + p.TeamName + ";" + p.Role + ";" + p.SportType);

            fileWriter.Flush();
            fileWriter.Close();
        }

        public static Player ParsePlayer(string parse)
        {
            //Ex: Alexey Den Ivanov; 12.02.17; Swim, Destruct
            var parseStrings = parse.Split(';');
            if (parseStrings.Length != 3)
                throw new ArgumentException("Не соответствие количества аргументов");
            
            for (var i = 0; i < parseStrings.Length; i++)
                parseStrings[i] = parseStrings[i].Trim(' ');

            if (parseStrings[0] == "")
                throw new ArgumentException("Пустое поле ФИО");
            var parseName = parseStrings[0].Split(' ');
            if (parseName.Length != 3)
                throw new ArgumentException("ФИО состоит не из трех слов");
            foreach (var str in parseName)
                if (!IsValidWord(str))
                    throw new ArgumentException("Неправильное ФИО \"" + str + "\"");

            if (parseStrings[1] == "")
                throw new ArgumentException("Пустое поле даты");

            if (parseStrings[2] == "")
                throw new ArgumentException("Пустое поле видов спорта");

            DateTime date;
            try {
                date = DateTime.ParseExact(parseStrings[1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            } catch(FormatException) { throw new ArgumentException("Неправильный формат даты"); }
            
            if(date.Day <= 0 || date.Day >= 32 || date.Month <= 0 || date.Month >= 13 || date.Year <= 1964 || date.Year >= 2021 )
                throw new Exception("Недействительная дата");
                
            var parseSports = parseStrings[2].Split(',').ToList();
            foreach (var str in parseSports.Where(str => !IsValidWord(str)))
                throw new ArgumentException("Неправильный вид спорта \"" + str + "\"");

            return new Player(parseStrings[0], date, parseSports);
        }

        private static bool IsValidWord(string word)
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
            //Ex: Alexey Den Ivanov;Cheese;Goalkeeper;Swim
            var parseStrings = parse.Split(';');
            if (parseStrings.Length != 4)
                throw new ArgumentException("Не соответствие количества аргументов");

            for (var i = 0; i < parseStrings.Length; i++)
                parseStrings[i] = parseStrings[i].Trim(' ');

            if (parseStrings[0] == "")
                throw new ArgumentException("Пустое поле ФИО");
            var parseName = parseStrings[0].Split(' ');
            if (parseName.Length != 3)
                throw new ArgumentException("ФИО состоит не из трех слов");
            foreach (var str in parseName)
                if (!IsValidWord(str))
                    throw new ArgumentException("Неправильное ФИО \"" + str + "\"");

            if (parseStrings[1] == "")
                throw new ArgumentException("Пустое поле названия команды");
            if (!IsValidWord(parseStrings[1]))
                throw new ArgumentException("Неправильное название команды \"" + parseStrings[1] + "\"");

            if (parseStrings[2] == "")
                throw new ArgumentException("Пустое поле роли");
            if (!IsValidWord(parseStrings[2]))
                throw new ArgumentException("Неправильное название роли \"" + parseStrings[2] + "\"");

            if (parseStrings[3] == "")
                throw new ArgumentException("Пустое поле вида спорта");
            if (!IsValidWord(parseStrings[3]))
                throw new ArgumentException("Неправильное название вида спорта \"" + parseStrings[3] + "\"");

            return new TeamPlayer(parseStrings[0], parseStrings[1], parseStrings[2], parseStrings[3]);
        }

        public static void GenerateFile(int count = 1000)
        {
            GenerateData.GenerateDataBase(count);
            SavePlayers("Players.txt");
            SaveTeams("TeamPlayers.txt");
        }

        public static void SaveReport(string fileName, DataTable reports)
        {
            if (!File.Exists(fileName))
                throw new Exception("Файл не существует \"" + fileName + "\"");

            var fileWriter = new StreamWriter(fileName);
            foreach (DataRow dataRow in reports.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                    fileWriter.Write(item + "; ");
                fileWriter.WriteLine();
            }

            fileWriter.Flush();
            fileWriter.Close();
        }

        public static string ChooseFile()
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "";
            openFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            return openFileDialog.ShowDialog() != DialogResult.OK ? string.Empty : openFileDialog.FileName;
        }
    }
}