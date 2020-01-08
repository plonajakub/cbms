using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbms_src.backend
{
    public class DataProvider
    {
        /// <summary>
        /// For tests only
        /// </summary>
        public void Run()
        {
            SimpleEfTest();
        }

        private void SimpleEfTest()
        {
            using (var ctx = new CbmsMainDbEntities())
            {
                var departments = ctx.Departments.ToList();
                foreach (var department in departments)
                {
                    Console.WriteLine(department.ID + @": " + department.Name);
                }
            }
        }
    }

}
