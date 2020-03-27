using System;
using System.Collections.Generic;

namespace sorts
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            int[] tosort = { 6, 5, 2, 4, 8, 9, 3, 7, 10};


            sorterClass sorter = new sorterClass();
            sorter.allsorts(tosort);
        }
        class sorterClass
        {
            //public sorterClass()
            //{

            //}

            public void allsorts(int[] tosort)
            {
                int[] bubble = bubblesort(tosort);
                foreach (int i in bubble) { Console.Write("{0} ", Convert.ToString(i)); }
                Console.WriteLine("");
                int[] merged = mergesort(tosort);
                foreach (int i in merged) { Console.Write("{0} boop", Convert.ToString(i)); }
            }

            private int[] bubblesort(int[] tosort)
            {
                int len = tosort.Length;
                for (int j = 0; j < len-2; j++)
                {
                    for (int i = len - 2; i >= 0; i--)
                    {
                        if (tosort[len - i - 2] > tosort[len - i - 1])
                        {
                            int temp = tosort[len - i - 2];
                            tosort[len - i - 2] = tosort[len - i - 1];
                            tosort[len - i - 1] = temp;
                        }
                    }
                }
                    
                return tosort;
            }

            private int[] mergesort(int[] tosort)
            {
				if (tosort.Length > 2)
				{
					mergesort(left(tosort));
					mergesort(right(tosort));
				}
				return merge(left(tosort), right(tosort));
            }

            private int[] left(int[] tosplit)
            {
                int len = tosplit.Length;
                if (len == 1)
                {
                    return tosplit;
                }
                int[] lefT = new int[len / 2];

                Array.Copy(tosplit, 0, lefT, 0, len / 2);
                return lefT;
            }
            private int[] right(int[] tosplit)
            {
                int len = tosplit.Length;
                if (len == 1)
                {
                    return tosplit;
                }

                int[] righT = new int[len / 2];
                if (len % 2 == 1)
                {
                    righT = new int[len / 2 + 1];
                    Array.Copy(tosplit, len / 2, righT, 0, len / 2 + 1);
                }
                else
                {
                    Array.Copy(tosplit, len / 2, righT, 0, len / 2);
                }
                Array.Copy(tosplit, len/2, righT, 0, len / 2);
                return righT;
            }
			private int[] merge(int[] l, int[] r)
			{
				List<int> merged = new List<int>(l[0]);

				for (int i = 1; i < l.Length; i++)
                {
					for (int j = 0; j < merged.Count; j++)
                    {
						if (l[i] < merged[j])
						{
							merged.Insert(j + 1, l[i]);
						}
                    }
                }
				for (int i = 0; i < r.Length; i++)
				{
					for (int j = 0; j < merged.Count; j++)
					{
						if (r[i] < merged[j])
						{
							merged.Insert(j + 1, r[i]);
						}
					}
				}
                return merged.ToArray();
			}
		}
    }
}