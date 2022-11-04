using SimpleTodoApp.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inMemoryDb = new List<TodoItem>
{
    new TodoItem("Kjøpe ny støvsuger"),
    new TodoItem("Skifte dekk") {Done = new DateTime(2020,11,4)},
    new TodoItem("Male huset"),
};

app.MapGet("/todo", () =>
{
    return inMemoryDb;
});
app.MapPost("/todo", (TodoItem todoItem) =>
{
    inMemoryDb.Add(todoItem);
});
app.MapPut("/todo/{id}", (Guid id) =>
{
    var todoItem = inMemoryDb.SingleOrDefault(ti => ti.Id == id);
    todoItem.Done = DateTime.Today;
});
app.MapDelete("/todo/{id}", (Guid id) =>
{
    inMemoryDb.RemoveAll(ti => ti.Id == id);
});

app.UseStaticFiles();
app.Run();
