public class InMemoryTaskManager : ITaskManager
{
    private List<TaskItem> tasks;

    public InMemoryTaskManager()
    {
        tasks = new List<TaskItem>();
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public void UpdateTask(string title, TaskItem updatedTask)
    {
        TaskItem taskToUpdate = tasks.Find(t => t.Title == title);
        if (taskToUpdate != null)
        {
            taskToUpdate.Title = updatedTask.Title;
            taskToUpdate.Description = updatedTask.Description;
            taskToUpdate.IsCompleted = updatedTask.IsCompleted;
        }
    }

    public void RemoveTask(string title)
    {
        tasks.RemoveAll(t => t.Title == title);
    }

    public List<TaskItem> GetPendingTasks()
    {
        return tasks.Where(t => !t.IsCompleted).ToList();
    }

    public List<TaskItem> GetCompletedTasks()
    {
        return tasks.Where(t => t.IsCompleted).ToList();
    }
}
