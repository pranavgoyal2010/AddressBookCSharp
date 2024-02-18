namespace AddressBookCSharp;

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
                throw new ArgumentException("First name cannot be null, empty or whitespace");
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
                throw new ArgumentException("Last name cannot be null, empty or whitespace");
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
                throw new ArgumentException("Address cannot be null, empty or whitespace");
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
                throw new ArgumentException("City cannot be null, empty or whitespace");
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
                throw new ArgumentException("State cannot be null, empty or whitespace");
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
                throw new ArgumentException("Postal code cannot be null, empty or whitespace");
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
                throw new ArgumentException("Phone number cannot be null, empty or whitespace");
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
                throw new ArgumentException("Email cannot be null, empty or whitespace");
            }
            email = value.ToLower();
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

    /*public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Contact other = (Contact)obj;
        return PhoneNumber == other.PhoneNumber && Email == other.Email;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PhoneNumber, Email);
    }*/
}
