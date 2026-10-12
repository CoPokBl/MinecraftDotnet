using System.Net.Sockets;
using System.Text;

namespace TestClient;

/// <summary>A minimal RCON client, for setting up a vanilla server from a test.</summary>
public sealed class Rcon : IDisposable {
    private readonly TcpClient _tcp;
    private readonly NetworkStream _stream;
    private int _nextId = 1;

    public Rcon(string host, int port, string password) {
        _tcp = new TcpClient(host, port);
        _stream = _tcp.GetStream();
        Exchange(3, password);
    }

    public string Run(string command) => Exchange(2, command);

    private string Exchange(int type, string body) {
        int id = _nextId++;
        byte[] payload = Encoding.UTF8.GetBytes(body);
        byte[] packet = new byte[payload.Length + 14];
        BitConverter.TryWriteBytes(packet.AsSpan(0), payload.Length + 10);
        BitConverter.TryWriteBytes(packet.AsSpan(4), id);
        BitConverter.TryWriteBytes(packet.AsSpan(8), type);
        payload.CopyTo(packet, 12);
        _stream.Write(packet);

        byte[] lengthBytes = new byte[4];
        _stream.ReadExactly(lengthBytes);
        int length = BitConverter.ToInt32(lengthBytes);
        byte[] response = new byte[length];
        _stream.ReadExactly(response);
        return Encoding.UTF8.GetString(response, 8, Math.Max(0, length - 10));
    }

    public void Dispose() {
        _tcp.Dispose();
    }
}
