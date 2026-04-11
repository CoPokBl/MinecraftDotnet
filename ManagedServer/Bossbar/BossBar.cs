using ManagedServer.Viewables;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Text;

namespace ManagedServer.Bossbar;

public class BossBar(TextComponent title, float health = 1.0f, ClientBoundBossBarPacket.Color color = ClientBoundBossBarPacket.Color.Purple, ClientBoundBossBarPacket.Division division = ClientBoundBossBarPacket.Division.Zero, ClientBoundBossBarPacket.Flags flags = ClientBoundBossBarPacket.Flags.None) {
    public TextComponent Title {
        get => _title;
        set {
            _title = value;
            SendPacket(new ClientBoundBossBarPacket.UpdateTitle(_title));
        }
    }

    public float Health {
        get => _health;
        set {
            _health = value;
            SendPacket(new ClientBoundBossBarPacket.UpdateHealth(_health));
        }
    }

    public ClientBoundBossBarPacket.Color Color {
        get => _color;
        set {
            _color = value;
            SendPacket(new ClientBoundBossBarPacket.UpdateStyle(_color, _division));
        }
    }

    public ClientBoundBossBarPacket.Division Division {
        get => _division;
        set {
            _division = value;
            SendPacket(new ClientBoundBossBarPacket.UpdateStyle(_color, _division));
        }
    }

    public ClientBoundBossBarPacket.Flags Flags {
        get => _flags;
        set {
            _flags = value;
            SendPacket(new ClientBoundBossBarPacket.UpdateFlags(_flags));
        }
    }
    
    private TextComponent _title = title;
    private float _health = health;
    private ClientBoundBossBarPacket.Color _color = color;
    private ClientBoundBossBarPacket.Division _division = division;
    private ClientBoundBossBarPacket.Flags _flags = flags;
    
    private readonly List<IAudience> _viewers = [];
    private readonly Guid _id = Guid.NewGuid();

    public void AddViewer(IAudience audience) {
        _viewers.Add(audience);
        audience.SendPacket(new ClientBoundBossBarPacket {
            Action = new ClientBoundBossBarPacket.Add(Title, Health, Color, Division, Flags),
            Uuid = _id
        });
    }

    public void RemoveViewer(IAudience audience) {
        _viewers.Remove(audience);
        audience.SendPacket(new ClientBoundBossBarPacket {
            Action = new ClientBoundBossBarPacket.Remove(),
            Uuid = _id
        });
    }

    public void RemoveAllViewers() {
        foreach (IAudience audience in _viewers) {
            RemoveViewer(audience);
        }
    }

    public List<IAudience> GetViewers() {
        return _viewers.ToList();
    }

    private void SendPacket(ClientBoundBossBarPacket.IActionData action) {
        foreach (IAudience audience in _viewers) {
            audience.SendPacket(new ClientBoundBossBarPacket {
                Action = action,
                Uuid = _id
            });
        }
    }
}