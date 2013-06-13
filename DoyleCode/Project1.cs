using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;



//Project 1
//===========
//Directions:
//    Create a class that, on instantiation, reads the attached file (test.txt) and stores only lines whose text can be converted to an Int32 data type. 
//    Convert all lines that meet this criteria to an Int32 and save in a data store of your choice.
//    Then, implement the following methods in your class.

//1. Create a method that returns a List<Int32> of all numbers in the data store.
//2. Create an overload of method #1 that provides an ascending or descending sorted List<Int32> of all numbers based on an ascending/descending parameter.
//3. Create a method that returns a List<Int32> of even numbers in the data store.
//4. Cretae a method that returns a List<Int32> of odd numbers in the data store.
//5. Create a method that returns a List<Int32> of numbers in the data store that are between 200 and 2000.
//6. Create a method that returns a List<string> where a string is added for each number in the data store as follows:
// - add "fizz" if the number is a multiple of 3
// - add "buzz" if the number is a multiple of 5
// - add "fizzbuzz" if the number is a multiple of 3 and 5
// - add "none" if none of the above apply

//When finished, send a full archive of all code and resources necessary
//to build your projects.

namespace DoyleCode
{

    public enum SortingDirection { ASCENDING, DESCENDING };

    class Project1
    {
        // Create a class that, on instantiation, reads the attached file (test.txt) and stores only lines whose text can be converted to an Int32 data type. 
        // Convert all lines that meet this criteria to an Int32 and save in a data store of your choice.
        public Project1()
        {
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(@"../../test.txt");
                String line;
                Int32 num = -1;
                mData = new List<Int32>();

                while ((line = reader.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);

                    if (Int32.TryParse(line, out num))
                    {
                        //Console.WriteLine("****" + num.ToString());
                        mData.Add(num);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }

        //1. Create a method that returns a List<Int32> of all numbers in the data store.
        public List<Int32> GetInts()
        {
            return new List<Int32>(mData);
        }

        //2. Create an overload of method #1 that provides an ascending or descending sorted List<Int32> of all numbers based on an ascending/descending parameter.
        public List<Int32> GetInts(SortingDirection direction)
        {
            var tmpdata = new List<Int32>(mData);
            tmpdata.Sort();

            if (direction == SortingDirection.DESCENDING)
                tmpdata.Reverse();

            return tmpdata;
        }

        //3. Create a method that returns a List<Int32> of even numbers in the data store.
        public List<Int32> GetEvenInts()
        {
            return new List<Int32>(
                mData.FindAll(delegate(Int32 item) { return (item % 2) == 0; }));
        }

        //4. Create a method that returns a List<Int32> of odd numbers in the data store.
        public List<Int32> GetOddInts()
        {
            return new List<Int32>(
                mData.FindAll(delegate(Int32 item) { return (item % 2) == 1; }));
        }

        //5. Create a method that returns a List<Int32> of numbers in the data store that are between 200 and 2000.
        public List<Int32> GetIntsBetween200and2000()
        {
            return new List<Int32>(
                mData.FindAll(delegate(Int32 item) { return item > 200 && item < 2000; }));
        }

        // 6. Create a method that returns a List<string> where a string is added for each number in the data store as follows:
        // - add "fizz" if the number is a multiple of 3
        // - add "buzz" if the number is a multiple of 5
        // - add "fizzbuzz" if the number is a multiple of 3 and 5
        // - add "none" if none of the above apply
        public List<String> Fizzbuzzify()
        {
            var fizzbuzz = new List<String>(mData.Count);
            foreach (var item in mData)
            {
                if ((item % 3 == 0) && (item % 5 == 0))
                    fizzbuzz.Add(item.ToString() + "fizzbuzz");
                else if (item % 3 == 0)
                    fizzbuzz.Add(item.ToString() + "fizz");
                else if (item % 5 == 0)
                    fizzbuzz.Add(item.ToString() + "buzz");
                else
                    fizzbuzz.Add(item.ToString() + "none");
            }
            return fizzbuzz;
        }

        // Members
        private List<Int32> mData;
    }
}