namespace AddressBookCSharp
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void PrintContact()
        {
            Console.WriteLine("CONTACT INFO");
            Console.WriteLine("First Name : " + FirstName);
            Console.WriteLine("Last Name : " + LastName);
            Console.WriteLine("Address : " + Address);
            Console.WriteLine("City : " + City);
            Console.WriteLine("State : " + State);
            Console.WriteLine("Postal Code : " + PostalCode);
            Console.WriteLine("Phone Number : " + PhoneNumber);
            Console.WriteLine("Email : " + Email);
        }
    }
}
