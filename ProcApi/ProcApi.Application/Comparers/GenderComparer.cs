using ProcApi.Domain.Enums;

namespace ProcApi.Application.Comparers;

public class GenderComparer : IComparer<Gender>
{
    public int Compare(Gender x, Gender y)
    {
        if (x == y) return 0;

        return x switch
        {
            Gender.Male => 1,
            Gender.Female => y switch
            {
                Gender.Male => -1,
                Gender.Unknown => 1,
                _ => -1
            },
            Gender.Unknown => -1,
            _ => -1
        };
    }
}