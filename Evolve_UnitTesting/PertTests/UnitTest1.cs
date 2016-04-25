using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PertTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
public void PertEstimate_CalculationWithPositiveValues_CheckAccuracyIsSuccess()
        {
            // Arrange
            double likelyAmount = 20;
            double bestCaseAmount = 12;
            double worstCaseAmount = 40;
            double estimatedResult = 22;
            // Act
            double actualAmount =  PertEstimate.PertEstimate.Estimate(likelyAmount,
            bestCaseAmount, worstCaseAmount);
            // Assert
            Assert.AreEqual(estimatedResult, actualAmount);
        }
    }
}
