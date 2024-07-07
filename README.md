Asp.Net Core, EF Core, Clean Architecture without DDD

Application follows Clean Architecture.
Infrastructure Layer contains:

1. DBContext (EF with SQL)
2. Repositories which call EF to interact with SQL.

Domain layer contains only the entity classes.
NOTE: Actual DDD implementation will be done in the future.
