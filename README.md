COVID Clinic Member Management System (for Hadasim)
The COVID Clinic Member Management System is a client-server application designed to streamline the management of members within a COVID clinic. 
This system allows clinic staff to efficiently register, update, and manage information about clinic members, including patients, healthcare workers, and other staff.
In addition - the system data is used to provide statistics regarding the corona

Features
Member Registration: Register new members into the HMO clinic system, focusing on patients.
Member Profile Management: View and update member profiles with relevant information such as personal details, medical events, and vaccination records.
1/ Members Management screen
![image](https://github.com/GittySinai/Hadasim/assets/165305099/62a70476-0db4-4c1e-a1c7-78708590685e)
2/ Member management funcitons
![image](https://github.com/GittySinai/Hadasim/assets/165305099/5edea726-e979-4fd1-85a8-3ed54cc94a42)
2.1/ Add a member screen
![image](https://github.com/GittySinai/Hadasim/assets/165305099/b49b506b-ad41-45ea-9e06-caafe2205492)
2.2/ Viewing a member
![image](https://github.com/GittySinai/Hadasim/assets/165305099/9ec64ba8-3a65-4bb4-8039-5bdeea95a1e8)
2.3/ Modifing an existing member
![image](https://github.com/GittySinai/Hadasim/assets/165305099/47e2312c-ff17-4050-8938-e81f524a075b)
2.4/ Upload member profile image - this is an initial solution (local storage - will need to be stord as a BLOB field in the DB)
![image](https://github.com/GittySinai/Hadasim/assets/165305099/41bbf0a7-c4f8-40b5-ad85-9c1732f3461e)

3. Events Management: Schedule, cancel, and manage events of any type for the HMO members.
![image](https://github.com/GittySinai/Hadasim/assets/165305099/e1d19ffb-b333-4614-8d24-264244cbfd8c)

4. Vaccination Record Tracking: Track vaccination records for members, including vaccine types, and vaccination dates.
![image](https://github.com/GittySinai/Hadasim/assets/165305099/34a404e9-0d6f-45cd-bbb8-0b83d7bd753f)


Technologies Used
Frontend:
Angular.js
PrimeNG

Backend:
ASP.NET Core (for building RESTful APIs and server-side logic)
Entity Framework Core (for database interactions)
C# (for server-side programming)
Database:
Microsoft SQL Server (for storing member information and system data)

Notes:
1/ This project was chellenging and gave me a great opportunity to build from scratch a client - server application.
I planned to cretae the DB and applicationlayers in a well-designed way, so you can see the ERD is normalized and the main tables are suiting the application needs.
2/ Regarding the practical coding - 
2.1/ I followed the N-Tier layers model
2.2/ For the first time experienced the auto-mapper concept - a very good experience
2.3/ Connectivity between the client to the server (ANgular) for th first time
So basically - great experience overall... but - a start...

3/ As the time was tight - I needed to give-up on a few areas - 
3.1/ Reporting, Data queries (Created the classes but not yet the code...)
3.2/ Image uploads - save localy (browser storage) - should been saved into to a BLOB column
3.3/ Client facing messages - limited investing

Setup Instructions
Clone the Repository: Clone this repository to your local machine.

Setup Backend:
Navigate to the backend directory.
Open the solution file in Visual Studio.
Configure database connection strings in appsettings.json.
Run the SQL script https://github.com/GittySinai/Hadasim/blob/main/HMODBScript.sql

Setup Frontend:
Navigate to the frontend directory: Client.
Install dependencies using npm.

Run the Application:
Start the backend server.
Start the frontend development server.

