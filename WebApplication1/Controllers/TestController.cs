using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            int[] input = new int[] { 1, 2, 1, 5, 5, 3, 3, 3, 4 };


            int challange = Challenge(input);
            if (challange == -1)
                return "Invalid Input Array";

            else
                return "Output: " + challange;
        }

        //Resolving Challenge by C# code.
        public int Challenge(int[] input)
        {
            if (input.Count() <= 1)
            {
                return -1;
            }

            var inputGrp = input.GroupBy(i => i);
            int maxOccurance = inputGrp.Max(i => i.Count());
            var filterGrp = inputGrp.Where(i => i.Count() >= maxOccurance - 1).Select(i=>i.Key);
            input = input.Where(i => filterGrp.Contains(i)).ToArray();
            int maxSum = 0;
            for (int i = 0; i < input.Count() - 1; i++)
            {                
                int sum = input[i] + input[i + 1];
                maxSum = sum > maxSum ? sum : maxSum;
            }
            return maxSum;
        }
        //your program is receiving an array of integer
        //each element of array is repeated maximum M times
        //and you want to find the biggest combination of two neighbor element of the array when the element
        //of array is repeated at least M-1 times.
        //Write the program in most efficient way that you can.Can you tell what is your solution O(n) size?
        //example 1:
        //input: [1,2,1,5,5,3,3,3,4]
        //        output: 10
        //explanation:
        //number 1 is repeated 2 times,
        //number 2 is repeated 1 time,
        //number 3 is repeated 3 times,
        //number 4 is repeated 1 time
        //number 5 repeated 2 times,
        //so, the M is equal to 3, so we need to filter all the input with at least the M-1 repeat that would be
        //[1, 1, 5, 5, 3, 3, 3].
        //the biggest combination of neighbor element that can be found is 10
        //example2:
        //input: [1,6,1,2,6,1,6,6]
        //        output: 6
        //explanation:
        //the M is equal to 4, so the element that repeated at least M-1 is [1,6,1,6,1,6,6]
        //        the biggest two neighbor
        //elements[6, 6] are 12
    }
}