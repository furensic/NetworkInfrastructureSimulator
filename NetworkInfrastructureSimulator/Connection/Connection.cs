namespace NetworkInfrastructureSimulator.Connection;

public interface IConnection {
    public void EnableConnection();
    public void DisableConnection();
}

public abstract class Connection : IConnection {
    public Guid ConnectionId { get; set; } = Guid.NewGuid();
    public List<ConnectionParticipant> ConnectionParticipants { get; set; } = new();
    
    public bool IsEnabled { get; set; } = false;
    
    public void EnableConnection() {
        if (IsEnabled) {
            Console.WriteLine("Connection already enabled");
            return;
        }
        
        IsEnabled = true;
        
        Console.WriteLine("Connection <{0}> enabled", ConnectionId);
    }

    public void DisableConnection() {
        if (!IsEnabled) {
            Console.WriteLine("Connection not enabled");
            return;
        }
        
        IsEnabled = false;
        
        Console.WriteLine("Connection <{0}> disabled", ConnectionId);
    }

    public ConnectionParticipant AddParticipant() {
        var tmp = new ConnectionParticipant(Guid.NewGuid());
        this.ConnectionParticipants.Add(tmp);
        Console.WriteLine("Added participant <{0}> to connection <{1}>", tmp.ConnectionParticipantId, this.ConnectionId);
        
        return tmp;
    }

    public void RemoveParticipant(ConnectionParticipant connectionParticipant) {
        this.ConnectionParticipants.Remove(connectionParticipant);
    }

    public void ShowParticipants() {
        Console.WriteLine("Total participants: {0}", this.ConnectionParticipants.Count);
        var i = 0;
        foreach (var connectionParticipant in this.ConnectionParticipants) {
            Console.WriteLine("Participant <{0}> index: {1}", connectionParticipant.ConnectionParticipantId, i);
            i++;
        }
    }
}

public class PhysicalConnection : Connection {
    public PhysicalConnection() {
        
    }

    public void WriteBuffer(ConnectionParticipant connectionParticipant, string buffer) {
        connectionParticipant.WriteBuffer(buffer);
    }
}

public class ConnectionParticipant(Guid guid) {
    public Guid ConnectionParticipantId { get; set; } = guid;

    public string Buffer;

    public void WriteBuffer(string buffer) {
        this.Buffer = buffer;
    }

    public void ReadBuffer() {
        Console.WriteLine("Participant <{0}> buffer: {1}",this.ConnectionParticipantId, this.Buffer);
    }
}