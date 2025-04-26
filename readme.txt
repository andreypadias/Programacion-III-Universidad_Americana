<div align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET"/>
  <img src="https://img.shields.io/badge/OOP-FF8A00?style=for-the-badge&logoColor=white" alt="OOP"/>
  
  # 🎓 Programación III | UAM
  ### Programación Orientada a Objetos en C#
</div>

<table>
  <tr>
    <td width="50%">
      <h2>🇪🇸 Español</h2>
      <p>Este repositorio está destinado a subir los códigos desarrollados en clase sobre temas relacionados a la Programación Orientada a Objetos (POO) en C#. Forma parte del curso de <strong>Programación III</strong> en la <strong>Universidad Americana (UAM)</strong>.</p>
    </td>
    <td width="50%">
      <h2>🇺🇸 English</h2>
      <p>This repository is intended to upload the code developed during class related to Object-Oriented Programming (OOP) in C#. It is part of the <strong>Programming III</strong> course at the <strong>Universidad Americana (UAM)</strong>.</p>
    </td>
  </tr>
</table>

## 📋 Objetivo | Purpose

<table>
  <tr>
    <td width="50%">
      <p>Como profesor, mi objetivo es compartir constantemente ejemplos de código que ayuden a los estudiantes a comprender mejor los conceptos clave de POO y su aplicación práctica en el lenguaje de programación C#. Los ejercicios y ejemplos presentados aquí están diseñados para complementar los contenidos teóricos del curso, proporcionando una base sólida para el aprendizaje de la programación orientada a objetos.</p>
    </td>
    <td width="50%">
      <p>As a professor, my goal is to consistently share code examples that help students better understand key OOP concepts and their practical application in the C# programming language. The exercises and examples presented here are designed to complement the theoretical content of the course, providing a solid foundation for learning object-oriented programming.</p>
    </td>
  </tr>
</table>

## 📚 Contenido | Content

<table>
  <tr>
    <td width="33%" align="center">
      <h3>📝 Ejemplos de código</h3>
      <h3>Code examples</h3>
      <p>Fragmentos de código que ilustran conceptos como herencia, encapsulamiento, polimorfismo y otros principios de POO.<br><br>Code snippets illustrating concepts such as inheritance, encapsulation, polymorphism, and other OOP principles.</p>
    </td>
    <td width="33%" align="center">
      <h3>💻 Proyectos completos</h3>
      <h3>Complete projects</h3>
      <p>Aplicaciones en C# que implementan los temas vistos en clase.<br><br>Full C# applications implementing the topics covered in class.</p>
    </td>
    <td width="33%" align="center">
      <h3>📖 Material de apoyo</h3>
      <h3>Support material</h3>
      <p>Documentación adicional o comentarios dentro del código para facilitar su comprensión.<br><br>Additional documentation or comments within the code to facilitate understanding.</p>
    </td>
  </tr>
</table>

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

<table>
  <tr>
    <td width="33%" align="center">
      <h3>1</h3>
      <p>Clona o descarga el repositorio.<br>Clone or download the repository.</p>
      <code>git clone https://github.com/andreypadias/Programacion-III-UAM.git</code>
    </td>
    <td width="33%" align="center">
      <h3>2</h3>
      <p>Abre los archivos <code>.cs</code> con tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).<br>Open the <code>.cs</code> files with your preferred development environment (Visual Studio, Visual Studio Code, etc.).</p>
    </td>
    <td width="33%" align="center">
      <h3>3</h3>
      <p>Revisa el código y sigue las instrucciones o comentarios dentro de los archivos para comprender mejor cada tema.<br>Review the code and follow the instructions or comments within the files to better understand each topic.</p>
    </td>
  </tr>
</table>

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

<hr>

<div align="center">
  <p>Desarrollado por | Developed by</p>
  <h3>Prof. Andrey Padias</h3>
  
  <img src="https://capsule-render.vercel.app/api?type=waving&color=239120&height=100&section=footer" width="100%">
</div>
