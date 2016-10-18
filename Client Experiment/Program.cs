using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Experiment
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new FhirClient("https://localhost:44384/fhir");
            bool valid = false;

            Console.WriteLine("Welcome to the FHIR client.");

            while (true)
            {
                Console.WriteLine("Please type the name of a resource. (Patient/Device/Observation)");
                string resInput = Console.ReadLine();

                if (resInput.Equals("Patient") ||
                    resInput.Equals("Device") ||
                    resInput.Equals("Observation"))
                {
                    int id = 0;

                    Console.WriteLine("Please type the id of the resource. (integer)");
                    string idInput = Console.ReadLine();

                    ResourceIdentity identity = ResourceIdentity.Build(resInput, idInput);

                    if (resInput.Equals("Patient"))
                    {
                        try
                        {
                            var patient = client.Read<Patient>(identity);
                            Console.WriteLine("Patient's given name: " + patient.Name[0].Given.FirstOrDefault());
                            Console.WriteLine("Patient's family name: " + patient.Name[0].Family.FirstOrDefault());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Patient not found!");
                            continue;
                        }
                    }
                    else if (resInput.Equals("Device"))
                    {
                        try
                        {
                            var device = client.Read<Device>(identity);
                            Console.WriteLine("Device's manufacturer: " + device.Manufacturer);
                            Console.WriteLine("Device's model: " + device.Model);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Device not found!");
                            continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            var observation = client.Read<Observation>(identity);
                            Console.WriteLine("Observation's paired device: " + observation.Device.Reference);
                            Console.WriteLine("Observation's status: " + observation.Status);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Observation not found!");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error in input. Try again!");
                }
            }
        }
    }
}
