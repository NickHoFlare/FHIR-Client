# FHIR-Client 
This project was created as part of the work done for the thesis "Development of a Telehealth Framework for an Android Platform", by Nicholas Ho.

This is the client demonstration component of the project, containing an implementation of a client that accesses data using the FHIR API provided by the FHIR Server.

To run:
1) Clone/download a copy of of this repository
2) Open the .sln file using Visual Studio 2015
3) Build the project.
	a) If there are any errors during the building process, close VS2015, navigate to the directory containing the source files and delete the "packages" folder (if present)
4) Open ANOTHER instance of VS2015 and open the FHIR Server project (https://github.com/terran324/FHIR-Server)
5) Run the FHIR server as per the instructions in the README.md of the server project
6) Run the FHIR client by clicking on the Start button in VS for this project.
7) A console application will open, prompting input. 
8) Enter input, as desired.

NOTE: The names of resources are case-sensitive and have to be typed as prompted (Patient, Device, Observation)