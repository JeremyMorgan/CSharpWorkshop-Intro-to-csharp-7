using System;

namespace csvtohtml
{
    class Program
    {
        static void Main(string[] args)
        {

            // our file path
            string filepath = @"C:\Users\Jeremy Morgan\Desktop\CsharpCourse\csvtohtml\";

            // counter to see how many lines were added
            int counter = 0;
            // temporary variable for lines
            string line;
            // text we'll be writing to html
            string textToSend = @"<h1>Customers</h1>
            <table border=1>";

            // Read the file and display it line by line.
            System.IO.StreamReader file =
            new System.IO.StreamReader(filepath + "test.csv");

            // loop thru
            while((line = file.ReadLine()) != null)
            {
                // create a temporary string array
                string[] tempLine = line.Split(',');
                // open a table row
                textToSend += "<tr>\n";
                // first line is the table header
                if (counter == 0){
                    textToSend += "<th>" + tempLine[0] + "</th>\n";
                    textToSend += "<th>" + tempLine[1] + "</th>\n";
                    textToSend += "<th>" + tempLine[2] + "</th>\n";
                    textToSend += "<th>" + tempLine[3] + "</th>\n";
                }else {
                    // remaining lines here
                    textToSend += "<td>" + tempLine[0] + "</td>\n";
                    textToSend += "<td>" + tempLine[1] + "</td>\n";
                    textToSend += "<td>" + tempLine[2] + "</td>\n";
                    textToSend += "<td>" + tempLine[3] + "</td>\n";
                }
                // close the table row
                textToSend += "</tr>\n";
                // increment the counter
                counter++;
            }
            // close the table
            textToSend += "</table>";

            // output to the console
            System.Console.Write(textToSend);

            // write all text to a file
            System.IO.File.WriteAllText(filepath + "test.html", textToSend);

            // close the file
            file.Close();
            // how many customers did we write to the file?
            System.Console.WriteLine("\n\nWrote {0} Customers to page.", counter -1);
            // Suspend the screen.
            //System.Console.ReadLine();
        }
    }
}
