using NetworkInfrastructureSimulator.Connection;
using NetworkInfrastructureSimulator.NetworkDevices.NetworkSwitch;

namespace NetworkInfrastructureSimulator;

internal static class Program {
    private static void Main(string[] args) {
        var Switch = new NetworkSwitch("Switch 1");
        Switch.Initialize();
    }
}