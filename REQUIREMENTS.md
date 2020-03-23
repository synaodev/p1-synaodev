<!-- pizzabox::requirements -->

# pizzabox

The goal of the project is to build a Pizza Ordering System.

## architecture (REQUIRED)

- [solution] PizzaBox.sln
  - [project - mvc] PizzaBox.Client.csproj
  - [project - classlib] PizzaBox.Domain.csproj
    - [folder] Abstracts
    - [folder] Interfaces
    - [folder] Models
  - [project - classlib ] PizzaBox.Storing.csproj
    - [folder] Repositories
  - [project - xunit] PizzaBox.Testing.csproj
    - [folder] Specs

## requirements

The project should support objects of User, Store, Order, Pizza.

### store

- [required] there should exist at least 2 stores
- [required] each store should be able to view its completed/placed orders (users and associated order within a range)
- [required] each store should be able to view its sales (pizzas and revenue within a range)
- [optional] each strore should be able to view its inventory

### order

- [required] each order must be able to view its pizzas
- [required] each order must be able to compute its cost
- [required] each order must be able to limit its cost to no more than \$250
- [optional] each order should be able to limit its pizza count to no more than 50

### pizza

- [required] each pizza must be able to have a crust
- [required] each pizza must be able to have a size
- [required] each pizza must be able to compute its cost
- [required] each pizza must be able to have at least 2 default toppings
- [optional] should be able to limit its toppings to no more than 5

### user

- [required] must be able to view its order history
- [required] must be able to only order from 1 location/24-hour period
- [required] must be able to only order if an account exists (registered user)
- [optional] should be able to only order 1 time within a 2 hour period

## technologies

- .NET Core - ASP.NET MVC
- .NET Core - C#
- .NET Core - EF + SQL
- .NET Core - xUnit

## timelines

### due on Mar-23 at 10p Central

### present on Mar-24 starting at 9.30a Central

## showcase (as many requirements as you can implement)

### user story

as a user, i will do this:

- login to the system
- see a list of locations
- select a location
- place an order
- with either custom or preset pizzas
- if custom
- select crust, size and toppings
- if preset
- select pizza
- see a tally of my order
- add or remove more pizzas
- and checkout when complete with placing order
- see my order history
- logout when done or make another order

### store story

as a store, i will do this:

- login to the system
- see options for order history, inventory, sales
- if order history
- see orders with associated user
- if inventory
- see current level of components of pizza making
- add or remove components
- if sales
- see pizza type, count, revenue
