using Bogus;

namespace IoTDevice.Models
{
    public class DeviceFakeData
    {
        public int InsideTemperature { get; set; }

        public int OutsideTemperature { get; set; }

        public int WaterTemperature { get; set; }

        public static Faker<DeviceFakeData> FakeData { get; } = new Faker<DeviceFakeData>()
            .RuleFor(p => p.InsideTemperature, f => f.Random.Int(-150, 150))
            .RuleFor(p => p.OutsideTemperature, f => f.Random.Int(-100, 100))
            .RuleFor(p => p.WaterTemperature, f => f.Random.Int(-100, 100));
    }
}
