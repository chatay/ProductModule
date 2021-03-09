## **Which pattern have you use and why?**

I implemented **repository pattern**  as a design pattern. The reason is that we do not have to modify the data access logic or business access login so no need to change the repository logic.

## Some experience with the techology and libraries

I had no previously experience with **SQLite** as it is so easy to set up however I had some config issues and it made me lose time.

I had experience in **.net core** version of 3.0. I like using it as it provides many features. Such as async is a great way to make queries and not wasting time on db calls or logging cases. Attempted to use async to get TransactionId from database.

I added screenshot of insertion of transaction, sorry to not be able to push it as there were some errors to handle.

Automapper is a way to map classes where it leads to segregated models. In the project, it makes no sense to return database model transaction, so generated a transactionPoco class to return a more clear class to the client.

## What would you like to add if you have had more time?

* **Middleware** enables use to modify the request as it before reaches to the core project. 
* **Identity library** to be able to use authorization
* **fluentvalidation** as it provides good structured data annotions.
* **logger** is a core function for a project to handle issues. I had intention to use Nlog as it provides **ElasticSearch** support.

## Anything more to add?
* I would have normally used decimal but did not want to waste time on converting.
* I focused more on **designing the api architecture** because once the architecture is correctly designed, it is really easy to fetch data from database. That is the reason I could not accomplish all the methods you asked me to do 
