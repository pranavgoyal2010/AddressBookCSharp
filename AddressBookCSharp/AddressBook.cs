using System.Text.RegularExpressions;

namespace AddressBookCSharp;

public class AddressBook
{

    HashSet<Contact> list;
    public AddressBook()
    {
        this.list = new HashSet<Contact>();
    }

    public void AddPreviousContact(string firstName, string lastName, string address, string city,
            string state, string postalCode, string phoneNumber, string email)
    {
        Contact contact = new Contact();
        contact.FirstName = firstName;
        contact.LastName = lastName;
        contact.Address = address;
        contact.City = city;
        contact.State = state;
        contact.PostalCode = postalCode;
        contact.PhoneNumber = phoneNumber;
        contact.Email = email;
        this.list.Add(contact);
    }
    public void AddressBookOperations(string fileName)
    {

        bool isTrue = true;

        while (isTrue)
        {
            Console.WriteLine("Enter appropriate option");
            Console.WriteLine("1. Add a new contact");
            Console.WriteLine("2. Edit an existing contact");
            Console.WriteLine("3. Delete an existing contact");
            Console.WriteLine("4. Display address book details");
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
                        //CREATING NEW CONTACT

                        Contact contact = new Contact();

                        Console.WriteLine("Enter First Name : ");
                        contact.FirstName = Console.ReadLine();

                        Console.WriteLine("Enter Last Name : ");
                        contact.LastName = Console.ReadLine();

                        Console.WriteLine("Enter Address: ");
                        contact.Address = Console.ReadLine();

                        Console.WriteLine("Enter City : ");
                        contact.City = Console.ReadLine();

                        Console.WriteLine("Enter State : ");
                        contact.State = Console.ReadLine();

                        Console.WriteLine("Enter Postal Code : ");
                        contact.PostalCode = Console.ReadLine();

                        Console.WriteLine("Enter Phone Number : ");
                        string input = Console.ReadLine();
                        if (!isValidPhoneNumber(input))
                        {
                            Console.WriteLine("Invalid Phone number");
                            break;
                        }
                        else
                            contact.PhoneNumber = input;


                        Console.WriteLine("Enter Email : ");
                        input = Console.ReadLine();
                        if (!isValidEmail(input))
                        {
                            Console.WriteLine("Invalid email");
                            break;
                        }
                        else
                            contact.Email = input;



                        //ADDING NEW CONTACT

                        bool isAdded = list.Add(contact);

                        if (!isAdded)
                        {
                            throw new Exception("Duplicate entry: phone number and email already exists");
                        }

                        //WRITING TO CSV FILE
                        string details = $"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.PostalCode},{contact.PhoneNumber},{contact.Email}\n";
                        File.AppendAllText(fileName, details);

                        Console.WriteLine("Contact added");

                        Console.WriteLine();

                        break;




                    case 2:
                        //EDITING CONTACT
                        if (list.Count == 0)
                        {
                            throw new InvalidOperationException("Contact list is empty");
                        }
                        Console.WriteLine("Enter first name and last name of contact to edit");


                        string firstName = Console.ReadLine();

                        if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
                        {
                            throw new NullReferenceException("First name cannot be null, empty or whitespace");
                        }
                        string lastName = Console.ReadLine();
                        if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
                        {
                            throw new NullReferenceException("Last name cannot be null, empty or whitespace");
                        }


                        firstName = firstName.ToLower();
                        lastName = lastName.ToLower();

                        Contact contactToEdit = null;

                        //recording the row number of the contact we want to delete.
                        int lineNumber = 0;

                        foreach (Contact c in list)
                        {
                            if ((c.FirstName.ToLower()).Equals(firstName) && (c.LastName.ToLower()).Equals(lastName))
                            {
                                contactToEdit = c;
                                lineNumber++;
                                break;
                            }
                            lineNumber++;
                        }

                        if (contactToEdit == null)
                        {
                            throw new NullReferenceException("Contact does not exist");
                        }
                        else
                        {
                            Console.WriteLine("Enter option to edit");
                            Console.WriteLine("1. First Name");
                            Console.WriteLine("2. Last Name");
                            Console.WriteLine("3. Address");
                            Console.WriteLine("4. City");
                            Console.WriteLine("5. State");
                            Console.WriteLine("6. Postal Code");
                            Console.WriteLine("7. Phone Number");
                            Console.WriteLine("8. Email");

                            int choice;

                            if (!int.TryParse(Console.ReadLine(), out choice))
                            {
                                throw new NullReferenceException("Enter valid option");
                            }

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter new First Name");
                                    contactToEdit.FirstName = Console.ReadLine();
                                    Console.WriteLine("First Name updated");
                                    break;
                                case 2:
                                    Console.WriteLine("Enter new Last Name");
                                    contactToEdit.LastName = Console.ReadLine();
                                    Console.WriteLine("Last Name updated");
                                    break;
                                case 3:
                                    Console.WriteLine("Enter new Address");
                                    contactToEdit.Address = Console.ReadLine();
                                    Console.WriteLine("Address updated");
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new City");
                                    contactToEdit.City = Console.ReadLine();
                                    Console.WriteLine("City updated");
                                    break;
                                case 5:
                                    Console.WriteLine("Enter new State");
                                    contactToEdit.State = Console.ReadLine();
                                    Console.WriteLine("State updated");
                                    break;
                                case 6:
                                    Console.WriteLine("Enter new Postal Code");
                                    contactToEdit.PostalCode = Console.ReadLine();
                                    Console.WriteLine("Postal code updated");
                                    break;
                                case 7:
                                    Console.WriteLine("Enter new Phone Number");
                                    string oldPhoneNumber = contactToEdit.PhoneNumber;
                                    contactToEdit.PhoneNumber = Console.ReadLine();

                                    //trying to add the updated contact to list.
                                    //If its duplicate then it won't get added.
                                    //otherwise after adding we remove the contact.
                                    if (list.Add(contactToEdit))
                                    {
                                        Console.WriteLine("Phone Number updated");
                                        list.Remove(contactToEdit);
                                    }
                                    else
                                    {
                                        contactToEdit.PhoneNumber = oldPhoneNumber;
                                        throw new Exception("Duplicate entry: phone number and email already exists");
                                    }

                                    break;

                                case 8:
                                    Console.WriteLine("Enter new Email");
                                    string oldEmail = contactToEdit.Email;
                                    contactToEdit.Email = Console.ReadLine();

                                    //trying to add the updated contact to list.
                                    //If its duplicate then it won't get added.
                                    //otherwise after adding we remove the contact.
                                    if (list.Add(contactToEdit))
                                    {
                                        Console.WriteLine("Email updated");
                                        list.Remove(contactToEdit);
                                    }
                                    else
                                    {
                                        contactToEdit.Email = oldEmail;
                                        throw new Exception("Duplicate entry: phone number and email already exists");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Option does not exist");
                                    break;
                            }

                        }

                        string[] lines = File.ReadAllLines(fileName);

                        details = $"{contactToEdit.FirstName},{contactToEdit.LastName},{contactToEdit.Address},{contactToEdit.City},{contactToEdit.State},{contactToEdit.PostalCode},{contactToEdit.PhoneNumber},{contactToEdit.Email}";
                        lines[lineNumber] = details;
                        File.WriteAllLines(fileName, lines);

                        Console.WriteLine();
                        break;


                    case 3:
                        if (list.Count == 0)
                        {
                            throw new InvalidOperationException("Contact list is empty");
                        }
                        Console.WriteLine("Enter first name and last name of contact to delete");

                        firstName = Console.ReadLine();

                        if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
                        {
                            throw new NullReferenceException("First name cannot be null, empty or whitespace");
                        }
                        lastName = Console.ReadLine();
                        if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
                        {
                            throw new NullReferenceException("Last name cannot be null, empty or whitespace");
                        }
                        firstName = firstName.ToLower();
                        lastName = lastName.ToLower();


                        Contact contactToDelete = null;
                        lineNumber = 0;
                        foreach (Contact c in list)
                        {
                            if ((c.FirstName.ToLower()).Equals(firstName) && (c.LastName.ToLower()).Equals(lastName))
                            {
                                contactToDelete = c;
                                list.Remove(c);
                                lineNumber++;
                                Console.WriteLine("Contact deleted");
                                break;
                            }
                            lineNumber++;
                        }


                        if (contactToDelete == null)
                        {
                            throw new NullReferenceException("Contact does not exist");
                        }

                        Console.WriteLine();

                        lines = File.ReadAllLines(fileName);
                        if (lineNumber >= 0 && lineNumber < lines.Length)
                        {
                            // Remove the line at the specified index
                            string[] updatedLines = new string[lines.Length - 1];
                            int j = 0;
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (i != lineNumber)
                                {
                                    updatedLines[j++] = lines[i];
                                }
                            }
                            File.WriteAllLines(fileName, updatedLines);
                        }

                        break;

                    case 4:
                        if (list.Count == 0)
                        {
                            throw new InvalidOperationException("Contact list is empty");
                        }
                        foreach (Contact c in list)
                        {
                            c.PrintContact();
                            Console.WriteLine();
                        }
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

    public bool isValidEmail(string input)
    {
        string pattern = @"^[a-zA-Z]([\w]*|\.[\w]+)*\@[a-zA-Z0-9]+\.[a-z]{2,3}$";
        return Regex.IsMatch(input, pattern);
    }

    public bool isValidPhoneNumber(string input)
    {
        string pattern = @"^[0-9]{10}$";
        return Regex.IsMatch(input, pattern);
    }

}



