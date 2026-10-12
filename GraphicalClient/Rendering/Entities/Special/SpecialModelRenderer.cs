using System.Numerics;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary>
/// <c>SpecialModelRenderer</c>: an item drawn by code rather than by a baked model, from an argument it
/// reads off the stack. The enchantment glint (<c>hasFoil</c>) is not drawn, as for every item here.
/// </summary>
public interface ISpecialModelRenderer {
    object? ExtractArgument(ItemStack stack);

    void Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight);

    /// <summary>What <c>submit</c> draws when <c>hasFoil</c> is set, besides what it always draws; most renderers ignore it.</summary>
    void SubmitFoil(object? argument, PoseStack pose, IModelSink sink) { }

    void GetExtents(Action<Vector3> output);

    /// <summary>
    /// <c>appendModelIdentityElement(argument)</c>: what tells two stacks' drawings apart, so a GUI icon is
    /// drawn once per distinct look. Null when the argument draws as a stack with no components does.
    /// </summary>
    string? IdentityOf(object? argument);
}

/// <summary>A renderer whose argument has a type, as vanilla's generic parameter gives it one.</summary>
public abstract class SpecialModelRenderer<T> : ISpecialModelRenderer where T : class {
    public abstract T? ExtractArgument(ItemStack stack);

    public abstract void Submit(T? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight);

    public virtual void SubmitFoil(T? argument, PoseStack pose, IModelSink sink) { }

    public abstract void GetExtents(Action<Vector3> output);

    public virtual string? IdentityOf(T? argument) => null;

    object? ISpecialModelRenderer.ExtractArgument(ItemStack stack) => ExtractArgument(stack);

    void ISpecialModelRenderer.Submit(object? argument, PoseStack pose, IModelSink sink, float skyLight, float blockLight) =>
        Submit(argument as T, pose, sink, skyLight, blockLight);

    void ISpecialModelRenderer.SubmitFoil(object? argument, PoseStack pose, IModelSink sink) => SubmitFoil(argument as T, pose, sink);

    string? ISpecialModelRenderer.IdentityOf(object? argument) => IdentityOf(argument as T);
}

/// <summary><c>SpecialModelRenderer.BakingContext</c>: what a renderer is built with.</summary>
public sealed class SpecialModelBakingContext {
    public required ISpriteGetter Sprites { get; init; }
}

/// <summary><c>SpecialModelRenderer.Unbaked</c>: a renderer as an item definition names it, built per context.</summary>
public interface ISpecialModelUnbaked {
    /// <summary>Null when the renderer cannot be built, which vanilla draws as the missing model.</summary>
    ISpecialModelRenderer? Bake(SpecialModelBakingContext context);
}
