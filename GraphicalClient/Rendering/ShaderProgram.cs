using System.Numerics;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

public sealed class ShaderProgram : IDisposable {
    private readonly GL _gl;
    private readonly Dictionary<string, int> _uniforms = new();

    public uint Handle { get; }

    public ShaderProgram(GL gl, string vertexSource, string fragmentSource) {
        _gl = gl;
        Handle = Link(Compile(ShaderType.VertexShader, vertexSource), Compile(ShaderType.FragmentShader, fragmentSource));
    }

    /// <summary>A compute program.</summary>
    public ShaderProgram(GL gl, string computeSource) {
        _gl = gl;
        Handle = Link(Compile(ShaderType.ComputeShader, computeSource));
    }

    private uint Compile(ShaderType type, string source) {
        uint shader = _gl.CreateShader(type);
        _gl.ShaderSource(shader, source);
        _gl.CompileShader(shader);
        _gl.GetShader(shader, ShaderParameterName.CompileStatus, out int compiled);
        if (compiled == 0) {
            throw new InvalidOperationException($"{type} compile failed: {_gl.GetShaderInfoLog(shader)}");
        }
        return shader;
    }

    private uint Link(params uint[] shaders) {
        uint program = _gl.CreateProgram();
        foreach (uint shader in shaders) {
            _gl.AttachShader(program, shader);
        }
        _gl.LinkProgram(program);
        _gl.GetProgram(program, ProgramPropertyARB.LinkStatus, out int linked);
        if (linked == 0) {
            throw new InvalidOperationException($"Shader link failed: {_gl.GetProgramInfoLog(program)}");
        }
        foreach (uint shader in shaders) {
            _gl.DetachShader(program, shader);
            _gl.DeleteShader(shader);
        }
        return program;
    }

    public void Use() => _gl.UseProgram(Handle);

    private int Location(string name) {
        if (!_uniforms.TryGetValue(name, out int location)) {
            location = _gl.GetUniformLocation(Handle, name);
            _uniforms[name] = location;
        }
        return location;
    }

    public void Set(string name, int value) => _gl.Uniform1(Location(name), value);
    public void Set(string name, uint value) => _gl.Uniform1(Location(name), value);
    public void Set(string name, float value) => _gl.Uniform1(Location(name), value);
    public void Set(string name, int x, int y, int z) => _gl.Uniform3(Location(name), x, y, z);
    public void Set(string name, Vector2 value) => _gl.Uniform2(Location(name), value.X, value.Y);
    public void Set(string name, Vector3 value) => _gl.Uniform3(Location(name), value.X, value.Y, value.Z);

    public unsafe void Set(string name, ReadOnlySpan<Vector3> values) {
        fixed (Vector3* p = values) {
            _gl.Uniform3(Location(name), (uint)values.Length, (float*)p);
        }
    }

    public unsafe void Set(string name, ReadOnlySpan<Vector4> values) {
        fixed (Vector4* p = values) {
            _gl.Uniform4(Location(name), (uint)values.Length, (float*)p);
        }
    }

    public void Dispose() => _gl.DeleteProgram(Handle);
}
