namespace SimpleTodoApp.Model
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime? Done { get; set; }

        public TodoItem(string text) : this()
        {
            Text = text;
        }

        public TodoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
