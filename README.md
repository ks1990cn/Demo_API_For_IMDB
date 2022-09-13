# DEMO API FOR IMDB

Key attraction in this Dummy API :

1.) Use of user secret for connection string <br />
2.) Use of Dependency Injection <br />
3.) Separate and clean code to maintain project <br />
4.) Use of swaggerUI <br />
5.) Transaction in EF <br />
6.) Unit Test Cases <br />
7.) Mocking of DBContext (https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN) <br />
8.) Filters <br />
9.) Custom Middleware <br />
10.) Custom Validation   <br />
11.) Microservice API Gateway using Ocelot   <br />
12.) Gzip Response compression in startup file, added controller to demo this <br />
13.) Rate Limiter to IMDB API using AspNetCoreRateLimit.

How to run this? <br />
**Make sure to have atleast SQL Server 18 and VS19 / 22. <br />

1.) Goto Database folder run in following order <br />
   a.) AssignmentScript - Table and Database Creation <br />
   b.) AssignmentScript - Adding Joining Tables <br />
   c.) AssignmentScript - DQL <br />
   d.) Open PM Command note and in this folder and copy the command <br />
2.) Goto API and open .sln file, then PM Console and paste the command in it. <br />
3.) Build and run. <br />

<br />
<br />
Here are few screenshots to visualize:
<br />
![3-edit-movie](https://user-images.githubusercontent.com/29522704/179511711-0037bd54-9230-494b-b38c-dd44b3527f1e.png) <br />
![2-create-movie](https://user-images.githubusercontent.com/29522704/179511724-80bda0b6-a045-4c6f-b28c-e653022be6de.png) <br />
![1-list-movies](https://user-images.githubusercontent.com/29522704/179511732-bd39f7d6-8576-463c-9b6b-19ad59e4bdf6.png) <br />
![5-create-producer](https://user-images.githubusercontent.com/29522704/179511737-c5537b79-acf1-4483-90ae-65780892e459.png) <br />
![4-create-actor](https://user-images.githubusercontent.com/29522704/179511746-ff54e5b9-46ca-475c-8926-48c8f8c0712a.png) <br />
