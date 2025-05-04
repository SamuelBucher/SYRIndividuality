using RimWorld;
using Verse;

namespace SyrTraits;

public class ThoughtWorker_RandomMood : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        switch ((p.GetHashCode() ^ ((GenLocalDate.DayOfYear(p) + GenLocalDate.Year(p) +
                                     ((int)(GenMath.RoundTo(GenLocalDate.DayPercent(p), 0.25f) * 10f) * 60)) * 391)) %
                12)
        {
            case 0:
                return p.story.traits.DegreeOfTrait(SyrTraitDefOf.Neurotic) != 2
                    ? ThoughtState.Inactive
                    : ThoughtState.ActiveAtStage(0);

            case 1:
            case 2:
                return ThoughtState.ActiveAtStage(1);
            case 3:
            case 4:
                return ThoughtState.ActiveAtStage(2);
            case 5:
            case 6:
                return ThoughtState.Inactive;
            case 7:
            case 8:
                return ThoughtState.ActiveAtStage(3);
            case 9:
            case 10:
                return ThoughtState.ActiveAtStage(4);
            case 11:
                return p.story.traits.DegreeOfTrait(SyrTraitDefOf.Neurotic) != 2
                    ? ThoughtState.Inactive
                    : ThoughtState.ActiveAtStage(5);

            default:
                return ThoughtState.Inactive;
        }
    }
}