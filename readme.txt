# 🎓 Programación III | UAM

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![OOP](https://img.shields.io/badge/OOP-FF8A00?style=for-the-badge&logoColor=white)

## 🇪🇸 Español

Este repositorio está destinado a subir los códigos desarrollados en clase sobre temas relacionados a la Programación Orientada a Objetos (POO) en C#. Forma parte del curso de **Programación III** en la **Universidad Americana (UAM)**.

### Objetivo del Repositorio

Como profesor, mi objetivo es compartir constantemente ejemplos de código que ayuden a los estudiantes a comprender mejor los conceptos clave de POO y su aplicación práctica en el lenguaje de programación C#. Los ejercicios y ejemplos presentados aquí están diseñados para complementar los contenidos teóricos del curso, proporcionando una base sólida para el aprendizaje de la programación orientada a objetos.

## 🇺🇸 English

This repository is intended to upload the code developed during class related to Object-Oriented Programming (OOP) in C#. It is part of the **Programming III** course at the **Universidad Americana (UAM)**.

### Repository Purpose

As a professor, my goal is to consistently share code examples that help students better understand key OOP concepts and their practical application in the C# programming language. The exercises and examples presented here are designed to complement the theoretical content of the course, providing a solid foundation for learning object-oriented programming.

---

## 📚 Contenido | Content

### 📝 Ejemplos de código | Code examples
Fragmentos de código que ilustran conceptos como herencia, encapsulamiento, polimorfismo y otros principios de POO.

Code snippets illustrating concepts such as inheritance, encapsulation, polymorphism, and other OOP principles.

### 💻 Proyectos completos | Complete projects
Aplicaciones en C# que implementan los temas vistos en clase.

Full C# applications implementing the topics covered in class.

### 📖 Material de apoyo | Support material
Documentación adicional o comentarios dentro del código para facilitar su comprensión.

Additional documentation or comments within the code to facilitate understanding.

## 🗂️ Estructura del Repositorio | Repository Structure

```
Programacion-III-UAM/
├── 01-Fundamentos/              # Fundamentos de POO | OOP Fundamentals
│   ├── Clases/                  # Clases y Objetos | Classes and Objects
│   ├── Encapsulamiento/         # Encapsulamiento | Encapsulation
│   └── ...
├── 02-Herencia/                 # Herencia | Inheritance
│   ├── EjemploBasico/           # Ejemplo Básico | Basic Example
│   ├── HerenciaMultiple/        # Herencia Múltiple | Multiple Inheritance
│   └── ...
├── 03-Polimorfismo/             # Polimorfismo | Polymorphism
├── 04-Interfaces/               # Interfaces | Interfaces
├── 05-Proyectos/                # Proyectos | Projects
│   ├── Proyecto1/               # Proyecto 1 | Project 1
│   ├── Proyecto2/               # Proyecto 2 | Project 2
│   └── ...
└── README.md
```

## 🚀 Instrucciones | Instructions

### 1️⃣ Paso 1 | Step 1
Clona o descarga el repositorio.

Clone or download the repository.
```bash
git clone https://github.com/andreypadias/Programacion-III-UAM.git
```

### 2️⃣ Paso 2 | Step 2
Abre los archivos `.cs` con tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).

Open the `.cs` files with your preferred development environment (Visual Studio, Visual Studio Code, etc.).

### 3️⃣ Paso 3 | Step 3
Revisa el código y sigue las instrucciones o comentarios dentro de los archivos para comprender mejor cada tema.

Review the code and follow the instructions or comments within the files to better understand each topic.

## 📝 Ejemplo de Código | Code Example

```csharp
// Ejemplo básico de una clase en C#
// Basic example of a class in C#

public class Estudiante
{
    // Propiedades | Properties
    public string Nombre { get; set; }
    public int Edad { get; set; }
    private double _promedio;
    
    // Constructor
    public Estudiante(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
        _promedio = 0;
    }
    
    // Método | Method
    public void AsignarCalificacion(double calificacion)
    {
        if (calificacion >= 0 && calificacion <= 100)
        {
            _promedio = calificacion;
        }
    }
    
    // Método con polimorfismo | Polymorphic method
    public virtual string ObtenerInformacion()
    {
        return $"Estudiante: {Nombre}, Edad: {Edad}, Promedio: {_promedio}";
    }
}
```

---

### Desarrollado por | Developed by
**Prof. Andrey Padias**
