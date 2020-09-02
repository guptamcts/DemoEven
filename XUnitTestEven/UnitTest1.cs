using DemoEven;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using Xunit;

namespace XUnitTestEven
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string textFile = "";
            if (!string.IsNullOrEmpty(textFile))
            {
                textFile = ConfigurationManager.AppSettings["FileWithPath"];
            }
            else
            {
                textFile = @"C:\Users\bhush\source\repos\GitHub\DemoEven\DemoEven\File\data.txt";// 
            }
            string str = "";
            if (File.Exists(textFile))
            {
                str = File.ReadAllText(textFile, Encoding.UTF8);
            }
            
            if (!String.IsNullOrEmpty(str.Trim()))
            {
                Program obj = new Program();
                var result = obj.InputCalculation(str);
                Assert.Equal(8291, result[0,0]);                
            }
            
        }
    }
}
