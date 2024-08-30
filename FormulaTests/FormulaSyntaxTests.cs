// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright ?2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> [Jason Chang] </authors>
// <date> [August 30 2024] </date>

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
    ///     Test for a single token which is a letter follow by a single number,
    ///     just a number, and a number with a decimal point.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_OneToken_Valid()
    {
        _ = new Formula("A1");
        _ = new Formula("123");
        _ = new Formula("5.5");
    }

    /// <summary>
    ///     Test for bunch of different invalid token examples.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_OneToken_InValid()
    {
        _ = new Formula("A1B1");
        _ = new Formula("1B");
        _ = new Formula("$");
        _ = new Formula("x");
        _ = new Formula("#");
    }

    /// <summary>
    ///      Test for lower case specific notation.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_OneTokenLowerSpecificNotation_Valid()
    {
        _ = new Formula("2e5");
        _ = new Formula("2e-5");
    }

    /// <summary>
    ///     Test for uppercase specific notation.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_OneTokenUpperSpecificNotation_Valid()
    {
        _ = new Formula("2E5");
        _ = new Formula("2E-5");
    }

    // --- Tests for Valid Token Rule ---

    /// <summary>
    ///     Test for expression with an invalid token.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_InvalidTokenExpression_Invalid()
    {
        _ = new Formula("5 + $");
    }

    /// <summary>
    ///     Test for a valid variable expression token rule.
    ///     Letter follow by one number.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_VariableExpression_Valid()
    {
        _ = new Formula("A1 + B1");
    }

    /// <summary>
    ///     Test for an invalid expression with just a single letter.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_VariableExpression_InValid()
    {
        _ = new Formula("A + B");
    }

    /// <summary>
    ///     Test for an Invalid expression with a number followed by a letter.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_VariableExpression2_InValid()
    {
        _ = new Formula("1A + 1B");
    }

    /// <summary>
    ///     Test for an Invalid expression with a number followed by a letter and then a number again.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_VariableExpression3_InValid()
    {
        _ = new Formula("1A1 + 1B1");
    }

    /// <summary>
    ///     Test for an expression with overall valid tokens and rules followed.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_Expression_Valid()
    {
        _ = new Formula("(3 - 2) / x2 + 10");
    }

    // --- Tests for Closing Parenthesis Rule

    /// <summary>
    ///     Test for an unbalanced number of opening and closing parenthesis.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_ClosingParenthesis_Invalid()
    {
        _ = new Formula("((5 + 2) * 3)))");
    }

    // --- Tests for Balanced Parenthesis Rule

    /// <summary>
    ///     Test for an unequal number of opening and closing parenthesis expression.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_BalancedParenthesis_Invalid()
    {
        _ = new Formula("(5 + 2 * (3");
    }

    /// <summary>
    ///     Test for a valid expression with balanced parenthesis.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_BalancedParenthesis_valid()
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
    public void FormulaConstructor_FirstTokenNumber_Valid( )
    {
        _ = new Formula("1+1");
    }

    /// <summary>
    ///     Test for an invalid first token starter.
    ///     Operator.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FirstTokenOperator_Invalid()
    {
        _ = new Formula("+ 5 * 2");
    }

    /// <summary>
    ///     Test for a valid first token starter.
    ///     Number.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FristTokenNumber_Valid()
    {
        _ = new Formula("5 * 2");
    }

    /// <summary>
    ///     Test for a valid first token starter.
    ///     Variable.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FirstTokenVariable_Valid()
    {
        _ = new Formula("A1 * B2");
    }

    /// <summary>
    ///     Test for a valid first token.
    ///     Parenthesis.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FirstTokenParenthesis_Valid()
    {
        _ = new Formula("(5) / 2");
    }

    // --- Tests for Last Token Rule ---

    /// <summary>
    ///     Test for an invalid last token.
    ///     Operator.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_LastTokenOperator_Invalid()
    {
        _ = new Formula("5 + 2 *");
    }

    /// <summary>
    ///     Test for an invalid last token.
    ///     Single letter.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_LastTokenVariable_Invalid()
    {
        _ = new Formula("5 + A");
        _ = new Formula("5 + a");
    }

    /// <summary>
    ///     Test for an invalid last token.
    ///     Opening parenthesis.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_LastTokenOpeningParenthesis_InValid()
    {
        _ = new Formula("10 + 1(");
    }

    /// <summary>
    ///     Test for a valid last token.
    ///     Number.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_LastTokenNumber_Valid()
    {
        _ = new Formula("10 + 1");
    }

    /// <summary>
    ///     Test for a valid last token.
    ///     Variable.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_LastTokenVariable_Valid()
    {
        _ = new Formula("10 + A1");
        _ = new Formula("10 + a1");
    }

    // --- Tests for Parenthesis/Operator Following Rule ---

    /// <summary>
    ///     Test for an invalid following rule.
    ///     Operator followed by an operator.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingOperator_Invalid()
    {
        _ = new Formula("5 + * 2");
    }

    /// <summary>
    ///     Test for an invalid following rule.
    ///     Opening parenthesis followed by an operator.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingParenthesis_Invalid()
    {
        _ = new Formula("10 + (*2)");
    }

    /// <summary>
    ///     Test for a valid operator following rule.
    ///     Operator followed by number, variable, or opening parenthesis.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingOperator_Valid()
    {
        _ = new Formula("5 + A1 + (2 * 3)");
    }

    /// <summary>
    ///     Test for a valid parenthesis following rule.
    ///     Opening parenthesis followed by a variable or a number.
    ///     Closing parenthesis followed by an operator.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingParenthesis_Valid()
    {
        _ = new Formula("(a5 + 1) / 5 + (5)");
    }


    // --- Tests for Extra Following Rule ---

    /// <summary>
    ///     Test for an invalid number following rule.
    ///     Number followed by a number.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingNumber_Invalid()
    {
        _ = new Formula("5 5 + 2");
    }

    /// <summary>
    ///     Test for an invalid variable following rule.
    ///     Variable followed by a variable.
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingVariable_Invalid()
    {
        _ = new Formula("5 + A1 B1");
    }

    /// <summary>
    ///     Test for an invalid closing parenthesis following rule.
    ///     Closing parenthesis followed by number and variable.
    ///     
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_FollowingClosingParenthesis_Invalid()
    {
        _ = new Formula("(5 + 1)10");
        _ = new Formula("(5 + 1)A1");
    }

    /// <summary>
    ///     Test for a valid number following rule.
    ///     Number followed by an operator or closing parenthesis.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingNumber_Valid()
    {
        _ = new Formula("(5 + 2)");
    }

    /// <summary>
    ///     Test for a valid closing parenthesis following rule.
    ///     Closing parenthesis followed by an operator or closing parenthesis.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_FollowingClosingParenthesis_Valid()
    {
        _ = new Formula("((1 / 1) * (5 + 2))");
    }
}