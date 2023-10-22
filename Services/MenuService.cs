
using InlämningsUppgiften.Models;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace InlämningsUppgiften.Services;

public class MenuService
{
    private static readonly ContactService _contactService = new ContactService();

    public void MainMenu()
    {
      do
        {
            Console.Clear();
            Console.WriteLine(@"////Contacts\\\\");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Delete a contact");
            Console.WriteLine("3. Show all contacts");
            Console.WriteLine("4. Show one contact");
            Console.WriteLine("0. Exit.");
            Console.WriteLine(@"////---------\\\\");
            Console.Write("Use an alternative above: ");
            var option = Console.ReadLine();

            switch (option!.ToLower())
            {
                case "1":
                    AddMenu();
                    break;

                case "2":
                    RemoveMenu();
                    break;

                case "3":
                    ShowAllMenu();
                    break;

                case "4":
                    ShowOneMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }
        while (true);

    }

    public void AddMenu()
    {
        

        var contact = new Contact();        
        Console.Clear();
        Console.Write("Firstname: ");
        contact.FirstName = Console.ReadLine()!;  
        
        Console.Write("Lastname: ");
        contact.LastName = Console.ReadLine()!;   
        
        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;

        contact.Address = new Address();
        Console.Write("Streetname: ");
        contact.Address.StreetName = Console.ReadLine()!;       
        
        Console.Write("Streetnumber: ");
        contact.Address.StreetNumber = Console.ReadLine()!;  
        
        Console.Write("Postalcode: ");
        contact.Address.PostalCode = Console.ReadLine()!;   
        
        Console.Write("City: ");
        contact.Address.City = Console.ReadLine()!;

        _contactService.AddContactToList(contact);
    }

    public void RemoveMenu()
    {
        Console.Clear();
        Console.Write("Emailaddress: ");
        var email = Console.ReadLine()!;

        _contactService.RemoveUserFromList(x => x.Email == email);
    }

    public void ShowAllMenu()
    {
        

        Console.Clear();
        foreach(var contact in _contactService.GetContactsFromList())
        Console.WriteLine($" {contact.FirstName} {contact.LastName} {contact.Email} <{contact.Address.FullAddress}> \n");
        
    }

    public void ShowOneMenu()
    {
        Console.Clear();
        Console.Write("Emailaddress: ");
        var email = Console.ReadLine()!;


        var contact = _contactService.GetContactFromList(x => x.Email == email);
        if (contact != null)
            Console.WriteLine($" {contact.FirstName} {contact.LastName} {contact.Email} <{contact.Address.FullAddress}> \n");
        else
            Console.WriteLine("No contact was found");
    }
}
