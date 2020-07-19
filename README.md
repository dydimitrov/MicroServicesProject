# MicroServicesProject
Project for Softuni Micro services course exam defense


README
This README would normally document whatever steps are necessary to get your application up and running.

Prerequisite
Visual Studio 2019
Installed Docker for Windows: https://docs.docker.com/docker-for-windows/install/

How do I get set up?
Clone the repository localy

Start Powershell in the root of project where is docker-compose.yml file

Run command docker-compose up -d

If nothing changed in docker-compose.yml the needed microservice will runing on ports:
    "Identity": "http://localhost:5001",
    "News": "http://localhost:5003",
    "Appointment": "http://localhost:5005",
    "Property": "http://localhost:5007",
    "Bookmark": "http://localhost:5010",
    "BookmarkGateway": "https://localhost:5012",
    "Statistic": "http://localhost:5014"


Next step is to run localy the web client and gateway for bookmarks.
  -Go to Visual Studio and set start project to multiple projects
  -Set to start RealEstate and RealEstate.Bookmarks.Gateway
  
 

