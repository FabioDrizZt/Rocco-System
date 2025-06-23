using System;

class Programa
{
    // Se anida el struct Usuario dentro de la clase Programa para que pueda acceder a las constantes.
    struct Usuario
    {
        public string NombreCompleto;
        public string DNI;
        public string Correo;
        public string NombreDeUsuario;
        public string Clave;
        public string[] CursosInscritos; // No se puede inicializar aquí en un struct de .NET 4.0
        public int CantidadDeCursos;
    }

    const int MaxUsuarios = 100;
    const int MaxCursosPorUsuario = 10;
    const int MaxSugerencias = 100;

    static Usuario[] listaDeUsuarios = new Usuario[MaxUsuarios];
    static int cantidadDeUsuarios = 0;
    static string[] cursosDisponibles = { "Conceptos de programación", "Introducción a la Matemática", "Problemas de Historia", "Prácticas culturales" };
    static string[] sugerencias = new string[MaxSugerencias];
    static int cantidadDeSugerencias = 0;
    static int indiceUsuarioActual = -1; // Usaremos un índice en lugar de un objeto

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n========================================");
            if (indiceUsuarioActual == -1) // Comprobamos si hay un usuario logueado usando el índice
            {
                MostrarMenuPrincipal();
                string eleccion = Console.ReadLine();
                switch (eleccion)
                {
                    case "1":
                        IniciarSesion();
                        break;
                    case "2":
                        RegistrarUsuario();
                        break;
                    case "3":
                        EnviarSugerencia();
                        break;
                    case "4":
                        Console.WriteLine("Fin del programa.");
                        return;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
            else
            {
                MostrarMenuUsuarioLogueado();
                string eleccion = Console.ReadLine();
                switch (eleccion)
                {
                    case "1":
                        MostrarCursos();
                        break;
                    case "2":
                        VerCursosDelUsuario();
                        break;
                    case "3":
                        InscribirseACurso();
                        break;
                    case "4":
                        CancelarInscripcion();
                        break;
                    case "5":
                        CerrarSesion();
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
        }
    }

    static void MostrarMenuPrincipal()
    {
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Iniciar sesión");
        Console.WriteLine("2. Registrarse");
        Console.WriteLine("3. Enviar sugerencia");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void MostrarMenuUsuarioLogueado()
    {
        Console.WriteLine($"¡Hola, {listaDeUsuarios[indiceUsuarioActual].NombreDeUsuario}!");
        Console.WriteLine("=== MENÚ DE USUARIO ===");
        Console.WriteLine("1. Ver cursos disponibles");
        Console.WriteLine("2. Ver mis cursos");
        Console.WriteLine("3. Inscribirse a un curso");
        Console.WriteLine("4. Cancelar inscripción");
        Console.WriteLine("5. Cerrar sesión");
        Console.Write("Seleccione una opción: ");
    }

    static void RegistrarUsuario()
    {
        if (cantidadDeUsuarios >= MaxUsuarios)
        {
            Console.WriteLine("Se ha alcanzado el límite de usuarios.");
            return;
        }
        Usuario nuevoUsuario = new Usuario();
        nuevoUsuario.CursosInscritos = new string[MaxCursosPorUsuario]; // Inicializamos el array aquí
        nuevoUsuario.CantidadDeCursos = 0;


        Console.Write("Nombre y apellido: ");
        nuevoUsuario.NombreCompleto = Console.ReadLine();
        if (string.IsNullOrEmpty(nuevoUsuario.NombreCompleto)) { Console.WriteLine("El nombre no puede estar vacío."); return; }

        Console.Write("DNI: ");
        nuevoUsuario.DNI = Console.ReadLine();
        if (string.IsNullOrEmpty(nuevoUsuario.DNI)) { Console.WriteLine("El DNI no puede estar vacío."); return; }

        Console.Write("Correo electrónico: ");
        nuevoUsuario.Correo = Console.ReadLine();
        if (string.IsNullOrEmpty(nuevoUsuario.Correo)) { Console.WriteLine("El correo no puede estar vacío."); return; }

        Console.Write("Nombre de usuario: ");
        nuevoUsuario.NombreDeUsuario = Console.ReadLine();
        if (string.IsNullOrEmpty(nuevoUsuario.NombreDeUsuario)) { Console.WriteLine("El nombre de usuario no puede estar vacío."); return; }

        Console.Write("Clave: ");
        nuevoUsuario.Clave = Console.ReadLine();
        if (string.IsNullOrEmpty(nuevoUsuario.Clave)) { Console.WriteLine("La clave no puede estar vacía."); return; }

        listaDeUsuarios[cantidadDeUsuarios] = nuevoUsuario;
        cantidadDeUsuarios++;
        Console.WriteLine("Usuario registrado con éxito.");
    }

    static void MostrarCursos()
    {
        Console.WriteLine("=== Cursos disponibles ===");
        for (int i = 0; i < cursosDisponibles.Length; i++)
        {
            Console.WriteLine("- " + cursosDisponibles[i]);
        }
    }

    static void IniciarSesion()
    {
        Console.Write("Nombre de usuario: ");
        string usuarioIngresado = Console.ReadLine();
        Console.Write("Clave: ");
        string claveIngresada = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < cantidadDeUsuarios; i++)
        {
            if (listaDeUsuarios[i].NombreDeUsuario == usuarioIngresado && listaDeUsuarios[i].Clave == claveIngresada)
            {
                indiceUsuarioActual = i; // Guardamos el índice del usuario
                Console.WriteLine("Inicio de sesión exitoso.");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Datos incorrectos.");
        }
    }

    static void CerrarSesion()
    {
        indiceUsuarioActual = -1; // Reseteamos el índice
        Console.WriteLine("Sesión cerrada.");
    }

    static void VerCursosDelUsuario()
    {
        Console.WriteLine("=== Mis cursos ===");
        if (listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos == 0)
        {
            Console.WriteLine("No estás inscripto en ningún curso.");
        }
        else
        {
            for (int i = 0; i < listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos; i++)
            {
                Console.WriteLine("- " + listaDeUsuarios[indiceUsuarioActual].CursosInscritos[i]);
            }
        }
    }

    static int BuscarPosicionCurso(string nombreCurso)
    {
        for (int i = 0; i < cursosDisponibles.Length; i++)
        {
            if (cursosDisponibles[i] == nombreCurso)
            {
                return i;
            }
        }
        return -1; // No encontrado
    }

    static int BuscarPosicionInscripcion(string nombreCurso)
    {
        for (int i = 0; i < listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos; i++)
        {
            if (listaDeUsuarios[indiceUsuarioActual].CursosInscritos[i] == nombreCurso)
            {
                return i;
            }
        }
        return -1; // No encontrado
    }

    static void InscribirseACurso()
    {
        MostrarCursos();
        Console.Write("Escriba el nombre exacto del curso al que desea inscribirse: ");
        string cursoElegido = Console.ReadLine();

        if (string.IsNullOrEmpty(cursoElegido))
        {
            Console.WriteLine("El nombre del curso no puede estar vacío.");
            return;
        }

        if (BuscarPosicionCurso(cursoElegido) != -1)
        {
            if (BuscarPosicionInscripcion(cursoElegido) == -1)
            {
                if (listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos < MaxCursosPorUsuario)
                {
                    listaDeUsuarios[indiceUsuarioActual].CursosInscritos[listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos] = cursoElegido;
                    listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos++;
                    Console.WriteLine("Inscripción exitosa.");
                }
                else
                {
                    Console.WriteLine("Has alcanzado el límite de cursos inscritos.");
                }
            }
            else
            {
                Console.WriteLine("Ya estás inscrito en ese curso.");
            }
        }
        else
        {
            Console.WriteLine("Ese curso no está disponible.");
        }
    }

    static void CancelarInscripcion()
    {
        VerCursosDelUsuario();

        if (listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos == 0)
        {
            return;
        }

        Console.Write("Curso a cancelar: ");
        string cursoCancelar = Console.ReadLine();

        if (string.IsNullOrEmpty(cursoCancelar))
        {
            Console.WriteLine("El nombre del curso no puede estar vacío.");
            return;
        }

        int posicion = BuscarPosicionInscripcion(cursoCancelar);

        if (posicion != -1)
        {
            for (int j = posicion; j < listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos - 1; j++)
            {
                listaDeUsuarios[indiceUsuarioActual].CursosInscritos[j] = listaDeUsuarios[indiceUsuarioActual].CursosInscritos[j + 1];
            }
            listaDeUsuarios[indiceUsuarioActual].CursosInscritos[listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos - 1] = null; // Limpiar el último elemento
            listaDeUsuarios[indiceUsuarioActual].CantidadDeCursos--;
            Console.WriteLine("Curso cancelado.");
        }
        else
        {
            Console.WriteLine("No estabas inscrito en ese curso.");
        }
    }

    static void EnviarSugerencia()
    {
        Console.Write("Ingrese su sugerencia: ");
        string texto = Console.ReadLine();
        if (string.IsNullOrEmpty(texto))
        {
            Console.WriteLine("La sugerencia no puede estar vacía.");
            return;
        }

        if (cantidadDeSugerencias < MaxSugerencias)
        {
            sugerencias[cantidadDeSugerencias] = texto;
            cantidadDeSugerencias++;
            Console.WriteLine("Gracias por tu sugerencia.");
        }
        else
        {
            Console.WriteLine("Ya se alcanzó el límite de sugerencias.");
        }
    }
} 