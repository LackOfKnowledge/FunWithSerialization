using System.Xml.Serialization;

namespace SerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pobieranie danych od użytkownika
            PersonInput input = new PersonInput();
            input.GetDataFromUser();

            // Sprawdzanie danych
            var validator = new PersonValidator();
            var validationResult = validator.Validate(input.Person);
            if (!validationResult.IsValid)
            {
                Console.WriteLine("Wprowadzone dane są niepoprawne!!");
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.ReadLine();
                return;
            }

            // Serializacja wprowadzonych danych do XML
            //Tworzenie ścieżki zapisu i podanie miejsca zapisu
            Directory.CreateDirectory(@"C:\temp");
            string xmlFilePath = @"C:\temp\person.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, input.Person);
            }
            Console.WriteLine("Serializacja zakończona, plik został zapisany w: " + xmlFilePath);

            // Deserializacja pliku XML do obiektu
            Person deserializedPerson;
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                deserializedPerson = (Person)serializer.Deserialize(fileStream);
            }
            Console.WriteLine("Deserializacja zakończona! Oto obiekt odczytany z pliku XML.");
            Console.WriteLine(deserializedPerson.FirstName + " " + deserializedPerson.LastName + " " + deserializedPerson.Age + " " + deserializedPerson.PlaceOfBirth);

            Console.ReadLine();
        }
    }
}
