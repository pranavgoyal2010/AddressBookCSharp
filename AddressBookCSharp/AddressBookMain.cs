namespace AddressBookCSharp
{
    public class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();
            bool isTrue = true;


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
                            string? name = Console.ReadLine();
                            AddressBook addressBook = new AddressBook();

                            if (name == null)
                            {
                                //Console.WriteLine("Please enter name again");
                                throw new ArgumentNullException("Please enter name again");
                            }
                            else
                            {
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
                                        ab.AddressBookOperations();
                                        dict[name] = ab;
                                    }
                                }

                            }

                            if (!flag)
                                Console.WriteLine("Address book name does not exist");

                            Console.WriteLine();

                            break;

                        case 3:
                            //int count = 1;
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
