#region License
//
// Command Line Library: Singleton.cs
//
// Author:
//   Giacomo Stelluti Scala (gsscoder@gmail.com)
//
// Copyright (C) 2005 - 2012 Giacomo Stelluti Scala
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
#endregion
#region Using Directives
using System;
using System.IO;
using NUnit.Framework;
using Should.Fluent;
using CommandLine.Tests.Mocks;
#endregion
namespace CommandLine.Tests
{
    [TestFixture]
    public class Singleton
    {
        [Test]
        public void ParseStringIntegerBoolOptions()
        {
            var options = new SimpleOptions();
            bool result = CommandLineParser.Default.ParseArguments(
                    new string[] { "-s", "another string", "-i100", "--switch" }, options);

            result.Should().Be.True();
            options.StringValue.Should().Equal("another string");
            options.IntegerValue.Should().Equal(100);
            options.BooleanValue.Should().Be.True();
            Console.WriteLine(options);
        }

        [Test]
        public void DefaultDoesntSupportMutuallyExclusiveOptions()
        {
            var options = new OptionsWithMultipleSet();
            bool result = CommandLineParser.Default.ParseArguments(
                new string[] { "-r1", "-g2", "-b3", "-h4", "-s5", "-v6" }, options);

            result.Should().Be.True(); // enabling MutuallyExclusive option it would fails
        }
    }
}