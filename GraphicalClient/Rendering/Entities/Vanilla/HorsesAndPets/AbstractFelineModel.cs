namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class AbstractFelineModel<S> : EntityModel<S> where S : FelineRenderState {
    protected readonly ModelPart LeftHindLeg;
    protected readonly ModelPart RightHindLeg;
    protected readonly ModelPart LeftFrontLeg;
    protected readonly ModelPart RightFrontLeg;
    protected readonly ModelPart Tail1;
    protected readonly ModelPart Tail2;
    protected readonly ModelPart Head;
    protected readonly ModelPart Body;

    protected AbstractFelineModel(ModelPart root) : base(root) {
        Head = root.GetChild("head");
        Body = root.GetChild("body");
        Tail1 = root.GetChild("tail1");
        Tail2 = root.GetChild("tail2");
        LeftHindLeg = root.GetChild("left_hind_leg");
        RightHindLeg = root.GetChild("right_hind_leg");
        LeftFrontLeg = root.GetChild("left_front_leg");
        RightFrontLeg = root.GetChild("right_front_leg");
    }
}
