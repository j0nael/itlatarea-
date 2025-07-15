//jonthan geraldo 2024-2604 Friday night class

using proyectcontacs;
Console.WriteLine("Mi Agenda Perrón");

Console.WriteLine("Bienvenido a tu lista de contactes");
Dictionary<int, Contacto> contactos = new Dictionary<int, Contacto>();


bool running = true;
while (running)
{

    Console.Write("1. Agregar Contacto      ");
    Console.Write("2. Ver Contactos     ");
    Console.Write("3. Buscar Contactos      ");
    Console.Write("4. Modificar Contacto        ");
    Console.Write("5. Eliminar Contacto     ");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            AddContact(ref contactos);
            break;
        case 2:
            ViewContacts(ref contactos);
            break;
        case 4:
            EditContact(ref contactos);
            break;
        case 5:
            DeleteContact(ref contactos);
            break;
        case 3: //esto es intencional, no importa el orden en que pongan los cases, pero, traten de ser siempre lo mas ordenados posible
            SearchContact(ref contactos);
            break;
        case 6:
            running = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}

static void AddContact(ref Dictionary<int, Contacto> contactos)
{
    Console.WriteLine("Vamos a agregar ese contacte que te trae loco.");

    int id = contactos.Count + 1;

    Console.Write("Digite el Nombre: ");
    var name = Console.ReadLine();
    
    Console.Write("Digite el Teléfono: ");
    var telefono = Console.ReadLine();
   

    Console.Write("Digite el Email: ");
    var email = Console.ReadLine();
   
    Console.Write("Digite la dirección: ");
    var address = Console.ReadLine();
   
    

    contactos.Add(id, new Contacto(name, telefono, email, address));

}

static void ViewContacts(ref Dictionary<int, Contacto> contactos)
{
    Console.WriteLine("Id           Nombre          Telefono            Email           Dirección");
    Console.WriteLine("___________________________________________________________________________");

    foreach (var Contacto in contactos)
    {
        Console.WriteLine($"{Contacto.Key}    {Contacto.Value.name}      {Contacto.Value.phone}      {Contacto.Value.email}     {Contacto.Value.address}");
    }
}

static void EditContact(ref Dictionary<int, Contacto> contactos)
{
    ViewContacts(ref contactos);
    Console.WriteLine("Digite un  Id de Contacto Para Editar");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());
    var nombreSeleccionado = contactos[idSeleccionado].name;
    var telefonoSeleccionado = contactos[idSeleccionado].phone;
    var emailSeleccionado = contactos[idSeleccionado].email;
    string direccionSeleccionada = contactos[idSeleccionado].address;

    Console.Write($"El nombre es: {nombreSeleccionado}, Digite el Nuevo Nombre: ");
    var name = Console.ReadLine();
    contactos[idSeleccionado].name = String.IsNullOrEmpty(name) ? name:nombreSeleccionado ;

    Console.Write($"El Teléfono es: {telefonoSeleccionado}, Digite el Nuevo Teléfono: ");
    var telefono = Console.ReadLine();
    contactos[idSeleccionado].phone = String.IsNullOrEmpty(telefono) ?  telefonoSeleccionado : telefono;


    Console.Write($"El Email es: {emailSeleccionado}, Digite el Nuevo Email: ");
    var email = Console.ReadLine();
    contactos[idSeleccionado].email= String.IsNullOrEmpty(email) ?  emailSeleccionado:email ;

    Console.Write($"La dirección es: {direccionSeleccionada}, Digite la nueva dirección: ");
    var address = Console.ReadLine();
    contactos[idSeleccionado].address = String.IsNullOrEmpty(address) ? direccionSeleccionada:address;
}


static void DeleteContact(ref Dictionary<int, Contacto> contactos)
{
    ViewContacts(ref contactos);
    Console.WriteLine("Digite un Id de Contacto Para Eliminar");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
    int opcion = Convert.ToInt32(Console.ReadLine());
    if (opcion == 1)
    {
       
        contactos.Remove(idSeleccionado);
        
    }

}

static void SearchContact(ref Dictionary<int, Contacto> contactos)
{
    ViewContacts(ref contactos);
    Console.WriteLine("Digite un Id de Contacto Para Mostrar");
    int idSeleccionado = Convert.ToInt32(Console.ReadLine());
     var nombreSeleccionado = contactos[idSeleccionado].name;
    var telefonoSeleccionado = contactos[idSeleccionado].phone;
    var emailSeleccionado = contactos[idSeleccionado].email;
    string direccionSeleccionada = contactos[idSeleccionado].address;


    Console.Write($"El nombre es: {nombreSeleccionado}"); 
    Console.Write($"El Teléfono es: {telefonoSeleccionado}"); 
    Console.Write($"El Email es: {emailSeleccionado}"); 
    Console.Write($"La dirección es: {direccionSeleccionada}");
}
