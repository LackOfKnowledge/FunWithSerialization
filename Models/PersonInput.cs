namespace FunWithSerialization.Models
{
    public class PersonInput
    {
        public Person Person { get; set; }

        public void GetDataFromUser()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter place of birth");
            string placeOfBirth = Console.ReadLine();

            Person = new Person { FirstName = firstName, LastName = lastName, Age = age, PlaceOfBirth = placeOfBirth };
        }
    }
}
