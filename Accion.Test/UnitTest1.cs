using Accion.Logical;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Accion.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void IsBalanced_Success()
        {
            string input = "(){}[]";
            Class1 ob1 = new Class1();
            Assert.IsTrue(ob1.IsBalanced(input));
        }

        [Test]
        public void IsBalanced_UnSuccess()
        {
            string input = "([)]";
            Class1 ob1 = new Class1();
            Assert.IsFalse(ob1.IsBalanced(input));
        }
    }
}