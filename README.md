# Todo App

This is a test app for building a web API using ASP.NET Core.

Based on [this tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio-code).

## To Run

```bash
dotnet run
```

The service will then run on [localhost:7159](https://localhost:7159/).

## To See All Books

```bash
http --verify no https://localhost:7159/api/books | jq '.'
```

```json
[
  {
    "Id": "61f1e70651d3aedad21a89b4",
    "Name": "Design Patterns",
    "Price": 54.93,
    "Category": "Computers",
    "Author": "Ralph Johnson"
  },
  {
    "Id": "61f1e70651d3aedad21a89b5",
    "Name": "Clean Code",
    "Price": 43.15,
    "Category": "Computers",
    "Author": "Robert C. Martin"
  }
]
```

## To See A Single Book

```bash
http --verify no https://localhost:7159/api/books/61f1e70651d3aedad21a89b4 | jq '.'
```

```json
{
  "Id": "61f1e70651d3aedad21a89b4",
  "Name": "Design Patterns",
  "Price": 54.93,
  "Category": "Computers",
  "Author": "Ralph Johnson"
}
```

## To Create A Book

```bash
http --verify no https://localhost:7159/api/books name="Building Microservices" category=Computers author="Sam Newman" Price:=69.99 | jq '.'
```

```json
{
    "Author": "Sam Newman",
    "Category": "Computers",
    "Id": "61f1f0f51436c79b6f34ccef",
    "Name": "Building Microservices",
    "Price": 69.99
}
```

## To Delete A Book

```bash
http --verify no DELETE https://localhost:7159/api/todoitems/1
```

A `DELETE` request only returns a `204` status code.
