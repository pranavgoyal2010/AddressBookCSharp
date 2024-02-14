namespace AddressBookCSharp;

public class AddressBookMain
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Welcome to Address Book System");

        List<Contact> addressBook = new List<Contact>();

        Contact contact = new Contact();

        Console.WriteLine("Enter First Name : ");
        contact.FirstName = Console.ReadLine();

        Console.WriteLine("Enter Last Name : ");
        contact.LastName = Console.ReadLine();

        Console.WriteLine("Enter Address Name : ");
        contact.Address = Console.ReadLine();

        Console.WriteLine("Enter City : ");
        contact.City = Console.ReadLine();

        Console.WriteLine("Enter State : ");
        contact.State = Console.ReadLine();

        Console.WriteLine("Enter Postal Code : ");
        contact.PostalCode = Console.ReadLine();

        Console.WriteLine("Enter Phone Number : ");
        contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Email : ");
        contact.Email = Console.ReadLine();

        addressBook.Add(contact);

        //Console.WriteLine(addressBook.ToString());
    }
}



