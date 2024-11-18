# Learning Unit Testing in C#

## General Concepts

The main focus of this learning journey is to get the grip of the **TDD**, Test Driven Development. This key concept tells us to build our solution based mainly on tests, to reduce expressively the occurence of bugs when running our program.

### The Practice of TDD

In a few words, the test driven development preaches to us to first develop a test for our solution and then build our code with the minimal construction. The ideia here is that this minmal structured function fails when it's submitted to test. After this step, we improve our solution to pass on the test.

## C# Annotations

I took this explanation from the [Microsoft Learn website](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test).

- `[Fact]`: declares a test method that's run by the test runner
- `[Theory]`: represents a suite of tests that execute the same code but have different input arguments.
- `[InlineData]`: attribute specifies values for those inputs.
