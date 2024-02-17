namespace AddressBookCSharp
{
    public class Contact
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string postalCode;
        private string phoneNumber;
        private string email;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty");
                }
                lastName = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or empty");
                }
                address = value;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be null or empty");
                }
                city = value;
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("State cannot be null or empty");
                }
                state = value;
            }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Postal code cannot be null or empty");
                }
                postalCode = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone number cannot be null or empty");
                }
                phoneNumber = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }
                email = value;
            }
        }

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
