namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Generic where vanilla's is fixed to <c>EquineRenderState</c> and handed on as <c>EntityModel&lt;? super S&gt;</c>, which C# cannot say.</summary>
public class HorseModel<S>(ModelPart root) : AbstractEquineModel<S>(root) where S : EquineRenderState;
