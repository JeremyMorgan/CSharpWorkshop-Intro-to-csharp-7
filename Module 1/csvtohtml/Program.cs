using System;

namespace csvtohtml
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            string textToSend = @"<h1>Customers</h1>
            <table border=1>";
            string filepath = @"C:\Users\Jeremy Morgan\Desktop\CsharpCourse\csvtohtml\";

            // Read the file and display it line by line.
            System.IO.StreamReader file =
            new System.IO.StreamReader(filepath + "test.csv");
            while((line = file.ReadLine()) != null)
            {
                string[] tempLine = line.Split(',');
                textToSend += "<tr>";
                if (counter == 0){
                    textToSend += "<th>" + tempLine[0] + "</th>";
                    textToSend += "<th>" + tempLine[1] + "</th>";
                    textToSend += "<th>" + tempLine[2] + "</th>";
                    textToSend += "<th>" + tempLine[3] + "</th>";
                }else {
                    textToSend += "<td>" + tempLine[0] + "</td>";
                    textToSend += "<td>" + tempLine[1] + "</td>";
                    textToSend += "<td>" + tempLine[2] + "</td>";
                    textToSend += "<td>" + tempLine[3] + "</td>";
                }
                textToSend += "</tr>";
                counter++;
            }

            textToSend += "</table>";

            System.Console.Write(textToSend);

            System.IO.File.WriteAllText(filepath + "test.html", textToSend);

            file.Close();

            System.Console.WriteLine("Wrote {0} Customers to page.", counter -1);
            // Suspend the screen.
            System.Console.ReadLine();
        }
    }
}
