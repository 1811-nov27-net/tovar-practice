using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = GetPeople();

            // backslashes are an "escape haracter" in strings like this
            // to treat them literally, use an @-string
            SerializeToFile(@"C:\revature\training-code\week1\day5", list);
        }

        private static void SerializeToFile(string fileName, IList<Person> people)
        {
            // first, we need to convert the data in memory (the list of person)
            // into some byte representation (aka serial representation)
            // we can use many formats for this - we could maek up our own,
            // or we could use JSON, or we could use XML,  or some other format we'll use XML

            var serializer = new XmlSerializer(typeof(List<Person>));
            FileStream fileStream = null;

            Task<List<Person>> listTask = DeserializeFromFileAsync(fileName);
            // at this point in time, i have not yet started reading the file

            // synchronously wait on the task to get the return value.

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);

                serializer.Serialize(fileStream, people);
            }
            catch (IOException e)
            {
                Console.WriteLine($"some eror in file I/O:{e.Message}");
            }

            finally
            {
                // ? == null condition operator
                fileStream?.Dispose();
            }
        }

        // as soon as we start doing something async:
        // 1. await some async method.
        // 2. make your method async, return Task and named ... Async
        // 3. repeat with all methods that call that method, on and on

        // async on a method is just a flag to tell poeple that this returns
        // Task and it needs to be awaited to actualy get the result.
        public static async Task<List<Person>> DeserializeFromFileAsync(string fielName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            List<Person> result;

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fielName, FileMode.Open))
                {

                    // copy the fileStream asynchronously in the memoryStream.

                    await fileStream.CopyToAsync(memoryStream);
                    // when we await a task, other code can ru in the meantime
                }
            }







        }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Name = new Name
                    {

                    }

                }

            };
        }
    }
}
