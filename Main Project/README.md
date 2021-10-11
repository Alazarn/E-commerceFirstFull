# E-commerceFirstFull

This project is designed to explore the nuances of web development. It Includes a catalog of products that are divided into categories. The ability to search, pagination and sorting are also included. There is an opportunity to make orders and put product in the shopping cart. An account is required to complete purchase. That is why registration and authorization are also implemented. 

There is an administration panel that only users with administrator rights have access to. The administrator is preregistered in the system, so you don`t need to create it manually but of course you can do that in the admin panel.
The Admin panel was designed in the minimalistic style of old IMB BIOS systems. At this stage of development, you have the opportunity to edit information on existing product and users as well as create new ones.

* Login: Admin
* Password: 1111


![Image alt](https://github.com/Alazarn/Imagies/raw/master/img/E-commercefFirstFull.gif)


# Prerequirements

* .Net 5.0
* EF Core

# How to configure and run (Visual Studio)

* Clone code from Github: git clone https://github.com/Alazarn/E-commerceFirstFull.git
* Open solution E-commerceFirstFull.sln in Visual Studio
* Change connection string in Appsetting.json if you are not ready to use MSSQL
* Open Tools --> Nuget Package Manager --> Package Manager Console in Visual Studio
* Create Migration with Add-Migration [name] command, run Update-database command and press Enter
* Press F5 to run the project
