//using System.IO.File;
namespace AddressBookCSharp
{
    public class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();
            bool isTrue = true;
            //string filePath = "C:\\Users\\prana\\Desktop\\BridgeLabz\\AddressBookCSharp\\AddressBookCSharp\\bin\\Debug\\net8.0";
            //string[] csvFiles = Directory.GetFiles(filePath, "*.csv");
            //string[] csvFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
            string[] csvFiles = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                csvFiles[i] = Path.GetFileName(filePaths[i]);
            }

            foreach (string csvFile in csvFiles)
            {
                //string file = csvFile;
                string key = csvFile.Substring(0, csvFile.Length - 4);
                AddressBook addressBook = new AddressBook();
                string[] lines = File.ReadAllLines(csvFile);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] details = lines[i].Split(",");
                    addressBook.AddPreviousContacts(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                }

                dict.Add(key, addressBook);
            }


            while (isTrue)
            {
                Console.WriteLine("Select Options");
                Console.WriteLine("1. Create new address book");
                Console.WriteLine("2. Select from existing address books");
                Console.WriteLine("3. Display address book");
                Console.WriteLine("4. Exit");

                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter name for new Address book");
                            string name = Console.ReadLine();
                            AddressBook addressBook = new AddressBook();

                            if (name == null)
                            {
                                //Console.WriteLine("Please enter name again");
                                throw new ArgumentNullException("Please enter name again");
                            }
                            else if (dict.ContainsKey(name))
                            {
                                throw new Exception("Name already exists.");
                            }
                            else
                            {
                                string fileName = name + ".csv";
                                string details = "FirstName,LastName,Address,City,State,PostalCode,PhoneNumber,Email\n";
                                File.AppendAllText(fileName, details);

                                dict.Add(name, addressBook);
                            }
                            Console.WriteLine();
                            break;


                        case 2:
                            if (dict.Count == 0)
                            {
                                throw new InvalidOperationException("No address book created yet");
                            }
                            Console.WriteLine("Enter name of requested address book");
                            name = Console.ReadLine();
                            bool flag = false;
                            if (name == null)
                            {
                                throw new ArgumentNullException("Please enter name again");
                            }
                            else
                            {
                                foreach (KeyValuePair<string, AddressBook> kvp in dict)
                                {
                                    if ((kvp.Key.ToLower()).Equals(name.ToLower()))
                                    {
                                        flag = true;
                                        AddressBook ab = kvp.Value;
                                        //file = kvp.Key;
                                        kvp.Value.AddressBookOperations(kvp.Key + ".csv");
                                        dict[name] = ab;
                                    }
                                }

                            }

                            if (!flag)
                                Console.WriteLine("Address book name does not exist");

                            Console.WriteLine();

                            break;

                        case 3:
                            if (dict.Count == 0)
                            {
                                throw new InvalidOperationException("No address book created yet");
                            }
                            foreach (KeyValuePair<string, AddressBook> kvp in dict)
                            {
                                Console.WriteLine(kvp.Key);
                            }
                            Console.WriteLine();
                            break;


                        default:
                            isTrue = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

    }
}
