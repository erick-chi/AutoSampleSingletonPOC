using SingletonFramework.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTests.Drivers
{
    public class Setups:BaseTest
    {
        [BeforeScenario()]
        public void Init()
        {
            SetUp();
        }

        [AfterScenario()]
        public void End() {
            CleanUp();
        }
    }
}
