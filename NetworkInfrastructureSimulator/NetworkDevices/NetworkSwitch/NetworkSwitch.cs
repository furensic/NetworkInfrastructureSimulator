namespace NetworkInfrastructureSimulator.NetworkDevices.NetworkSwitch;

public class NetworkSwitch(string switchName) {
    public List<NetworkSwitchPort> Ports             { get; set; } = new();
    public string                  NetworkSwitchName { get; set; } = switchName;
    public Guid                    NetworkSwitchId   { get; set; } = Guid.NewGuid();

    public void Initialize() {
        Console.WriteLine("NetworkSwitch <{0}> {1} initialized", NetworkSwitchId, NetworkSwitchName);
    }
}