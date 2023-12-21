using System;
using System.Collections.Generic;
using System.Linq;


// Класс Contact представляет сущность контакта с основными свойствами.
public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Email: {Email}";
    }
}
// Класс ContactBook используется для управления списком контактов.
public class ContactBook
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1;

    public void AddContact(string firstName, string lastName, string phoneNumber, string email)
    {
        var newContact = new Contact
        {
            Id = nextId++, // Auto-increment the ID
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };

        contacts.Add(newContact);
        Console.WriteLine("Contact added successfully:\n{0}", newContact);
    }

    public IEnumerable<Contact> SearchContacts(string query)
    {
        return contacts.Where(c =>
            c.FirstName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.LastName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.PhoneNumber.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
    // EditContact изменяет существующий контакт, найденный по ID.
    public void EditContact(int id, string firstName, string lastName, string phoneNumber, string email)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact != null)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.PhoneNumber = phoneNumber;
            contact.Email = email;
            Console.WriteLine("Contact updated successfully:\n{0}", contact);
        }
        else
        {
            Console.WriteLine($"Contact with ID {id} not found.");
        }
    }

    public void DeleteContact(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine($"Contact with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Contact with ID {id} not found.");
        }
    }
    // Отображает список всех контактов в книге.
    public void ListAllContacts()
    {
        if (contacts.Any())
        {
            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
    }
}
