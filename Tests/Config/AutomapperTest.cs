using Configuration.Mapping;
using NUnit.Framework;

namespace Tests.Config
{
    [TestFixture]
    public class AutomapperTest
    {
        [Test]
        public void AutomapperConfigTest()
        {
            MappingConfig.RegisterMappings();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
