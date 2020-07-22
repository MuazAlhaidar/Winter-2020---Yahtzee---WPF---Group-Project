using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Yahtzee {

    public class YahtzeeGame {

        //This is the number of dice being held.
        private static int CountHeldDice = 0;

        private static int RollCounter = 3;
        private static int Comb = 13;

        //Current score of yahtzee
        private static int YahtzeeScore = 0;

        public readonly SolidColorBrush Black = new SolidColorBrush(Colors.Black);
        public readonly SolidColorBrush Red = new SolidColorBrush(Colors.Red);

        public List<System.Windows.Controls.Button> HeldDiceList = new List<System.Windows.Controls.Button>();
        public List<System.Windows.Controls.Button> FieldDiceList = new List<System.Windows.Controls.Button>();
        public List<System.Windows.Controls.TextBox> UpperCombList = new List<System.Windows.Controls.TextBox>();
        public List<System.Windows.Controls.TextBox> LowerCombList = new List<System.Windows.Controls.TextBox>();
        public List<System.Windows.Controls.TextBox> BonusAndSumAndTotalScoreList = new List<System.Windows.Controls.TextBox>();
        public List<System.Windows.Controls.Label> RollCounterLabel = new List<System.Windows.Controls.Label>();
        private List<int> Arr = new List<int>();

        public void UpdateRollCounterTextBox() {

            RollCounterLabel[0].Content = $"Roll Count: {RollCounter}";
        }

        public void HeldDiceCheck() {

            if (Comb < 0) {

                MessageBox.Show("You won HURRAY");

                for (int i = 0; i < 5; i++) {

                    HeldDiceList[i].Visibility = System.Windows.Visibility.Hidden;
                    FieldDiceList[i].Visibility = System.Windows.Visibility.Hidden;
                }
            }
            else {

                // This is the tricky/shit part. Right now I'll check each value, but if you find a better way be my guess to changae it.
                // The alg to use is for each value in heldDice, if it's not -1, incrase number of CountHeldDice
                CountHeldDice = 0;
                Arr.Clear();

                BubbleSortHeldDice();

                for (int i = 0; i < HeldDiceList.Count(); i++) {

                    if (HeldDiceList[i].Content.ToString() == "-1") {

                        HeldDiceList[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    else {

                        HeldDiceList[i].Visibility = System.Windows.Visibility.Visible;

                        Arr.Add(Int32.Parse(HeldDiceList[CountHeldDice].Content.ToString()));
                        CountHeldDice++;
                    }

                    if (FieldDiceList[i].Content.ToString() == "-1") {

                        FieldDiceList[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                        FieldDiceList[i].Visibility = System.Windows.Visibility.Visible;
                }

                DisplayScoresToTextBoxes(Arr);
            }
        }

        public void RollDice() {

            if (RollCounter > 0) {

                var rand = new Random();

                int[] Rolls = { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };

                for (int i = 0; i < 5; i++) {
                    FieldDiceList[i].Content = "-1";
                }
                for (int i = 0; i < 5 - CountHeldDice; i++) {
                    FieldDiceList[i].Content = Rolls[i];
                }

                RollCounter--;
                UpdateRollCounterTextBox();
            }

            HeldDiceCheck();
        }

        private void BubbleSortHeldDice() {

            int heldDiceListLength = 5;

            for (int x = 0; x < heldDiceListLength - 1; x++) {
                for (int y = 0; y < heldDiceListLength - x - 1; y++) {

                    if (Int32.Parse(HeldDiceList[y].Content.ToString()) <= Int32.Parse(HeldDiceList[y + 1].Content.ToString())) {

                        int integerHolderForSwap = Int32.Parse(HeldDiceList[y].Content.ToString());
                        HeldDiceList[y].Content = HeldDiceList[y + 1].Content;
                        HeldDiceList[y + 1].Content = integerHolderForSwap.ToString();
                    }
                }
            }
        }

        private void DisplayScoresToTextBoxes(List<int> Arr) {

            int[] TempArr = Arr.ToArray();
            int BonusCheck = 0;

            if (TempArr.Length != 0) {

                for (int i = 0; i < 7; i++) {

                    if (LowerCombList[i].Foreground != Black || i == 6) {

                        if (i == 6) {

                            int temp = (SectionCombinations.LowerSection(TempArr, i + 1));
                            LowerCombList[i].Text = (temp + YahtzeeScore).ToString();
                        }
                        else {

                            LowerCombList[i].Text = (SectionCombinations.LowerSection(TempArr, i + 1)).ToString();
                        }
                    }
                    if (i < 6) {

                        if (UpperCombList[i].Foreground != Black) {

                            UpperCombList[i].Text = (SectionCombinations.UpperSection(TempArr, i + 1)).ToString();
                        }
                        else {

                            BonusCheck += Int32.Parse(UpperCombList[i].Text);
                        }
                    }
                }
            }
            else {

                for (int i = 0; i < 7; i++) {

                    if (LowerCombList[i].Foreground != Black) {

                        LowerCombList[i].Text = ("0");
                    }
                    if (i < 6) {

                        if (UpperCombList[i].Foreground != Black) {

                            UpperCombList[i].Text = ("0");
                        }
                        else {
                            BonusCheck += Int32.Parse(UpperCombList[i].Text);
                        }
                    }
                }
            }

            BonusAndSumAndTotalScoreList[1].Text = BonusCheck.ToString();

            if (BonusCheck > 63 && BonusAndSumAndTotalScoreList[0].Foreground != Red) {

                BonusAndSumAndTotalScoreList[0].Text = 35.ToString();
                BonusAndSumAndTotalScoreList[0].Foreground = Black;
            }
        }

        public void ResetRollCounter() {

            CountHeldDice = 0;

            var rand = new Random();

            int[] Rolls = { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };

            for (int i = 0; i < 5; i++) {
                FieldDiceList[i].Content = Rolls[i];
                FieldDiceList[i].Visibility = System.Windows.Visibility.Visible;
                HeldDiceList[i].Content = "-1";
                HeldDiceList[i].Visibility = System.Windows.Visibility.Hidden;
            }

            RollCounter = 3;
            Comb--;
            int Sum = 0;
            for (int i = 0; i < 7; i++) {

                if (LowerCombList[i].Foreground == Black) {

                    Sum += Int32.Parse(LowerCombList[i].Text);
                }
                if (i < 6) {
                    if (UpperCombList[i].Foreground == Black) {
                        Sum += Int32.Parse(UpperCombList[i].Text);

                    }
                }
            }


            if (BonusAndSumAndTotalScoreList[0].Text.Length != 0)
                Sum += Int32.Parse(BonusAndSumAndTotalScoreList[0].Text.ToString());
            
            BonusAndSumAndTotalScoreList[2].Text = Sum.ToString();

            Arr.Clear();

            DisplayScoresToTextBoxes(Arr);

            UpdateRollCounterTextBox();
        }

        public void SwapValueToFieldDice(int diceNumber) {

            for (int i = 0; i < 5; i++) {
                if (FieldDiceList[i].Content.ToString() == "-1") {
                    FieldDiceList[i].Content = HeldDiceList[diceNumber].Content;
                    HeldDiceList[diceNumber].Content = -1;
                }
            }

            HeldDiceCheck();
        }

        public void SwapValueToHandDice(int diceNumber) {

            for (int i = 0; i < 5; i++) {
                if (HeldDiceList[i].Content.ToString() == "-1") {
                    HeldDiceList[i].Content = FieldDiceList[diceNumber].Content;
                    FieldDiceList[diceNumber].Content = -1;
                }
                else {

                }
            }

            HeldDiceCheck();
        }

        /// <summary>
        /// this will change the appropriate texbox's color to black when that textbox's
        /// appropriate button is clicked
        /// </summary>
        /// <param name="textboxNumber"> which of the texboxes in the upper or lower list is to be changed</param>
        /// <param name="upperOrLowerList"> the choice of whether the texbox is in the upper list or the lower list
        ///  upperlist = 1 and lowerlist = 2 </param>
        public void ChangeTextBoxColorToBlack(int textboxNumber, bool upperOrLowerList) {

            if (upperOrLowerList) {

                UpperCombList[textboxNumber - 1].Foreground = Black;
            }
            else {

                LowerCombList[textboxNumber - 1].Foreground = Black;
            }
        }

        public void YahtzeeScoreCalculator() {

            int temp = (SectionCombinations.LowerSection(Arr.ToArray(), 6 + 1));

            if (temp != 0)
                YahtzeeScore += temp;

            ChangeTextBoxColorToBlack(7, false);
        }
    }
}
