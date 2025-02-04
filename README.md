# Tarea Enlace - Aplicación WPF con C# y XAML

Este proyecto es una aplicación de escritorio desarrollada en WPF (Windows Presentation Foundation) utilizando C# y XAML. Su objetivo es vincular dinámicamente datos ingresados por el usuario a elementos de la interfaz y almacenarlos en un archivo XML.

## Descripción

La aplicación permite al usuario:

- Ingresar un nombre y un número de teléfono en dos campos de texto.
- Ver reflejados estos datos en tiempo real en dos etiquetas de visualización.
- Guardar los datos ingresados en un archivo XML al pulsar un botón, el cual solo se activa cuando ambos campos están llenos.

## Características

- **Interfaz de Usuario**: Diseñada con XAML para una experiencia de usuario intuitiva.
- **Enlace de Datos**: Utiliza el patrón MVVM para la vinculación dinámica de datos.
- **Persistencia de Datos**: Guarda los datos en formato XML.
- **Validación Básica**: El botón de guardar solo está habilitado cuando ambos campos están completos.

## Tecnologías Utilizadas

- **C#**: Para la lógica de negocio y el ViewModel.
- **XAML**: Para el diseño de la interfaz gráfica.
- **.NET Framework** / **.NET Core**: Dependiendo de la elección al crear el proyecto.
- **WPF**: Para la creación de la aplicación de escritorio.
