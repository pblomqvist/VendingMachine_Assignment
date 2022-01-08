using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;

namespace VendingMachine_Assignment.Models.Features
{
    public class Change
    {
        
        public string GiveChange(int moneypool, string msg)
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

            if (moneypool > 0)
            {
                while (moneypool > 0)
                {
                    if (moneypool >= 1000)
                    {
                        thousand++;
                        moneypool -= 1000;
                        
                    } else if (moneypool >= 500)
                    {
                        fivehundred++;
                        moneypool -= 500;
                    }
                    else if (moneypool >= 100)
                    {
                        hundred++;
                        moneypool -= 100;
                    }
                    else if (moneypool >= 50)
                    {
                        fifty++;
                        moneypool -= 50;
                    }
                    else if (moneypool >= 20)
                    {
                        twenty++;
                        moneypool -= 20;
                    }
                    else if (moneypool >= 10)
                    {
                        ten++;
                        moneypool -= 10;
                    }
                    else if (moneypool >= 5)
                    {
                        five++;
                        moneypool -= 5;
                    }
                    else if (moneypool >= 2)
                    {
                        two++;
                        moneypool -= 2;
                    }
                    else if (moneypool >= 1)
                    {
                        one++;
                        moneypool -= 1;
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

            string result = $"Your change is:\n";

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
