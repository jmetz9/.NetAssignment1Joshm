using System;
using System.IO;

namespace CourseGPAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            int id = 1;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        int lineNum = 0;
                        while (!sr.EndOfStream)
                        {
                            //display data
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                            lineNum++;
                        }
                        //make id correct in case they want to add more tickets
                        id = lineNum + 1;
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    //ask to make a ticket
                    Console.WriteLine("Make a new ticket? (Y/N)?");
                    //user inputs response
                    string resp = Console.ReadLine().ToUpper();
                    if (resp == "Y"){
                    //create file from data
                    StreamWriter sw = new StreamWriter(file);
                    //set id number and then increment id by 1
                    int ticketID = id;
                    id++;
                    //Ask for Summary and get reponse
                    Console.WriteLine("add a summary");
                    string summary = Console.ReadLine();
                    //Status
                    Console.WriteLine("add a status");
                    string status = Console.ReadLine();
                    //Priority
                    Console.WriteLine("enter ticket priority");
                    string priority = Console.ReadLine();
                    //Submitter
                    Console.WriteLine("who submitted this ticket?");
                    string submitter = Console.ReadLine();
                    //Assigned
                    Console.WriteLine("who is this ticket assigned to?");
                    string assigned = Console.ReadLine();
                    //Watching
                    Console.WriteLine("who is watching?");
                    string watching = Console.ReadLine();
                    string respWatch;
                    do{
                        Console.WriteLine("anyone else? (Y/N)?");
                        respWatch = Console.ReadLine().ToUpper();
                        if(respWatch == "N"){
                            break;
                        }
                        Console.WriteLine("who?");
                        watching += "|" + Console.ReadLine();
                    } while (respWatch == "Y");
                    //Save info
                    sw.WriteLine(ticketID + "," + summary + "," + status + "," + priority
                    + "," + submitter + "," + assigned + "," + watching);
                    sw.Close();
                    }
                    
                }
            } while (choice == "1" || choice == "2");
        }
    }
}