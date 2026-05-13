using System.Text.RegularExpressions;

// Initial state
var registeredEmail = "test@gmail.com";
var registeredPassword = "Password123#";
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n--- SISTEMA DE ACCESO ---");
    Console.WriteLine("1. Registrarse");
    Console.WriteLine("2. Iniciar sesión");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Register();
            break;
        case "2":
            Login();
            break;
        case "3":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

void Register()
{
    Console.WriteLine("\n--- REGISTRO ---");
    Console.Write("Ingrese su correo electrónico: ");
    string newEmail = Console.ReadLine();

    if (!IsValidEmail(newEmail))
    {
        Console.WriteLine("Error: El formato del correo no es válido.");
        return;
    }

    if (newEmail == registeredEmail)
    {
        Console.WriteLine("Error: El correo ya está registrado.");
        return;
    }

    Console.Write("Ingrese su contraseña: ");
    string newPass = Console.ReadLine();

    if (!IsValidPassword(newPass))
    {
        Console.WriteLine("Error: La contraseña no cumple los requisitos de seguridad.");
        return;
    }

    Console.Write("Confirme su contraseña: ");
    string confirmPass = Console.ReadLine();

    if (newPass != confirmPass)
    {
        Console.WriteLine("Error: Las contraseñas no coinciden.");
        return;
    }

    // Update local "database"
    registeredEmail = newEmail;
    registeredPassword = newPass;
    Console.WriteLine("¡Registro exitoso! Ya puede iniciar sesión.");
}

void Login()
{
    Console.WriteLine("\n--- INICIO DE SESIÓN ---");
    Console.Write("Correo: ");
    string inputEmail = Console.ReadLine();
    Console.Write("Contraseña: ");
    string inputPass = Console.ReadLine();

    if (inputEmail == registeredEmail && inputPass == registeredPassword)
    {
        Console.WriteLine("¡Bienvenido al sistema!");
        isRunning = false; // Stop the loop after successful login
    }
    else
    {
        Console.WriteLine("Credenciales incorrectas. Intente de nuevo.");
    }
}

bool IsValidEmail(string email)
{
    if (string.IsNullOrWhiteSpace(email)) return false;
    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
}

bool IsValidPassword(string password)
{
    if (string.IsNullOrWhiteSpace(password)) return false;
    // Length 8+, 1 Uppercase, 1 Lowercase, 1 Digit, 1 Special
    string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#]).{8,}$";
    return Regex.IsMatch(password, pattern);
}