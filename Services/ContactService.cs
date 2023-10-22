using InlämningsUppgiften.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace InlämningsUppgiften.Services;

public class ContactService
{
    private List<Contact> _contactList = new List<Contact>();
    private readonly string path = @"c:\Code\contacts.json";

    public ContactService()
    {
        GetContactsFromList();
    }

    public void AddContactToList(Contact contact)
    {
        _contactList.Add(contact);
        FileServices.SaveToFile(path, JsonConvert.SerializeObject(_contactList));
        
    }

    public IEnumerable<Contact> GetContactsFromList() 
    {
        try
        {
            var contacts = FileServices.ReadFromFile(path);
            if (!string.IsNullOrEmpty(contacts))
            {
                _contactList = JsonConvert.DeserializeObject<List<Contact>>(contacts)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contactList;
    }

    public Contact GetContactFromList(Func<Contact, bool> expression)
    {
        try
        {
            var contact = _contactList.FirstOrDefault(expression);
            if (contact != null)
                return contact;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;

    }      

    public Contact  UpdateContact(Contact contact) 
    { 
        
        var _contact = _contactList.FirstOrDefault(x => x.Id == contact.Id);
        if (_contact != null)
        {
            if (_contact.FirstName != contact.FirstName)
                _contact.FirstName = contact.FirstName;

            if (_contact.LastName != contact.LastName)
                _contact.LastName = contact.LastName;

            if (_contact.Email != contact.Email)
                _contact.Email = contact.Email;
            
            if (_contact.Address != contact.Address)
                _contact.Address = contact.Address;


            //_userList.Remove(_contact);
            //AddContactToList(_contact);
            FileServices.SaveToFile(path, JsonConvert.SerializeObject(_contactList));
            return _contact;
        }

        return null!;
    }

    public bool RemoveUserFromList(Func<Contact, bool> expression)
    {
        var contact = GetContactFromList(expression);
        if (contact != null)
        {
            _contactList.Remove(contact);
            FileServices.SaveToFile(path, JsonConvert.SerializeObject(_contactList));
            return true;
        }
        return false;
    }
}
