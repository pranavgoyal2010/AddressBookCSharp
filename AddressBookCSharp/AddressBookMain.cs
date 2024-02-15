﻿namespace AddressBookCSharp;

public class AddressBookMain
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Welcome to Address Book System");



        List<Contact> addressBook = new List<Contact>();

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
        contact.PhoneNumber = Console.ReadLine();

        Console.WriteLine("Enter Email : ");
        contact.Email = Console.ReadLine();



        //ADDING NEW CONTACT

        addressBook.Add(contact);

        Console.WriteLine();

        foreach (Contact c in addressBook)
        {
            c.PrintContact();
        }

        Console.WriteLine();

        //EDITING CONTACT

        Console.WriteLine("Enter first name and last name of contact to edit");

        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        firstName = firstName.ToLower();
        lastName = lastName.ToLower();

        Contact? contactToEdit = null;

        foreach (Contact c in addressBook)
        {
            if ((c.FirstName.ToLower()).Equals(firstName) && (c.LastName.ToLower()).Equals(lastName))
            {
                contactToEdit = c;
                break;
            }
        }

        if (contactToEdit == null)
        {
            Console.WriteLine("Contact does not exist");
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
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
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
                    Console.WriteLine("Address Name updated");
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
                    contactToEdit.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Phone Number updated");
                    break;
                case 8:
                    Console.WriteLine("Enter new Email");
                    contactToEdit.Email = Console.ReadLine();
                    Console.WriteLine("Email updated");
                    break;
                default:
                    Console.WriteLine("Wrong input try again.");
                    break;
            }

            Console.WriteLine();
            contactToEdit.PrintContact();
        }

        Console.WriteLine();

        Console.WriteLine("Enter first name and last name of contact to delete");

        firstName = Console.ReadLine();
        lastName = Console.ReadLine();
        firstName = firstName.ToLower();
        lastName = lastName.ToLower();

        Contact? contactToDelete = null;

        foreach (Contact c in addressBook)
        {
            if ((c.FirstName.ToLower()).Equals(firstName) && (c.LastName.ToLower()).Equals(lastName))
            {
                contactToDelete = c;
                addressBook.Remove(c);
                Console.WriteLine("Contact deleted");
                break;
            }
        }


        if (contactToDelete == null)
        {
            Console.WriteLine("Contact does not exist");
        }

        Console.WriteLine();

        foreach (Contact c in addressBook)
        {
            c.PrintContact();
        }
    }
}



