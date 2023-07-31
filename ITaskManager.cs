public interface ITaskManager
{
    void AddTask(TaskItem task);
    void UpdateTask(string title, TaskItem updatedTask);
    void RemoveTask(string title);
    List<TaskItem> GetPendingTasks();
    List<TaskItem> GetCompletedTasks();
}
