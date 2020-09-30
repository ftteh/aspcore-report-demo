# aspcore-report-demo

## Setup
1.Open the solution file.

2.Open the nuget console and create the db with predefined migration using update-database command.

3.Build the application and run it.


Initially please create the accounts for login at link **localhost:xxxxx/users/create** 
  - create at least one role with admin, as only admin role can view the readership stats.
  - normal user can have the staff role.
  
## Run  
Once acc created visit localhost:xxxxx to login.

Now you can upload/download/view readership stat based on your role.

 
Some links info:
 
 __/Readerships/Index__ : Summary of readerships, total views and last access tiem for each report.
 
 __/Readerships/Detailed__: Individual access for each users
 
 


