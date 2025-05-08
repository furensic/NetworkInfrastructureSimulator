using NetworkInfrastructureSimulator.Connection;

namespace NetworkInfrastructureSimulator;

internal static class Program {
    private static void Main(string[] args) {
        var physicalConnection = new PhysicalConnection();
        physicalConnection.EnableConnection();
        var tmp1 = physicalConnection.AddParticipant();
        var tmp2 = physicalConnection.AddParticipant();
        
        physicalConnection.WriteBuffer(tmp1, "test1");
        physicalConnection.WriteBuffer(tmp2, "test2");
        tmp1.ReadBuffer();
        tmp2.ReadBuffer();
    }
}