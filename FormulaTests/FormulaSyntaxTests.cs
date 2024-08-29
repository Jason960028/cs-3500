// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright ?2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> [Insert Your Name] </authors>
// <date> [Insert the Date] </date>

namespace CS3500.FormulaTests;

using CS3500.Formula1
    ; // Change this using statement to use different formula implementations.

/// <summary>
///   <para>
///     The following class shows the basics of how to use the MSTest framework,
///     including:
///   </para>
///   <list type="number">
///     <item> How to catch exceptions. </item>
///     <item> How a test of valid code should look. </item>
///   </list>
/// </summary>
[TestClass]
public class FormulaSyntaxTests

    //20-30 Test to cover all possible edge cases.
    //bug report is a hypothesis. There is nothing right or wrong.
{
    // --- Tests for One Token Rule ---

    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown
    ///     when trying to create a formula with no tokens.
    ///   </para>
    ///   <remarks>
    ///     <list type="bullet">
    ///       <item>
    ///         We use the _ (discard) notation because the formula object
    ///         is not used after that point in the method.  Note: you can also
    ///         use _ when a method must match an interface but does not use
    ///         some of the required arguments to that method.
    ///       </item>
    ///       <item>
    ///         string.Empty is often considered best practice (rather than using "") because it
    ///         is explicit in intent (e.g., perhaps the coder forgot to but something in "").
    ///       </item>
    ///       <item>
    ///         The name of a test method should follow the MS standard:
    ///         https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    ///       </item>
    ///       <item>
    ///         All methods should be documented, but perhaps not to the same extent
    ///         as this one.  The remarks here are for your educational
    ///         purposes (i.e., a developer would assume another developer would know these
    ///         items) and would be superfluous in your code.
    ///       </item>
    ///       <item>
    ///         Notice the use of the attribute tag [ExpectedException] which tells the test
    ///         that the code should throw an exception, and if it doesn't an error has occurred;
    ///         i.e., the correct implementation of the constructor should result
    ///         in this exception being thrown based on the given poorly formed formula.
    ///       </item>
    ///     </list>
    ///   </remarks>
    ///   <example>
    ///     <code>
    ///        // here is how we call the formula constructor with a string representing the formula
    ///        _ = new Formula( "5+5" );
    ///     </code>
    ///   </example>
    /// </summary>
    [TestMethod]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void FormulaConstructor_TestNoTokens_Invalid( )
    {
        _ = new Formula(string.Empty);
    }

    /// <summary>
    ///     This test should run correctly because each token used is correct.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestOneToken_Valid()
    {
        _ = new Formula("A1");
        _ = new Formula("123");
        _ = new Formula("5.5");
    }

    [TestMethod]//Question
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_OneToken_InValid()
    {
        //_ = new Formula("A1B1");
        _ = new Formula("1B");
        _ = new Formula("$");
        _ = new Formula("x");
        _ = new Formula("100");
    }



    /// <summary>
    ///     This test make sure program run correctly when special notation is used. 
    ///     1. Bug report on formula1. This should run correctly since 2e5 and 2e-5 are correct token accordint to the guideline. 
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestOneTokenSpecial_Valid()
    {
        _ = new Formula("2e5");
        _ = new Formula("2e-5");

    }

    /// <summary>
    ///     This test make sure program run correctly when special notation token is used.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestOneTokenSpecial2_Valid()
    {
        _ = new Formula("2E5");
        _ = new Formula("2E-5");

    }

    // --- Tests for Valid Token Rule ---

    /// <summary>
    /// This test should throw exception correctly because '$' is not a valid token.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidToken_Invalid()
    {
        _ = new Formula("5 + $");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestValidTokens_Valid()
    {
        _ = new Formula("(3 - 2) / x2 + 10");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestVariable_Valid()
    {
        _ = new Formula("A1 + B1");
    }

    /// <summary>
    /// Test for Invalid combination of variable token.
    /// This test should successfully throw exception.
    /// 
    /// 1.bug report for formula1. Should throw exception but not throwing.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariable_InValid()
    {
        _ = new Formula("A + B");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariable2_InValid()
    {
        _ = new Formula("1A + 1B");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVariable3_InValid()
    {
        _ = new Formula("1A1 + 1B1");
    }

    // --- Tests for Closing Parenthesis Rule

    /// <summary>
    /// This test should throw exception since number of opening parentheses and closing parentheses does not match.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestClosingParentheses_Invalid()
    {
        _ = new Formula("5 + 2) * 3)");
    }

    // --- Tests for Balanced Parentheses Rule

    /// <summary>
    /// Test for unbalanced parentheses equation. This test should throw exception sucessfully.
    /// 1. Bug report on this formula1. The equation is indeed not valid equation, but running correctly.
    /// 
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestBalancedParentheses_Invalid()
    {
        _ = new Formula("(5 + 2 * (3");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestBalancedParentheses_valid()
    {
        _ = new Formula("(10 + 2) / (3)");
    }

    // --- Tests for First Token Rule

    /// <summary>
    ///   <para>
    ///     Make sure a simple well formed formula is accepted by the constructor (the constructor
    ///     should not throw an exception).
    ///   </para>
    ///   <remarks>
    ///     This is an example of a test that is not expected to throw an exception, i.e., it succeeds.
    ///     In other words, the formula "1+1" is a valid formula which should not cause any errors.
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestFirstTokenNumber_Valid( )
    {
        _ = new Formula( "1+1" );
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidFirstToken_Invalid()
    {
        _ = new Formula("+ 5 * 2");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FristTokenNumber_Valid()
    {
        _ = new Formula("5 * 2");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FirstTokenVariable_Valid()
    {
        _ = new Formula("A1 * B2");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FirstTokenParentheses_Valid()
    {
        _ = new Formula("(1) / 2");
    }




    // --- Tests for  Last Token Rule ---

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_LastTokenOperator_Invalid()
    {
        _ = new Formula("5 + 2 *");
    }

    /// <summary>
    ///     
    ///     1. bug report on formula 1. Should sucessfully throw exception but not since A and a itself without one integer is not a valid token. 
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_LastTokenVariable_Invalid()
    {
        _ = new Formula("5 + A");
        _ = new Formula("5 + a");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_LastTokenNumber_Valid()
    {
        _ = new Formula("10 + 1");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_LastTokenVariable_Valid()
    {
        _ = new Formula("10 + A1");
        _ = new Formula("10 + a1");
    }


    // --- Tests for Parentheses/Operator Following Rule ---

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingOperator_Invalid()
    {
        _ = new Formula("5 + * 2");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingParentheses_Invalid()
    {
        _ = new Formula("10 + (*2)");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingOperator_Valid()
    {
        _ = new Formula("5 + (2 * 3)");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingParentheses_Valid()
    {
        _ = new Formula("(a5 + 1) / 5 + (5)");
    }


    // --- Tests for Extra Following Rule ---

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingNumber_Invalid()
    {
        _ = new Formula("5 5 + 2");
    }
    
    /// <summary>
    ///     
    ///     A1 B1 throw exception correctly on formula 1 but A1B1 consider as valid token some how fix it later.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingVariable_Invalid()
    {
        _ = new Formula("5 + A1 B1");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingNumber_Valid()
    {
        _ = new Formula("(5 + 2)");
    }

    /// <summary>
    ///     
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingClosingParentheses_Valid()
    {
        _ = new Formula("(1 / 1 * (5 + 2))");
    }
}