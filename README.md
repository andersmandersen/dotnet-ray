## Debug your .Net Core with Ray to fix problems faster

This module can be installed in any .Net Core application to send messages to the Ray app. I comes in very usefull when working with "watch"

For more information about Ray visit https://myray.app/

## 🔧 Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```bash
$ dotnet add package Velcon.Ray
```

or with the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```bash
$ Install-Package Velcon.Ray
```

## 👷‍ Usage

Send message to Ray client 
```c#

using System;
using Velcon.Ray;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {   
			// Send charles         
            new Ray().Charles();

			// Send message
            new Ray("Hallo world!");            
        }        
    }
}
```

Send object to Ray client
```c#

using System;
using Velcon.Ray;

namespace ConsoleApp
{
    class Program
    {
		public class Book
        {
            public string BookId { get; set; }
            public string Title { get; set; }
        }


        static void Main(string[] args)
        {   
			var book = new Book { BookId = "123",  Title = "Pride and Prejudice" };

			// Send message
            new Ray(book);            
        }        
    }
}
```

## Contribute
Feel free to contribute with pull requests, bug reports or enhancement suggestions. We love PR's

## License

The MIT License (MIT). Please see [License File](LICENSE.md) for more information.