1)Developed the C# ASP.NET core  Microservices using containers on Kubernetes. Created two services: API and Calculation. API service is at C# and Calculation service on angular front end.<br />
2) Dockerized the .NET core API and angular app. Run and deploy containers to the Kubernetes with docker desktop.<br />
3) .NET Core API dockerized using docker desktop and map ports on docker UI. On the other hand angular app using NGINX Ingress controller. <br />
4) Used Sqlite for database and EntityFrameworkCore for object database mapping.<br />
5) For the API Specification configured the swagger UI. <br />
6) integrate yaml pipeline script for setup and build. Created two Kubernetes deployments and  each deployment as a service.Exposed both services on same port exposed via an Ingress<br />
7) Events can be integrated for inter microservice communication and rabbitmq, entityframework can be used.<br />
8) Solution can be improved by using Design principles and patterns in order to make it more simple and scalable. <br />
9) A Testing framework can be build by setting up a testing pipeline to automate the process using build server such as jenkins, team city so it can be testedbefore releases. <br />
