// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright ?2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> [Insert Your Name] </authors>
// <date> [Insert the Date] </date>

namespace CS3500.FormulaTests;

using CS3500.Formula1; // Change this using statement to use different formula implementations.

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
        _ = new Formula( string.Empty );  // note: it is arguable that you should replace "" with string.Empty for readability and clarity of intent (e.g., not a cut and paste error or a "I forgot to put something there" error).
    }

    /// <summary>
    ///     This test should run correctly with single token formula.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestOneToken_Valid()
    {
        _ = new Formula("A1");
        _ = new Formula("123");
        _ = new Formula("5.5");
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


    [TestMethod]
    public void FormulaConstructor_TestValidTokens_Valid()
    {
        _ = new Formula("(3 - 2) / x2 + 10");
    }


    // --- Tests for Closing Parenthesis Rule

    /// <summary>
    /// This test should throw exception since number of opening parentheses and closing parentheses does not match.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestMoreClosingParentheses_Invalid()
    {
        _ = new Formula("5 + 2) * 3)");
    }


    // --- Tests for Balanced Parentheses Rule

    /// <summary>
    /// Bug report on this formula1.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestUnbalancedParentheses_Invalid()
    {
        _ = new Formula("(5 + 2 * (3");
    }

    [TestMethod]
    public void FormulaConstructor_TestUnbalancedParentheses_valid()
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

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidFirstToken_Invalid()
    {
        _ = new Formula("+ 5 * 2");
    }

    [TestMethod]
    public void FormulaConstructor_TestValidFirstToken_Valid()
    {
        _ = new Formula("5 * 2");
        _ = new Formula("(3 + 4)");
    }


    // --- Tests for  Last Token Rule ---

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidLastToken_Invalid()
    {
        _ = new Formula("5 + 2 *");
    }

    [TestMethod]
    public void FormulaConstructor_TestValidLastToken_Valid()
    {
        _ = new Formula("5 * 2");
        _ = new Formula("(3 + 4)");
        _ = new Formula("(3 + 4) + A");
    }


    // --- Tests for Parentheses/Operator Following Rule ---

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidFollowingOperator_Invalid()
    {
        _ = new Formula("5 + * 2");
    }


    [TestMethod]
    public void FormulaConstructor_TestValidFollowingOperator_Valid()
    {
        _ = new Formula("5 + (2 * 3)");
    }


    // --- Tests for Extra Following Rule ---

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestInvalidFollowingNumber_Invalid()
    {
        _ = new Formula("5 5 + 2");
    }


    [TestMethod]
    public void FormulaConstructor_TestValidFollowingNumber_Valid()
    {
        _ = new Formula("5 + 2");
        _ = new Formula("a1 * (b2 + c3)");
    }


    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFormulaFormatException_Thrown()
    {
        _ = new Formula("5 +- 2");
    }

}