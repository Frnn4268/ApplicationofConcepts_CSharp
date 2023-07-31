public class TaskManagerProxy : ITaskManager
{
    private InMemoryTaskManager taskManager;

    public TaskManagerProxy()
    {
        taskManager = new InMemoryTaskManager();
    }

    public void AddTask(TaskItem task)
    {
        lock (taskManager)
        {
            taskManager.AddTask(task);
        }
    }

    public void UpdateTask(string title, TaskItem updatedTask)
    {
        lock (taskManager)
        {
            taskManager.UpdateTask(title, updatedTask);
        }
    }

    public void RemoveTask(string title)
    {
        lock (taskManager)
        {
            taskManager.RemoveTask(title);
        }
    }

    public List<TaskItem> GetPendingTasks()
    {
        lock (taskManager)
        {
            return taskManager.GetPendingTasks();
        }
    }

    public List<TaskItem> GetCompletedTasks()
    {
        lock (taskManager)
        {
            return taskManager.GetCompletedTasks();
        }
    }
}
