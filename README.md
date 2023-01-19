# Clean architecture and CQRS in .NET

This is a template project where I try to illustrate how to build a webapp using "Clean
architecture" and CQRS. These are two concepts I have been trying to learn about, and my goal is to
learn how to better structure an application for scalability. I have experienced that big projects
can become hard to maneuver and consequently harder to maintain.

## About Clean Architecture

My interpretation of "Clean architecture" here is as follows:
- Essential entities that does not change very often is gathered in the 'Domain' project.
- Business logic should mainly be gathered in the 'Application' project (layer).
- The 'Web' project is the link between the application and the world, in this example it is a web
  application. We can have other projects that target other links to the world as well, for instance
  a mobile application or a native program.
- Other projects and layers should be created as they are needed. For instance a Data Access layer
  for persisting data. It should be a separate project that has access to 'Application' and should
  be accessed by 'Web' project. It should implement interfaces that are defined in the
  'Application' layer.

### Conclusion

"Clean Architecture" provides value in that we can separate what is stable, what is business logic
and what is infrastruture around the main application. I think it is valueable, as it is a
structure that can help us to organize our code better, and maybe make it easier for any new
developers since they can hopefully find the use cases and figure out what the application is about
by simply looking at the `Application` layer.

## About CQRS

My interpretation of 'CQRS' is as follows:
- Requests are separated into `Commands` and `Queries`.
- `Commands` implement `ICommand` and will do writes, meaning it will do some changes to the
  database.
- `Commands` will only return success or failure and no other data.
- `Queries` implement `IQuery` and will do reads, meaning it should not modify application state.
- `Queries` can return both simple and complex data structures.

### Conclusion

CQRS separates queries and commands. According to
[Microsoft](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs), read and write
workloads are often asymmetrical, with very different performance and scale requirements. I have
not worked on any application that was so big that it needed multiple database nodes to manage all
the read load. What I have worked on, are systems that grows so big that it is hard to recognise
what is a use case, and where is the business logic for a particular type of problem.

I think it would be a good thing to bring use cases down to a level of detail where they can be
coded individually. And I think it can be helpful to divide use cases between a need to see
something and a need to change something. To that end I think CQRS can help, that the use cases
that cares about seeing something will be a query, while use cases that cares about changing
something will be a command.
