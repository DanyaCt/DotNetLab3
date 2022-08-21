using DotNetLab3;
using DotNetLab3.Factory;


var txtloggerFactory = new TxtLoggerFactory();
var xmlloggerFactory = new XmlLoggerFactory();
var txtlogger = txtloggerFactory.CreateLogger();
var xmllogger = xmlloggerFactory.CreateLogger();
var menu = new Menu(txtlogger, xmllogger);

while (true)
{
    try
    {
        menu.PrintMenu();
    }
    catch (ArgumentException e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
        Console.WriteLine();
    }
}