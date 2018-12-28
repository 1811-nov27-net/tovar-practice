using LINQAndTestingLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace LINQAndTesting.Tests
{
    // typically one test class to test each real class
    public class MyCollectionTests
    {
        // in XUnit, each unit test, to test one thing, should be a method with "Fact" attribute
        [Fact] // this kind of thing is called an "attribute" - 
               //   special kind of class that adds extra behavior to a class, method, poperty, etc. 
            // arrange (set up the situation to be tested.)
        public void EmptyCollectionShouldHaveZeroLength()
            {
                // arrange (set up the situation to be tested)
                // sometimes people use acronym "SUT" for "subject under test"

                var sut = new MyCollection();
                // it's already empty

                // act (run the method/behavior that we're specifically testing.)
                var result = sut.Length;

                // assert (define what the correct result is and check that we got it.)
                Assert.Equal(0, result);
                // Assert class ha s lots of static methods to check various things
        }

        // [Fact] is for tests that don't take any parameters.
        // [Theory] is a convenient way to run a paramterized test with more than one set of data
        [Theory]
        [InlineData(new string[] { "a", "ab" }, "ab")]
        [InlineData(new string[] { "a", "a" }, "ab")]
        [InlineData(new string[] { "a" } , "a")]
        [InlineData(new string[] { "ab", "b2" }, "ab")]
        [InlineData(new string[] { }, null)]
        [InlineData(new string[] { "a", null, "a" }, "ab")]
        public void LongestShouldReturnLongest(string[] items, string expected)
        {
            // arrange 
            var coll = new MyCollection();

            foreach(var item in items)
            {
                coll.Add(item);
            }
            // act
            string actual = coll.longest();

            //assert
            Assert.Equal(expected, actual);
        }

        // test-driven develop:
        // step 1: write test(s)
        
        [Fact]
        public void EmptyShouldBeEmpty()
        {
            var coll = new MyCollection();
        }
    }
}
