using System.Collections.Generic;

namespace CarRental.ConsoleTestApp
{
    public class YieldReturnTest
    {
        //See this SO post:http://stackoverflow.com/questions/2413851/c-yield-return-within-a-foreach-fails-body-cannot-be-an-iterator-block
        private List<int> _list = new List<int>();

        public IEnumerable<int> CheckListWithYieldReturn(int number)
        {
            for (int i = 0; i < 2000000; i++)
            {
                _list.Add(i);
            }

            foreach (var item in _list)
            {
                if (item == number)
                {
                    yield return item;
                }
            }
        }

        public int CheckListWithNoYieldReturn(int number)
        {
            for (int i = 0; i < 200000000; i++)
            {
                _list.Add(i);
            }

            foreach (var item in _list)
            {
                if (item == number)
                {
                     return item;
                }
            }

            return -1;
        }
    }
}