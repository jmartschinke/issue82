using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetFramework
{
    public class PropertyArgumentCtorTests : MethodBoundaryAspectNetFrameworkTestBase
    {
        private static readonly Type TestClassType = typeof(TriggerPropChangedTestClass);

        [Fact]
        public void IfPropertyAccessorWithConstructorArgIsCalled_ThenCorrectCtorIsDiscerned()
        {
            // Arrange
            const string testMethodName = "get_TestProp";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("a");
        }

        [Fact]
        public void IfPropertyAccessorWithConstructorArgInForeignAssemblyIsCalled_ThenCorrectCtorIsDiscerned()
        {
            // Arrange
            const string testMethodName = "get_TestPropCrossDll";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("expectedResult");
        }

        [Fact]
        public void IfPropertyAccessorWithConstructorArgTypeArrayInForeignAssemblyIsCalled_ThenCorrectCtorIsDiscerned()
        {
            // Arrange
            const string testMethodName = "get_TestTypeArrayCrossDll";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("System.String;System.Object");
        }
    }
}