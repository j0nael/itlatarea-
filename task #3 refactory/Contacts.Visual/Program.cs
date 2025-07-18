Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                showContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);


            }
            break;
        case 3: //search
            {

                Console.WriteLine("ingresa el Id del usuario a buscar");
                int id = Convert.ToInt32(Console.ReadLine());
                SearchContact(id, ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);



            }
            break;
        case 4: //modify
            {

                Console.WriteLine("ingresa el Id del usuario a modificar");
                int id = Convert.ToInt32(Console.ReadLine());
                modifyContacts(ids, id, names, lastnames, addresses, telephones, emails, ages, bestFriends);


            }
            break;
        case 5: //delete
            {

                Console.WriteLine("ingresa el Id del usuario a borrar");
                int id = Convert.ToInt32(Console.ReadLine());
                DeleteContacts(ids, id, names, lastnames, addresses, telephones, emails, ages, bestFriends);



            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("opcion invalida");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

}

static void SearchContact(int id, List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

    if (ids.Contains(id))
    {
        string firstName = names[id];
        string lastName = lastnames[id];
        string address = addresses[id];
        string phoneNumber = telephones[id];
        string email = emails[id];
        int age = ages[id];
        bool isBestFriend = bestFriends[id];

        Console.WriteLine("=== Contact Found ===");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Best Friend: {(isBestFriend ? "Yes" : "No")}");
        Console.WriteLine("======================");
    }
    else
    {
        Console.WriteLine($"No contact found with ID {id}.");
    }
}

static void showContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];


        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");

    }
}

static void modifyContacts(List<int> ids, int id, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (!ids.Contains(id))
    {
        Console.WriteLine($"El contacto con ID {id} no existe.");
        return;
    }
    while (true)
    {
        Console.WriteLine("Qué desea modificar?");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Apellido");
        Console.WriteLine("3. Dirección");
        Console.WriteLine("4. Teléfono");
        Console.WriteLine("5. Email");
        Console.WriteLine("6. Edad");
        Console.WriteLine("7. Mejor amigo?");
        Console.WriteLine("8. Modificar todo");
        Console.WriteLine("9. Salir");
        Console.Write("Opción: ");
        string modify = Console.ReadLine();

        switch (modify)
        {
            case "1":
                Console.Write("Nuevo nombre: ");
                names[id] = Console.ReadLine();
                break;

            case "2":
                Console.Write("Nuevo apellido: ");
                lastnames[id] = Console.ReadLine();
                break;

            case "3":
                Console.Write("Nueva dirección: ");
                addresses[id] = Console.ReadLine();
                break;

            case "4":
                Console.Write("Nuevo teléfono: ");
                telephones[id] = Console.ReadLine();
                break;
            case "5":
                Console.Write("Nuevo email: ");
                emails[id] = Console.ReadLine();
                break;

            case "6":
                Console.Write("Nueva edad: ");
                ages[id] = int.Parse(Console.ReadLine());
                break;

            case "7":
                Console.Write("Es mejor amigo? (1. Sí, 2. No): ");
                bestFriends[id] = Console.ReadLine() == "1";
                break;

            case "8":
                Console.Write("Nuevo nombre: ");
                names[id] = Console.ReadLine();

                Console.Write("Nuevo apellido: ");
                lastnames[id] = Console.ReadLine();

                Console.Write("Nueva dirección: ");
                addresses[id] = Console.ReadLine();

                Console.Write("Nuevo teléfono: ");
                telephones[id] = Console.ReadLine();

                Console.Write("Nuevo email: ");
                emails[id] = Console.ReadLine();

                Console.Write("Nueva edad: ");
                ages[id] = int.Parse(Console.ReadLine());

                Console.Write("Es mejor amigo? (1. Sí, 2. No): ");
                bestFriends[id] = Console.ReadLine() == "1";
                break;

            case "9":
                Console.WriteLine("Modificación realizada.");
                return;

            default:
                Console.WriteLine("Opción erronea Intente nuevamente.");
                break;
        }
    }
}
static void DeleteContacts(List<int> ids, int id, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{

    Console.WriteLine("Seguro que lo quieres borrar ? 1.Si / 2.No");
    int seguro = int.Parse(Console.ReadLine());
    Boolean borrador = true;
    while (borrador)
    {
        switch (seguro)
        {

            case 1:
                ids.Remove(id);
                names.Remove(id);
                lastnames.Remove(id);
                addresses.Remove(id);
                telephones.Remove(id);
                emails.Remove(id);
                ages.Remove(id);
                bestFriends.Remove(id);
                Console.WriteLine("Se borro al usuario");
                break;
            case 2:
                borrador = false;
                break;
            default:

                break;
        }

    }

}



