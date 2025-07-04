namespace Minecraft;

public class ListStream(List<byte> list) : Stream {
    
    public override void Flush() {
        
    }

    public override int Read(byte[] buffer, int offset, int count) {
        throw new NotSupportedException();
    }

    public override long Seek(long offset, SeekOrigin origin) {
        throw new NotSupportedException();
    }

    public override void SetLength(long value) {
        throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count) {
        if (offset < 0 || count < 0 || offset + count > buffer.Length) {
            throw new ArgumentOutOfRangeException();
        }
        
        for (int i = 0; i < count; i++) {
            list.Add(buffer[offset + i]);
        }
    }

    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override long Length => list.Count;
    public override long Position { 
        get => list.Count; 
        set => throw new NotSupportedException("Setting position is not supported in ListStream."); 
    }
}
