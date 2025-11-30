using Newtonsoft.Json;

namespace WebApp.DataClasses
{
    public class TodoList
    {
        public int Id {  get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
