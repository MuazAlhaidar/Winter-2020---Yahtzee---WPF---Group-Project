using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee {

    public class SectionCombinations {

        //This is the lower comibnations

        /// <summary>
        /// Whoa check it out /// 3 times makes this!
        /// Anyways using the upperseciton thing from wikiepida, this is the result
        /// This is the sum of the dicew with teh same value
        /// </summary>
        /// <param name="Arr">This is supposed to repersent the dice</param>
        /// <param name="Val">This is to repersent the dice you want to use. So if Arr is {1,2,1,2,3,4} and Val is 2, you want the sum of all 2</param>
        /// <returns>A score of the times Val appears Arr, multiple by Val</returns>
        public static int UpperSection(int[] Arr, int Val) {

            int count = 0;

            if (Arr.Length > 5 || Arr.Length < 0)
                Console.WriteLine("Zaki/Muaz bro how the hell did you do it, there shouldn't be more/less than 5 dice here!");

            if (Val > 6 || Val < 1)
                Console.WriteLine("Zaki/Muaz bro how the hell did you do it, the value for input is invalid");

            for (int i = 0; i < Arr.Length; i++) {

                if (Arr[i] == Val)
                    count++;
            }

            int Score = count * Val;

            return Score;
        }

        /// <summary>
        /// This is the lower section, which is poker themed one.
        /// This is alot tricker to code, due to the dependence of the souranding dice
        /// Not only thta, but they use all dice in the field. 
        /// I think so far, to sort it, so for Small/Large Straight, which requires sequencial order, which will be easier to code
        /// The other ones, like Three/Four of a kind and full house, is a case by case basis.
        /// ALSO IDK HOW TO GET ENUM WORKING so use this shitty int one.
        /// </summary>
        /// <param name="Arr">The dice array</param>
        /// <param name="Comb">This repersents which lower combination to use.</param>
        /// <returns>If a combination exist for the seciton, like three of a kind, return a natural (or interger greater than 0), else return 0
        /// the 0 is used to indciate this combaitnion is not selectable.</returns>
        public static int LowerSection(int[] Arr, int Comb) {

            Array.Sort(Arr);

            int count = 0;
            int temp = 0;

            switch (Comb) {

                //Three of a kind: Three  dice are the same
                //You add the sum of all diec.
                case 1:

                    if (Arr.Length >= 3) {

                        if ((Arr[0] == Arr[1]) && (Arr[0] == Arr[2])) {

                            return Arr.Sum();
                        }
                        else if ((Arr.Length >= 4) && ((Arr[1] == Arr[2]) && (Arr[1] == Arr[3]))) {

                            return Arr.Sum();
                        }
                        else if ((Arr.Length == 5) && ((Arr[2] == Arr[3]) && (Arr[2] == Arr[4]))) {

                            return Arr.Sum();
                        }
                    }
                    break;

                case 2:

                    if (Arr.Length >= 4) {

                        // Check if 4 of a kind is there
                        // If return the sum of the array.
                        if ((Arr[0] == Arr[1]) && (Arr[0] == Arr[2]) && (Arr[0] == Arr[3])) {

                            return Arr.Sum();
                        }
                        else if ((Arr.Length == 5) && ((Arr[1] == Arr[2]) && (Arr[1] == Arr[3]) && (Arr[1] == Arr[4]))) {

                            return Arr.Sum();
                        }
                    }
                    break;

                case 3:

                    // This one is tricky. It's full house, which means you have to count 3 of one number, and 2 of another
                    // So for
                    if (Arr.Length == 5) {

                        if ((Arr[0] == Arr[1]) && (Arr[0] == Arr[2]) && (Arr[3] == Arr[4])) {

                            return 25;
                        }
                        else if ((Arr[0] == Arr[1]) && (Arr[2] == Arr[3]) && (Arr[2] == Arr[4])) {

                            return 25;
                        }
                    }
                    break;

                case 4:

                    temp = Arr[0];
                    count = 0;

                    // Small Straight
                    // THis is the tricky part: You have to count the sequence.
                    // Fuck you past me for not explaining what this is. This is small straigth
                    // This means that it needs to have 4 sequencial dice
                    for (int i = 0; i < Arr.Length; i++) {

                        if (count == 3) {
                            return 30;
                        }
                        if (temp == Arr[i]) {

                            temp++;
                            count++;
                        }
                        else {

                            temp = Arr[i] + 1;
                            count = 1;
                        }
                    }
                    break;

                case 5:

                    temp = Arr[0];
                    count = 0;

                    // Large Straight
                    // THis is the tricky part: You have to count the sequence.
                    // Fuck you past me for not explaining what this is. This is LARGE straigth
                    // This means that it needs to have 5 sequencial dice
                    for (int i = 0; i < Arr.Length; i++) {

                        if (count == 4) {
                            return 40;
                        }
                        if (temp == Arr[i]) {

                            temp++;
                            count++;
                        }
                        else {

                            temp = Arr[i] + 1;
                            count = 1;
                        }
                    }
                    break;

                //This is chance, which is the sum of all dice
                case 6:

                    return Arr.Sum();
                    break;

                case 7:

                    // This is yathzee, which means all 5 die are the same.
                    if (Arr.Distinct().Count() == 1 && Arr.Length == 5)
                        return 50;
                    break;
            }

            return 0;
        }
    }
} 