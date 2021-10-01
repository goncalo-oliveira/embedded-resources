# Assembly extensions for embedded resources

This project contains a few extensions to make it easier to read content from embedded resources.

## Installation

Install the package from [nuget.org](https://nuget.org)

```bash
$ dotnet add package Faactory.Extensions.EmbeddedResources
```

## Usage

From an `Assembly` instance, retrieve a reference for the embedded resource.

> Note: It's important to remember that the resource Uri is case-sensitive.

```csharp
var resource = Assembly.GetExecutingAssembly()
    .GetEmbeddedResource( "~/Embedded/MyFile.txt" );
```

By using the `~/` prefix, we are prepending the resource name with the assembly name. In many cases this is true, but if the root namespace (defined in the project file) is different from the assembly name, we can use an absolute uri.

```csharp
var resource = Assembly.GetExecutingAssembly()
    .GetEmbeddedResource( "root_namespace/Embedded/MyFile.txt" );
```

After we construct the resource reference, we can retrieve the stream or read the content directly as a string.

```csharp
var resource = Assembly.GetExecutingAssembly()
    .GetEmbeddedResource( "~/Embedded/MyFile.txt" );

// get resource stream
using ( var stream = resource.GetStream() )
{
    ...
}

// read content as string
var content = resource.ReadAsString();

// read content as a string asynchronously
var content = await resource.ReadAsStringAsync();
```

And naturally, we can chain all of this

```csharp
var content = Assembly.GetExecutingAssembly()
    .GetEmbeddedResource( "~/Embedded/MyFile.txt" )
    .ReadAsString();
```

Using the above examples, our project would be structure like this

```
src/
src/Program.cs
src/Embedded/
src/Embedded/MyFile.txt
```
