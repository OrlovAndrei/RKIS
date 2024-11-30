public static void RunTests()
{
    Test("hello world", new[] { "hello", "world" });
    Test("hello  world", new[] { "hello", "world" });
    Test(String.Empty, new string[0]);
    Test("'x y'", new[] { "x y" });
    Test(""a 'b' 'c' d"", new[] { "a 'b' 'c' d" });
    Test("'"1"", new[] { ""1"" });
    Test("a"b c d e"", new[] { "a", "b c d e" });
    Test(""b c d e"f", new[] { "b c d e", "f" });
    Test(" 1 ", new[] { "1" });
    Test(""a \\"c\\""", new[] { "a "c"" });
    Test(""\\\\"", new[]{"\"});        
}
