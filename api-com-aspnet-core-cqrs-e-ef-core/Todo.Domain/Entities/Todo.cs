namespace ToDo.Domain.Entities
{
    public class ToDoItem : Entity
    {
        public ToDoItem(string title, DateTime date, string refUser)
        {
            Title = title;
            Done = false;
            Date = date;
            RefUser = refUser;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string RefUser { get; private set; }

        public void MarkAsDone()
        {
            if (Done)
                throw new Exception("This item is already marked as done.");
            else
                Done = true;
        }

        public void UnmarkAsDone()
            => Done = false;

        public void UpdateTitle(string title)
            => Title = title;
    }
}