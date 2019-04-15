 

using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Contracts;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.ConsoleApp.Gateways
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Dictionary<string, Course> _store = new Dictionary<string, Course>
        {
            { "IF3150", new Course {
                    Code = "IF3150",
                    Description = "Sistems 3150",
                    StartDate = DateTime.UtcNow.AddMonths(2),
                    EndDate = DateTime.UtcNow.AddMonths(6)
                }
            },
             { "XS1200", new Course {
                    Code = "XS1200",
                    Description = "Stadistic 1200",
                    StartDate = DateTime.UtcNow.AddMonths(2),
                    EndDate = DateTime.UtcNow.AddMonths(6)
                }
            },
             { "MAT1100", new Course {
                    Code = "MAT1100",
                    Description = "Math 1100",
                    StartDate = DateTime.UtcNow.AddMonths(2),
                    EndDate = DateTime.UtcNow.AddMonths(6)
                }
            }
        };

        public Course GetByCode(string code)
        {
            return _store[code];
        }

        public List<Course> GetAll()
        {
            return _store.Values.ToList();
        }
    }
}
