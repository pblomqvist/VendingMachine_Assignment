using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;

namespace VendingMachine_Assignment.Models.Features
{
    public class Change
    {
        public int[] denominations = { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
        public string GiveChange(int balance, string msg)
        {
            string result = string.Empty;
            int thousand = 0;
            int fivehundred = 0;
            int hundred = 0;
            int fifty = 0;
            int twenty = 0;
            int ten = 0;
            int five = 0;
            int two = 0;
            int one = 0;

            if (balance > 0)
            {
                while (balance > 0)
                {
                    if (balance >= 1000)
                    {
                        thousand++;
                        balance -= 1000;
                        
                    } else if (balance >= 500)
                    {
                        fivehundred++;
                        balance -= 500;
                    }
                    else if (balance >= 100)
                    {
                        hundred++;
                        balance -= 100;
                    }
                    else if (balance >= 50)
                    {
                        fifty++;
                        balance -= 50;
                    }
                    else if (balance >= 20)
                    {
                        twenty++;
                        balance -= 20;
                    }
                    else if (balance >= 10)
                    {
                        ten++;
                        balance -= 10;
                    }
                    else if (balance >= 5)
                    {
                        five++;
                        balance -= 5;
                    }
                    else if (balance >= 2)
                    {
                        two++;
                        balance -= 2;
                    }
                    else if (balance >= 1)
                    {
                        one++;
                        balance -= 1;
                    }

                }

                result = GetMessage(thousand, fivehundred, hundred, fifty, twenty, ten, five, two, one);

            } else
            {
                result = "No money to return";
            }

            return result;
        }

        private string GetMessage(int thousand, int fivehundred,
                                int hundred, int fifty, int twenty,
                                int ten,int five, int two, int one)
        {

            string result = $"\n---\n\nYour change is:\n";

            // Message assembly
            if (thousand > 0)
            {
                result += $"{thousand} x 1000 kr\n";
            }

            if (fivehundred > 0)
            {
                result += $"{fivehundred} x 500 kr\n";
            }

            if (hundred > 0)
            {
                result += $"{hundred} x 100 kr\n";
            }

            if (fifty > 0)
            {
                result += $"{fifty} x 50 kr\n";
            }

            if (twenty > 0)
            {
                result += $"{twenty} x 20 kr\n";
            }

            if (ten > 0)
            {
                result += $"{ten} x 10 kr\n";
            }

            if (five > 0)
            {
                result += $"{five} x 5 kr\n";
            }

            if (two > 0)
            {
                result += $"{two} x 2 kr\n";
            }

            if (one > 0)
            {
                result += $"{one} x 1 kr\n";
            }



            return result;
        }

    }
}
