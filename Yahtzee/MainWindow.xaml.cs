using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yahtzee {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        YahtzeeGame game;

        public MainWindow() {

            InitializeComponent();

            game = new YahtzeeGame();

            game.HeldDiceList.Add(BtnHeldDice1);
            game.HeldDiceList.Add(BtnHeldDice2);
            game.HeldDiceList.Add(BtnHeldDice3);
            game.HeldDiceList.Add(BtnHeldDice4);
            game.HeldDiceList.Add(BtnHeldDice5);

            game.FieldDiceList.Add(BtnFieldDice1);
            game.FieldDiceList.Add(BtnFieldDice2);
            game.FieldDiceList.Add(BtnFieldDice3);
            game.FieldDiceList.Add(BtnFieldDice4);
            game.FieldDiceList.Add(BtnFieldDice5);

            game.UpperCombList.Add(TxtbxOnes);
            game.UpperCombList.Add(TxtbxTwos);
            game.UpperCombList.Add(TxtbxThrees);
            game.UpperCombList.Add(TxtbxFours);
            game.UpperCombList.Add(TxtbxFives);
            game.UpperCombList.Add(TxtbxSixes);

            game.LowerCombList.Add(TxtbxThreeOfAKind);
            game.LowerCombList.Add(TxtbxFourOfAKind);
            game.LowerCombList.Add(TxtbxFullHouse);
            game.LowerCombList.Add(TxtbxSmallStraight);
            game.LowerCombList.Add(TxtbxLargeStraight);
            game.LowerCombList.Add(TxtbxChance);
            game.LowerCombList.Add(TxtbxYahtzee);

            game.BonusAndSumAndTotalScoreList.Add(TxtbxBonus);
            game.BonusAndSumAndTotalScoreList.Add(TxtbxSum);
            game.BonusAndSumAndTotalScoreList.Add(TxtbxTotalScore);

            game.RollCounterLabel.Add(LblRollCounter);

            for (int i = 0; i < game.UpperCombList.Count; i++) {

                game.UpperCombList[i].Foreground = game.Red;
            }

            for (int i = 0; i < game.LowerCombList.Count; i++) {

                game.LowerCombList[i].Foreground = game.Red;
            }

            game.HeldDiceCheck();
        }

        //Rolls the dice, based on the 5-CountHeldDice
        private void BtnRoll_Click(object sender, RoutedEventArgs e) {

            game.RollDice();
        }

        private void PointButton_Click(object sender, RoutedEventArgs e) {

            if (sender == BtnOnes) {

                game.ChangeTextBoxColorToBlack(1, true);
            }
            else if (sender == BtnTwos) {

                game.ChangeTextBoxColorToBlack(2, true);
            }
            else if (sender == BtnThrees) {

                game.ChangeTextBoxColorToBlack(3, true);
            }
            else if (sender == BtnFours) {

                game.ChangeTextBoxColorToBlack(4, true);
            }
            else if (sender == BtnFives) {

                game.ChangeTextBoxColorToBlack(5, true);
            }
            else if (sender == BtnSixes) {

                game.ChangeTextBoxColorToBlack(6, true);
            }
            else if (sender == BtnThreeOfAKind) {

                game.ChangeTextBoxColorToBlack(1, false);
            }
            else if (sender == BtnFourOfAKind) {

                game.ChangeTextBoxColorToBlack(2, false);
            }
            else if (sender == BtnFullHouse) {

                game.ChangeTextBoxColorToBlack(3, false);
            }
            else if (sender == BtnSmallStraight) {

                game.ChangeTextBoxColorToBlack(4, false);
            }
            else if (sender == BtnLargeStraight) {

                game.ChangeTextBoxColorToBlack(5, false);
            }
            else if (sender == BtnChance) {

                game.ChangeTextBoxColorToBlack(6, false);
            }
            else if (sender == BtnYahtzee) {

                game.YahtzeeScoreCalculator();
            }

            game.ResetRollCounter();
        }

        private void HeldDice_Click(object sender, RoutedEventArgs e) {

            if (sender == BtnHeldDice1) {

                game.SwapValueToFieldDice(0);
            }
            else if (sender == BtnHeldDice2) {

                game.SwapValueToFieldDice(1);
            }
            else if (sender == BtnHeldDice3) {

                game.SwapValueToFieldDice(2);
            }
            else if (sender == BtnHeldDice4) {

                game.SwapValueToFieldDice(3);
            }
            else if (sender == BtnHeldDice5) {

                game.SwapValueToFieldDice(4);
            }
        }

        private void FieldDice_Click(object sender, RoutedEventArgs e) {

            if (sender == BtnFieldDice1) {

                game.SwapValueToHandDice(0);
            }
            else if (sender == BtnFieldDice2) {

                game.SwapValueToHandDice(1);
            }
            else if (sender == BtnFieldDice3) {

                game.SwapValueToHandDice(2);
            }
            else if (sender == BtnFieldDice4) {

                game.SwapValueToHandDice(3);
            }
            else if (sender == BtnFieldDice5) {

                game.SwapValueToHandDice(4);
            }
        }
    }
}
