```mermaid
graph TD
    subgraph "Flujo Principal"
        Start["Inicio"] --> Init["Inicializar Variables"]
        Init --> ShowMenu["1. Mostrar Menú"]
        ShowMenu --> GetChoice["2. Leer Opción"]
        GetChoice --> Choice{"3. Evaluar Opción"}
    end

    Choice -- "7" --> End["Fin del Programa"]
    Choice -- "Inválida" --> InvalidOption["Mostrar 'Opción incorrecta'"]
    InvalidOption --> ShowMenu

    subgraph "Opción 1: Cargar Usuario"
        direction LR
        Choice -- "1" --> Proc1_CheckLimit{"¿Hay cupo?"}
        Proc1_CheckLimit -- "Sí" --> Proc1_Load["Pedir datos y<br/>guardar usuario"]
        Proc1_CheckLimit -- "No" --> Proc1_Error["Mostrar error de límite"]
        Proc1_Load --> ShowMenu
        Proc1_Error --> ShowMenu
    end

    subgraph "Opción 2: Ver Cursos"
        direction LR
        Choice -- "2" --> Proc2_Show["Listar cursos disponibles"]
        Proc2_Show --> ShowMenu
    end

    subgraph "Opción 6: Enviar Sugerencia"
        direction LR
        Choice -- "6" --> Proc6_CheckLimit{"¿Hay cupo?"}
        Proc6_CheckLimit -- "Sí" --> Proc6_Send["Pedir y guardar<br/>sugerencia"]
        Proc6_CheckLimit -- "No" --> Proc6_Error["Mostrar error de límite"]
        Proc6_Send --> ShowMenu
        Proc6_Error --> ShowMenu
    end

    subgraph "Funciones con Autenticación"
        Choice -- "3" --> Proc3_CheckLogin{"¿Sesión Iniciada?"}
        Choice -- "4" --> Proc4_CheckLogin{"¿Sesión Iniciada?"}
        Choice -- "5" --> Proc5_CheckLogin{"¿Sesión Iniciada?"}

        Proc3_CheckLogin -- "No" --> LoginFlow
        Proc4_CheckLogin -- "No" --> LoginFlow
        Proc5_CheckLogin -- "No" --> LoginFlow
        
        Proc3_CheckLogin -- "Sí" --> Proc3_ShowCourses["Ver Cursos Propios"]
        Proc4_CheckLogin -- "Sí" --> Proc4_Enroll["Inscribirse a Curso"]
        Proc5_CheckLogin -- "Sí" --> Proc5_Cancel["Cancelar Inscripción"]
    end

    subgraph "Sub-flujo: Iniciar Sesión"
        LoginFlow["Pedir Usuario y Clave"] --> Validate{"¿Credenciales Válidas?"}
        Validate -- "No" --> LoginFail["Mostrar 'Datos incorrectos'"]
        LoginFail --> ShowMenu
        Validate -- "Sí" --> LoginSuccess["Éxito, sesión iniciada"]
    end

    LoginSuccess --> Proc3_ShowCourses
    LoginSuccess --> Proc4_Enroll
    LoginSuccess --> Proc5_Cancel

    subgraph "Flujo 'Ver Mis Cursos'"
        Proc3_ShowCourses --> Proc3_HasCourses{"¿Tiene cursos?"}
        Proc3_HasCourses -- "Sí" --> Proc3_List["Listar mis cursos"]
        Proc3_HasCourses -- "No" --> Proc3_NoCourses["Mostrar 'No estás inscrito'"]
        Proc3_List --> ShowMenu
        Proc3_NoCourses --> ShowMenu
    end
    
    subgraph "Flujo 'Inscribirse'"
        Proc4_Enroll --> Proc4_GetCourse{"Pedir curso"}
        Proc4_GetCourse --> Proc4_Exists{"¿Curso existe?"}
        Proc4_Exists -- "No" --> Proc4_ErrNoCourse["Error: Curso no disponible"]
        Proc4_Exists -- "Sí" --> Proc4_IsEnrolled{"¿Ya inscrito?"}
        Proc4_IsEnrolled -- "Sí" --> Proc4_ErrEnrolled["Error: Ya estás inscrito"]
        Proc4_IsEnrolled -- "No" --> Proc4_DoEnroll["Inscribir y confirmar"]
        Proc4_ErrNoCourse --> ShowMenu
        Proc4_ErrEnrolled --> ShowMenu
        Proc4_DoEnroll --> ShowMenu
    end

    subgraph "Flujo 'Cancelar Inscripción'"
        Proc5_Cancel --> Proc5_GetCourse{"Pedir curso a cancelar"}
        Proc5_GetCourse --> Proc5_IsEnrolled{"¿Estás inscrito?"}
        Proc5_IsEnrolled -- "No" --> Proc5_ErrNotEnrolled["Error: No estabas inscrito"]
        Proc5_IsEnrolled -- "Sí" --> Proc5_DoCancel["Cancelar y confirmar"]
        Proc5_ErrNotEnrolled --> ShowMenu
        Proc5_DoCancel --> ShowMenu
    end

style LoginSuccess fill:#d4edda,stroke:#155724
style LoginFail fill:#f8d7da,stroke:#721c24