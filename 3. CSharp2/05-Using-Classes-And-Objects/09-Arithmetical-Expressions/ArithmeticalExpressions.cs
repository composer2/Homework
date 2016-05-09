﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Arithmetical_Expressions
{
    class ArithmeticalExpressions
    {
        // static Vars
        static List<string> OutputString = new List<string>();
        static List<string> OperatorStack = new List<string>();

        static string[] OperatorKey = "+ - * / %".Split(' ');

        static void Main()
        {
            // variables
            string toAdd = "";

            // input as string
            string InputExpression = Console.ReadLine()
                                            .ToLower();

            // iterate through the string
            for (int curElement = 0;
                curElement < InputExpression.Length;
                curElement++)
            {
                // reset
                toAdd = "";


                // if the current element is a digit
                // read the number
                if (InputExpression[curElement] >= '0' &&   
                    InputExpression[curElement] <= '9')     
                {
                    toAdd = ReadNumber(           // Read The Number
                              InputExpression,    //
                              curElement          //
                              );

                    OutputString.Add(toAdd);      // Add Numnber to output
                                                  //
                    curElement += toAdd.Length - 1;   // skip the length of the number

                    continue;
                }

                // if current element is an operator 
                if (OperatorKey.Contains(          
                        InputExpression[curElement].ToString()))
                {
                    ReadOperator(InputExpression[curElement].ToString());

                    continue;
                }

                // if Opening Parenthesis
                if (InputExpression[curElement] == '(')
                {
                    OperatorStack.Add(InputExpression[curElement].ToString());

                    continue;
                }

                // if closing Parenthesis
                if (InputExpression[curElement] == ')')
                {

                    continue;
                }


            }
        }

        // Read A Number
        public static string ReadNumber
            (
                string InputExpression,
                int StartPosition
            )
        {
            string toReturn = "";

            for (int curElement = StartPosition;
                curElement < InputExpression.Length;
                curElement++)
            {
                if ((InputExpression[curElement] >= '0' &&      // if current element is
                     InputExpression[curElement] <= '9') ||     // a digit or a float DOT
                     InputExpression[curElement] == '.')        // add to the string
                {
                    toReturn += InputExpression[curElement];
                }                                               // else break
                else                                            // and return
                {
                    break;
                }
            }

            // Output
            return toReturn;
        }

        // Read An Operator
        public static void ReadOperator(string curOperator)
        {
            // if the stack is empty
            // add the new Operator and return
            if (OperatorStack.Count() == 0)
            {
                OperatorStack.Add(curOperator);
                return;
            }

            // iterate through OperatorStack
            // starting at the top ( end ) 
            for (int curElement = OperatorStack.Count() - 1;
                     curElement >= 0;
                     curElement--)
            {
                // Check Precedence 
                // by checking index in the Operator Key
                // index 0 1 -> + - , index 2-4 -> * / %
                if (Array.IndexOf(OperatorKey, curOperator) >= 2 &&
                    Array.IndexOf(OperatorKey, OperatorStack[curElement]) < 2)

                {
                    OperatorStack.Add(curOperator);
                    return;
                }
                else
                {
                    OutputString.Add(OperatorStack[curElement]);
                    OperatorStack.RemoveAt(curElement);

                    if (OperatorStack.Count() == 0)     // case all previous
                    {                                   // operators are 
                        OperatorStack.Add(curOperator); // removed
                        return;                         //
                    }
                }
            }
        }
    }
}