namespace ClientLib.Events.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CallsEventAttribute(params Type[] eventTypes) : Attribute {
    public Type[] EventTypes { get; } = eventTypes;
}
