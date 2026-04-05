namespace CycleBike.Core.Common.Interfaces;

public interface IMessageBroker {
    public string Id { get;  }
    public string? MessageType { get;  }
    public DateTime CreatedAt { get;  }
    public bool Sent { get;  }
    public DateTime? SentAt { get;  }
    public int Attempts { get;  }
    public DateTime? LastAttempt { get;  }
    public string Status { get;  }
    public byte[]? Data { get;  }
}