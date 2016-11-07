# Note-GitHub-API

This upload is in response to a requested assessment.
I combined the notes backend API and the GitHub Issues frontend task into one project. 

Download the project folder zip and extract the files.

I created the project in VS2015 and used the v4.5.2 .NETFramework. If this framework is not installed on your machine then you should be able to change the target to one that is (4.5). When you try to start the project you will most likely get the following error: "CS1617: Invalid option '6' for /langversion; must be ISO-1, ISO-2, 3, 4, 5 or Default". If so open the Web.config file for the project and locate the following line in the compiler block:

compilerOptions="/langversion:6 /nowarn:1659;1699;1701" 

Change the langversion to 5.

Once you are able to start the project successfully, the page that renders initially will be that of the frontend task given in the assessment. 

As the project and local server is running you should be able to query the note api that is included in the project as well. (I used Postman, a chrome extension app)  

Cheers!
