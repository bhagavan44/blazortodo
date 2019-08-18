namespace BlazorTodo.Models
{
    public class Todo
    {
        public Todo()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
