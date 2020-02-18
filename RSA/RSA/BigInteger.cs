using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
        class BigInteger
        {


            public BigInteger()
            {

            }

            public string Subtract(string s1, string s2)
            {

                //Makeing sure that the bigger number is in s1
                if (s1 == s2)
                {
                    return "0";
                }
                bool swap = false;
                if (s2.Length > s1.Length)
                    swap = true;
                else if (s2.Length == s1.Length)
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] < s2[i])
                        {
                            swap = true;
                            break;
                        }
                        if (s1[i] > s2[i])
                            break;
                    }
                if (swap)
                {
                    string tp = s1;
                    s1 = s2;
                    s2 = tp;
                }


                s1 = ReverseString(s1);
                s2 = ReverseString(s2);
                int Borrow = 0, Current;
                string res = "";

                for (int i = 0; i < s2.Length; i++)
                {
                    Current = (s1[i] - '0') - (s2[i] - '0') - Borrow;
                    if (Current < 0)
                    {
                        res += (10 + Current).ToString();
                        Borrow = 1;
                    }
                    else
                    {
                        Borrow = 0;
                        res += (char)(Current + '0');
                    }
                }

                for (int i = s2.Length; i < s1.Length; i++)
                {

                    Current = (s1[i] - '0') - Borrow;
                    if (Current < 0)
                    {
                        res += (Current + 10).ToString();
                        Borrow = 1;
                    }
                    else
                    {
                        Borrow = 0;
                        res += (char)(Current + '0');
                    }
                }
                return RemoveLeftZeroes(ReverseString(res));

            }

            //multpication of two big integer
            public string multiplication(string FirstNum, string SecondNum)
            {
                int StrLength = Math.Max(FirstNum.Length, SecondNum.Length);

                //to make the strings equivalent in length
                while (FirstNum.Length < StrLength)
                {
                    FirstNum = FirstNum.Insert(0, "0");
                }

                while (SecondNum.Length < StrLength)
                {
                    SecondNum = SecondNum.Insert(0, "0");
                }

                //basecase 
                if (StrLength == 1)
                    return ((FirstNum[0] - '0') * (SecondNum[0] - '0')).ToString();

                //divide part : split first number into two halfes 
                string a = FirstNum.Substring(0, StrLength / 2);
                string b = FirstNum.Substring(StrLength / 2, StrLength - StrLength / 2);

                //split second number into two halfes
                string c = SecondNum.Substring(0, StrLength / 2);
                string d = SecondNum.Substring(StrLength / 2, StrLength - StrLength / 2);

                //conqure part : Recursivlly calculate the three multipications
                string ac = multiplication(a, c);
                string bd = multiplication(b, d);
                string z = multiplication(Addition(a, b), Addition(c, d));

                //calculating new z which equals ad+bd according to this equation ad+bd=z-(ac+bd)
                z = Subtract(z, Addition(ac, bd));

                //multipication of 10^N/2 *z and  10^N *ac  "N=StrLength"         
                ac = ReverseString(ac);
                z = ReverseString(z);

                for (int i = 0; i < 2 * (StrLength - StrLength / 2); i++)
                {
                    ac = ac.Insert(0, "0");
                }

                for (int i = 0; i < (StrLength - StrLength / 2); i++)
                {
                    z = z.Insert(0, "0");
                }

                ac = ReverseString(ac);
                z = ReverseString(z);

                string result = Addition(Addition(ac, bd), z);

                return result;
            }



            public string FindMod(string B, string P, string M)
            {
                string mod = null, res = null, result = null, temp, temp1;

                if (P == "0")
                    return "1";

                else
                {
                    Division(P, "2", ref res, ref mod);
                    if (mod == "0")
                    {
                        Division(P, "2", ref res, ref mod);
                        result = res;
                        temp = multiplication(B, B);
                        Division(temp, M, ref res, ref mod);
                        return FindMod(mod, result, M);
                    }

                    else
                    {
                        P = Subtract(P, "1");
                        Division(P, "2", ref res, ref mod);
                        result = res;
                        temp = multiplication(B, B);
                        Division(temp, M, ref res, ref mod);
                        temp1 = mod;
                        Division(multiplication(B, FindMod(temp1, result, M)), M, ref res, ref mod);
                        return mod;
                    }

                }
            }



            private bool CheckZeroes(string num)
            {
                int numlength = num.Length;
                for (int i = 0; i < numlength; i++)
                    if (num[i] != '0')
                        return false;
                return true;
            }

            public string Addition(string FirstNumber, string SecondNumber)
            {
                int NumberOfZeroes;
                int FirstNumberSize = FirstNumber.Length, SecondNumberSize = SecondNumber.Length;
                FirstNumber = ReverseString(FirstNumber);
                SecondNumber = ReverseString(SecondNumber);

                if (FirstNumberSize > SecondNumberSize)
                {
                    NumberOfZeroes = FirstNumberSize - SecondNumberSize;
                    //if there is any additional digit
                    for (int DigitsToFit = 0; DigitsToFit < NumberOfZeroes; DigitsToFit++)
                        SecondNumber += '0';
                }
                else if (FirstNumberSize < SecondNumberSize)
                {
                    NumberOfZeroes = SecondNumberSize - FirstNumberSize;
                    //if there is any additional digit
                    for (int DigitsToFit = 0; DigitsToFit < NumberOfZeroes; DigitsToFit++)
                        FirstNumber += '0';
                }
                if (CheckZeroes(FirstNumber) && CheckZeroes(SecondNumber))
                    return "0";


                //if there is any additional digit
                FirstNumber += '0';
                SecondNumber += '0';
                FirstNumber = ReverseString(FirstNumber);
                SecondNumber = ReverseString(SecondNumber);
                return AddingTwoStrings(FirstNumber, SecondNumber);
            }

            private string AddingTwoStrings(string FirstNumber, string SecondNumber)
            {
                string Result = "";
                byte Carry = 0;
                int Temp, FirstNumberSize = FirstNumber.Length;//Because of adding digit with zero, I don't care about size because it is the same
                for (int Digit = FirstNumberSize - 1; Digit >= 0; Digit--)
                {
                    Temp = Carry + (FirstNumber[Digit] - '0') + (SecondNumber[Digit] - '0');
                    if (Temp > 9)
                    {
                        Temp %= 10;
                        Result += Temp;
                        Carry = 1;
                    }
                    else
                    {
                        Result += Temp;
                        Carry = 0;
                    }
                }
                Result += Carry;
                Result = ReverseString(Result);
                Result = RemoveLeftZeroes(Result);
                return Result;
            }

            private string RemoveLeftZeroes(string Number)
            {
                string Result = "";
                int NumberLength = Number.Length;
                bool FirstNonZeroDigit = false;
                for (int Digit = 0; Digit < NumberLength; Digit++)
                {
                    if (Number[Digit] != '0')
                    {
                        FirstNonZeroDigit = true;
                    }
                    if (FirstNonZeroDigit == true)
                    {
                        Result += Number[Digit];
                    }
                }

                return Result;
            }

            private string ReverseString(string Text)
            {
                string Result = "";
                int TextSize = Text.Length;
                for (int Digit = TextSize - 1; Digit >= 0; Digit--)
                {
                    Result += Text[Digit];
                }
                return Result;
            }
        public string Div(string n, string m)
        {
            string res, q = "", r = "";
            Division(n, m, ref q, ref r);
            res = q;
            return res;
        }



        public string mod(string n, string m)
        {
            string res, q = "", r = "";
            Division(n, m, ref q, ref r);
            res = r;
            return res;
        }
        //Division function takes two strings as numbers and other two variables quotiont and remainder as input 
        //and doesn't return anything
        //O(N)
        public void Division(string FirstNumber, string SecondNumber, ref string Quotient, ref string Remainder)
            {
                if (RemoveLeftZeroes(SecondNumber) == "")
                {
                    Console.WriteLine("Result = Error You Cant Divide By Zero \nReminder =  :) ");
                    return;
                }
                else
                {
                    if (IsSmaller(FirstNumber, SecondNumber))
                    {
                        Quotient = "0";
                        Remainder = FirstNumber;
                        return;
                    }
                    Quotient = FirstNumber;
                    Remainder = SecondNumber;
                    Division(FirstNumber, multiplication("2", SecondNumber), ref Quotient, ref Remainder);
                    Quotient = multiplication("2", Quotient);
                    if (IsSmaller(Remainder, SecondNumber))
                        return;
                    else
                    {
                        Quotient = Addition(Quotient, "1");
                        Remainder = Subtract(Remainder, SecondNumber);
                        return;
                    }
                }
            }

            public bool IsBigger(string num1, string num2)
            {
                if (Comparison(num1, num2) == 1)
                    return true;
                return false;
            }

            public bool IsSmaller(string num1, string num2)
            {
                if (Comparison(num1, num2) == -1)
                    return true;
                return false;
            }


            public bool IsEqual(string num1, string num2)
            {
                if (Comparison(num1, num2) == 0)
                    return true;
                return false;
            }

            private int Comparison(string num1, string num2)
            {
                string res = Subtract(num1, num2);
                if (res[0] == '-')
                    return -1;
                else if (res[0] == '0')
                    return 0;
                else
                    return 1;
            }
        }
    }
