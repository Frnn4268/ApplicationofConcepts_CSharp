using System;

class Program
{
    static void Main(string[] args)
    {
        ITaskManager taskManager = new TaskManagerProxy();

        while (true)
        {
            Console.WriteLine("-------- GESTIÓN DE TAREAS --------");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Modificar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Ver tareas pendientes");
            Console.WriteLine("5. Ver tareas completadas");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese la opción deseada: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        AddTask(taskManager);
                        break;
                    case 2:
                        UpdateTask(taskManager);
                        break;
                    case 3:
                        RemoveTask(taskManager);
                        break;
                    case 4:
                        ShowPendingTasks(taskManager);
                        break;
                    case 5:
                        ShowCompletedTasks(taskManager);
                        break;
                    case 6:
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }

            Console.WriteLine();
        }
    }

    static void AddTask(ITaskManager taskManager)
    {
        Console.Write("Ingrese el título de la tarea: ");
        string title = Console.ReadLine();
        Console.Write("Ingrese la descripción de la tarea: ");
        string description = Console.ReadLine();

        TaskItem newTask = new TaskItem
        {
            Title = title,
            Description = description,
            IsCompleted = false
        };

        taskManager.AddTask(newTask);
        Console.WriteLine("Tarea agregada exitosamente.");
    }

    static void UpdateTask(ITaskManager taskManager)
    {
        Console.Write("Ingrese el título de la tarea a modificar: ");
        string title = Console.ReadLine();

        TaskItem existingTask = taskManager.GetPendingTasks().Find(t => t.Title == title);
        if (existingTask == null)
        {
            Console.WriteLine("Tarea no encontrada o ya completada.");
            return;
        }

        Console.Write("Ingrese el nuevo título de la tarea: ");
        string newTitle = Console.ReadLine();
        Console.Write("Ingrese la nueva descripción de la tarea: ");
        string newDescription = Console.ReadLine();
        Console.Write("¿La tarea está completada? (S/N): ");
        bool isCompleted = (Console.ReadLine().ToUpper() == "S");

        TaskItem updatedTask = new TaskItem
        {
            Title = newTitle,
            Description = newDescription,
            IsCompleted = isCompleted
        };

        taskManager.UpdateTask(title, updatedTask);
        Console.WriteLine("Tarea modificada exitosamente.");
    }

    static void RemoveTask(ITaskManager taskManager)
    {
        Console.Write("Ingrese el título de la tarea a eliminar: ");
        string title = Console.ReadLine();

        taskManager.RemoveTask(title);
        Console.WriteLine("Tarea eliminada exitosamente.");
    }

    static void ShowPendingTasks(ITaskManager taskManager)
    {
        Console.WriteLine("-------- TAREAS PENDIENTES --------");
        var pendingTasks = taskManager.GetPendingTasks();
        foreach (var task in pendingTasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Descripción: {task.Description}");
            Console.WriteLine($"Completada: {task.IsCompleted}");
            Console.WriteLine("--------------------------");
        }
    }

    static void ShowCompletedTasks(ITaskManager taskManager)
    {
        Console.WriteLine("-------- TAREAS COMPLETADAS --------");
        var completedTasks = taskManager.GetCompletedTasks();
        foreach (var task in completedTasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Descripción: {task.Description}");
            Console.WriteLine($"Completada: {task.IsCompleted}");
            Console.WriteLine("--------------------------");
        }
    }
}
