using System;
using System.Collections.Generic;

record Usuario {
    public string? NombreCompleto;
    public string? DNI;
    public string? Correo;
    public string? NombreDeUsuario;
    public string? Clave;
    public string[] CursosInscritos = new string[10];
    public int CantidadDeCursos = 0;
}

class Programa {
    static Usuario[] listaDeUsuarios = new Usuario[100];
    static int cantidadDeUsuarios = 0;
    static string[] cursosDisponibles = { "Conceptos de programación", "Introducción a la Matemática", "Problemas de Historia", "Prácticas culturales" };
    static int cantidadDeCursosDisponibles = 4; // contador manual
    static string[] sugerencias = new string[100];
    static int cantidadDeSugerencias = 0;
    static bool haySesionIniciada = false;
    static Usuario? usuarioActual;

    static void Main() {
        string? eleccion;
        do {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            eleccion = Console.ReadLine();

            switch (eleccion)
            {
                case "1":
                    CargarUsuario();
                    break;
                case "2":
                    MostrarCursos();
                    break;
                case "3":
                    VerCursosDelUsuario();
                    break;
                case "4":
                    InscribirseACurso();
                    break;
                case "5":
                    CancelarInscripcion();
                    break;
                case "6":
                    EnviarSugerencia();
                    break;
                case "7":
                    Console.WriteLine("Fin del programa.");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        } while (eleccion != "7");
    }

    static void MostrarMenu() {
        Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Cargar datos de un usuario");
        Console.WriteLine("2. Ver cursos disponibles");
        Console.WriteLine("3. Ver mis cursos");
        Console.WriteLine("4. Inscribirse a un curso");
        Console.WriteLine("5. Cancelar inscripción");
        Console.WriteLine("6. Enviar sugerencia");
        Console.WriteLine("7. Salir");
    }

    static void CargarUsuario() {
        if (cantidadDeUsuarios >= 100)
        {
            Console.WriteLine("Se ha alcanzado el límite de usuarios.");
            return;
        }
        Usuario nuevoUsuario = new Usuario();
        Console.Write("Nombre y apellido: ");
        nuevoUsuario.NombreCompleto = Console.ReadLine();
        Console.Write("DNI: ");
        nuevoUsuario.DNI = Console.ReadLine();
        Console.Write("Correo electrónico: ");
        nuevoUsuario.Correo = Console.ReadLine();
        Console.Write("Nombre de usuario: ");
        nuevoUsuario.NombreDeUsuario = Console.ReadLine();
        Console.Write("Clave: ");
        nuevoUsuario.Clave = Console.ReadLine();

        listaDeUsuarios[cantidadDeUsuarios] = nuevoUsuario;
        cantidadDeUsuarios++;
        Console.WriteLine("Usuario registrado con éxito.");
    }

    static void MostrarCursos() {
        Console.WriteLine("=== Cursos disponibles ===");
        int i = 0;
        while (i < cantidadDeCursosDisponibles) {
            Console.WriteLine("- " + cursosDisponibles[i]);
            i++;
        }
    }

    static void IniciarSesion() {
        Console.Write("Nombre de usuario: ");
        string? usuarioIngresado = Console.ReadLine();
        Console.Write("Clave: ");
        string? claveIngresada = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < cantidadDeUsuarios; i++) {
            if (listaDeUsuarios[i].NombreDeUsuario == usuarioIngresado && listaDeUsuarios[i].Clave == claveIngresada) {
                usuarioActual = listaDeUsuarios[i];
                haySesionIniciada = true;
                Console.WriteLine("Inicio de sesión exitoso.");
                encontrado = true;
                break;
            }
        }
        if (!encontrado) {
            Console.WriteLine("Datos incorrectos.");
        }
    }

    static void VerCursosDelUsuario() {
        if (!haySesionIniciada) IniciarSesion();
        if (haySesionIniciada) {
            Console.WriteLine("=== Mis cursos ===");
            if (usuarioActual.CantidadDeCursos == 0) {
                Console.WriteLine("No estás inscripto en ningún curso.");
            } else {
                for (int i = 0; i < usuarioActual.CantidadDeCursos; i++) {
                    Console.WriteLine("- " + usuarioActual.CursosInscritos[i]);
                }
            }
        }
    }

    static void InscribirseACurso() {
        if (!haySesionIniciada) IniciarSesion();
        if (haySesionIniciada) {
            MostrarCursos();
            Console.Write("Escriba el nombre exacto del curso al que desea inscribirse: ");
            string? cursoElegido = Console.ReadLine();

            bool existe = false;
            for (int i = 0; i < cantidadDeCursosDisponibles; i++) {
                if (cursosDisponibles[i] == cursoElegido) {
                    existe = true;
                }
            }

            if (existe) {
                bool yaInscripto = false;
                for (int i = 0; i < usuarioActual.CantidadDeCursos; i++) {
                    if (usuarioActual.CursosInscritos[i] == cursoElegido) {
                        yaInscripto = true;
                    }
                }

                if (!yaInscripto) {
                    usuarioActual.CursosInscritos[usuarioActual.CantidadDeCursos] = cursoElegido;
                    usuarioActual.CantidadDeCursos++;
                    Console.WriteLine("Inscripción exitosa.");
                } else {
                    Console.WriteLine("Ya estás inscrito en ese curso.");
                }
            } else {
                Console.WriteLine("Ese curso no está disponible.");
            }
        }
    }

    static void CancelarInscripcion() {
        if (!haySesionIniciada) IniciarSesion();
        if (haySesionIniciada) {
            VerCursosDelUsuario();
            Console.Write("Curso a cancelar: ");
            string? cursoCancelar = Console.ReadLine();

            int posicion = -1;
            for (int i = 0; i < usuarioActual.CantidadDeCursos; i++) {
                if (usuarioActual.CursosInscritos[i] == cursoCancelar) {
                    posicion = i;
                }
            }

            if (posicion != -1) {
                for (int j = posicion; j < usuarioActual.CantidadDeCursos - 1; j++) {
                    usuarioActual.CursosInscritos[j] = usuarioActual.CursosInscritos[j + 1];
                }
                usuarioActual.CantidadDeCursos--;
                Console.WriteLine("Curso cancelado.");
            } else {
                Console.WriteLine("No estabas inscrito en ese curso.");
            }
        }
    }

    static void EnviarSugerencia() {
        Console.Write("Ingrese su sugerencia: ");
        string? texto = Console.ReadLine();
        if (cantidadDeSugerencias < 100) {
            sugerencias[cantidadDeSugerencias] = texto;
            cantidadDeSugerencias++;
            Console.WriteLine("Gracias por tu sugerencia.");
        } else {
            Console.WriteLine("Ya se alcanzó el límite de sugerencias.");
        }
    }
} 