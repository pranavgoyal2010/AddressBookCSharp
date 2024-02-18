//using System.IO.File;
namespace AddressBookCSharp
{
    public class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();
            bool isTrue = true;

            //Gives the absolute path where each csv file is stored.
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
            //creating array to store just filenames.
            string[] csvFiles = new string[filePaths.Length];

            //extracting the filename with extension from absolute path and storing it in array.
            for (int i = 0; i < filePaths.Length; i++)
            {
                csvFiles[i] = Path.GetFileName(filePaths[i]);
            }

            foreach (string csvFile in csvFiles)
            {

                string key = csvFile.Substring(0, csvFile.Length - 4);
                AddressBook addressBook = new AddressBook();
                string[] lines = File.ReadAllLines(csvFile);

                //ignoring the headings hence starting from index 1
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] details = lines[i].Split(",");
                    addressBook.AddPreviousContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                }

                dict.Add(key, addressBook);
            }


            while (isTrue)
            {
                Console.WriteLine("Select Options");
                Console.WriteLine("1. Create new address book");
                Console.WriteLine("2. Select an address book");
                Console.WriteLine("3. Display all address books");
                Console.WriteLine("4. Delete an address book");
                Console.WriteLine("5. Exit");

                try
                {
                    int option;

                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        throw new NullReferenceException("Enter valid option");
                    }

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter name for new Address book");
                            string name = Console.ReadLine();
                            name = name.ToLower();
                            AddressBook addressBook = new AddressBook();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                throw new NullReferenceException("Address book name cannot be null, empty or whitespace");
                            }
                            else if (dict.ContainsKey(name))
                            {
                                throw new Exception("Address book name already exists.");
                            }
                            else
                            {
                                string fileName = name + ".csv";
                                string details = "FirstName,LastName,Address,City,State,PostalCode,PhoneNumber,Email\n";
                                File.AppendAllText(fileName, details);

                                dict.Add(name, addressBook);

                                Console.WriteLine("Address book created");
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
                            name = name.ToLower();

                            bool flag = false;

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                throw new NullReferenceException("Address book name cannot be null, empty or whitespace");
                            }
                            else
                            {
                                foreach (KeyValuePair<string, AddressBook> kvp in dict)
                                {
                                    if ((kvp.Key).Equals(name))
                                    {
                                        flag = true;
                                        AddressBook ab = kvp.Value;
                                        ab.AddressBookOperations(kvp.Key + ".csv");
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

                        case 4:
                            if (dict.Count == 0)
                            {
                                throw new InvalidOperationException("No address book created yet");
                            }

                            flag = false;
                            Console.WriteLine("Enter name of requested address book");
                            name = Console.ReadLine();
                            name = name.ToLower();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                throw new NullReferenceException("Address book name cannot be null, empty or whitespace");
                            }
                            else
                            {
                                foreach (KeyValuePair<string, AddressBook> kvp in dict)
                                {
                                    if ((kvp.Key).Equals(name))
                                    {
                                        flag = true;
                                        dict.Remove(kvp.Key);
                                        File.Delete(kvp.Key + ".csv");
                                        Console.WriteLine("Address book deleted.");
                                    }
                                }

                            }

                            if (!flag)
                                Console.WriteLine("Address book name does not exist");

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
                    Console.WriteLine();
                }

            }

        }

    }
}
