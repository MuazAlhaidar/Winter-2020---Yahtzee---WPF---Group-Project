using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;

namespace SectionCombinationsUnitTests {

    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestMethodUpperSection() {

            // Arrange
            int[] OnesArray     = { 1, 1, 1, 1, 1 };
            int[] TwosArray     = { 2, 2, 2, 2, 2 };
            int[] ThreesArray   = { 3, 3, 3, 3, 3 };
            int[] FoursArray    = { 4, 4, 4, 4, 4 };
            int[] FivesArray    = { 5, 5, 5, 5, 5 };
            int[] SixesArray    = { 6, 6, 6, 6, 6 };

            // Act
            int ReturnedOnesSum     = SectionCombinations.UpperSection(OnesArray,   1);
            int ReturnedTwosSum     = SectionCombinations.UpperSection(TwosArray,   2);
            int ReturnedThreesSum   = SectionCombinations.UpperSection(ThreesArray, 3);
            int ReturnedFoursSum    = SectionCombinations.UpperSection(FoursArray,  4);
            int ReturnedFivesSum    = SectionCombinations.UpperSection(FivesArray,  5);
            int ReturnedSixesSum    = SectionCombinations.UpperSection(SixesArray,  6);

            // Assert
            Assert.AreEqual(ReturnedOnesSum,    5);
            Assert.AreEqual(ReturnedTwosSum,    10);
            Assert.AreEqual(ReturnedThreesSum,  15);
            Assert.AreEqual(ReturnedFoursSum,   20);
            Assert.AreEqual(ReturnedFivesSum,   25);
            Assert.AreEqual(ReturnedSixesSum,   30);
        }

        [TestMethod]
        public void TestMethodUpperSectionNotAllValuesInArrayAreTheSame() {

            // Arrange
            int[] OnesArray = { 1, 2, 1, 1, 1 };

            // Act
            int ReturnedOnesSum = SectionCombinations.UpperSection(OnesArray, 1);

            // Assert
            Assert.AreEqual(ReturnedOnesSum, 4);
        }

        [TestMethod]
        public void TestMethodUpperSectionTheArrayIsNotFiveInLength() {

            // Arrange
            int[] OnesArray = { 1, 2, 1, 1 };

            // Act
            int ReturnedOnesSum = SectionCombinations.UpperSection(OnesArray, 1);

            // Assert
            Assert.AreEqual(ReturnedOnesSum, 3);
        }

        [TestMethod]
        public void TestMethodLowerSectionThreeOfAKind() {

            // Arrange
            int[] OnesArray = { 1, 2, 1, 1 };
            int[] TwosArray = { 1, 2, 2, 2};
            int[] ThreesArray = { 1, 2, 3, 3, 3 };

            // Act
            int ReturnedOnesSum = SectionCombinations.LowerSection(OnesArray, 1);
            int ReturnedTwosSum = SectionCombinations.LowerSection(TwosArray, 1);
            int ReturnedThreesSum = SectionCombinations.LowerSection(ThreesArray, 1);

            // Assert
            Assert.AreEqual(ReturnedOnesSum, 5);
            Assert.AreEqual(ReturnedTwosSum, 7);
            Assert.AreEqual(ReturnedThreesSum, 12);
        }

        [TestMethod]
        public void TestMethodLowerSectionFourOfAKind() {

            // Arrange
            int[] OnesArray = { 1, 1, 1, 1 };
            int[] TwosArray = { 1, 2, 2, 2, 2 };
            int[] ThreesArray = { 1, 1, 1, 1, 3 };

            // Act
            int ReturnedOnesSum = SectionCombinations.LowerSection(OnesArray, 2);
            int ReturnedTwosSum = SectionCombinations.LowerSection(TwosArray, 2);
            int ReturnedThreesSum = SectionCombinations.LowerSection(ThreesArray, 2);

            // Assert
            Assert.AreEqual(ReturnedOnesSum, 4);
            Assert.AreEqual(ReturnedTwosSum, 9);
            Assert.AreEqual(ReturnedThreesSum, 7);
        }

