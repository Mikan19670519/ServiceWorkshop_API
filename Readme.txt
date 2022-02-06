Notes on how I approached and tested this solution (Visual Studio 2019):

I Created a Winform Solution called ServiceWorkshop using the .NET 4.7.2 Framework.
I Created an API called ServiceWorkshopAPI using .NET 5.0

Further functionality could be added, such as log all errors to a serilog file .

Automated testing of the UI, using Visual Studio Test Professional or a tool like Selenium, would provide another level of testing to ensure the application works as expected.

SQL DATABASE:
I used SQL 2019
SQL Script needed to create DB ServiceWorkshop: 
ServiceWorkshop_DB_Script.sql located at WorkshopService Assignment\Api\ServiceWorkshop_API\

Change Web.config to point to your SQL server
 "ConnectionStrings": {
    "DbContext": "Server=(local);Trusted_Connection=True;initial catalog=ServiceWorkshop;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }

NOTE:

