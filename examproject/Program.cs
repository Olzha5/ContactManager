using System;

class Program
{// Главный класс для управления книгой контактов в консольном приложении.
    static ContactBook contactBook = new ContactBook();

    static void Main(string[] args)
    {
        while (true)
        {// Выводим меню действий пользователю.
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Search Contacts");
            Console.WriteLine("3: Edit Contact");
            Console.WriteLine("4: Delete Contact");
            Console.WriteLine("5: List All Contacts");
            Console.WriteLine("6: Exit");
            Console.Write("Enter option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    SearchContacts();
                    break;
                case "3":
                    EditContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    ListAllContacts();
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    // Собирает информацию от пользователя и добавляет новый контакт.
    static void AddContact()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        // Добавляем контакт используя введенные данные.
        contactBook.AddContact(firstName, lastName, phoneNumber, email);
    }
    // Поиск контактов на основе запроса пользователя.
    static void SearchContacts()
    {
        Console.Write("Enter search query: ");
        string query = Console.ReadLine();
        var foundContacts = contactBook.SearchContacts(query);

        Console.WriteLine("Found contacts:");
        foreach (var contact in foundContacts)
        {
            Console.WriteLine(contact);
        }
    }
    // Редактирует существующий контакт, идентифицированный по ID.
    static void EditContact()
    {
        Console.Write("Enter the ID of the contact to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Enter new first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter new last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter new phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter new email: ");
            string email = Console.ReadLine();

            contactBook.EditContact(id, firstName, lastName, phoneNumber, email);
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
    // Удаляет контакт по ID, предоставленному пользователем.
    static void DeleteContact()
    {
        Console.Write("Enter the ID of the contact to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            contactBook.DeleteContact(id);
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    static void ListAllContacts()
    {
        contactBook.ListAllContacts();
    }
}
