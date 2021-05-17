using System;
using System.Reflection;
using User_lib;

namespace Proj.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new User("Tom", 18);
            person.ToCosnole();
            Console.WriteLine();

            var asm = Assembly.LoadFrom(
                "E:\\C# proj\\Nix-proj\\Lesson-1\\Practice\\Resourses\\User-lib.dll");

            var types = asm.GetTypes();
            foreach (var type in types)
            {
                var members = type.GetMembers();
                Console.WriteLine(type.FullName);
                
                foreach (var member in members)
                {
                    Console.WriteLine($"  {member.Name}\n    {member.DeclaringType}");
                }

                Console.WriteLine();
            }

            //or
            var userType = asm.GetType("User_lib.User");
            Console.WriteLine(userType?.FullName);
            foreach (var member in userType?.GetMembers())
            {
                Console.WriteLine($"  {member.Name}\n    {member.DeclaringType}");
            }
        }
    }
}