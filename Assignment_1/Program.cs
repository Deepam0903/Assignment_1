using System;
using System.Linq;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
               int n = 5;
               Console.WriteLine("Pattern");
               PrintPattern(n);
               Console.WriteLine();

               int n2 = 6;
               Console.WriteLine("Series");
               PrintSeries(n2);
               Console.WriteLine();

               string s = "11:20:35PM";
               string t = UsfTime(s);
               Console.Write("\nUSF Time");
               Console.Write("\n"+t);
               

               int n3 = 110;
               int k = 11;
               Console.WriteLine();
               Console.Write("\nUSF Numbers:");
               Console.WriteLine();
               UsfNumbers(n3, k);

               string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
               Console.WriteLine();
               Console.WriteLine("The indices of Plaindrome in the given string are :");
               PalindromePairs(words);

               int n4 = 15;
               Console.WriteLine();
               Console.Write("Moves by both the players: when number of stones are"+ " "+n4+":"+" ");
               Stones(n4);
        }


        //PATTERN
        private static void PrintPattern(int n)
          {
              try
              {
                  if (n > 0) //Check if the number is greater than 0
                  {
                      for (int i = n; i >= 1; i--) // The for loop over here runs till integer i >= 1 and it starts with i= number (which is 5 in this case)
                      {
                          Console.Write(i + " "); //the value of i gets printed here
                      }
                      Console.WriteLine(" "); //As soon as the value of i becomes less than 1, it exits the for loop and starts with the next line
                      PrintPattern(n - 1); //Over here the method is calling itself with a vaue which is 1 less than the number n.
                  }
                  
              }
              catch
              {
                  Console.WriteLine("Exception Occured while computing printPattern");
              }
          }

        //SERIES
        private static void PrintSeries(int n2)
        {
            try
            {
                int i, temp = 1, x = 1;
                for (i = 1; i <= n2; i++) // This loop will run from 1 to the number n2.
                {
                    Console.Write(temp + " "); // will write the value of temp
                    x = x + 1; // this will add 1 to the value of x.
                    temp = temp + x; // the temp variable is initialized with 1, and then have added x to temp.
                }

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }


        }

        //USF Time
        public static string UsfTime(string s)
        {
            try
            {

                int usf_U,earth_H,diff,U,S,F;
                int divisor = 2700;
                string[] arr = s.Split(':'); //This is to split the input time by the delimiter : and storing the values in the array
                string new_String = new String(arr[2].Where(Char.IsDigit).ToArray()); //This step is to separate PM and the integer, which is present in the second element of the array.
                string x;

                if (s.Contains("PM")) //Now, if the string contains PM then the below calculation will be performed.
                {
                    usf_U = (Convert.ToInt32(arr[0]) + 12) * 60 * 45 + (Convert.ToInt32(arr[1])) * 45 + (Convert.ToInt32(new_String));//this step will convert the earth timein USF seconds
                    earth_H = (Convert.ToInt32(arr[0]) + 12) * 60 * 60 + (Convert.ToInt32(arr[1])) * 60 + Convert.ToInt32(new_String);//this step will convert the earth time in earth seconds
                    diff = earth_H - usf_U;//it will calculate the difference between both the time, asthe uSF time is that many seconds behind the earth time
                    U = (Convert.ToInt32(arr[0]) + 12) + (diff / divisor);//it will first add 12 to the hours in PM time and then add this to the hours that we get with diff/divisor(2700)
                    S = (Convert.ToInt32(arr[1])) + ((diff % divisor) / 45);//it will add remainder/45 to the number of minutes in earth time.
                    F = (Convert.ToInt32(new_String)) + ((diff % divisor) % 45);//it will add earthe seconds to the USF seconds.
                    if(S>=60)
                    {
                        U = U + (S/60);
                        S = S % 60;
                        x = U + ":" + S + ":" + F;
                    }
                    else
                    {
                        x = U + ":" + S + ":" + F;//it will contatenate the USF U,S and F.
                    }
                     

                }
                else //When the time is in AM the below calculation will be performed
                {
                    usf_U = (Convert.ToInt32(arr[0])) * 60 * 45 + (Convert.ToInt32(arr[1])) * 45 + Convert.ToInt32(new_String);
                    earth_H = (Convert.ToInt32(arr[0])) * 60 * 60 + (Convert.ToInt32(arr[1])) * 60 + Convert.ToInt32(new_String);
                    diff = earth_H - usf_U;
                    U = (Convert.ToInt32(arr[0])) + (diff / divisor);
                    S = (Convert.ToInt32(arr[1])) + ((diff % divisor) / 45);
                    F = (Convert.ToInt32(new_String)) + ((diff % divisor) % 45);
                     x = U + ":" + S + ":" + F;

                }
                return x;
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }

        //USF NUmbers
        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                object[] new_array = new object[120];
                for (int j = 1; j <= n3; j++) // the for loop will run till the number n3
                {
                    new_array[j] = j; // this step will populate the value of j in the object array 

                    if (j % 3 == 0 && j % 5 == 0) //if the number j is divisible by 3 and 5 it will replace the number in the array with US
                    {
                        new_array[j] = "US";
                    }

                    else if (j % 3 == 0) //if the number j is divisible by 3 it will replace the number in the array with U
                    {
                        new_array[j] = "U";
                    }
                    else if (j % 5 == 0 && j % 7 == 0)
                    {
                        new_array[j] = "SF"; //if the number j is divisible by 5 and 7 it will replace the number in the array with SF
                    }
                    else if (j % 5 == 0)
                    {
                        new_array[j] = "S"; //if the number j is divisible by 5 it will replace the number in the array with S
                    }
                    else if (j % 7 == 0)
                    {
                        new_array[j] = "F"; //if the number j is divisible by 7 it will replace the number in the array with F

                    }

                }

                for (int f = 1; f <= n3; f++) // the for loop will run till the number n3
                {
                    if (f % k != 0) // the if condition will check if the number of lines are equal to the number specified in k, if yes it will start printing the array from next line
                    {
                        Console.Write(new_array[f] + " "); 
                    }
                    else
                    {
                        Console.Write(" " + new_array[f] + "\n");
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }

        //Palindrome
        public static void PalindromePairs(string[] words)
        {
            try
            {
                string str;

                for (int i = 0; i < words.Length; i++)//the two for loops will be used toconcatanate every element with each
                {
                    for (int y = 0; y < words.Length; y++)
                    {
                        if (i != y) // the if condition will ensure that the element doesn't contanenate with itself
                        {
                            str = words[i] + words[y];//concatenation of elements
                            string rev = ""; // initializing empty string to store the reversed string
                            for (int j = str.Length - 1; j >= 0; j--) // this for loop will run from last element of the string, so j equals to the index of last character in the string
                            {
                                rev += str[j];// will store the reversed string
                            }
                            if (rev == str)//this will check if the reversed string equals to the string and if yes it will return the indices of the same.
                            {
                                Console.WriteLine(i + "," + y);
                            }
                        }
                    }
                }
            }

            catch
            {

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }
        //Stones
        public static void Stones(int n4)
        {
            try
            {
              
                Random r = new Random();// this instance r will be used in the program further to randomly generate moves taken by Player2
                int[] moves = new int[40]; // array to store moves by both the players
                int p2m = n4 / 4; //number of moves by Player 2 to wine the game
                int p2s = p2m * 4;//number of stones when player 2 will win the game
                int p1m = (p2s / 2) + 1; //total number of moves required for Player 1 to win the game


                if (n4 % 4 != 0) //when the number of stones are not divisible by 4 then the below loop will calculate the moves
                {

                    moves[0] = n4 % 4;// the first move by player 1 will always be number of stones modulus 4

                    for (int i = 1; i <= p1m; i += 2)// the for loop will run from 1 to the number of moves required for player 1 to win. It will increment the value of i by 2 steps in every iteration. Since we are calculating two moves in one iteration.
                    {
                        moves[i] = r.Next(1, 3); //this step will randomly generate the moves of Player2 from the number 1,2 and 3..
                        moves[i + 1] = 4 - moves[i];//Everytime the Player1 will move 4 - (player2's move)

                    }

                    for (int j = 0; j <= p1m - 1; j++)//this loop will print the elements of the array. 
                    {
                        if (j != p1m - 1)
                        {
                            Console.Write(moves[j] + ",");
                        }
                        else
                        {
                            Console.Write(moves[j]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(false);
                }


            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }


    }
}






