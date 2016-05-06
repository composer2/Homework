﻿using System;
using System.Linq;
using System.Collections;

namespace _07_Largest_Area_In_Matrix_2
{
    class LargestAreaInMatrix2
    {
        public static BitArray[] isChecked;

        static void Main()
        {
            // With Diagonals - > 100/ 100
            // Wihtout Diagonals

            // INPUT N Rows, M Columns
            // Sizes[0] Rows, Sizes[1] Cols
            short[] Sizes = Console.ReadLine()
                                   .Trim(' ')
                                   .Split(' ')
                                   .Select(short.Parse)
                                   .ToArray();

            // Read The Array
            int[][] toSearch = new int[Sizes[0]][];

            //Flags for each row
            //static BitArray[] 
            isChecked = new BitArray[toSearch.Length];

            for (int row = 0; row < toSearch.Length; row++)
            {
                // Read Input row
                toSearch[row] = Console.ReadLine()
                                       .Trim(' ')
                                       .Split(' ')
                                       .Select(int.Parse)
                                       .ToArray();

                // Create Flags for each element 
                // of the current input row
                isChecked[row] = new BitArray(toSearch[row].Length);
            }

            // Output
            var MaxSequence = int.MinValue;

            // Check for each element 
            // not checked before
            for (int Row = 0;
                     Row < toSearch.Length;
                     Row++)
            {
                for (int Col = 0;
                         Col < toSearch[Row].Length;
                         Col++)
                {
                    int curSequence = 1;

                    if (isChecked[Row][Col] == false)
                    {
                        isChecked[Row][Col] = true;

                        // find sequence for current element
                        curSequence = CheckElement
                                      (
                                        Row,
                                        Col,
                                        curSequence,
                                        toSearch
                                      );
                    }

                    // Is the current sequence larger ? 
                    MaxSequence = curSequence > MaxSequence ?
                                  curSequence : MaxSequence;
                }
            }

            // Print Output
            Console.WriteLine(MaxSequence);
        }

        // Get Sequence - Up, Down, Left, Right
        public static int CheckElement
            (
                      int Row,
                      int Col,
                      int curSequence,
                      int[][] toSearch
            //BitArray[] isChecked
            )
        {
            // Check Down
            if (Row + 1 < toSearch.Length)
            {
                if (toSearch[Row + 1][Col] ==
                    toSearch[Row][Col] &&
                    isChecked[Row + 1][Col] == false)
                {
                    curSequence++;

                    isChecked[Row + 1][Col] = true;

                    curSequence = CheckElement
                                  (
                                      Row + 1,
                                      Col,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // Check Right
            if (Col + 1 < toSearch[Row].Length)
            {
                if (toSearch[Row][Col + 1] ==
                    toSearch[Row][Col] &&
                    isChecked[Row][Col + 1] == false)
                {
                    curSequence++;

                    isChecked[Row][Col + 1] = true;

                    curSequence = CheckElement
                                  (
                                      Row,
                                      Col + 1,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // Check Up
            if (Row - 1 >= 0)
            {
                if (toSearch[Row - 1][Col] ==
                    toSearch[Row][Col] &&
                    isChecked[Row - 1][Col] == false)
                {
                    curSequence++;

                    isChecked[Row - 1][Col] = true;

                    curSequence = CheckElement
                                  (
                                      Row - 1,
                                      Col,
                                      curSequence,
                                      toSearch
                                  );
                }                 
            }

            // Check Left
            if (Col - 1 >= 0)
            {
                if (toSearch[Row][Col - 1] ==
                    toSearch[Row][Col] &&
                    isChecked[Row][Col - 1] == false)
                {
                    curSequence++;

                    isChecked[Row][Col - 1] = true;

                    curSequence = CheckElement
                                  (
                                      Row,
                                      Col - 1,
                                      curSequence,
                                      toSearch
                                  );
                }
            }

            // TODO:
            return curSequence;
        }
    }
}
