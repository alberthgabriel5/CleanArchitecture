

using System;
using System.Collections.Generic;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.Entities
{
    public class StudentTests
    {
        [Fact]
        public void CannotRegisterForCourseWithin5DaysOfStartDate()
        {
            // arrange
            var student = new Student();
            var course = new Course { Code = "IF1300", Name = "Introduccion", StartDate = DateTime.UtcNow.AddDays(+3) };

            // act
            var result = student.RegisterForCourse(course);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CannotRegisterForCourseAlreadyEnrolledIn()
        {
            // arrange
            var student = new Student
            {
                EnrolledCourses = new List<Course>
                {
                   new Course { Code = "IF1400", Name = "Logica" },
                   new Course { Code = "MA1070", Name = "Mathematicas Discretas" }
                }
            };

            // act
            var result = student.RegisterForCourse(new Course { Code = "IF1400" });

            // assert
            Assert.False(result);
        }

        [Fact]
        public void CannotRegisterForCourseAlreadyRegisteredFor()
        {
            // arrange
            var student = new Student
            {
                RegisteredCourses = new List<Course>
                {
                   new Course { Code = "IF1400", Name = "Logica" },
                   new Course { Code = "MA1070", Name = "Mathematicas Discretas" }
                }
            };

            // act
            var result = student.RegisterForCourse(new Course { Code = "IF1400" });
            
            // assert
            Assert.False(result);
        }
    }
}