        [TestMethod]
        public void TestMethodLowerSectionFullHouse() {

            // Arrange
            int[] OnesArray = { 1, 1, 1, 2, 2 };
            int[] TwosArray = { 2, 2, 2, 1, 1 };
            int[] ThreesArray = { 3, 3, 3, 3, 2 };

            // Act
            int ReturnedOnesSum = SectionCombinations.LowerSection(OnesArray, 3);
            int ReturnedTwosSum = SectionCombinations.LowerSection(TwosArray, 3);
            int ReturnedThreesSum = SectionCombinations.LowerSection(ThreesArray, 3);

            // Assert
            Assert.AreEqual(ReturnedOnesSum, 25);
            Assert.AreEqual(ReturnedTwosSum, 25);
            Assert.AreEqual(ReturnedThreesSum, 0);
        }

        [TestMethod]
        public void TestMethodLowerSectionSmallStraight() {

            // Arrange
            int[] NotSmallStraight = { 1, 1, 1, 2, 2 };
            int[] IsSmallStraight = { 1, 2, 3, 4, 1 };
            int[] IsSmallStraightButShorter = { 3, 4, 5, 6 };

            // Act
            int ReturnedNotSmallStraightSum = SectionCombinations.LowerSection(NotSmallStraight, 4);
            int ReturnedIsSmallStraightSum = SectionCombinations.LowerSection(IsSmallStraight, 4);
            int ReturnedIsSmallStraightButShorterSum = SectionCombinations.LowerSection(IsSmallStraightButShorter, 4);

            // Assert
            Assert.AreEqual(ReturnedNotSmallStraightSum, 0);
            Assert.AreEqual(ReturnedIsSmallStraightSum, 30);
            Assert.AreEqual(ReturnedIsSmallStraightButShorterSum, 30);
        }

        [TestMethod]
        public void TestMethodLowerSectionLargeStraight() {

            // Arrange
            int[] NotLargeStraight = { 1, 1, 1, 2, 2 };
            int[] IsLargeStraight = { 1, 2, 3, 4, 5 };
            int[] IsLargeStraight2 = { 2, 3, 4, 5, 6 };

            // Act
            int ReturnedNotLargeStraightSum = SectionCombinations.LowerSection(NotLargeStraight, 5);
            int ReturnedIsLargeStraightSum = SectionCombinations.LowerSection(IsLargeStraight, 5);
            int ReturnedIsLargeStraightSum2 = SectionCombinations.LowerSection(IsLargeStraight2, 5);
            
            // Assert
            Assert.AreEqual(ReturnedNotLargeStraightSum, 0);
            Assert.AreEqual(ReturnedIsLargeStraightSum, 40);
            Assert.AreEqual(ReturnedIsLargeStraightSum2, 40);
        }

        [TestMethod]
        public void TestMethodLowerSectionChance() {

            // Arrange
            int[] OnesArray     = { 1, 1, 1, 1, 1 };
            int[] TwosArray     = { 2, 2, 2, 2 };
            int[] ThreesArray   = { 3, 3, 3 };
            int[] FoursArray    = { 4, 4 };
            int[] FivesArray    = { 5 };

            // Act
            int ReturnedOnesArraySum = SectionCombinations.LowerSection(OnesArray, 6);
            int ReturnedTwosArraySum = SectionCombinations.LowerSection(TwosArray, 6);
            int ReturnedThreesArraySum = SectionCombinations.LowerSection(ThreesArray, 6);
            int ReturnedFoursArraySum = SectionCombinations.LowerSection(FoursArray, 6);
            int ReturnedFiveArraySum = SectionCombinations.LowerSection(FivesArray, 6);

            // Assert
            Assert.AreEqual(ReturnedOnesArraySum, 5);
            Assert.AreEqual(ReturnedTwosArraySum, 8);
            Assert.AreEqual(ReturnedThreesArraySum, 9);
            Assert.AreEqual(ReturnedFoursArraySum, 8);
            Assert.AreEqual(ReturnedFiveArraySum, 5);

        }

        [TestMethod]
        public void TestMethodLowerSectionYahtzee() {

            // Arrange
            int[] NotYahtzee = { 1, 1, 1, 2, 2 };
            int[] IsYahtzee = { 1, 1, 1, 1, 1 };

            // Act
            int ReturnedNotLargeStraightSum = SectionCombinations.LowerSection(NotYahtzee, 7);
            int ReturnedIsLargeStraightSum = SectionCombinations.LowerSection(IsYahtzee, 7);

            // Assert
            Assert.AreEqual(ReturnedNotLargeStraightSum, 0);
            Assert.AreEqual(ReturnedIsLargeStraightSum, 50);
        }
    }
}
